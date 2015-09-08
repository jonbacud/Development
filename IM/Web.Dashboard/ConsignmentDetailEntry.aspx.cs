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
    public partial class ConsignmentDetailEntry : System.Web.UI.Page
    {
        readonly ConsignmentOrderManager _consignmentOrderManager = new ConsignmentOrderManager();
        readonly ConsignmentOrderDetailManager _consignmentOrderDetailManager = new ConsignmentOrderDetailManager();
        readonly UnitManager _unitManager = new UnitManager();
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

        public int ConsignmentDetailId
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

        public int ConsignmentOrderId
        {
            get
            {
                if (Mode == Transaction.TransactionMode.NewEntry)
                {
                    return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString());
                }
                return ConsignmentOrderDetail.ConsignmentId;
            }
        }

        public ConsignmentOrderDetail ConsignmentOrderDetail
        {
            get { return _consignmentOrderDetailManager.FetchById(ConsignmentDetailId); }
        }

        public ConsignmentOrder ConsignmentOrder
        {
            get { return _consignmentOrderManager.FetchById(ConsignmentOrderId); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }


        private void InitItems()
        {
            var items = _itemManager.FetchAll(ConsignmentOrder.DepartmentId);
            DDLItems.DataSource = items;
            DDLItems.DataValueField = "Id";
            DDLItems.DataTextField = "ItemName";
            DDLItems.DataBind();

            var selectedItem = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            txtBarcode.Text = selectedItem.BarCode;
        }

        private void InitUnits()
        {
            var items = _unitManager.FetchAll(ConsignmentOrder.DepartmentId);
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
            if(!IsPostBack)
            {
                txtReferenceNumber.Text = ConsignmentOrder.ConsignmentId;
                txtTotalQuantity.Text = ConsignmentOrder.TotalQuantity.ToString();
                txtDonationDate.Text = ConsignmentOrder.ConsignmentDate.ToString("MMM dd, yyyy");
                txtDeliverTo.Text = ConsignmentOrder.DeliverTo;
                txtRISNumber.Text = ConsignmentOrder.RequisitionNumber;
                txtCompany.Text = ConsignmentOrder.CompanyName;
                txtPreparedBy.Text = ConsignmentOrder.PreparedBy;
                txtDaysDeliver.Text = ConsignmentOrder.DaysDeliver.ToString();
                hpLinkBack.NavigateUrl = "/consignment-detail/0/" + ConsignmentOrder.Id;
                switch (Mode)
                {
                    case Transaction.TransactionMode.NewEntry:
                        break;
                    case Transaction.TransactionMode.UpdateEntry:
                        DDLItems.SelectedValue = ConsignmentOrderDetail.ItemId.ToString();
                        DDLUnits.SelectedValue = ConsignmentOrderDetail.UnitId.ToString();
                        txtBarcode.Text = ConsignmentOrderDetail.Barcode;
                        txtItemQuantity.Text = ConsignmentOrderDetail.Quantity.ToString();
                        txtPrice.Text = ConsignmentOrderDetail.Price.ToString("##0.00");
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
            var donationDetail = new ConsignmentOrderDetail
            {
                Barcode = txtBarcode.Text,
                ConsignmentId = ConsignmentOrder.Id,
                Id = ConsignmentDetailId,
                ItemId = int.Parse(DDLItems.SelectedValue),
                Price = decimal.Parse(txtPrice.Text),
                Quantity = int.Parse(txtItemQuantity.Text),
                Uid = Guid.NewGuid(),
                UnitId = int.Parse(DDLUnits.SelectedValue)
            };

            _consignmentOrderDetailManager.Save(donationDetail);
            var consignment = ConsignmentOrder;
            consignment.TotalQuantity = _consignmentOrderDetailManager.FetchAll(ConsignmentOrder.Id).Sum(dd => dd.Quantity);
            _consignmentOrderManager.Save(consignment);
            txtTotalQuantity.Text = consignment.TotalQuantity.ToString();
            divMessageBox.Visible = true;
            divMessageBox.Attributes.Add("class", "notify info");
            ltrlMessageHeader.Text = "Saved Sucessful!";
            ltrlMessage.Text = "Consignment Detail Entry has been saved!";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var consignment = ConsignmentOrder;
            consignment.TotalQuantity = _consignmentOrderDetailManager.FetchAll(ConsignmentOrder.Id)
                .Sum(dd => dd.Quantity) - ConsignmentOrderDetail.Quantity;
            _consignmentOrderManager.Save(consignment);
            txtTotalQuantity.Text = consignment.TotalQuantity.ToString();
            var consignementDetailToDelete = new ConsignmentOrderDetail
            {
                Id = ConsignmentDetailId
            };
            _consignmentOrderDetailManager.Delete(consignementDetailToDelete);
            divMessageBox.Visible = true;
            divMessageBox.Attributes.Add("class", "notify warning");
            ltrlMessageHeader.Text = "Saved Sucessful!";
            ltrlMessage.Text = "Consigment Detail Entry has been deleted!";
            btnDelete.Enabled = false;
            btnSave.Enabled = false;
        }
    }
}