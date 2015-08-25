using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("trn_receiving_detail")]
    public class ReceivingDetail
    {
        [PrimaryKey,NonUpdatable]
        [MapField("receiving_detail_id")]
        public int Id { get; set; }

        [MapField("receiving_id")]
        public int ReceivingId { get; set; }

        [MapField("reference_no")]
        public string ReferenceNumber { get; set; }

        [MapField("item_id")]
        public int ItemId { get; set; }

        [MapField("barcode")]
        public string Barcode { get; set; }

        [MapField("expirydate")]
        public DateTime ExpiryDate { get; set; }

        [MapField("recvdQTY")]
        public int ReceiveQuantity { get; set; }

        [MapField("unit_id")]
        public int UnitId { get; set; }

        [MapField("price")]
        public decimal Price { get; set; }

        [MapField("Total_amount")]
        public decimal TotalAmount { get; set; }

        [MapField("selling_price")]
        public decimal SellingPrice { get; set; }

        [MapField("location_id")]
        public int LocationId { get; set; }

        [MapField("rack_id")]
        public int RackId { get; set; }

        [MapField("bin_id")]
        public int BinId { get; set; }

        [MapField("shelve_id")]
        public int Shelfid { get; set; }

        [MapField("supplier_id")]
        public int SupplierId { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("remarks")]
        public string Remarks { get; set; }

        [MapField("datecreated")]
        public DateTime DateCreated { get; set; }

        [MapField("receiving_remarks")]
        public string ReceivingReamrks { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }
    }
}
