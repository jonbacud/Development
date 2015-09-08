using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;
using Web.Dashboard.Shared;

namespace Web.Dashboard
{
    public partial class DonationDetailEntry : System.Web.UI.Page
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

        public int DonationDetailId
        {
            get
            {
                if (Mode==Transaction.TransactionMode.NewEntry)
                {
                    return 0;
                }
                return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString());
            }
        }

        public int DonationId
        {
            get
            {
                if (Mode==Transaction.TransactionMode.NewEntry)
                {
                    return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString());
                }
                return DonationDetail.DonationId;
            }
        }

        public DonationDetail DonationDetail
        {
            get { return _donationDetailsManager.FetchById(DonationDetailId); }
        }

        public Donation Donation
        {
            get { return _donationManager.FetchById(DonationId); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }


        private void InitItems()
        {
            var items = _itemManager.FetchAll(Donation.DepartmentId);
            DDLItems.DataSource = items;
            DDLItems.DataValueField = "Id";
            DDLItems.DataTextField = "ItemName";
            DDLItems.DataBind();

            var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            txtBarcode.Text = selectedItem.BarCode;
        }

        private void InitUnits()
        {
            var items = _unitManager.FetchAll(Donation.DepartmentId);
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
                txtReferenceNumber.Text = Donation.DonationId;
                txtTotalQuantity.Text = Donation.TotalQuantity.ToString();
                txtDonationDate.Text = Donation.DonationDate.ToString("MMM dd, yyyy");
                txtReceivedBy.Text = Donation.ReceivedBy;
                txtRISNumber.Text = Donation.RequisitionNumber;
                txtDonatedBy.Text = Donation.DonatedBy;
                txtDonatedTo.Text = Donation.DonatedTo;
                hpLinkBack.NavigateUrl = "/donation-detail/0/" + Donation.Id;
                switch (Mode)
                {
                    case Transaction.TransactionMode.NewEntry:
                        break;
                    case Transaction.TransactionMode.UpdateEntry:
                        DDLItems.SelectedValue = DonationDetail.ItemId.ToString();
                        DDLUnits.SelectedValue = DonationDetail.UnitId.ToString();
                        txtBarcode.Text = DonationDetail.Barcode;
                        txtItemQuantity.Text = DonationDetail.Quantity.ToString();
                        txtPrice.Text = DonationDetail.Price.ToString("##0.00");
                        btnDelete.Visible = true;
                        break;
                }
            }
        }

        protected void DDLDonatedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItems();
            InitUnits();
        }

        protected void DDLItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            txtBarcode.Text = selectedItem.BarCode;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var donationDetail = new DonationDetail
            {
                Barcode = txtBarcode.Text,
                DonationId = Donation.Id,
                Id = DonationDetailId,
                ItemId = int.Parse(DDLItems.SelectedValue),
                Price = decimal.Parse(txtPrice.Text),
                Quantity = int.Parse(txtItemQuantity.Text),
                Uid = Guid.NewGuid(),
                UnitId = int.Parse(DDLUnits.SelectedValue)
            };

            _donationDetailsManager.Save(donationDetail);
            var donation = Donation;
            donation.TotalQuantity = _donationDetailsManager.FetchAll(Donation.Id).Sum(dd=>dd.Quantity);
            _donationManager.Save(donation);
            txtTotalQuantity.Text = donation.TotalQuantity.ToString();
            divMessageBox.Visible = true;
            divMessageBox.Attributes.Add("class", "notify info");
            ltrlMessageHeader.Text = "Saved Sucessful!";
            ltrlMessage.Text = "Donation Detail Entry has been saved!";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var donation = Donation;
            donation.TotalQuantity = _donationDetailsManager.FetchAll(Donation.Id).Sum(dd => dd.Quantity)-DonationDetail.Quantity;
            _donationManager.Save(donation);
            txtTotalQuantity.Text = donation.TotalQuantity.ToString();
            var donationDetailToDelete = new DonationDetail
            {
                Id = DonationDetailId
            };
            _donationDetailsManager.Delete(donationDetailToDelete);
            divMessageBox.Visible = true;
            divMessageBox.Attributes.Add("class", "notify warning");
            ltrlMessageHeader.Text = "Saved Sucessful!";
            ltrlMessage.Text = "Donation Detail Entry has been deleted!";
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }
    }
}