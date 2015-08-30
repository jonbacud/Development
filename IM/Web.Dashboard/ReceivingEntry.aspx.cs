using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;

namespace Web.Dashboard
{
    public partial class ReceivingEntry : System.Web.UI.Page
    {
        private readonly DepartmentManager _dManager = new DepartmentManager();
        private readonly SupplierManager _supplierManager = new SupplierManager();
        private readonly ItemManager _itemManager = new ItemManager();
        private readonly LocationManager _locationManager = new LocationManager();
        private readonly RackManager _rackManager = new RackManager();
        private readonly BinManager _binManager = new BinManager();
        private readonly ShelveManager _shelveManager = new ShelveManager();
        private readonly CategoryManager _categoryManager = new CategoryManager();

        public List<ReceivingItem> ReceivedItems()
        {
            var items = new List<ReceivingItem>();
            if (Session["RECEIVING_ITEMS"] != null)
            {
                items = (List<ReceivingItem>)Session["RECEIVING_ITEMS"];
            }
            else
            {
                Session["RECEIVING_ITEMS"] = items;
            }
            return items;
        } 


        protected void Page_Init(object sender, EventArgs e)
        {
            var departments = _dManager.FetchAll();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();

            InitDepartmentData();

            txtExpiryDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
            txtReceivingDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
        }

        private void InitDepartmentData()
        {
            InitSuppliers(int.Parse(DDLDepartments.SelectedValue));
            InitCategories();
            InitItems();
            InitLocations();
            InitRacks();
            InitBins();
            InitShelves();
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
            DDLSuppliers.DataSource = _supplierManager.FetchAll(departmentId).OrderBy(s=>s.Name);
            DDLSuppliers.DataTextField = "Name";
            DDLSuppliers.DataValueField = "Id";
            DDLSuppliers.DataBind();
        }

        private void InitItems()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLItems.DataSource = _itemManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLItems.DataTextField = "ItemName";
            DDLItems.DataValueField = "Id";
            DDLItems.DataBind();
        }

        private void InitLocations()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLLocations.DataSource = _locationManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLLocations.DataTextField = "Description";
            DDLLocations.DataValueField = "Id";
            DDLLocations.DataBind();
        }

        private void InitRacks()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLRacks.DataSource = _rackManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLRacks.DataTextField = "Description";
            DDLRacks.DataValueField = "Id";
            DDLRacks.DataBind();
        }

        private void InitBins()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLBins.DataSource = _binManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLBins.DataTextField = "BinDescription";
            DDLBins.DataValueField = "Id";
            DDLBins.DataBind();
        }

        private void InitShelves()
        {
            if (string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                string.IsNullOrWhiteSpace((DDLDepartments.SelectedValue.Trim()))) return;
            DDLShelves.DataSource = _shelveManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLShelves.DataTextField = "Description";
            DDLShelves.DataValueField = "Id";
            DDLShelves.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvSelectedItems.DataSource = ReceivedItems();
                gvSelectedItems.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var receivingManager = new ReceivingManager();
            var receivingDetailManager = new ReceivingDetailManager();
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
              Uid = Guid.NewGuid()
            };
            receivingManager.Save(newReceiving);

            var identity = receivingManager.Identity;

            var receivingDetails = ReceivedItems().Select(item => new ReceivingDetail
            {
                Barcode = item.Barcode,
                BinId = item.BinId,
                DateCreated = DateTime.Now,
                DepartmentId = item.DepartmentId,
                ExpiryDate = item.ExpiryDate,
                ItemId = item.ItemId,
                LocationId = item.LocationId,
                Price = item.Price,
                RackId = item.RackId,
                ReceiveQuantity = item.ReceivedQuantity,
                ReceivingId = identity,
                ReceivingReamrks = item.Remarks,
                ReferenceNumber = item.ReferenceNumber,
                Remarks = item.Remarks,
                SellingPrice = item.SellingPrice,
                Shelfid = item.ShelveId,
                SupplierId = item.SupplierId,
                TotalAmount = item.TotalAmount,
                UnitId = item.UnitId,
                Uid = Guid.NewGuid()
            }).ToList();

            receivingDetailManager.Save(receivingDetails);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void gvSelectedItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var list = ReceivedItems();
            var row = gvSelectedItems.Rows[e.RowIndex];
            var hfId = (HiddenField)row.FindControl("hfUniqueId");
            var uid = Guid.Parse(hfId.Value);
            list.RemoveAll(o => o.Uid == uid);

            gvSelectedItems.DataSource = ReceivedItems();
            gvSelectedItems.DataBind();
        }

        protected void lnkButtonAdd_Click(object sender, EventArgs e)
        {
            var itemDetails = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            var items = ReceivedItems();
            var item = new ReceivingItem
            {
                ItemName = DDLItems.SelectedItem.Text,
                UnitId = int.Parse(DDLUnits.SelectedValue),
                UnitName = DDLUnits.SelectedItem.Text,
                Uid = Guid.NewGuid(),
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                Barcode = itemDetails.BarCode,
                BinId = int.Parse(DDLBins.SelectedValue),
                BinName = DDLBins.SelectedItem.Text,
                DepartmentName = DDLDepartments.SelectedItem.Text,
                ExpiryDate = DateTime.Parse(txtExpiryDate.Text),
                ItemId = itemDetails.Id,
                LocationId = int.Parse(DDLLocations.SelectedValue),
                LocationName = DDLLocations.SelectedItem.Text,
                Price = Decimal.Parse(txtPrice.Text),
                RackId = int.Parse(DDLRacks.SelectedValue),
                RackName = DDLRacks.SelectedItem.Text,
                ReceivedQuantity = int.Parse(txtReceivedQuantity.Text),
                ReceivingRemarks = txtRemarks.Text,
                Remarks = txtRemarks.Text,
                SellingPrice = decimal.Parse(txtSellingPrice.Text),
                ShelveId = int.Parse(DDLShelves.SelectedValue),
                ShelveName = DDLShelves.SelectedItem.Text,
                SupplierId = int.Parse(DDLSuppliers.SelectedValue),
                SupplierName = DDLSuppliers.SelectedItem.Text,
                TotalAmount = (int.Parse(txtReceivedQuantity.Text)*decimal.Parse(txtPrice.Text)),
                ReferenceNumber = txtReferenceNumber.Text
            };

            items.Add(item);
            gvSelectedItems.DataSource = items;
            gvSelectedItems.DataBind();
        }

        protected void DDLDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitDepartmentData();
        }
    }
}