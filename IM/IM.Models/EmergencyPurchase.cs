using System;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("emergency_purchases")]
    public class EmergencyPurchase
    {
        [PrimaryKey,NonUpdatable]
        [MapField("id")]
        public int Id { get; set; }

        [MapField("ep_id")]
        public string EmergencyPurchaseId { get; set; }

        [MapField("ep_date")]
        public DateTime EmergencyPurchaseDate { get; set; }

        [MapField("item_code")]
        public string ItemCode { get; set; }

        [MapField("received_by")]
        public string ReceivedBy { get; set; }

        [MapField("unit_code")]
        public string UnitCode { get; set; }

        [MapField("ep_quantity")]
        public int TotalQuantity { get; set; }

        [MapField("ep_status")]
        public string Status { get; set; }

        [MapField("based_dept_id")]
        public int DepartmentId { get; set; }

        [MapField("requisition_no")]
        public string RequisitionNumber { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }
    }
}
