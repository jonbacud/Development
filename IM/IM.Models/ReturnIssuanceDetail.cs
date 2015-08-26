using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("trn_return_issuance_detail")]
    public  class ReturnIssuanceDetail
    {
        [PrimaryKey,NonUpdatable]
        [MapField("return_iss_detail_id")]
        public int Id { get; set; }

        [MapField("return_iss_id")]
        public int ReturnIssuanceId { get; set; }

        [MapField("item_id")]
        public int ItemId { get; set; }

        [MapField("barcode")]
        public string Barcode { get; set; }

        [MapField("return_qty")]
        public int ReturnQuantity { get; set; }

        [MapField("unit_id")]
        public int UnitId { get; set; }

        [MapField("price")]
        public decimal Price { get; set; }
    }
}
