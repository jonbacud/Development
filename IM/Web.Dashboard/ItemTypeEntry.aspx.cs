using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;

namespace Web.Dashboard
{
    public partial class ItemTypeEntry : System.Web.UI.Page
    {
        readonly ItemTypeManager _itemTypeManager = new ItemTypeManager();

        public int ItemTypeId
        {
            get { return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]); }
        }

        public ItemType ItemType
        {
            get { return _itemTypeManager.FetchById(ItemTypeId); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var dManager = new DepartmentManager();
            var departments = dManager.FetchAll();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();
            
            if (ItemTypeId>0)
            {
                txtItemTypeCode.Text = ItemType.ItemTypeCode;
                txtItemTypeDescription.Text = ItemType.ItemDesciption;
                DDLDepartments.SelectedValue = ItemType.DepartmentId.ToString();
                btnDelete.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newItemType = new ItemType
            {
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                ItemDesciption = txtItemTypeDescription.Text,
                ItemTypeCode = txtItemTypeCode.Text,
                UniqueId = Guid.NewGuid(),
                Id = ItemTypeId
            };
            _itemTypeManager.Save(newItemType);
            Response.Redirect("ItemTypeManagementPanel.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var itemTypeToDelete = new ItemType
            {
                Id = ItemTypeId
            };
            _itemTypeManager.Delete(itemTypeToDelete);
            Response.Redirect("ItemTypeManagementPanel.aspx");
        }
    }
}