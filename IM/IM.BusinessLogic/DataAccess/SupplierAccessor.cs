using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class SupplierAccessor : AccessorBase<SupplierAccessor.DB, SupplierAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

    }
}
