using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("purchase_requests")]
    public class PurchaseRequest
    {
        [PrimaryKey,NonUpdatable]
        [MapField("id")]
        public int Id { get; set; }

        [MapField("pr_date")]
        public DateTime PurcahaseRequestDate { get; set; }

        [MapField("sai_number")]
        public string SaiNumber { get; set; }

        [MapField("alobs_number")]
        public string AlobsNmber { get; set; }

        [MapField("stock_number")]
        public string  StockNumber { get; set; }

        [MapField("item_code")]
        public string ItemCode { get; set; }

        [MapField("requested_by")]
        public string RequestBy { get; set; }

        [MapField("received_by")]
        public string ReceiveBy { get; set; }

        [MapField("based_dept_id")]
        public int BaseDepartmentId { get; set; }

        [MapField("pr_status")]
        public string Status { get; set; }

        [MapField("pr_id")]
        public string PrId { get; set; }

        [MapField("unit_code")]
        public string UnitCode { get; set; }

        [MapField("pr_quantity")]
        public int RequestQuantity { get; set; }

        [MapField("requisition_no")]
        public string  RequisitionNumber { get; set; }

        public Guid uid { get; set; }
    }
}
