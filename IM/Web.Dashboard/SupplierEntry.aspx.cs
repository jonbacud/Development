using IM.BusinessLogic.DataManager;
using IM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Web.Dashboard.Shared;

namespace Web.Dashboard
{
    public partial class SupplierEntry : System.Web.UI.Page
    {
        readonly SupplierManager _supplierManager = new SupplierManager();
        public int SupplierId
        {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
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

            switch (Mode)
            {
                case Transaction.TransactionMode.UpdateEntry:
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
                    break;
                case Transaction.TransactionMode.NewEntry:
                    txtSupplierCode.Text = Transaction.TransactionType.SUPP + "-Auto";
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var code = Supplier.Code;
            if (Mode ==Transaction.TransactionMode.NewEntry)
            {
                code = Transaction.TransactionType.SUPP+"-"+_supplierManager.ReferenceNumber+1;
            }
            var newSupplier = new Supplier
            {
                Address = txtSupplierAddress.Text.Trim(),
                Code = code,
                ContactPerson = txtContactPerson.Text,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                EmailAddress = txtEmailAddress.Text,
                FaxNumber = txtFaxNumber.Text,
                IsConsignment = chkIsConsignment.Checked,
                Name = txtSupplierName.Text,
                TelephoneNumber = txtTelephoneNumber.Text,
                UniqueId = Guid.NewGuid(),
                Id = SupplierId
            };
            _supplierManager.Save(newSupplier);
            Response.Redirect("/SupplierManagementPanel");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var suplierToDelete = new Supplier
            {
                Id = SupplierId
            };
            _supplierManager.Delete(suplierToDelete);
            Response.Redirect("/SupplierManagementPanel");

        }
    }
}