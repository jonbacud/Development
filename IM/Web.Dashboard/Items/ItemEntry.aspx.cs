using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;
using IM.Models;

namespace Web.Dashboard.Items
{
    public partial class ItemEntry : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            ItemManager itemManager = new ItemManager();

            Item newItem = new Item
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
                UniqueId = Guid.NewGuid()
            };
            itemManager.Save(newItem);
        }
    }
}