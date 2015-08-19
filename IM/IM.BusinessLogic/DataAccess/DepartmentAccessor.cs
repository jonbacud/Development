using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class DepartmentAccessor : AccessorBase<DepartmentAccessor.DB, DepartmentAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        public virtual void SearchDepartment(string searchParam, SqlDataSource datasource)
        {
            StringBuilder strCmd =new StringBuilder("SELECT * FROM [ref_department] ");
            if (!string.IsNullOrEmpty(searchParam))
            {
                strCmd.Append(" WHERE department_desc like '%"+searchParam+"%'");
            }
            strCmd.Append(" order by department_id desc");
            datasource.SelectCommand = strCmd.ToString();
            datasource.DataBind();
        }
    }
}
