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
    public partial class ConsignmentDetails : System.Web.UI.Page
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

        public int ConsignmentId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public ConsignmentOrder ConsignmentOrder
        {
            get { return _consignmentOrderManager.FetchById(ConsignmentId); }
        }

        private void InitDepartments()
        {
            var departments = _departmentManager.FetchAll();
            DDlDeliverTo.DataSource = departments;
            DDlDeliverTo.DataTextField = "Description";
            DDlDeliverTo.DataValueField = "Id";
            DDlDeliverTo.DataBind();
        }

        private void InitSuppliers()
        {
            var suppliers = _supplierManager.FetchAll().Where(s => s.DepartmentId.Equals(UserAccount.DeaprtmentId));
            DDLCompanies.DataSource = suppliers;
            DDLCompanies.DataTextField = "Name";
            DDLCompanies.DataValueField = "Id";
            DDLCompanies.DataBind();
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
                hpLinkNewDetail.NavigateUrl = "/consignment-detail-entry/1/" + ConsignmentId;
                switch (Mode)
                {
                    case Transaction.TransactionMode.NewEntry:
                        break;
                    case Transaction.TransactionMode.UpdateEntry:
                        txtReferenceNumber.Text = ConsignmentOrder.ConsignmentId;
                        txtConsignmentDate.Text = ConsignmentOrder.ConsignmentDate.ToString("MMM dd, yyyy");
                        txtPreparedBy.Text = ConsignmentOrder.PreparedBy;
                        txtTotalQuantity.Text = ConsignmentOrder.TotalQuantity.ToString();
                        DDLCompanies.SelectedValue = ConsignmentOrder.SupplierId.ToString();
                        DDlDeliverTo.SelectedValue = ConsignmentOrder.DepartmentId.ToString();
                        txtDaysDeliver.Text = ConsignmentOrder.DaysDeliver.ToString();
                        var items = (from donationDetail in _consignmentOrderDetailManager.FetchAll(ConsignmentId)
                                     let itemDetail = _itemManager.FetchById(donationDetail.ItemId)
                                     let unitDetail = _unitManager.FetchById(donationDetail.UnitId)
                                     select new ConsignmentDetailItem
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
                        hpLinkBack.NavigateUrl = "/ConsignmentManagementPanel";
                        btnDelete.Visible = true;
                        break;
                }
            }
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
            var supplier = _supplierManager.FetchById(int.Parse(DDLCompanies.SelectedValue));
            var consignment = new ConsignmentOrder
            {
                CompanyName = supplier.Name,
                SupplierId = supplier.Id,
                DeliverTo = DDlDeliverTo.SelectedItem.Text,
                DepartmentId = int.Parse(DDlDeliverTo.SelectedValue),
                ConsignmentDate = DateTime.Parse(txtConsignmentDate.Text),
                ConsignmentId = txtReferenceNumber.Text,
                ItemCode = "",
                PreparedBy = txtPreparedBy.Text,
                RequisitionNumber = txtRISNumber.Text,
                ConsignmentStatus = Transaction.TransactionStatus.Posted.ToString(),
                TotalQuantity = int.Parse(txtTotalQuantity.Text),
                Uid = ConsignmentOrder.Uid,
                UnitCode = "",
                Id = ConsignmentId,
                CompanyAddress = supplier.Address,
                DaysDeliver = int.Parse(txtDaysDeliver.Text)
            };
            _consignmentOrderManager.Save(consignment);
            divMessageBox.Visible = true;
            divMessageBox.Attributes.Add("class", "notify info");
            ltrlMessageHeader.Text = "Saved Sucessful!";
            ltrlMessage.Text = "Consignment Entry has been Updated!";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}