﻿using System;
using System.Linq;
using System.Web.Configuration;
using System.Web.UI;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.Shared;

namespace Web.Dashboard
{
    public partial class ItemEntry : Page
    {
        readonly BarcodeManager _bManager = new BarcodeManager();
        readonly ItemManager _itemManager = new ItemManager();

        public int ItemId {
            get { return (Page.RouteData.Values["id"] == null) ? 0 : int.Parse(Page.RouteData.Values["id"].ToString()); }
        }

        public Item Item {
            get { return _itemManager.FetchById(ItemId); }
        }

        public Barcode Barcode
        {
            get
            {
                return _bManager.FetchAll().FirstOrDefault();
            }
        }

        public Transaction.TransactionMode Mode
        {
            get { return (Transaction.TransactionMode) int.Parse(Page.RouteData.Values["mode"].ToString()); }
        }

        public void InitializeDepartments()
        {
            var departmentManager = new DepartmentManager();
            DDLDepartments.DataSource = departmentManager.FetchAll();
            DDLDepartments.DataTextField = "Description";
            DDLDepartments.DataValueField = "Id";
            DDLDepartments.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeDepartments();
                
                switch (Mode)
                {
                    case Transaction.TransactionMode.UpdateEntry:
                        InitItemDetails();
                        btnDelete.Visible = true;
                        break;
                    case Transaction.TransactionMode.ViewDetail:
                        txtBarCode.ReadOnly = true;
                        txtItemCode.ReadOnly = true;
                        txtItemName.ReadOnly = true;
                        btnDelete.Visible = false;
                        InitItemDetails();
                        btnSave.Visible = false;
                        hpLinkBack.Visible = false;
                        break;
                    case  Transaction.TransactionMode.NewEntry:
                        if (Barcode != null)
                            txtBarCode.Text = (long.Parse(Barcode.Code) + 1).ToString();
                        break;
                }
                
            }
        }

        private void InitItemDetails()
        {
            txtBarCode.Text = Item.BarCode;
            txtItemCode.Text = Item.ItemCode;
            txtItemName.Text = Item.ItemName;
            txtLastPurchaseDate.Text = Item.LastPurchaseDate.ToString("MMM dd, yyyy");
            txtLastPurchasePrice.Text = Item.LastPurchasePrice.ToString("##0.00");
            txtLastSellingPrice.Text = Item.LastSellingPrice.ToString("##0.00");
            txtQuantity.Text = Item.ReOrderQuantity.ToString();
            txtReOrderLevel.Text = Item.ReOrderLevel.ToString();
            DDLDepartments.SelectedValue = Item.DepartmentId.ToString();
            DDLClassifications.SelectedValue = Item.ClassificationId.ToString();
            DDLTypes.SelectedValue = Item.TypeId.ToString();
            DDLUnits.SelectedValue = Item.UnitId.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            var newItem = new Item
            {
                ItemCode = txtItemCode.Text,
                BarCode = txtBarCode.Text,
                ItemName = txtItemName.Text,
                ClassificationId = int.Parse(DDLClassifications.SelectedValue),
                TypeId = int.Parse(DDLTypes.SelectedValue),
                UnitId = int.Parse(DDLUnits.SelectedValue),
                LastPurchaseDate = DateTime.Parse(txtLastPurchaseDate.Text),
                ReOrderQuantity = int.Parse(txtQuantity.Text),
                LastPurchasePrice = Decimal.Parse(txtLastPurchasePrice.Text),
                LastSellingPrice = Decimal.Parse(txtLastSellingPrice.Text),
                DateCreated = DateTime.Now,
                DepartmentId = int.Parse(DDLDepartments.SelectedValue),
                ReOrderLevel = int.Parse(txtReOrderLevel.Text),
                UniqueId = Guid.NewGuid(),
                Id = ItemId
            };
            _itemManager.Save(newItem);
            var bc = Barcode;
            bc.Code = txtBarCode.Text;
            _bManager.Save(bc);
            Response.Redirect("ItemManagementPanel.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            var itemToDelete = new Item
            {
                Id = ItemId
            };
            _itemManager.Delete(itemToDelete);
            Response.Redirect("ItemManagementPanel.aspx");
        }

    }
}