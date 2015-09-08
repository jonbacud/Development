using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class EmergencyPurchaseAccessor : AccessorBase<EmergencyPurchaseAccessor.DB, EmergencyPurchaseAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        [SqlQuery(@"Select top 1 ep_id from emergency_purchases order by id desc")]
        public abstract string GetLastReferenceNumber();

    }
}
