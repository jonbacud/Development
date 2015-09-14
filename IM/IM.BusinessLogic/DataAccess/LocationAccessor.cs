using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class LocationAccessor : AccessorBase<LocationAccessor.DB, LocationAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

    }
}
