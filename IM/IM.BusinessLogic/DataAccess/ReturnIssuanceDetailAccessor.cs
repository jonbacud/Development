using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class ReturnIssuanceDetailAccessor : AccessorBase<ReturnIssuanceDetailAccessor.DB, ReturnIssuanceDetailAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }
    }
}
