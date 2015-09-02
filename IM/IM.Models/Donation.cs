using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{

    [TableName("donation_forms")]
    public class Donation
    {
        [PrimaryKey,NonUpdatable]
        [MapField("id")]
        public int Id { get; set; }

        [MapField("df_id")]
        public string DonationId { get; set; }

        [MapField("df_date")]
        public DateTime DonationDate { get; set; }

        [MapField("item_code")]
        public string ItemCode { get; set; }

        [MapField("donated_by")]
        public string DonatedBy { get; set; }

        [MapField("donated_to")]
        public string DonatedTo { get; set; }

        [MapField("received_by")]
        public string ReceivedBy { get; set; }

        [MapField("unit_code")]
        public string UnitCode { get; set; }

        [MapField("df_quantity")]
        public int TotalQuantity { get; set; }

        [MapField("df_status")]
        public string Status { get; set; }

        [MapField("based_dept_id")]
        public int DepartmentId { get; set; }

        [MapField("requisition_no")]
        public string RequisitionNumber { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }
    }
}
