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
    public partial class ItemClassificationEntry : System.Web.UI.Page
    {
        readonly ItemClassificationManager _itemClassificationManager = new ItemClassificationManager();
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
            var ic = new ItemClassification
            {
                ClassificationName = txtName.Text,
                Code = txtItemClassificationCode.Text,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                UniqueId = Guid.NewGuid()
            };
            _itemClassificationManager.Save(ic);
        }
    }
}