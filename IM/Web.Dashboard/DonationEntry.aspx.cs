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
    public partial class DonationEntry : Page
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

        public int DepartmentId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public List<DonationDetailItem> DonationDetailItems()
        {
            var items = new List<DonationDetailItem>();
            if (Session["DONATION_ITEMS"] != null)
            {
                items = (List<DonationDetailItem>)Session["DONATION_ITEMS"];
            }
            else
            {
                Session["DONATION_ITEMS"] = items;
            }
            return items;
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

        private void InitItems()
        {
            var items = _itemManager.FetchAll(int.Parse(DDLDonatedTo.SelectedValue));
            DDLItems.DataSource = items;
            DDLItems.DataValueField = "Id";
            DDLItems.DataTextField = "ItemName";
            DDLItems.DataBind();

            var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            txtBarcode.Text = selectedItem.BarCode;
        }

        private void InitUnits()
        {
            var items = _unitManager.FetchAll(int.Parse(DDLDonatedTo.SelectedValue));
            DDLUnits.DataSource = items;
            DDLUnits.DataValueField = "Id";
            DDLUnits.DataTextField = "Description";
            DDLUnits.DataBind();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            InitSuppliers();
            InitDepartments();
            InitItems();
            InitUnits();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvSelectedItems.DataSource = DonationDetailItems();
                gvSelectedItems.DataBind();

                switch (Mode)
                {
                    case Transaction.TransactionMode.NewEntry:
                        txtReferenceNumber.Text = Transaction.TransactionType.DON+"-"+ (_donationManager.ReferenceNumber + 1);
                        txtDonationDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
                        break;
                    case Transaction.TransactionMode.UpdateEntry:
                        break;
                }
            }
        }

        protected void lnkButtonAdd_Click(object sender, EventArgs e)
        {
            divMessageBox.Visible = false;
            if (string.IsNullOrEmpty(txtPrice.Text) || string.IsNullOrWhiteSpace(txtPrice.Text))
            {
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify warning");
                ltrlMessageHeader.Text = "Warning!";
                ltrlMessage.Text = "Price is Required";
                return;
            }
            var items = DonationDetailItems();
            var donationItem = new DonationDetailItem
            {
                Barcode = txtBarcode.Text,
                ItemId =int.Parse(DDLItems.SelectedValue),
                ItemName = DDLItems.SelectedItem.Text,
                Price = (int.Parse(txtItemQuantity.Text)* decimal.Parse(txtPrice.Text)),
                Quantity = int.Parse(txtItemQuantity.Text),
                Uid = Guid.NewGuid(),
                UnitId = int.Parse(DDLUnits.SelectedValue),
                UnitName = DDLUnits.SelectedItem.Text
            };
            items.Add(donationItem);
            gvSelectedItems.DataSource = items;
            gvSelectedItems.DataBind();

            txtTotalQuantity.Text = items.Sum(i => i.Quantity).ToString();

        }

        protected void DDLDonatedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItems();
            InitUnits();
        }

        protected void gvSelectedItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var list = DonationDetailItems();
            var row = gvSelectedItems.Rows[e.RowIndex];
            var hfId = (HiddenField)row.FindControl("hfUniqueId");
            var uid = Guid.Parse(hfId.Value);
            list.RemoveAll(o => o.Uid == uid);

            txtTotalQuantity.Text = list.Sum(i => i.Quantity).ToString();
            gvSelectedItems.DataSource = DonationDetailItems();
            gvSelectedItems.DataBind();
        }

        protected void DDLItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            txtBarcode.Text = selectedItem.BarCode;
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

            var donationDetails = DonationDetailItems();
            if (donationDetails.Count>0)
            {
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
                    Uid = Guid.NewGuid(),
                    UnitCode =""
                };
                _donationManager.Save(donation);
                int donationIdentity = _donationManager.Identity;
                var  details = donationDetails.Select(donationDetail => new DonationDetail
                {
                    Barcode = donationDetail.Barcode, 
                    DonationId = donationIdentity, 
                    ItemId = donationDetail.ItemId, 
                    Price = donationDetail.Price, 
                    Quantity = donationDetail.Quantity, 
                    Uid = donationDetail.Uid, 
                    UnitId = donationDetail.UnitId
                }).ToList();
                _donationDetailsManager.Save(details);

                btnSave.Enabled = false;
                lnkButtonAdd.Enabled = false;
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify info");
                ltrlMessageHeader.Text = "Saved Sucessful!";
                ltrlMessage.Text = "New Donation Entry has been saved!";
            }
            else
            {
                
            }
        }
    }
}