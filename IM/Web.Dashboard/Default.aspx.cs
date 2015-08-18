using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
namespace Web.Dashboard
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DepartmentManager dm = new DepartmentManager();
                //gvDepartments.DataSource = dm.FetchAll();
                //gvDepartments.DataBind();

            }
        }
    }
}