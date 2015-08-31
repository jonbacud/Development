using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class IssuanceAccessor : AccessorBase<IssuanceAccessor.DB, IssuanceAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        [SqlQuery(@"Select top 1 reference_number from trn_issuance_header order by issuance_id desc")]
        public abstract string GetLastReferenceNumber();
    }
}
