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
    public partial class CategoryEntry : System.Web.UI.Page
    {
        readonly CategoryManager _categoryManager = new CategoryManager();
        public int CategoryId {
               get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public Category Category {
            get { return _categoryManager.FetchById(CategoryId); }
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

            if (CategoryId>0)
            {
                txtCategoryCode.Text = Category.Code;
                txtCategoryName.Text = Category.Description;
                DDLDepartments.SelectedValue = Category.DepartmentId.ToString();
                btnDelete.Enabled = true;
                btnDelete.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newCategory = new Category
            {
                Code = txtCategoryCode.Text.Trim(),
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                Description = txtCategoryName.Text,
                UniqueId = Guid.NewGuid(),
                Id = CategoryId
            };
            _categoryManager.Save(newCategory);
            Response.Redirect("~/CategoryManagementPanel");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var categoryToDelete = new Category
            {
                Id = CategoryId
            };
            _categoryManager.Delete(categoryToDelete);
            Response.Redirect("~/CategoryManagementPanel");
        }
    }
}