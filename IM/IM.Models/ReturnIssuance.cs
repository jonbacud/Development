using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("trn_return_issuance_header")]
    public class ReturnIssuance
    {
        [PrimaryKey,NonUpdatable]
        [MapField("return_iss_id")]
        public int Id { get; set; }

        [MapField("ris_id")]
        public int ReturnIssuanceId { get; set; }

        [MapField("issuance_id")]
        public int IssuanceId { get; set; }

        [MapField("reference_number")]
        public string IssuanceNumber { get; set; }

        [MapField("return_date")]
        public DateTime ReturnDate { get; set; }

        [MapField("issued_to")]
        public string IssuedTo { get; set; }

        [MapField("total_amount")]
        public decimal TotalAmount { get; set; }

        [MapField("remarks")]
        public string Remarks { get; set; }

        [MapField("status")]
        public int Status { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("uid")]
        public Guid Unid { get; set; }
    }
}
