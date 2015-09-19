using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using System.Web.UI.WebControls;
using BLToolkit.DataAccess;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class SupplierAccessor : AccessorBase<SupplierAccessor.DB, SupplierAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        [SqlQuery(@"Select top 1 supplier_code from ref_supplier order by supplier_id desc")]
        public abstract string GetLastReferenceNumber();
        public virtual void SearchSupplier(string searchParam, SqlDataSource datasource)
        {
            StringBuilder strCmd = new StringBuilder("SELECT * FROM [ref_supplier] ");
            if (!string.IsNullOrEmpty(searchParam))
            {
                strCmd.Append(" WHERE supplier_name like '%" + searchParam + "%'");
            }
            strCmd.Append(" order by supplier_id desc");
            datasource.SelectCommand = strCmd.ToString();
            datasource.DataBind();
        }
    }
}
