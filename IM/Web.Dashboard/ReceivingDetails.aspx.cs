using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;

namespace Web.Dashboard
{
    public partial class ReceivingDetails : System.Web.UI.Page
    {
        private readonly DepartmentManager _dManager = new DepartmentManager();
        private readonly SupplierManager _supplierManager = new SupplierManager();
        private readonly ItemManager _itemManager = new ItemManager();
        private readonly LocationManager _locationManager = new LocationManager();
        private readonly RackManager _rackManager = new RackManager();
        private readonly BinManager _binManager = new BinManager();
        private readonly ShelveManager _shelveManager = new ShelveManager();
        private readonly CategoryManager _categoryManager = new CategoryManager();
        private readonly ReceivingManager _receivingManager = new ReceivingManager();
        private readonly ReceivingDetailManager _receivingDetailManager = new ReceivingDetailManager();
        private readonly UnitManager _unitManager = new UnitManager();
        public int ReceivingId
        {
            get
            {
                return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]);
            }
        }

        public Receiving Receiving
        {
            get { return _receivingManager.FetchById(ReceivingId); }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            var departments = _dManager.FetchAll();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();

            InitDepartmentData();

            txtReceivingDate.Text = DateTime.Now.ToString("MMM dd, yyyy");

            if (ReceivingId>0)
            {
                txtReferenceNumber.Text = Receiving.ReferenceNumber;
                txtPONumber.Text = Receiving.PurchaseOrderNumber;
                txtInvoiceNumber.Text = Receiving.InvoiceNumber;
                txtPRNumber.Text = Receiving.PrNumber;
                DDLDepartments.SelectedValue = Receiving.DepartmentId.ToString();
                txtReceivingDate.Text = Receiving.ReceivingDate.ToString("MMM dd, yyyy");
                DDLSuppliers.SelectedValue = Receiving.SupplierId.ToString();
                DDLCategories.SelectedValue = Receiving.CategoryId.ToString();
                txtAlobsNumber.Text = Receiving.AloBsNumber;
                txtModeProcurement.Text = Receiving.ModeProcurement;
                txtAmount.Text = Receiving.Amount.ToString("F");
                txtSellingAmount.Text = Receiving.SellingAmount.ToString("F");
                InitReceivingDeatailData();
            }

        }

        private void InitReceivingDeatailData()
        {
             var receivingItems = (from rd in _receivingDetailManager.FetchAllByReceivingId(ReceivingId)
                let bin = _binManager.FetchById(rd.BinId)
                let dept = _dManager.FetchById(rd.DepartmentId)
                let item = _itemManager.FetchById(rd.ItemId)
                let location = _locationManager.FetchById(rd.LocationId)
                let rack = _rackManager.FetchById(rd.RackId)
                let shelf = _shelveManager.FetchById(rd.Shelfid)
                let supplier = _supplierManager.FetchById(rd.SupplierId)
                let unit = _unitManager.FetchById(rd.UnitId)
                select new ReceivingItem
                {
                    Barcode = rd.Barcode, 
                    BinName = bin.BinDescription, 
                    BinId = bin.Id, 
                    DepartmentId = rd.DepartmentId, 
                    DepartmentName = dept.Description, 
                    ExpiryDate = rd.ExpiryDate, 
                    ItemId = rd.ItemId, 
                    ItemName = item.ItemName, 
                    LocationId = rd.LocationId, 
                    LocationName = location.Description, 
                    Price = rd.Price, 
                    RackId = rd.RackId, 
                    RackName = rack.Description, 
                    ReceivedQuantity = rd.ReceiveQuantity, 
                    ReceivingRemarks = rd.Remarks, 
                    ReferenceNumber = rd.ReferenceNumber,
                    Remarks = rd.Remarks,
                    SellingPrice = rd.SellingPrice,
                    ShelveId = rd.Shelfid,
                    ShelveName = shelf.Description,
                    SupplierId = rd.SupplierId,
                    SupplierName = supplier.Name,
                    TotalAmount = rd.TotalAmount, 
                    Uid = rd.Uid, 
                    UnitId = rd.UnitId,
                    UnitName = unit.Description,
                }).ToList();

            gvSelectedItems.DataSource = receivingItems;
            gvSelectedItems.DataBind();
        }

        private void InitDepartmentData()
        {
            InitSuppliers(int.Parse(DDLDepartments.SelectedValue));
            InitCategories();
        }

        private void InitCategories()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
            string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLCategories.DataSource = _categoryManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLCategories.DataTextField = "Description";
            DDLCategories.DataValueField = "Id";
            DDLCategories.DataBind();
        }

        private void InitSuppliers(int departmentId)
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
             string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLSuppliers.DataSource = _supplierManager.FetchAll(departmentId).OrderBy(s => s.Name);
            DDLSuppliers.DataTextField = "Name";
            DDLSuppliers.DataValueField = "Id";
            DDLSuppliers.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newReceiving = new Receiving
            {
                AloBsNumber = txtAlobsNumber.Text,
                Amount = decimal.Parse(txtAmount.Text),
                SellingAmount = decimal.Parse(txtSellingAmount.Text),
                CategoryId = int.Parse(DDLCategories.SelectedValue),
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                EndUserId = 0, // todo: to be replace by logged user
                InvoiceNumber = txtInvoiceNumber.Text,
                ModeProcurement = txtModeProcurement.Text,
                PrNumber = txtPRNumber.Text,
                PurchaseOrderNumber = txtPONumber.Text,
                ReceivingDate = DateTime.Parse(txtReceivingDate.Text),
                ReceivingKey = Guid.NewGuid(),
                ReferenceNumber = txtReferenceNumber.Text,
                Status = true,
                SupplierId = int.Parse(DDLSuppliers.SelectedValue),
                Uid = Guid.NewGuid(),
                Id = ReceivingId
            };
            _receivingManager.Save(newReceiving);
           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void lnkButtonAdd_Click(object sender, EventArgs e)
        {
            //var itemDetails = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            //var items = ReceivedItems();
            //var item = new ReceivingItem
            //{
            //    ItemName = DDLItems.SelectedItem.Text,
            //    UnitId = int.Parse(DDLUnits.SelectedValue),
            //    UnitName = DDLUnits.SelectedItem.Text,
            //    Uid = Guid.NewGuid(),
            //    DepartmentId = int.Parse(DDLDepartments.SelectedValue),
            //    Barcode = itemDetails.BarCode,
            //    BinId = int.Parse(DDLBins.SelectedValue),
            //    BinName = DDLBins.SelectedItem.Text,
            //    DepartmentName = DDLDepartments.SelectedItem.Text,
            //    ExpiryDate = DateTime.Parse(txtExpiryDate.Text),
            //    ItemId = itemDetails.Id,
            //    LocationId = int.Parse(DDLLocations.SelectedValue),
            //    LocationName = DDLLocations.SelectedItem.Text,
            //    Price = Decimal.Parse(txtPrice.Text),
            //    RackId = int.Parse(DDLRacks.SelectedValue),
            //    RackName = DDLRacks.SelectedItem.Text,
            //    ReceivedQuantity = int.Parse(txtReceivedQuantity.Text),
            //    ReceivingRemarks = txtRemarks.Text,
            //    Remarks = txtRemarks.Text,
            //    SellingPrice = decimal.Parse(txtSellingPrice.Text),
            //    ShelveId = int.Parse(DDLShelves.SelectedValue),
            //    ShelveName = DDLShelves.SelectedItem.Text,
            //    SupplierId = int.Parse(DDLSuppliers.SelectedValue),
            //    SupplierName = DDLSuppliers.SelectedItem.Text,
            //    TotalAmount = (int.Parse(txtReceivedQuantity.Text) * decimal.Parse(txtPrice.Text)),
            //    ReferenceNumber = txtReferenceNumber.Text
            //};

            //items.Add(item);
            //gvSelectedItems.DataSource = items;
            //gvSelectedItems.DataBind();
        }

        protected void DDLDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitDepartmentData();
        }
    }
}