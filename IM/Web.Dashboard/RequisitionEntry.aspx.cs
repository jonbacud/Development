using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;

namespace Web.Dashboard
{
    public partial class RequisitionEntry : System.Web.UI.Page
    {
        private readonly ItemManager _itemManager = new ItemManager();

        public List<RequestItem> RequestItems()
        {
            List<RequestItem> items = new List<RequestItem>();
            if (Session["REQUEST_ITEMS"]!=null)
            {
                items = (List<RequestItem>) Session["REQUEST_ITEMS"];
            }
            else
            {
                Session["REQUEST_ITEMS"] = items;
            }
            return items;
        } 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var dManager = new DepartmentManager();
                var departments = dManager.FetchAll();
                DDLDepartments.DataSource = departments;
                DDLDepartments.DataTextField = "Description";
                DDLDepartments.DataValueField = "Id";
                DDLDepartments.DataBind();
                DDLRequestTo.DataSource = departments;
                DDLRequestTo.DataTextField = "Description";
                DDLRequestTo.DataValueField = "Id";
                DDLRequestTo.DataBind();

                InitDetails();
                txtDateRequested.Text = DateTime.Now.ToString("MMM dd, yyyy");
              
                gvSelectedItems.DataSource = RequestItems();
                gvSelectedItems.DataBind();
              
            }
        }
      
        protected void DDLDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitDetails();
        }

        private void InitDetails()
        {
            if (!string.IsNullOrEmpty(DDLDepartments.SelectedValue.Trim()) ||
                !string.IsNullOrWhiteSpace(DDLDepartments.SelectedValue.Trim()))
            {
                InitClassifications();
                InitTypes();
                InitItems();
                InitUnits();
            }
        }

        private void InitItems()
        {
            if (!string.IsNullOrEmpty(DDLClassifications.SelectedValue.Trim()) &&
                !string.IsNullOrEmpty(DDLTypes.SelectedValue.Trim()))
            {
               
                DDLProducts.DataSource = _itemManager.FetchAll(int.Parse(DDLDepartments.SelectedValue),
                    int.Parse(DDLClassifications.SelectedValue)
                    , int.Parse(DDLTypes.SelectedValue));
                DDLProducts.DataTextField = "ItemName";
                DDLProducts.DataValueField = "Id";
                DDLProducts.DataBind();
                GetItemDetails(_itemManager);
            }
        }

        private void GetItemDetails(ItemManager itemManager)
        {
            if (!string.IsNullOrEmpty(DDLProducts.SelectedValue))
            {
                var item = itemManager.FetchById(int.Parse(DDLProducts.SelectedValue));
                txtBarCode.Text = item.BarCode;
                txtItemCode.Text = item.ItemCode;
            }
            else
            {
                txtBarCode.Text = string.Empty;
                txtItemCode.Text = string.Empty;
            }
        }

        private void InitTypes()
        {
            ItemTypeManager itemTypeManager = new ItemTypeManager();
            DDLTypes.DataSource = itemTypeManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLTypes.DataTextField = "ItemDesciption";
            DDLTypes.DataValueField = "Id";
            DDLTypes.DataBind();
        }

        private void InitClassifications()
        {
            ItemClassificationManager itemClassificationManager = new ItemClassificationManager();
            DDLClassifications.DataSource =
                itemClassificationManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLClassifications.DataTextField = "ClassificationName";
            DDLClassifications.DataValueField = "Id";
            DDLClassifications.DataBind();
        }


        private void InitUnits()
        {
            UnitManager uManager = new UnitManager();
            DDLUnits.DataSource = uManager.FetchAll(int.Parse(DDLDepartments.SelectedValue));
            DDLUnits.DataTextField = "Description";
            DDLUnits.DataValueField = "Id";
            DDLUnits.DataBind();
        }

        protected void DDLClassifications_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItems();
        }

        protected void DDLTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItems();
        }

        protected void DDLProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetItemDetails(_itemManager);
        }

        protected void lnkButtonAdd_Click(object sender, EventArgs e)
        {
            List<RequestItem> items = RequestItems();
            var item = new RequestItem
            {
                ItemId = int.Parse(DDLProducts.SelectedValue),
                Barcode = txtBarCode.Text.Trim(),
                CalssificationName = DDLClassifications.SelectedItem.Text,
                ClassificationId = int.Parse(DDLClassifications.SelectedValue),
                DepartmentId = int.Parse(DDLRequestTo.SelectedValue),
                DepartmentName = DDLDepartments.SelectedItem.Text,
                ItemCode = txtItemCode.Text,
                ItemName = DDLProducts.SelectedItem.Text,
                ReferenceNumber = txtReferenceNumber.Text.Trim(),
                TypeId = int.Parse(DDLTypes.SelectedValue),
                TypeName = DDLTypes.SelectedItem.Text,
                UnitId = int.Parse(DDLUnits.SelectedValue),
                UnitName = DDLUnits.SelectedItem.Text,
                RequestDate = DateTime.Parse(txtDateRequested.Text),
                Uid = Guid.NewGuid()
            };
            items.Add(item);
            gvSelectedItems.DataSource = items;
            gvSelectedItems.DataBind();
        }

        protected void gvSelectedItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<RequestItem> list = RequestItems();
            GridViewRow row = gvSelectedItems.Rows[e.RowIndex];
            HiddenField hfId = (HiddenField)row.FindControl("hfUniqueId");
            Guid uid = Guid.Parse(hfId.Value);
            list.RemoveAll(o => o.Uid == uid);

             gvSelectedItems.DataSource = RequestItems();
             gvSelectedItems.DataBind();
        }

        protected void btnSubmitEntry_Click(object sender, EventArgs e)
        {
            var requests = new List<Requisition>();
            if (RequestItems().Count > 0)
            {
                requests.AddRange(RequestItems().Select(ri => new Requisition
                {
                    UnitId = ri.UnitId, BarCode = ri.Barcode, DateCreated = DateTime.Now, DepartmentId = ri.DepartmentId, ItemClassificationId = ri.ClassificationId, ItemId = ri.ItemId, QuantityIssued = int.Parse(txtQuantityIssue.Text), SubmittedTo = DDLRequestTo.SelectedItem.Text, ReferenceNumber = txtReferenceNumber.Text.Trim(), RequisitionDate = DateTime.Parse(txtDateRequested.Text), Status = "Submmited", UniqueId = Guid.NewGuid(),QuantityReceived = 0
                }));
               RequisitionManager requisitionManager = new RequisitionManager();
                requisitionManager.Save(requests);
            }
        }
    }
}