using IM.BusinessLogic.DataManager;
using IM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web.Dashboard
{
    public partial class SupplierEntry : System.Web.UI.Page
    {
        readonly SupplierManager _supplierManager = new SupplierManager();
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
            var newSupplier = new Supplier
            {
                Address = txtSupplierAddress.Text.Trim(),
                Code = txtSupplierCode.Text.Trim(),
                 ContactPerson= txtContactPerson.Text,
                  DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                   EmailAddress= txtEmailAddress.Text,
                    FaxNumber = txtFaxNumber.Text,
                    IsConsignment = chkIsConsignment.Checked,
                    Name = txtSupplierName.Text,
                     TelephoneNumber = txtTelephoneNumber.Text,
                      UniqueId = Guid.NewGuid()
            };
            _supplierManager.Save(newSupplier);
            Response.Redirect("SupplierManagementPanel.aspx");
        }
    }
}