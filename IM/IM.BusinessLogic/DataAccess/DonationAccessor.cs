﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using BLToolkit.DataAccess;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class DonationAccessor : AccessorBase<DonationAccessor.DB, DonationAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        [SqlQuery(@"Select top 1 df_id from donation_forms order by id desc")]
        public abstract string GetLastReferenceNumber();
    }
}
