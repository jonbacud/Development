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

        public int RackId
        {
            get { return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]); }
        }

        public Rack Rack
        {
            get { return _rackManager.FetchById(RackId); }
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

            if (RackId>0)
            {
                txtRackCode.Text = Rack.Code;
                txtRackDescription.Text = Rack.Description;
                DDLDepartments.SelectedValue = Rack.DepartmentId.ToString();
                btnDelete.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var rack = new Rack
            {
                Code = txtRackCode.Text,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                Description = txtRackDescription.Text,
                UniqueId = Guid.NewGuid(),
                Id = RackId
            };
            _rackManager.Save(rack);
            Response.Redirect("RackManagementPanel.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var rackToDelete = new Rack
            {
                Id = RackId
            };
            _rackManager.Delete(rackToDelete);
            Response.Redirect("RackManagementPanel.aspx");
        }
    }
}