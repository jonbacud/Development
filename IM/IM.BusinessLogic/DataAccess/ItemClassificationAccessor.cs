using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class ItemClassificationAccessor : AccessorBase<ItemClassificationAccessor.DB, ItemClassificationAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        [SqlQuery(@"Select top 1 classification_code from ref_item_classifcation order by classifcation_id desc")]
        public abstract string GetLastReferenceNumber();
    }
}
