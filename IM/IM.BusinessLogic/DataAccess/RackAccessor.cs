using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataAccess
{
    public class RackAccessor : AccessorBase<RackAccessor.DB, RackAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }
    }
}
