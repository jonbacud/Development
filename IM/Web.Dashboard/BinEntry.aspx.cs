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
    public partial class BinEntry : Page
    {
        readonly BinManager _binManager = new BinManager();

        public int BinId
        {
            get { return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]); }
        }

        public Bin Bin
        {
            get { return _binManager.FetchById(BinId); }
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

            if (BinId>0)
            {
                txtBinCode.Text = Bin.BinCode;
                txtBinDescription.Text = Bin.BinDescription;
                DDLDepartments.SelectedValue = Bin.DepartmentId.ToString();
                btnDelete.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var bin = new Bin
            {
                BinCode = txtBinCode.Text,
                BinDescription = txtBinDescription.Text,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                Uid = Guid.NewGuid(),
                Id = BinId
            };
            _binManager.Save(bin);
            Response.Redirect("BinManagementPanel.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var binToDelete = new Bin
            {
                Id = BinId
            };
            _binManager.Delete(binToDelete);
            Response.Redirect("BinManagementPanel.aspx");

        }
    }
}