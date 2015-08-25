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
    public partial class LocationEntry : System.Web.UI.Page
    {
        readonly LocationManager _locationManager = new LocationManager();

        public int LocationId
        {
            get { return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]); }
        }

        public Location Location
        {
            get { return _locationManager.FetchById(LocationId); }
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
            if (LocationId>0)
            {
                txtLocationCode.Text = Location.Code;
                txtLocationDescription.Text = Location.Description;
                DDLDepartments.SelectedValue = Location.DepartmentId.ToString();
                btnDelete.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var location = new Location
            {
                Code = txtLocationCode.Text,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                Description = txtLocationDescription.Text,
                UniqueId = Guid.NewGuid(),
                Id = LocationId
            };
            _locationManager.Save(location);
            Response.Redirect("LocationManagementPanel.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var locationToDelete = new Location
            {
                Id = LocationId
            };

            _locationManager.Delete(locationToDelete);
            Response.Redirect("LocationManagementPanel.aspx");
        }
    }
}