using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Dashboard.ModelViews
{
    public class ReceivingItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Barcode { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int ReceivedQuantity { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal SellingPrice { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int RackId { get; set; }
        public string RackName { get; set; }
        public int BinId { get; set; }
        public string BinName { get; set; }
        public int ShelveId { get; set; }
        public string ShelveName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Remarks { get; set; }
        public string ReceivingRemarks { get; set; }
        public Guid Uid { get; set; }
        public string ReferenceNumber { get; set; }
    }
}