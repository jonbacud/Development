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
    public partial class NewDepartmentEntry : System.Web.UI.Page
    {
        readonly DepartmentManager _departmentManager = new DepartmentManager();
      
        public int DepartmentId
        {
            get
            {
                return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]);
            }
        }
        public string DepartmentType {
            get
            {
                return (rdioRetail.Checked) ? "RETAIL" : "WHOLESALE";
            }
         }

        public int Tmode
        {
            get
            {
                return (Request.QueryString["mode"] == null) ? 0 : int.Parse(Request.QueryString["mode"]);
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
                txtDepartmentCode.Text = Department.Type;
            }
        }

        protected void rdioWholesale_CheckedChanged(object sender, EventArgs e)
        {
           SetLastCodeCounter();
        }
    }
}