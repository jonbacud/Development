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
    public partial class RackEntry : System.Web.UI.Page
    {
        readonly RackManager _rackManager = new RackManager();
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
            var rack = new Rack
            {
                Code = txtRackCode.Text,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                Description = txtRackDescription.Text,
                UniqueId = Guid.NewGuid()
            };
            _rackManager.Save(rack);
            Response.Redirect("RackManagementPanel.aspx");
        }
    }
}