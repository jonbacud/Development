using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Dashboard.ModelViews
{
    public class PurchaseRequestItem
    {
        public int ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }

    }
}