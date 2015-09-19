using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class ItemTypeAccessor : AccessorBase<ItemTypeAccessor.DB, ItemTypeAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        [SqlQuery(@"Select top 1 item_type_code from ref_item_type order by itemtype_id desc")]
        public abstract string GetLastReferenceNumber();
    }
}
