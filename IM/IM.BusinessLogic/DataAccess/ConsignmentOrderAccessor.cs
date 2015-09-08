using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class ConsignmentOrderAccessor : AccessorBase<ConsignmentOrderAccessor.DB, ConsignmentOrderAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        [SqlQuery(@"Select top 1 co_id from consignment_orders order by id desc")]
        public abstract string GetLastReferenceNumber();
    }
}
