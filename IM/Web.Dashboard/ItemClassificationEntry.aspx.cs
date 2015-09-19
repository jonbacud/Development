using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.Shared;

namespace Web.Dashboard
{
    public partial class ItemClassificationEntry : System.Web.UI.Page
    {
        readonly ItemClassificationManager _itemClassificationManager = new ItemClassificationManager();

        public int ItemClassificationId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public ItemClassification ItemClassification
        {
            get { return _itemClassificationManager.FetchById(ItemClassificationId); }
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
            if (ItemClassificationId>0)
            {
                txtItemClassificationCode.Text = ItemClassification.Code;
                txtName.Text = ItemClassification.ClassificationName;
                DDLDepartments.SelectedValue = ItemClassification.DepartmentId.ToString();
                btnDelete.Visible = true;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var ic = new ItemClassification
            {
                ClassificationName = txtName.Text,
                Code = txtItemClassificationCode.Text.Trim(),
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                UniqueId = Guid.NewGuid(),
                Id = ItemClassificationId
            };
            _itemClassificationManager.Save(ic);
            Response.Redirect("/ItemClassificationPanel");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var itemClassificationToDelete = new ItemClassification
            {
               Id = ItemClassificationId
            };
            _itemClassificationManager.Delete(itemClassificationToDelete);
            Response.Redirect("/ItemClassificationPanel");
        }
    }
}