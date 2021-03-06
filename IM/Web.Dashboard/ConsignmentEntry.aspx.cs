﻿using System;
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
    public partial class ConsignmentEntry : System.Web.UI.Page
    {
        readonly ConsignmentOrderManager _consignmentOrderManager = new ConsignmentOrderManager();
        readonly ConsignmentOrderDetailManager _consignmentOrderDetailManager = new ConsignmentOrderDetailManager();

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

        public List<ConsignmentDetailItem> ConsignmentDetailItems()
        {
            var items = new List<ConsignmentDetailItem>();
            if (Session["CONSIGNMENT_ITEMS"] != null)
            {
                items = (List<ConsignmentDetailItem>)Session["CONSIGNMENT_ITEMS"];
            }
            else
            {
                Session["CONSIGNMENT_ITEMS"] = items;
            }
            return items;
        }

        private void InitDepartments()
        {
            var departments = _departmentManager.FetchAll();
            DDLDeliverTo.DataSource = departments;
            DDLDeliverTo.DataTextField = "Description";
            DDLDeliverTo.DataValueField = "Id";
            DDLDeliverTo.DataBind();
            DDLDeliverTo.SelectedIndex = 0;
        }

        private void InitSuppliers()
        {
            var suppliers = _supplierManager.FetchAll().Where(s => s.DepartmentId.Equals(UserAccount.DeaprtmentId));
            DDLCompanies.DataSource = suppliers;
            DDLCompanies.DataTextField = "Name";
            DDLCompanies.DataValueField = "Id";
            DDLCompanies.DataBind();
        }

        private void InitItems()
        {
            InitItemList();
            var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            txtBarcode.Text = selectedItem.BarCode;
        }

        private void InitItemList()
        {
            if (!string.IsNullOrEmpty(DDLDeliverTo.SelectedValue) || !string.IsNullOrWhiteSpace(DDLDeliverTo.SelectedValue))
            {
                var items = _itemManager.FetchAll(int.Parse(DDLDeliverTo.SelectedValue));
                DDLItems.DataSource = items;
                DDLItems.DataValueField = "Id";
                DDLItems.DataTextField = "ItemName";
                DDLItems.DataBind();
            }
        }

        private void InitUnits()
        {
            var items = _unitManager.FetchAll(int.Parse(DDLDeliverTo.SelectedValue));
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
                gvSelectedItems.DataSource = ConsignmentDetailItems();
                gvSelectedItems.DataBind();

                switch (Mode)
                {
                    case Transaction.TransactionMode.NewEntry:
                        txtReferenceNumber.Text = Transaction.TransactionType.CON + "-" + (_consignmentOrderManager.ReferenceNumber + 1);
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
            var items = ConsignmentDetailItems();
            var donationItem = new ConsignmentDetailItem
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

        protected void gvSelectedItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var list = ConsignmentDetailItems();
            var row = gvSelectedItems.Rows[e.RowIndex];
            var hfId = (HiddenField)row.FindControl("hfUniqueId");
            var uid = Guid.Parse(hfId.Value);
            list.RemoveAll(o => o.Uid == uid);

            txtTotalQuantity.Text = list.Sum(i => i.Quantity).ToString();
            gvSelectedItems.DataSource = ConsignmentDetailItems();
            gvSelectedItems.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPreparedBy.Text) || string.IsNullOrWhiteSpace(txtPreparedBy.Text))
            {
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify warning");
                ltrlMessageHeader.Text = "Warning!";
                ltrlMessage.Text = "Prepared by is Required";
                return;
            }

            var donationDetails = ConsignmentDetailItems();
            var supplier = _supplierManager.FetchById(int.Parse(DDLCompanies.SelectedValue));
            if (donationDetails.Count > 0)
            {
                var consignment = new ConsignmentOrder
                {
                    SupplierId = int.Parse(DDLCompanies.SelectedValue),
                    DepartmentId = int.Parse(DDLDeliverTo.SelectedValue),
                    ConsignmentDate = DateTime.Parse(txtDonationDate.Text),
                    ItemCode = "",
                    RequisitionNumber = txtRISNumber.Text,
                    TotalQuantity = int.Parse(txtTotalQuantity.Text),
                    Uid = Guid.NewGuid(),
                    UnitCode = "",
                    CompanyAddress = supplier.Address,
                    CompanyName = supplier.Name,
                    ConsignmentId = txtReferenceNumber.Text,
                    ConsignmentStatus = Transaction.TransactionStatus.Posted.ToString(),
                    DaysDeliver = int.Parse(txtDaysDeliver.Text),
                    DeliverTo = DDLDeliverTo.SelectedItem.Text,
                    PreparedBy = txtPreparedBy.Text
                };
                _consignmentOrderManager.Save(consignment);
                int consignmentIdentity = _consignmentOrderManager.Identity;
                var details = donationDetails.Select(donationDetail => new ConsignmentOrderDetail
                {
                    Barcode = donationDetail.Barcode,
                    ItemId = donationDetail.ItemId,
                    Price = donationDetail.Price,
                    Quantity = donationDetail.Quantity,
                    Uid = donationDetail.Uid,
                    UnitId = donationDetail.UnitId,
                    ConsignmentId = consignmentIdentity
                }).ToList();

                _consignmentOrderDetailManager.Save(details);

                btnSave.Enabled = false;
                lnkButtonAdd.Enabled = false;
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify info");
                ltrlMessageHeader.Text = "Saved Sucessful!";
                ltrlMessage.Text = "New Consignment Entry has been saved!";
                Session.Remove("CONSIGNMENT_ITEMS");
            }
            else
            {
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify warning");
                ltrlMessageHeader.Text = "Warning!";
                ltrlMessage.Text = "No Item to be add!";
            }
        }

        protected void DDLDeliverTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItemList();
            InitUnits();
        }

        protected void DDLItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLItems.Items.Count>0)
            {
                var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
                txtBarcode.Text = selectedItem.BarCode;
            }
        }
    }
}