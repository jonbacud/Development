using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using IM.BusinessLogic.DataManager;
using IM.Models;

namespace Web.Dashboard
{
    public partial class UnitEntry : System.Web.UI.Page
    {
        readonly UnitManager _unitManager = new UnitManager();
        public int UnitId {
            get { return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]); }
        }

        public Unit Unit
        {
            get { return _unitManager.FetchById(UnitId); }
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
            if (UnitId>0)
            {
                txtUnitCode.Text = Unit.Code;
                txtUnitDescription.Text = Unit.Description;
                DDLDepartments.SelectedValue = Unit.DepartmentId.ToString();
                btnDelete.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var unit = new Unit
            {
               Code = txtUnitCode.Text,
               DepartmentId = int.Parse(DDLDepartments.SelectedValue),
               Description = txtUnitDescription.Text,
               UniqueId = Guid.NewGuid(),
               Id = UnitId
            };
            _unitManager.Save(unit);
            Response.Redirect("UnitManagementPanel.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var unitToDelete = new Unit
            {
                Id = UnitId
            };
            _unitManager.Delete(unitToDelete);
            Response.Redirect("UnitManagementPanel.aspx");
        }
    }
}