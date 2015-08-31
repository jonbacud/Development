using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Dashboard.ModelViews
{
    public class RequestItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int ClassificationId { get; set; }
        public string ClassificationName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string Barcode { get; set; }
        public string ItemCode { get; set; }
        public string ReferenceNumber { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid Uid { get; set; }
        public int  RequestTo { get; set; }
        public int Quantity { get; set; }
        public int RequesitionId { get; set; }
        public decimal ItemPrice { get; set; }
        public int ReceivedQuantity { get; set; }
        public int IssuedQuantity { get; set; }
    }
}