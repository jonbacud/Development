using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Dashboard.ModelViews
{
    public class DonationDetailItem
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Barcode { get; set; }
        public Guid Uid { get; set; }
    }
}