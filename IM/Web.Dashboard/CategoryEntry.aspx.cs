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
    public partial class CategoryEntry : System.Web.UI.Page
    {
        readonly CategoryManager _categoryManager = new CategoryManager();
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
            var newCategory = new Category
            {
                Code = txtCategoryCode.Text.Trim(),
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                Description = txtCategoryDescription.Text,
                UniqueId = Guid.NewGuid()
            };
            _categoryManager.Save(newCategory);
            Response.Redirect("CategoryManagementPanel.aspx");
        }
    }
}