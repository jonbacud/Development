using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class PurchaseRequestAccessor : AccessorBase<PurchaseRequestAccessor.DB, PurchaseRequestAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        [SqlQuery(@"Select top 1 pr_id from purchase_requests order by id desc")]
        public abstract string GetLastReferenceNumber();
    }
}
