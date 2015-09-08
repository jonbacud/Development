using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;
using Web.Dashboard.Shared;

namespace Web.Dashboard
{
    public partial class EmergencyPurchaseDetails : System.Web.UI.Page
    {
        readonly EmergencyPurchaseManager _emergencyPurchaseManager = new EmergencyPurchaseManager();
        readonly EmergencyPurchaseDetailManager _emergencyPurchaseDetailManager = new EmergencyPurchaseDetailManager();
        readonly DepartmentManager _departmentManager = new DepartmentManager();
        readonly UnitManager _unitManager = new UnitManager();
        readonly SupplierManager _supplierManager = new SupplierManager();
        readonly ItemManager _itemManager = new ItemManager();

        public UserAccount UserAccount
        {
            get
            {
                return (Session["USER_ACCOUNT"] == null)
                    ? new UserAccount()
                    : (UserAccount)Session["USER_ACCOUNT"];
            }
        }

        public int EmergencyPurchaseId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public EmergencyPurchase EmergencyPurchase
        {
            get { return _emergencyPurchaseManager.FetchById(EmergencyPurchaseId); }
        }

        private void InitDepartments()
        {
            var departments = _departmentManager.FetchAll();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();

            DDlReceivedBy.DataSource = departments;
            DDlReceivedBy.DataTextField = "Description";
            DDlReceivedBy.DataValueField = "Id";
            DDlReceivedBy.DataBind();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitDepartments();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hpLinkNewDetail.NavigateUrl = "/emergencypurchase-detail-entry/1/" + EmergencyPurchaseId;
                switch (Mode)
                {
                    case Transaction.TransactionMode.NewEntry:
                        break;
                    case Transaction.TransactionMode.UpdateEntry:
                        txtReferenceNumber.Text = EmergencyPurchase.EmergencyPurchaseId;
                        txtDonationDate.Text = EmergencyPurchase.EmergencyPurchaseDate.ToString("MMM dd, yyyy");
                        DDLDepartments.SelectedValue = EmergencyPurchase.DepartmentId.ToString();
                        txtTotalQuantity.Text = EmergencyPurchase.TotalQuantity.ToString();
                        DDlReceivedBy.SelectedItem.Text = EmergencyPurchase.ReceivedBy;
                        var items = (from donationDetail in _emergencyPurchaseDetailManager.FetchAll(EmergencyPurchaseId)
                                     let itemDetail = _itemManager.FetchById(donationDetail.ItemId)
                                     let unitDetail = _unitManager.FetchById(donationDetail.UnitId)
                                     select new DonationDetailItem
                                     {
                                         Barcode = itemDetail.BarCode,
                                         ItemId = donationDetail.ItemId,
                                         ItemName = itemDetail.ItemName,
                                         Price = donationDetail.Price,
                                         Quantity = donationDetail.Quantity,
                                         Uid = donationDetail.Uid,
                                         UnitId = donationDetail.UnitId,
                                         UnitName = unitDetail.Description,
                                         Id = donationDetail.Id
                                     }).ToList();
                        gvSelectedItems.DataSource = items;
                        gvSelectedItems.DataBind();
                        hpLinkBack.NavigateUrl = "/EmergencyPurchaseManagementPanel";
                        btnDelete.Visible = true;
                        break;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            var emergencyPurchase = new EmergencyPurchase
            {
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                ItemCode = "",
                ReceivedBy = DDlReceivedBy.SelectedItem.Text,
                RequisitionNumber = txtRISNumber.Text,
                Status = Transaction.TransactionStatus.Posted.ToString(),
                TotalQuantity = int.Parse(txtTotalQuantity.Text),
                Uid = EmergencyPurchase.Uid,
                UnitCode = "",
                Id = EmergencyPurchaseId,
                EmergencyPurchaseDate = DateTime.Parse(txtDonationDate.Text),
                EmergencyPurchaseId = txtReferenceNumber.Text

            };
            _emergencyPurchaseManager.Save(emergencyPurchase);
            divMessageBox.Visible = true;
            divMessageBox.Attributes.Add("class", "notify info");
            ltrlMessageHeader.Text = "Saved Sucessful!";
            ltrlMessage.Text = "Emergency Purchase Entry has been Updated!";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}