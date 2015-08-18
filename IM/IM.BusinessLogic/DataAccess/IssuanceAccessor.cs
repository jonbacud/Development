using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class IssuanceAccessor : AccessorBase<IssuanceAccessor.DB, IssuanceAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }
    }
}
