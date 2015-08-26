using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("ref_item")]
    public class Item
    {
        [PrimaryKey,NonUpdatable]
        [MapField("item_id")]
        public int Id { get; set; }

        [MapField("item_code")]
        public string ItemCode { get; set; }

        [MapField("barcode")]
        public string BarCode { get; set; }

        [MapField("item_name")]
        public string ItemName { get; set; }

        [MapField("item_class_id")]
        public int ClassificationId { get; set; }

        [MapField("item_type_id")]
        public int TypeId { get; set; }

        [MapField("unit_id")]
        public int UnitId { get; set; }

        [MapField("last_purchased_date")]
        public DateTime LastPurchaseDate { get; set; }

        [MapField("last_purchase_price")]
        public decimal LastPurchasePrice { get; set; }

        [MapField("last_selling_price")]
        public decimal LastSellingPrice { get; set; }

        [MapField("reorder_qty")]
        public int ReOrderQuantity { get; set; }

        [MapField("reorder_level")]
        public int ReOrderLevel { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("datecreated")]
        public DateTime DateCreated { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }

    }
}
