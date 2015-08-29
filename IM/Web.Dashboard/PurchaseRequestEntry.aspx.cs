using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;

namespace Web.Dashboard
{
    public partial class PurchaseRequestEntry : System.Web.UI.Page
    {
        #region variables
        private readonly DepartmentManager   _departmentManager = new DepartmentManager();
        private readonly ItemManager _itemManager = new ItemManager();
        private readonly PurchaseRequestManager _purchaseRequestManager = new PurchaseRequestManager();
        private readonly UnitManager _unitManager = new UnitManager();
        #endregion
        public List<PurchaseRequest> RequestItems()
        {
           var items = new List<PurchaseRequest>();
            if (Session["PURCHASE_ITEMS"] != null)
            {
                items = (List<PurchaseRequest>)Session["PURCHASE_ITEMS"];
            }
            else
            {
                Session["PURCHASE_ITEMS"] = items;
            }
            return items;
        } 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitDepartments();
                InitItems();
                txtRequestDate.Text = DateTime.Now.ToString("MMM dd, yyyy");

                gvSelectedItems.DataSource = RequestItems();
                gvSelectedItems.DataBind();
            }
        }

        private void InitDepartments()
        {
            var departments = _departmentManager.FetchAll();
            DDLFromDepartments.DataSource = departments;
            DDLFromDepartments.DataTextField = "Description";
            DDLFromDepartments.DataValueField = "Id";
            DDLFromDepartments.DataBind();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();
            DDLFromDepartments.SelectedIndex = 0;
        }

        private void InitItems()
        {
            if (!string.IsNullOrEmpty(DDLFromDepartments.SelectedValue.Trim()) &&
                !string.IsNullOrWhiteSpace((DDLFromDepartments.SelectedValue.Trim())))
            {
                DDLItems.DataSource = _itemManager.FetchAll(int.Parse(DDLFromDepartments.SelectedValue));
                DDLItems.DataTextField = "ItemName";
                DDLItems.DataValueField = "Id";
                DDLItems.DataBind();
            }
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            var requests = new List<PurchaseRequest>();
            if (RequestItems().Count > 0)
            {
                requests.AddRange(RequestItems().Select(item => new PurchaseRequest
                {
                    AlobsNmber = item.AlobsNmber,
                    BaseDepartmentId = item.BaseDepartmentId, 
                    ItemCode = item.ItemCode, 
                    PrId = item.PrId.ToString(), 
                    PurcahaseRequestDate = item.PurcahaseRequestDate, 
                    ReceiveBy = item.ReceiveBy, 
                    RequestBy = item.RequestBy, 
                    RequestQuantity = item.RequestQuantity, 
                    RequisitionNumber = item.RequisitionNumber, 
                    SaiNumber = item.SaiNumber, 
                    Status = "Submmited", 
                    StockNumber = item.StockNumber, 
                    UnitCode = item.UnitCode,
                    uid = Guid.NewGuid()
                }));
                _purchaseRequestManager.Save(requests);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void lnkButtonAdd_Click(object sender, EventArgs e)
        {
            //var itemDetails = _itemManager.FetchById(int.Parse(DDLItems.SelectedValue));
            //var items = RequestItems();
            //var unit = _unitManager.FetchById(int.Parse(DDLUnits.SelectedValue));
            //var item = new PurchaseRequestItem
            //{
            //    ItemName = DDLItems.SelectedItem.Text,
            //    UnitId = int.Parse(DDLUnits.SelectedValue),
            //    UnitName = DDLUnits.SelectedItem.Text,
            //    Uid = Guid.NewGuid(),
            //    UnitCost = itemDetails.LastPurchasePrice,
            //    EstimatedCost = (itemDetails.LastPurchasePrice*int.Parse(txtQuantity.Text)),
            //    ItemNumber = int.Parse(DDLItems.SelectedValue),
            //    Quantity = int.Parse(txtQuantity.Text),
            //    RequestNumber = txtReferenceNumber.Text,
            //    StockNumber = txtStockNumber.Text,
            //    AlobsNumber = txtALOBSNumber.Text,
            //    SaiNumber = txtSAINumber.Text,
            //    DepartmentId = int.Parse(DDLDepartments.SelectedValue),
            //    ItemCode = itemDetails.ItemCode,
            //    DateRequest = DateTime.Parse(txtRequestDate.Text),
            //    ReceiveBy = DDLDepartments.SelectedItem.Text,
            //    RequestBy = DDLFromDepartments.SelectedItem.Text, //todo: to be replace by log in user
            //    UnitCode = unit.Code
            //};
           
            //items.Add(item);
            //gvSelectedItems.DataSource = items;
            //gvSelectedItems.DataBind();
        }

        protected void gvSelectedItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var list = RequestItems();
            var row = gvSelectedItems.Rows[e.RowIndex];
            var hfId = (HiddenField)row.FindControl("hfUniqueId");
            var uid = Guid.Parse(hfId.Value);
            list.RemoveAll(o => o.uid == uid);

            gvSelectedItems.DataSource = RequestItems();
            gvSelectedItems.DataBind();
        }

        protected void DDLFromDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItems();
        }
    }
}