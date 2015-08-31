using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class RequisitionAccessor : AccessorBase<RequisitionAccessor.DB, RequisitionAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        [SqlQuery(@"Select top 1 reference_number from trn_requisition order by ris_id desc")]
        public abstract string GetLastReferenceNumber();
    }
}
