using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("consignment_order_details")]
    public class ConsignmentOrderDetail
    {
        [PrimaryKey,NonUpdatable]
        public int Id { get; set; }

        [MapField("consignment_id")]
        public int ConsignmentId { get; set; }

        [MapField("unit_id")]
        public int UnitId { get; set; }

        [MapField("quantity")]
        public int Quantity { get; set; }

        [MapField("price")]
        public decimal Price { get; set; }

        [MapField("item_id")]
        public int ItemId { get; set; }

        [MapField("barcode")]
        public string Barcode { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }
    }
}
