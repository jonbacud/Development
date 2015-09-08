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
    public partial class DonationDetails : System.Web.UI.Page
    {
        readonly DonationManager _donationManager = new DonationManager();
        readonly DonationDetailsManager _donationDetailsManager = new DonationDetailsManager();
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

        public int DonationId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public Donation Donation
        {
            get { return _donationManager.FetchById(DonationId); }
        }

        private void InitDepartments()
        {
            var departments = _departmentManager.FetchAll();
            DDLDonatedTo.DataSource = departments;
            DDLDonatedTo.DataTextField = "Description";
            DDLDonatedTo.DataValueField = "Id";
            DDLDonatedTo.DataBind();
        }

        private void InitSuppliers()
        {
            var suppliers = _supplierManager.FetchAll().Where(s => s.DepartmentId.Equals(UserAccount.DeaprtmentId));
            DDLDonatedBy.DataSource = suppliers;
            DDLDonatedBy.DataTextField = "Name";
            DDLDonatedBy.DataValueField = "Id";
            DDLDonatedBy.DataBind();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitSuppliers();
            InitDepartments();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hpLinkNewDetail.NavigateUrl = "/donation-detail-entry/1/"+DonationId;
                switch (Mode)
                {
                    case Transaction.TransactionMode.NewEntry:
                        txtReferenceNumber.Text = Transaction.TransactionType.DON + "-" + (_donationManager.ReferenceNumber + 1);
                        txtDonationDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
                        break;
                    case Transaction.TransactionMode.UpdateEntry:
                        txtReferenceNumber.Text = Donation.DonationId;
                        txtDonationDate.Text = Donation.DonationDate.ToString("MMM dd, yyyy");
                        txtReceivedBy.Text = Donation.ReceivedBy;
                        txtTotalQuantity.Text = Donation.TotalQuantity.ToString();
                        DDLDonatedBy.SelectedValue = Donation.SupplierId.ToString();
                        DDLDonatedTo.SelectedValue = Donation.DepartmentId.ToString();

                        var items = (from donationDetail in _donationDetailsManager.FetchAll(DonationId)
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
                        hpLinkBack.NavigateUrl = "/DonationManagementPanel";
                        btnDelete.Visible = true;
                        break;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtReceivedBy.Text) || string.IsNullOrWhiteSpace(txtReceivedBy.Text))
            {
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify warning");
                ltrlMessageHeader.Text = "Warning!";
                ltrlMessage.Text = "Received by is Required";
                return;
            }

                var donation = new Donation
                {
                    DonatedBy = DDLDonatedBy.SelectedItem.Text,
                    SupplierId = int.Parse(DDLDonatedBy.SelectedValue),
                    DonatedTo = DDLDonatedTo.SelectedItem.Text,
                    DepartmentId = int.Parse(DDLDonatedTo.SelectedValue),
                    DonationDate = DateTime.Parse(txtDonationDate.Text),
                    DonationId = txtReferenceNumber.Text,
                    ItemCode = "",
                    ReceivedBy = txtReceivedBy.Text,
                    RequisitionNumber = txtRISNumber.Text,
                    Status = Transaction.TransactionStatus.Posted.ToString(),
                    TotalQuantity = int.Parse(txtTotalQuantity.Text),
                    Uid = Donation.Uid,
                    UnitCode = "",
                    Id = DonationId
                };
                _donationManager.Save(donation);
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify info");
                ltrlMessageHeader.Text = "Saved Sucessful!";
                ltrlMessage.Text = "Donation Entry has been Updated!";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}