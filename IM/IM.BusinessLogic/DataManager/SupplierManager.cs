using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;
using System.Web.UI.WebControls;
using BLToolkit.Data;

namespace IM.BusinessLogic.DataManager
{
    public class SupplierManager:IBaseManager<Supplier>
    {

        public int Identity
        {
            get; set;
        }

        public void Save(Supplier supplier)
        {
            using (var db = new  DbManager())
            {
                if (supplier.Id>0)
                {
                    Accessor.Query.Update(db, supplier);
                }
                else
                {
                    Accessor.Query.Insert(db, supplier);
                }
            }
        }

        public void Save(List<Supplier> suppliers)
        {
            foreach (var supplier in suppliers)
            {
                Save(supplier);
            }
        }

        public void Delete(Supplier supplier)
        {
            using (var db = new DbManager())
            {
                Accessor.Query.Delete(db,supplier);
            }
        }

        public void Delete(List<Supplier> suppliers)
        {
            foreach (var supplier in suppliers)
            {
                Delete(supplier);
            }
        }

        public List<Supplier> FetchAll()
        {
            return Accessor.Query.SelectAll<Supplier>()
                .OrderBy(s=>s.Name)
                .ToList();
        }

        public List<Supplier> FetchAll(int departmentId)
        {
            return Accessor.Query.SelectAll<Supplier>().Where(s=>s.DepartmentId.Equals(departmentId)).ToList();
        }

        public Supplier FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Supplier>(key) ?? new Supplier();
        }

        public void Search(string searchParam, SqlDataSource datasource)
        {
            Accessor.SearchSupplier(searchParam, datasource);
        }

        #region Accessor
        SupplierAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return SupplierAccessor.CreateInstance(); }
        }
        #endregion
    }
}
