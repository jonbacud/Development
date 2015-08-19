using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;

namespace Web.Dashboard
{
    public partial class PrintDepartments : System.Web.UI.Page
    {
        DepartmentManager _dManager = new DepartmentManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gvDepartments.DataSource = _dManager.FetchAll();
                gvDepartments.DataBind();
            }
        }
    }
}