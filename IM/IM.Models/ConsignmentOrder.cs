using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data.Linq;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("consignment_orders")]
    public class ConsignmentOrder
    {
        [PrimaryKey,NonUpdatable]
        [MapField("id")]
        public int Id { get; set; }

        [MapField("co_date")]
        public DateTime ConsignmentDate { get; set; }

        [MapField("company_name")]
        public string CompanyName { get; set; }

        [MapField("company_address")]
        public string CompanyAddress { get; set; }

        [MapField("deliver_to")]
        public string DeliverTo { get; set; }

        [MapField("prepared_by")]
        public string PreparedBy { get; set; }

        [MapField("item_code")]
        public string ItemCode { get; set; }

        [MapField("unit_code")]
        public string UnitCode { get; set; }

        [MapField("co_quantity")]
        public int TotalQuantity { get; set; }

        [MapField("co_id")]
        public string ConsignmentId { get; set; }

        [MapField("based_dept_id")]
        public int DepartmentId { get; set; }

        [MapField("co_status")]
        public string  ConsignmentStatus { get; set; }

        [MapField("days_deliver")]
        public int DaysDeliver { get; set; }

        [MapField("requisition_no")]
        public string RequisitionNumber { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }

        [MapField("supplier_id")]
        public int SupplierId { get; set; }
    }
}
