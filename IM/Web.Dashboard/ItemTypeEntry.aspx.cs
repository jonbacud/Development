﻿using System;
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
    public partial class ItemTypeEntry : Page
    {
        private readonly ItemTypeManager _itemTypeManager = new ItemTypeManager();

        public int ItemTypeId
        {
            get { return (Request.QueryString["id"] == null) ? 0 : int.Parse(Request.QueryString["id"]); }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode) int.Parse(Request.QueryString["mode"]); }
        }

        public ItemType ItemType
        {
            get { return _itemTypeManager.FetchById(ItemTypeId); }
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
                    txtItemTypeCode.Text = ItemType.ItemTypeCode;
                    txtItemTypeDescription.Text = ItemType.ItemDesciption;
                    DDLDepartments.SelectedValue = ItemType.DepartmentId.ToString();
                    btnDelete.Visible = true;
                    break;
                case Transaction.TransactionMode.ViewDetail:
                    btnDelete.Visible = false;
                    btnSave.Visible = false;
                    break;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var newItemType = new ItemType
            {
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                ItemDesciption = txtItemTypeDescription.Text,
                ItemTypeCode = txtItemTypeCode.Text,
                UniqueId = Guid.NewGuid(),
                Id = ItemTypeId
            };
            _itemTypeManager.Save(newItemType);
            Response.Redirect("ItemTypeManagementPanel.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var itemTypeToDelete = new ItemType
            {
                Id = ItemTypeId
            };
            _itemTypeManager.Delete(itemTypeToDelete);
            Response.Redirect("ItemTypeManagementPanel.aspx");
        }
    }
}