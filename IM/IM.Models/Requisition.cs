using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("trn_requisition")]
    public class Requisition
    {
        [PrimaryKey,NonUpdatable]
        [MapField("ris_id")]
        public int Id { get; set; }

        [MapField("reference_number")]
        public string ReferenceNumber { get; set; }

        [MapField("item_id")]
        public int ItemId { get; set; }

        [MapField("barcode")]
        public string BarCode { get; set; }

        [MapField("qty_issued")]
        public int QuantityIssued { get; set; }

        [MapField("qty_received")]
        public int QuantityReceived { get; set; }

        [MapField("submitted_to")]
        public string SubmittedTo { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("item_class_id")]
        public int ItemClassificationId { get; set; }

        [MapField("unit_id")]
        public int UnitId { get; set; }

        [MapField("status")]
        public string Status { get; set; }

        [MapField("requisition_date")]
        public DateTime RequisitionDate { get; set; }

        [MapField("datecreated")]
        public DateTime DateCreated { get; set; }

        [MapField("uid")]
        public Guid UniqueId { get; set; }
    }
}
