using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;

namespace Web.Dashboard
{
    public partial class CategoryManagementPanel : System.Web.UI.Page
    {
        CategoryManager categoryManager = new CategoryManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text)|| !string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                categoryManager.Search(txtSearch.Text,SqlDataSourceCategories);
                txtSearch.Focus();
            }
            gvCategories.DataBind();
        }
    }
}