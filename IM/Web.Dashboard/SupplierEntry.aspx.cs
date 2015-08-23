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
        public int SupplierId {
            get { return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]); }
        }

        public Supplier Supplier
        {
            get { return _supplierManager.FetchById(SupplierId); }
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
            
            if (SupplierId>0)
            {
                txtContactPerson.Text = Supplier.ContactPerson;
                txtEmailAddress.Text = Supplier.EmailAddress;
                txtFaxNumber.Text = Supplier.FaxNumber;
                txtSupplierAddress.Text = Supplier.Address;
                txtSupplierCode.Text = Supplier.Code;
                txtSupplierName.Text = Supplier.Name;
                txtTelephoneNumber.Text = Supplier.TelephoneNumber;
                btnDelete.Visible = true;
                DDLDepartments.SelectedValue = Supplier.DepartmentId.ToString();
                chkIsConsignment.Checked = Supplier.IsConsignment;
            }
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
                UniqueId = Guid.NewGuid(),
                Id = SupplierId
            };
            _supplierManager.Save(newSupplier);
            Response.Redirect("SupplierManagementPanel.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var suplierToDelete = new Supplier
            {
                 Id = SupplierId
            };
            _supplierManager.Delete(suplierToDelete);
            Response.Redirect("SupplierManagementPanel.aspx");

        }
    }
}