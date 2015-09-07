using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.DataAccess;
using BLToolkit.Mapping;

namespace IM.Models
{
    [TableName("donation_form_details")]
    public class DonationDetail
    {
        [PrimaryKey,NonUpdatable]
        [MapField("Id")]
        public int Id { get; set; }

        [MapField("donation_form_id")]
        public int DonationId { get; set; }

        [MapField("item_id")]
        public int ItemId { get; set; }

        [MapField("unit_id")]
        public int UnitId { get; set; }

        [MapField("quantity")]
        public int Quantity { get; set; }

        [MapField("price")]
        public decimal Price { get; set; }

        [MapField("barcode")]
        public string Barcode { get; set; }

        [MapField("uid")]
        public Guid Uid { get; set; }
    }
}
