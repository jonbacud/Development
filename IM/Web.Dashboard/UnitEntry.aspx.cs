﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using IM.BusinessLogic.DataManager;
using IM.Models;

namespace Web.Dashboard
{
    public partial class UnitEntry : System.Web.UI.Page
    {
        readonly UnitManager _unitManager = new UnitManager();
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
            var unit = new Unit
            {
               Code = txtUnitCode.Text,
               DepartmentId = int.Parse(DDLDepartments.SelectedValue),
               Description = txtUnitDescription.Text,
               UniqueId = Guid.NewGuid()
            };
            _unitManager.Save(unit);
            Response.Redirect("UnitManagementPanel.aspx");
        }
    }
}