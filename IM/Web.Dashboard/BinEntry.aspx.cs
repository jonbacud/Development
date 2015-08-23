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
    public partial class BinEntry : System.Web.UI.Page
    {
        readonly BinManager _binManager = new BinManager();
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
            var bin = new Bin
            {
                BinCode = txtBinCode.Text,
                BinDescription = txtBinDescription.Text,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                Uid = Guid.NewGuid()
            };
            _binManager.Save(bin);
            Response.Redirect("BinManagementPanel.aspx");
        }
    }
}