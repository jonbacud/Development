using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("trn_return_receiving_detail")]
    public class ReturnReceivingDetail
    {
        [PrimaryKey,NonUpdatable]
        [MapField("return_r_detail_id")]
        public int Id { get; set; }

        [MapField("return_r_header_id")]
        public int ReturnReceivingId { get; set; }

        [MapField("barcode")]
        public string Barcode { get; set; }

        [MapField("item_id")]
        public int ItemId { get; set; }

        [MapField("qty")]
        public int Quantity { get; set; }

        [MapField("unit_code")]
        public string UnitCode { get; set; }

        [MapField("price")]
        public decimal Price { get; set; }

        [MapField("amount")]
        public decimal  Amount { get; set; }

        [MapField("location_id")]
        public int LocationId { get; set; }

        [MapField("rack_id")]
        public int RackId { get; set; }

        [MapField("shelve_id")]
        public int ShelfId { get; set; }

        [MapField("bin_id")]
        public int BinId { get; set; }

        [MapField("remarks")]
        public string Remarks { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("status")]
        public bool Status { get; set; }

        [MapField("datecreated")]
        public DateTime DateCreated { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }
    }
}
