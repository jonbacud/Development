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
    public partial class NewDepartmentEntry : System.Web.UI.Page
    {
        readonly DepartmentManager _departmentManager = new DepartmentManager();
      
        public int DepartmentId
        {
                 get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode)int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public string DepartmentType {
            get
            {
                return (rdioRetail.Checked) ? "RETAIL" : "WHOLESALE";
            }
         }

        public Department Department
        {
            get
            {
                return _departmentManager.FetchById(DepartmentId);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (DepartmentId>0)
            {
                txtDepartmentCode.Text = Department.Code;
                txtDescription.Text = Department.Description;
                rdioRetail.Checked = (Department.Type.Equals("RETAIL"));
                rdioWholesale.Checked = !rdioRetail.Checked;
                btnDelete.Visible = true;
            }
            else
            {
                SetLastCodeCounter();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newDepartment = new Department
            {
                Code = txtDepartmentCode.Text,
                Description = txtDescription.Text.Trim(),
                Type = DepartmentType,
                UId = Guid.NewGuid(),
                Id = DepartmentId
            };
            _departmentManager.Save(newDepartment);
            Response.Redirect("DepartmentManagementPanel.aspx");
        }

        protected void rdioRetail_CheckedChanged(object sender, EventArgs e)
        {
            SetLastCodeCounter();
        }

        private void SetLastCodeCounter()
        {
            if (Department.Type != DepartmentType)
            {
                var lastCounter = _departmentManager.LastDepartmentCodeString(DepartmentType);
                txtDepartmentCode.Text = DepartmentType + "-" + (int.Parse(lastCounter) + 1);
            }
            else
            {
                txtDepartmentCode.Text = Department.Code;
            }
        }

        protected void rdioWholesale_CheckedChanged(object sender, EventArgs e)
        {
           SetLastCodeCounter();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var departmentToDelete = new Department
            {
                Id = DepartmentId
            }; 
            _departmentManager.Delete(departmentToDelete);
            Response.Redirect("DepartmentManagementPanel.aspx");

        }
    }
}