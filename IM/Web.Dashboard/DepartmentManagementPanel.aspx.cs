using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;

namespace Web.Dashboard
{
    public partial class DepartmentManagementPanel : System.Web.UI.Page
    {
        readonly DepartmentManager _dManager = new DepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchDepartment();
        }

        private void SearchDepartment()
        {
            _dManager.Search(txtSearch.Text, SqlDataSourceDepartments);
            txtSearch.Focus();
        }

        protected void gvDepartments_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SearchDepartment();
        }
    }
}