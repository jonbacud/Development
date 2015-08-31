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
    public partial class IssuanceDetailEntry : System.Web.UI.Page
    {
        private readonly DepartmentManager _dManager = new DepartmentManager();
        private readonly IssuanceManager _issuanceManager = new IssuanceManager();
        private readonly IssuanceDetailManager _issuanceDetailManager = new IssuanceDetailManager();
        private readonly ItemManager _itemManager = new ItemManager();
        private readonly RequisitionManager _requisitionManager = new RequisitionManager();

        public Guid IssuanceDetailsUid
        {
            get { return (Page.RouteData.Values["id"] == null) ? Guid.NewGuid() : Guid.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public IssuanceDetail IssuanceDetail
        {
            get { return _issuanceDetailManager.FetchById(IssuanceDetailsUid); }
        }


        public Issuance Issuance
        {
            get { return _issuanceManager.FetchById(IssuanceDetail.IssuanceId); }
        }

        public Item Item
        {
            get { return _itemManager.FetchById(IssuanceDetail.ItemId); }
        }

        public Requisition Requisition
        {
            get { return _requisitionManager.FetchById(IssuanceDetail.RequisitionId); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            hpLnkBack.Attributes.Add("href", "issuance-details/"+IssuanceDetail.IssuanceId);
            var departments = _dManager.FetchAll();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();

            //header
            txtRISNumber.Text = Issuance.RequisitionReferenceNumber;
            txtIssuanceDate.Text = Issuance.IssuanceDate.ToString("MMM dd, yyyy");
            txtReferenceNumber.Text = Issuance.ReferenceNumber;
            DDLDepartments.SelectedValue = Issuance.DepartmentId.ToString();
            txtTotalAmount.Text = (IssuanceDetail.Quantity*IssuanceDetail.Price).ToString("F");

            //detail
            txtItemName.Text = Item.ItemName;
            txtBarCode.Text = Item.BarCode;
            txtIssuedQuantity.Text = IssuanceDetail.Quantity.ToString();
            txtPrice.Text = Item.LastSellingPrice.ToString("###,##0.00");

            //requesition
            txtRequestQuantity.Text = Requisition.QuantityIssued.ToString();
            txtReceivedQuantity.Text = Requisition.QuantityReceived.ToString();
        }

        protected void btnSubmitIssuance_Click(object sender, EventArgs e)
        {
            //bool hasError = false;
            //var issuanceDetails = IssuanceDetails(ref hasError);
            //if (!hasError)
            //{
            //    var issuance = new Issuance
            //    {
            //        DateCreated = DateTime.Now,
            //        DepartmentId = int.Parse(DDLDepartments.SelectedValue),
            //        IsPosted = false,
            //        IssuanceDate = DateTime.Parse(txtIssuanceDate.Text),
            //        IssuedTo = DDLDepartments.SelectedItem.Text,
            //        ReferenceNumber = txtReferenceNumber.Text.Trim(),
            //        RequisitionId = 0,
            //        TotalAmount = decimal.Parse(txtTotalAmount.Text),
            //        Unid = Guid.NewGuid(),
            //        RequisitionReferenceNumber = txtRISNumber.Text
            //    };
            //    _issuanceManager.Save(issuance);
            //    var identity = _issuanceManager.Identity;
            //    foreach (var issuanceDetail in issuanceDetails)
            //    {
            //        issuanceDetail.IssuanceId = identity;
            //    }
            //    _issuanceDetailManager.Save(issuanceDetails);
            //    divMessageBox.Visible = true;
            //    divMessageBox.Attributes.Add("class", "notify info");
            //    ltrlMessageHeader.Text = "Submit Successful!";
            //    ltrlMessage.Text = "New Issuance data has been saved!";
            //    btnSubmitIssuance.Enabled = false;
           // }
        }

       

    }
}