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
    public partial class IssuanceDetails : System.Web.UI.Page
    {
        private readonly DepartmentManager _dManager = new DepartmentManager();
        private readonly IssuanceManager _issuanceManager = new IssuanceManager();
        private readonly IssuanceDetailManager _issuanceDetailManager = new IssuanceDetailManager();
        private readonly RequisitionManager _requisitionManager = new RequisitionManager();
        public int IssuanceId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Issuance Issuance
        {
            get { return _issuanceManager.FetchById(IssuanceId); }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            txtIssuanceDate.Text = Issuance.IssuanceDate.ToString("MMM dd, yyyy");
            txtDepartment.Text = Issuance.IssuedTo;
            txtReferenceNumber.Text = Issuance.ReferenceNumber;
            txtRISNumber.Text = Issuance.RequisitionReferenceNumber;
            InitialiazeIssuanceDetails();
        }

        private void InitialiazeIssuanceDetails()
        {
            ItemManager itemManager = new ItemManager();
            var items = _issuanceDetailManager.FetchAll(IssuanceId);
            txtTotalAmount.Text = Issuance.TotalAmount.ToString("##0.00");
            ItemClassificationManager classificationManager = new ItemClassificationManager();
            UnitManager uManager = new UnitManager();
            List<RequestItem> requesItems = (from ri in items
                                             let item = itemManager.FetchById(ri.ItemId)
                                             let classification = classificationManager.FetchById(item.ClassificationId)
                                             let unit = uManager.FetchById(ri.UnitId)
                                             let request = _requisitionManager.FetchById(ri.RequisitionId)
                                             select new RequestItem
                                             {
                                                 Barcode = ri.Barcode,
                                                 ClassificationName = classification.ClassificationName,
                                                 ClassificationId = classification.Id,
                                                 DepartmentId = Issuance.DepartmentId,
                                                 DepartmentName = Issuance.IssuedTo,
                                                 ItemCode = item.ItemCode,
                                                 ItemId = item.Id,
                                                 ItemName = item.ItemName,
                                                 ReferenceNumber = Issuance.ReferenceNumber,
                                                 UnitName = unit.Description,
                                                 UnitId = unit.Id,
                                                 Uid = ri.Uid,
                                                 Quantity = ri.Quantity,
                                                 RequesitionId = ri.RequisitionId,
                                                 ItemPrice = ri.Price,
                                                 ReceivedQuantity = request.QuantityReceived,
                                                 IssuedQuantity = request.QuantityIssued
                                             }).ToList();

            gvSelectedItems.DataSource = requesItems;
            gvSelectedItems.DataBind();

            if (requesItems.Count <= 0)
            {
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify warning");
                ltrlMessageHeader.Text = "Issuance!";
                ltrlMessage.Text = "No Requistion found!";
                btnSubmitIssuance.Enabled = false;
            }
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
            //}
        }

        protected void btnGetRISDetail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRISNumber.Text) || !string.IsNullOrWhiteSpace(txtRISNumber.Text))
            {

            }
        }
    }
}