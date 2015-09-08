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
    public partial class EmergencyPurchaseEntry : System.Web.UI.Page
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

        public int EmergencyPurchasetId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public List<EmergencyPurchaseDetailItem> DonationDetailItems()
        {
            var items = new List<EmergencyPurchaseDetailItem>();
            if (Session["EP_ITEMS"] != null)
            {
                items = (List<EmergencyPurchaseDetailItem>)Session["EP_ITEMS"];
            }
            else
            {
                Session["EP_ITEMS"] = items;
            }
            return items;
        }

        private void InitDepartments()
        {
            var departments = _departmentManager.FetchAll();
            DDLReceivedBy.DataSource = departments;
            DDLReceivedBy.DataTextField = "Description";
            DDLReceivedBy.DataValueField = "Id";
            DDLReceivedBy.DataBind();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();
        }


        private void InitItems()
        {
            InitItemsList();
            var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            txtBarcode.Text = selectedItem.BarCode;
        }

        private void InitItemsList()
        {
            var items = _itemManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLItems.DataSource = items;
            DDLItems.DataValueField = "Id";
            DDLItems.DataTextField = "ItemName";
            DDLItems.DataBind();
        }

        private void InitUnits()
        {
            var items = _unitManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLUnits.DataSource = items;
            DDLUnits.DataValueField = "Id";
            DDLUnits.DataTextField = "Description";
            DDLUnits.DataBind();
        }

        protected void Page_Init(object sender, EventArgs e)
        {
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
                        txtReferenceNumber.Text = Transaction.TransactionType.EPO + "-" + (_emergencyPurchaseManager.ReferenceNumber + 1);
                        txtEmergencyPurchaseDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
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
            var donationItem = new EmergencyPurchaseDetailItem
            {
                Barcode = txtBarcode.Text,
                ItemId = int.Parse(DDLItems.SelectedValue),
                ItemName = DDLItems.SelectedItem.Text,
                Price = (int.Parse(txtItemQuantity.Text) * decimal.Parse(txtPrice.Text)),
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
            InitItemsList();
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

            var donationDetails = DonationDetailItems();
            if (donationDetails.Count > 0)
            {
                var emergencyPurchase = new EmergencyPurchase
                {
                    DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                    ItemCode = "",
                    ReceivedBy = DDLReceivedBy.SelectedItem.Text,
                    RequisitionNumber = txtRISNumber.Text,
                    Status = Transaction.TransactionStatus.Posted.ToString(),
                    TotalQuantity = int.Parse(txtTotalQuantity.Text),
                    Uid = Guid.NewGuid(),
                    UnitCode = "",
                    EmergencyPurchaseDate = DateTime.Parse(txtEmergencyPurchaseDate.Text),
                    EmergencyPurchaseId = txtReferenceNumber.Text
                };
                _emergencyPurchaseManager.Save(emergencyPurchase);
                int emergencyPurchaseIdentity = _emergencyPurchaseManager.Identity;
                var details = donationDetails.Select(donationDetail => new EmergencyPurchaseDetail
                {
                    Barcode = donationDetail.Barcode,
                    EmergencyPurchaseId = emergencyPurchaseIdentity,
                    ItemId = donationDetail.ItemId,
                    Price = donationDetail.Price,
                    Quantity = donationDetail.Quantity,
                    Uid = donationDetail.Uid,
                    UnitId = donationDetail.UnitId
                }).ToList();
                _emergencyPurchaseDetailManager.Save(details);

                btnSave.Enabled = false;
                lnkButtonAdd.Enabled = false;
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify info");
                ltrlMessageHeader.Text = "Saved Sucessful!";
                ltrlMessage.Text = "New Emergency Purchase has been saved!";
                Session.Remove("EP_ITEMS");
            }
            else
            {
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify warning");
                ltrlMessageHeader.Text = "Warning!";
                ltrlMessage.Text = "No Item to be add!";
            }
        }
    }
}