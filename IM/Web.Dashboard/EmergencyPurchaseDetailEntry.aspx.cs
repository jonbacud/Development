using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.Shared;

namespace Web.Dashboard
{
    public partial class EmergencyPurchaseDetailEntry : System.Web.UI.Page
    {
        readonly EmergencyPurchaseManager _emergencyPurchaseManager = new EmergencyPurchaseManager();
        readonly EmergencyPurchaseDetailManager _emergencyPurchaseDetailManager = new EmergencyPurchaseDetailManager();
        readonly UnitManager _unitManager = new UnitManager();
        readonly ItemManager _itemManager = new ItemManager();
        readonly DepartmentManager _departmentManager = new DepartmentManager();
        public UserAccount UserAccount
        {
            get
            {
                return (Session["USER_ACCOUNT"] == null)
                    ? new UserAccount()
                    : (UserAccount)Session["USER_ACCOUNT"];
            }
        }

        public int EmergencyPurchaseDetailId
        {
            get
            {
                if (Mode == Transaction.TransactionMode.NewEntry)
                {
                    return 0;
                }
                return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString());
            }
        }

        public int EmergencyPurchaseId
        {
            get
            {
                if (Mode == Transaction.TransactionMode.NewEntry)
                {
                    return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString());
                }
                return EmergencyPurcahseDetail.EmergencyPurchaseId;
            }
        }

        public EmergencyPurchaseDetail EmergencyPurcahseDetail
        {
            get { return _emergencyPurchaseDetailManager.FetchById(EmergencyPurchaseDetailId); }
        }

        public EmergencyPurchase EmergencyPurchase
        {
            get { return _emergencyPurchaseManager.FetchById(EmergencyPurchaseId); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }


        private void InitItems()
        {
            InitItemList();
            var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            txtBarcode.Text = selectedItem.BarCode;
        }

        private void InitItemList()
        {
            var items = _itemManager.FetchAll(EmergencyPurchase.DepartmentId);
            DDLItems.DataSource = items;
            DDLItems.DataValueField = "Id";
            DDLItems.DataTextField = "ItemName";
            DDLItems.DataBind();
        }

        private void InitUnits()
        {
            var items = _unitManager.FetchAll(EmergencyPurchase.DepartmentId);
            DDLUnits.DataSource = items;
            DDLUnits.DataValueField = "Id";
            DDLUnits.DataTextField = "Description";
            DDLUnits.DataBind();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitItems();
            InitUnits();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var department = _departmentManager.FetchById(EmergencyPurchase.DepartmentId);
                txtReferenceNumber.Text = EmergencyPurchase.EmergencyPurchaseId;
                txtTotalQuantity.Text = EmergencyPurchase.TotalQuantity.ToString();
                txtDonationDate.Text = EmergencyPurchase.EmergencyPurchaseDate.ToString("MMM dd, yyyy");
                txtReceivedBy.Text = EmergencyPurchase.ReceivedBy;
                txtRISNumber.Text = EmergencyPurchase.RequisitionNumber;
                txtDonatedBy.Text = department.Description;
                hpLinkBack.NavigateUrl = "/emergencypurchase-detail/0/" + EmergencyPurchase.Id;
                switch (Mode)
                {
                    case Transaction.TransactionMode.NewEntry:
                        break;
                    case Transaction.TransactionMode.UpdateEntry:
                        DDLItems.SelectedValue = EmergencyPurcahseDetail.ItemId.ToString();
                        DDLUnits.SelectedValue = EmergencyPurcahseDetail.UnitId.ToString();
                        txtBarcode.Text = EmergencyPurcahseDetail.Barcode;
                        txtItemQuantity.Text = EmergencyPurcahseDetail.Quantity.ToString();
                        txtPrice.Text = EmergencyPurcahseDetail.Price.ToString("##0.00");
                        btnDelete.Visible = true;
                        break;
                }
            }
        }

        protected void DDLDonatedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItemList();
            InitUnits();
        }

        protected void DDLItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            txtBarcode.Text = selectedItem.BarCode;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var emergencyPurchaseDetail = new EmergencyPurchaseDetail
            {
                Barcode = txtBarcode.Text,
                 EmergencyPurchaseId = EmergencyPurchase.Id,
                Id = EmergencyPurchaseDetailId,
                ItemId = int.Parse(DDLItems.SelectedValue),
                Price = decimal.Parse(txtPrice.Text),
                Quantity = int.Parse(txtItemQuantity.Text),
                Uid = Guid.NewGuid(),
                UnitId = int.Parse(DDLUnits.SelectedValue)
            };

            _emergencyPurchaseDetailManager.Save(emergencyPurchaseDetail);
            var ep = EmergencyPurchase;
            ep.TotalQuantity = _emergencyPurchaseDetailManager.FetchAll(EmergencyPurchase.Id).Sum(dd => dd.Quantity);
            _emergencyPurchaseManager.Save(ep);
            txtTotalQuantity.Text = ep.TotalQuantity.ToString();
            divMessageBox.Visible = true;
            divMessageBox.Attributes.Add("class", "notify info");
            ltrlMessageHeader.Text = "Saved Sucessful!";
            ltrlMessage.Text = "Emergency Purchase Detail Entry has been saved!";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var donation = EmergencyPurchase;
            donation.TotalQuantity = _emergencyPurchaseDetailManager.FetchAll(EmergencyPurchase.Id).Sum(dd => dd.Quantity) - EmergencyPurcahseDetail.Quantity;
            _emergencyPurchaseManager.Save(donation);
            txtTotalQuantity.Text = donation.TotalQuantity.ToString();
            var epDetailToDelete = new EmergencyPurchaseDetail
            {
                Id = EmergencyPurchaseDetailId
            };
            _emergencyPurchaseDetailManager.Delete(epDetailToDelete);
            divMessageBox.Visible = true;
            divMessageBox.Attributes.Add("class", "notify warning");
            ltrlMessageHeader.Text = "Saved Sucessful!";
            ltrlMessage.Text = "Emergency Purchase Detail Entry has been deleted!";
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }
    }
}