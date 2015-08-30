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
    public partial class ReceivingDetailEntry : Page
    {
        private readonly ReceivingDetailManager _rdManager = new ReceivingDetailManager();
        private readonly DepartmentManager _dManager = new DepartmentManager();
        private readonly SupplierManager _supplierManager = new SupplierManager();
        private readonly ItemManager _itemManager = new ItemManager();
        private readonly LocationManager _locationManager = new LocationManager();
        private readonly RackManager _rackManager = new RackManager();
        private readonly BinManager _binManager = new BinManager();
        private readonly ShelveManager _shelveManager = new ShelveManager();
        private readonly CategoryManager _categoryManager = new CategoryManager();
        private readonly ReceivingManager _receivingManager = new ReceivingManager();
        private readonly ItemClassificationManager _itemClassificationManager = new ItemClassificationManager();
        private readonly ItemTypeManager _itemTypeManager = new ItemTypeManager();
        private readonly UnitManager _unitManager = new UnitManager();

        public int Mode
        {
            get { return (Page.RouteData.Values["mode"] == null) ? 1 : int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public Guid ReceivingDetailUid
        {
            get { return (Page.RouteData.Values["id"] == null) ? Guid.NewGuid() : Guid.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public ReceivingDetail ReceivingDetail
        {
            get { return _rdManager.FetchById(ReceivingDetailUid); }
        }

        public Receiving Receiving
        {
            get
            {
                return Mode==0 ? _receivingManager.FetchById(ReceivingDetail.ReceivingId) : _receivingManager.FetchById(ReceivingDetailUid);
            }
        }

        public Department Department
        {
            get { return _dManager.FetchById(Receiving.DepartmentId); }
        }

        public Supplier Supplier
        {
            get { return _supplierManager.FetchById(Receiving.SupplierId); }
        }

        public Category Category
        {
            get { return _categoryManager.FetchById(Receiving.CategoryId); }
        }

        public Item Item
        {
            get { return _itemManager.FetchById(ReceivingDetail.ItemId); }
        }

        public int ReceivingDetailId
        {
            get {
                return Mode==1 ? 0 : ReceivingDetail.Id;
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            hpLinkBack.Attributes.Add("href", "receiving-details/0/"+Receiving.Id);
            hpLinkDetails.Attributes.Add("href", "receiving-details/0/" + Receiving.Id);
            InitDepartmentData();

            //for header
            //init classifications and types for item filters
            InitSelections();

            
                txtReferenceNumber.Text = Receiving.ReferenceNumber;
                txtPONumber.Text = Receiving.PurchaseOrderNumber;
                txtInvoiceNumber.Text = Receiving.InvoiceNumber;
                txtPRNumber.Text = Receiving.PrNumber;
                txtDepartment.Text = Department.Description;

                txtReceivingDate.Text = Receiving.ReceivingDate.ToString("MMM dd, yyyy");
                txtSupplier.Text = Supplier.Name;
                txtCategory.Text = Category.Description;

                txtAlobsNumber.Text = Receiving.AloBsNumber;
                txtModeProcurement.Text = Receiving.ModeProcurement;
                txtAmount.Text = Receiving.Amount.ToString("##,##0.00");
                txtSellingAmount.Text = Receiving.SellingAmount.ToString("##,##0.00");

                if (Mode == 0)
                {
                //for details
                DDLItems.SelectedValue = ReceivingDetail.ItemId.ToString();
                DDLShelves.SelectedValue = ReceivingDetail.Shelfid.ToString();
                DDLUnits.SelectedValue = ReceivingDetail.UnitId.ToString();
                DDLRacks.SelectedValue = ReceivingDetail.RackId.ToString();
                DDLBins.SelectedValue = ReceivingDetail.BinId.ToString();
                txtExpiryDate.Text = ReceivingDetail.ExpiryDate.ToString("MMM dd, yyyy");
                txtReceivedQuantity.Text = ReceivingDetail.ReceiveQuantity.ToString();
                txtPrice.Text = ReceivingDetail.Price.ToString("F");
                txtSellingPrice.Text = ReceivingDetail.SellingPrice.ToString("F");
                txtTotalPrice.Text = ReceivingDetail.TotalAmount.ToString("F");
                txtRemarks.Text = ReceivingDetail.Remarks;
                btnDelete.Visible = true;
            }
        }

        private void InitSelections()
        {
            DDLClassifications.DataSource = _itemClassificationManager.FetchAll(Department.Id);
            DDLClassifications.DataTextField = "ClassificationName";
            DDLClassifications.DataValueField = "Id";
            DDLClassifications.DataBind();

            DDLTypes.DataSource = _itemTypeManager.FetchAll(Department.Id);
            DDLTypes.DataTextField = "ItemDesciption";
            DDLTypes.DataValueField = "Id";
            DDLTypes.DataBind();

            DDLUnits.DataSource = _unitManager.FetchAll(Department.Id);
            DDLUnits.DataTextField = "Description";
            DDLUnits.DataValueField = "Id";
            DDLUnits.DataBind();
        }

        private void InitDepartmentData()
        {
            InitItems();
            InitLocations();
            InitRacks();
            InitBins();
            InitShelves();
        }

        private void InitItems()
        {
            DDLItems.DataSource = _itemManager.FetchAll(Receiving.DepartmentId);
            DDLItems.DataTextField = "ItemName";
            DDLItems.DataValueField = "Id";
            DDLItems.DataBind();
        }

        private void InitLocations()
        {
            DDLLocations.DataSource = _locationManager.FetchAll(Receiving.DepartmentId);
            DDLLocations.DataTextField = "Description";
            DDLLocations.DataValueField = "Id";
            DDLLocations.DataBind();
        }

        private void InitRacks()
        {
           
            DDLRacks.DataSource = _rackManager.FetchAll(Receiving.DepartmentId);
            DDLRacks.DataTextField = "Description";
            DDLRacks.DataValueField = "Id";
            DDLRacks.DataBind();
        }

        private void InitBins()
        {
            DDLBins.DataSource = _binManager.FetchAll(Receiving.DepartmentId);
            DDLBins.DataTextField = "BinDescription";
            DDLBins.DataValueField = "Id";
            DDLBins.DataBind();
        }

        private void InitShelves()
        {
            DDLShelves.DataSource = _shelveManager.FetchAll(Receiving.DepartmentId);
            DDLShelves.DataTextField = "Description";
            DDLShelves.DataValueField = "Id";
            DDLShelves.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var item = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            var receivingDetail = new ReceivingDetail
            {
                Barcode = item.BarCode,
                BinId =int.Parse(DDLBins.SelectedValue),
                DateCreated = DateTime.Now,
                DepartmentId = Receiving.DepartmentId,
                ExpiryDate = DateTime.Parse(txtExpiryDate.Text),
                ItemId =item.Id,
                LocationId =int.Parse(DDLLocations.SelectedValue),
                Price =decimal.Parse(txtPrice.Text),
                RackId = int.Parse(DDLRacks.SelectedValue),
                ReceiveQuantity = int.Parse(txtReceivedQuantity.Text),
                ReceivingId = Receiving.Id,
                ReceivingReamrks = txtRemarks.Text,
                ReferenceNumber = Receiving.ReferenceNumber,
                Remarks = txtRemarks.Text,
                SellingPrice = decimal.Parse(txtSellingPrice.Text),
                Shelfid = int.Parse(DDLShelves.SelectedValue),
                SupplierId = Receiving.SupplierId,
                TotalAmount = (int.Parse(txtReceivedQuantity.Text)* decimal.Parse(txtPrice.Text)),
                UnitId =int.Parse(DDLUnits.SelectedValue),
                Uid = ReceivingDetailUid,
                Id = ReceivingDetailId
            };
            _rdManager.Save(receivingDetail);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var receivingDetailToDelete = new ReceivingDetail
            {
                Id = ReceivingDetailId
            };
            _rdManager.Delete(receivingDetailToDelete);

        }

        protected void DDLDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitDepartmentData();
        }
    }
}