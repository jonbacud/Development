using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Dashboard.Shared
{
    public static class Transaction
    {
        public enum TransactionMode
        {
            NewEntry = 1,
            UpdateEntry = 0,
            ViewDetail = 2
        }
    }
}