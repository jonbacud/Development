using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Dashboard
{
    public partial class ItemClassificationPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void chkALL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkALL.Checked)
            {
                DDLDepartments.Enabled = false;
                gvDepartments.DataSourceID = "SqlDataSourceAll";
            }
            else
            {
                DDLDepartments.Enabled = true;
                gvDepartments.DataSourceID = "SqlDataSourceItemClassifications";
            }
            gvDepartments.DataBind();
        }
    }
}