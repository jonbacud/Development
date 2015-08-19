using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using BLToolkit.Data;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class DepartmentManager: IBaseManager<Department>
    {

        public int Identity
        {
            get; set;
        }

        public void Save(Department department)
        {
            using (var db = new DbManager())
            {
                if (department.Id>0)
                {
                    Accessor.Query.Update(db, department);
                }
                else
                {
                    Accessor.Query.Insert(db, department);
                }
            }
        }

        public void Save(List<Department> departments)
        {
            foreach (var department in departments)
            {
                Save(department);
            }
        }

        public void Delete(Department department)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, department);
            }
        }

        public void Delete(List<Department> departments)
        {
            foreach (var department in departments)
            {
                Delete(department);
            }
        }

        public List<Department> FetchAll()
        {
            return  Accessor.Query.SelectAll<Department>().OrderBy(d => d.Description).ToList() ??
                   new List<Department>();
        }

        public Department FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Department>(key) ?? new Department();
        }

        public string LastDepartmentCodeString(string type)
        {
            var result = string.Empty;
            var firstOrDefault = FetchAll().OrderByDescending(d=>d.Code).FirstOrDefault(d => d.Type.Equals(type));
            if (firstOrDefault != null)
            {
                var lastCode = firstOrDefault.Code.Split('-')[1];
                result = lastCode;
            }
            return result;
        }

        public void Search(string searchParam, SqlDataSource datasource)
        {
            Accessor.SearchDepartment(searchParam,datasource);
        }

        #region Accessor
        DepartmentAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return DepartmentAccessor.CreateInstance(); }
        }
        #endregion
    }
}
