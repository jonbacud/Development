using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("trn_issuance_detail")]
    public class IssuanceDetail
    {
        [PrimaryKey,NonUpdatable]
        [MapField("issuance_detail_id")]
        public int Id { get; set; }

        [MapField("issuance_id")]
        public int IssuanceId { get; set; }

        [MapField("item_id")]
        public int ItemId { get; set; }

        [MapField("barcode")]
        public string Barcode { get; set; }

        [MapField("qty")]
        public int Quantity { get; set; }

        [MapField("price")]
        public decimal Price { get; set; }

        [MapField("unit_id")]
        public int UnitId { get; set; }

        [MapField("isPosted")]
        public bool IsPosted { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }

        [MapField("ris_id")]
        public int RequisitionId { get; set; }
    }
}
