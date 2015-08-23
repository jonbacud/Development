using IM.BusinessLogic.DataManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Dashboard
{
    public partial class SupplierManagementPanel : System.Web.UI.Page
    {
        readonly SupplierManager _dSupplier = new SupplierManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void SearchSupplier()
        {
            _dSupplier.Search(txtSearch.Text, SqlDataSourceDepartments);
            txtSearch.Focus();
        }

        protected void gvSuppliers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SearchSupplier();
        }
    }
}