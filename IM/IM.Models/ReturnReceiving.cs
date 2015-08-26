using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("trn_return_receiving_header")]
    public class ReturnReceiving
    {
        [PrimaryKey,NonUpdatable]
        [MapField("returnreceived_id")]
        public int Id { get; set; }

        [MapField("reference_no")]
        public string  ReferenceNumber { get; set; }

        [MapField("receiving_id")]
        public int ReceivingId { get; set; }

        [MapField("return_date")]
        public DateTime ReturnDate { get; set; }

        [MapField("po_number")]
        public string PurchaseOrderNumber { get; set; }

        [MapField("invoice_number")]
        public string InvoiceNumber { get; set; }

        [MapField("pr_number")]
        public string PrNumber { get; set; }

        [MapField("supplier_id")]
        public int SupplierId { get; set; }

        [MapField("return_total")]
        public decimal ReturnTotal { get; set; }

        [MapField("dep_id")]
        public int DepartmentId { get; set; }

        [MapField("status")]
        public bool Status { get; set; }

        [MapField("dateCreated")]
        public DateTime DateCreated { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }
    }
}
