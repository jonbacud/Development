using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Dashboard.ModelViews
{
    public class PurchaseRequestItem
    {
        public string RequestNumber { get; set; }
        public int ItemNumber { get; set; }
        public string ItemName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int Quantity { get; set; }
        public string StockNumber { get; set; }
        public decimal UnitCost { get; set; }
        public decimal EstimatedCost { get; set; }
        public string SaiNumber { get; set; }
        public string AlobsNumber { get; set; }
        public int DepartmentId { get; set; }
        public string ItemCode { get; set; }
        public DateTime DateRequest { get; set; }
        public string ReceiveBy { get; set; }
        public string RequestBy { get; set; }
        public Guid Uid { get; set; }
        public string UnitCode { get; set; }
    }
}