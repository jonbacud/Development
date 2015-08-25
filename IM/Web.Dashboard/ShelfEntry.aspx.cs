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
    public partial class ShelfEntry : System.Web.UI.Page
    {
        readonly ShelveManager _shelveManager = new ShelveManager();

        public int ShelfId
        {
            get { return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]); }
        }

        public Shelve Shelf
        {
            get { return _shelveManager.FetchById(ShelfId); }
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
            if (ShelfId>0)
            {
                txtShelfCode.Text = Shelf.Code;
                txtShelfDescription.Text = Shelf.Description;
                DDLDepartments.SelectedValue = Shelf.DepartmentId.ToString();
                btnDelete.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var shelf = new Shelve
            {
                Code = txtShelfCode.Text,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                Description = txtShelfDescription.Text,
                UniqueId = Guid.NewGuid(),
                Id = ShelfId
            };
            _shelveManager.Save(shelf);
            Response.Redirect("ShelveManagementPanel.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var shelfToDelete = new Shelve
            {
                Id = ShelfId
            };
            _shelveManager.Delete(shelfToDelete);
            Response.Redirect("ShelveManagementPanel.aspx");
        }
    }
}