using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;

namespace Web.Dashboard
{
    public partial class PurchaseRequestEntry : System.Web.UI.Page
    {
        readonly DepartmentManager   _departmentManager = new DepartmentManager();
        private readonly ItemManager _itemManager = new ItemManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitDepartments();
                InitItems();
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

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void lnkButtonAdd_Click(object sender, EventArgs e)
        {

        }

        protected void gvSelectedItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void DDLFromDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            InitItems();
        }
    }
}