using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataAccess
{
    public abstract class CategoryAccessor : AccessorBase<CategoryAccessor.DB, CategoryAccessor>
    {
        public class DB : DbManager { public DB() : base("IMConnectionString") { } }

        public virtual void SearchCategory(string searchParameter, SqlDataSource datasource)
        {
            var strCmd = new StringBuilder("SELECT ref_category.category_id,ref_category.category_code,ref_category.category_desc,ref_department.department_desc FROM [ref_category] inner join ref_department on ref_category.dep_id = ref_department.department_id ");
            if (!string.IsNullOrEmpty(searchParameter))
            {
                strCmd.Append(" WHERE category_desc like '%"+searchParameter+"%'");
            }
            strCmd.Append(" order by category_id desc");
            datasource.SelectCommand = strCmd.ToString();
            datasource.DataBind();
        }
    }
}
