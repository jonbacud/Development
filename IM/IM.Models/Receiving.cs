using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("trn_receivingHeader")]
    public  class Receiving
    {
        [PrimaryKey,NonUpdatable]
        [MapField("receiving_id")]
        public int Id { get; set; }

        [MapField("reference_no")]
        public string ReferenceNumber { get; set; }

        [MapField("po_number")]
        public string PurchaseOrderNumber { get; set; }

        [MapField("invoice_no")]
        public string  InvoiceNumber { get; set; }

        [MapField("pr_number")]
        public string PrNumber { get; set; }

        [MapField("receiving_date")]
        public DateTime ReceivingDate { get; set; }

        [MapField("supplier_id")]
        public int SupplierId { get; set; }

        [MapField("category_id")]
        public int CategoryId { get; set; }

        [MapField("enduserid")]
        public int EndUserId { get; set; }

        [MapField("alobs_number")]
        public string AloBsNumber { get; set; }

        [MapField("mode_procurement")]
        public string ModeProcurement { get; set; }

        [MapField("amount")]
        public decimal Amount { get; set; }

        [MapField("status")]
        public bool Status { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("selling_amount")]
        public decimal SellingAmount { get; set; }

        [MapField("receiving_key")]
        public Guid ReceivingKey  { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }
    }
}
