﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class DepartmentAccessor : AccessorBase<DepartmentAccessor.DB, DepartmentAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        public void SearchDepartment(string searcParam)
        {
            
        }
    }
}
