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
    public partial class ItemIssuanceEntry : System.Web.UI.Page
    {
        private readonly DepartmentManager _dManager = new DepartmentManager();
        private readonly IssuanceManager _issuanceManager = new IssuanceManager();
        private readonly IssuanceDetailManager _issuanceDetailManager = new IssuanceDetailManager();

        public int ItemId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            var departments = _dManager.FetchAll();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();
            switch (Mode)
            {
                case Transaction.TransactionMode.NewEntry:
                    txtReferenceNumber.Text = Transaction.TransactionType.ISS.ToString()+"-"+
                        (_issuanceManager.ReferenceNumber+1).ToString();
                    break;
                case Transaction.TransactionMode.UpdateEntry:
                    break;
                default:
                    Response.Redirect("/IssuanceManagementPanel");
                    break;
            }

            txtIssuanceDate.Text = DateTime.Now.ToString("MMM dd, yyyy");
        }

        private void InitialiazeIssuanceEntry(string requestReferenceNumber)
        {
            RequisitionManager rManager = new RequisitionManager();
            ItemManager itemManager = new ItemManager();
            var items = rManager.FetchAll()
                .Where(r => r.ReferenceNumber.Equals(requestReferenceNumber) 
                    && !r.Status.Equals(Transaction.TransactionStatus.Completed.ToString()));

            decimal totalAmount =
                (from p in items let item = itemManager.FetchById(p.ItemId) select item.LastSellingPrice*p.QuantityIssued).Sum();
            txtTotalAmount.Text = totalAmount.ToString("##0.00");

            ItemClassificationManager classificationManager = new ItemClassificationManager();
            ItemTypeManager itManager = new ItemTypeManager();
            UnitManager uManager = new UnitManager();
            List<RequestItem> requesItems = (from ri in items
                let classification = classificationManager.FetchById(ri.ItemClassificationId)
                let department = _dManager.FetchById(ri.DepartmentId)
                let item = itemManager.FetchById(ri.ItemId)
                let type = itManager.FetchById(item.TypeId)
                let unit = uManager.FetchById(ri.UnitId)
                select new RequestItem
                {
                    Barcode = ri.BarCode,
                    ClassificationName = classification.ClassificationName,
                    ClassificationId = classification.Id,
                    DepartmentId = department.Id,
                    DepartmentName = department.Description,
                    ItemCode = item.ItemCode,
                    ItemId = item.Id,
                    ItemName = item.ItemName,
                    ReferenceNumber = ri.ReferenceNumber,
                    RequestDate = ri.RequisitionDate,
                    RequestTo = ri.DepartmentId,
                    TypeId = type.Id,
                    TypeName = type.ItemDesciption,
                    UnitName = unit.Description,
                    UnitId = unit.Id,
                    Uid = ri.UniqueId,
                    Quantity = ri.QuantityIssued,
                    RequesitionId = item.Id,
                    ItemPrice = item.LastSellingPrice,
                    ReceivedQuantity = ri.QuantityReceived,
                    IssuedQuantity = ri.QuantityIssued
                }).ToList();

            Session["REQUEST_ITEMS"] = requesItems;
            gvSelectedItems.DataSource = requesItems;
            gvSelectedItems.DataBind();

          
            if (requesItems.Count>0)
            {
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify info");
                ltrlMessageHeader.Text = "Search Result!";
                ltrlMessage.Text = "(" + requesItems.Count + ") Requistion detail found!";
                btnSubmitIssuance.Enabled = true;
            }
            else
            {
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify warning");
                ltrlMessageHeader.Text = "Search Result!";
                ltrlMessage.Text = "No Requistion found!";
                btnSubmitIssuance.Enabled = false;
            }
        }

        private List<IssuanceDetail> IssuanceDetails(ref bool hasErrow)
        {
            List<RequestItem> requestItems = (List<RequestItem>)Session["REQUEST_ITEMS"];
            List<IssuanceDetail> issuanceDetails = new List<IssuanceDetail>();
            foreach (GridViewRow row in gvSelectedItems.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkItem = (CheckBox)row.FindControl("chkItem");
                    Label lblItemName = (Label)row.FindControl("lblItemName");
                    TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
                    if (chkItem.Checked)
                    {
                        var issuanceItem = requestItems.FirstOrDefault(ri => ri.RequesitionId.Equals(int.Parse(lblItemName.ToolTip)));
                        if (issuanceItem != null)
                        {
                            if (issuanceItem.DepartmentId == int.Parse(DDLDepartments.SelectedValue))
                            {
                                if (int.Parse(txtQuantity.Text) >(issuanceItem.IssuedQuantity - issuanceItem.ReceivedQuantity))
                                {
                                    divMessageBox.Visible = true;
                                    divMessageBox.Attributes.Add("class", "notify warning");
                                    ltrlMessageHeader.Text = "Warning!";
                                    ltrlMessage.Text = "Input Number data is not valid, Please check and try again!";
                                    btnSubmitIssuance.Enabled = true;
                                    hasErrow = true;
                                    break;
                                }
                                var issuanceDetail = new IssuanceDetail
                                {
                                    UnitId = issuanceItem.UnitId,
                                    Uid = Guid.NewGuid(),
                                    Quantity = issuanceItem.Quantity,
                                    Barcode = issuanceItem.Barcode,
                                    IsPosted = false,
                                    IssuanceId = 0,
                                    ItemId = issuanceItem.ItemId,
                                    Price = issuanceItem.ItemPrice,
                                    RequisitionId = issuanceItem.RequesitionId
                                };
                                issuanceDetails.Add(issuanceDetail);
                            }
                            else
                            {
                                divMessageBox.Visible = true;
                                divMessageBox.Attributes.Add("class", "notify warning");
                                ltrlMessageHeader.Text = "Warning!";
                                ltrlMessage.Text = "Selected Department data is not valid, Please check and try again!";
                                btnSubmitIssuance.Enabled = true;
                                hasErrow = true;
                                break;
                            }
                        }
                    }
                }
            }
            return issuanceDetails;
        } 

        protected void btnSubmitIssuance_Click(object sender, EventArgs e)
        {
            bool hasError = false;
           var issuanceDetails= IssuanceDetails(ref hasError);
            if (!hasError)
            {
                var issuance = new Issuance
                {
                    DateCreated = DateTime.Now,
                    DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                    IsPosted = false,
                    IssuanceDate = DateTime.Parse(txtIssuanceDate.Text),
                    IssuedTo = DDLDepartments.SelectedItem.Text,
                    ReferenceNumber = txtReferenceNumber.Text.Trim(),
                    RequisitionId = 0,
                    TotalAmount = decimal.Parse(txtTotalAmount.Text),
                    Unid = Guid.NewGuid(),
                    RequisitionReferenceNumber = txtRISNumber.Text
                };
                _issuanceManager.Save(issuance);
                var identity = _issuanceManager.Identity;
                foreach (var issuanceDetail in issuanceDetails)
                {
                    issuanceDetail.IssuanceId = identity;
                }
                _issuanceDetailManager.Save(issuanceDetails);
                divMessageBox.Visible = true;
                divMessageBox.Attributes.Add("class", "notify info");
                ltrlMessageHeader.Text = "Submit Successful!";
                ltrlMessage.Text = "New Issuance data has been saved!";
                btnSubmitIssuance.Enabled = false;
            }
        }

        protected void btnGetRISDetail_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtRISNumber.Text)|| !string.IsNullOrWhiteSpace(txtRISNumber.Text))
            {
                InitialiazeIssuanceEntry(txtRISNumber.Text);
          
            }
        }
    }
}