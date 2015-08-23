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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            var dManager = new DepartmentManager();
            var departments = dManager.FetchAll();
            DDLDepartments.DataSource = departments;
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newItemType = new ItemType
            {
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                ItemDesciption = txtItemTypeDescription.Text,
                ItemTypeCode = txtItemTypeCode.Text,
                UniqueId = Guid.NewGuid()
            };
            _itemTypeManager.Save(newItemType);
            Response.Redirect("ItemTypeManagementPanel.aspx");
        }
    }
}