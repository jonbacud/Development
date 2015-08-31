using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("trn_issuance_header")]
    public class Issuance
    {
        [PrimaryKey,NonUpdatable]
        [MapField("issuance_id")]
        public int Id { get; set; }

        [MapField("reference_number")]
        public string ReferenceNumber { get; set; }

        [MapField("issuance_date")]
        public DateTime IssuanceDate { get; set; }

        [MapField("issued_to")]
        public string IssuedTo { get; set; }

        [MapField("total_amount")]
        public decimal TotalAmount { get; set; }

        [MapField("ris_id")]
        public int RequisitionId { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("isPosted")]
        public bool IsPosted { get; set; }

        [MapField("datecreated")]
        public DateTime DateCreated { get; set; }

        [MapField("uid")]
        public Guid Unid { get; set; }

        [MapField("ris_reference_number")]
        public string RequisitionReferenceNumber { get; set; } // added for relationsip

    }
}
