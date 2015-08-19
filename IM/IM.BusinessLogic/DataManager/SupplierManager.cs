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
    public class SupplierManager:IBaseManager<Supplier>
    {

        public int Identity
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Save(Supplier model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Supplier> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(Supplier model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<Supplier> collection)
        {
            throw new NotImplementedException();
        }

        public List<Supplier> FetchAll()
        {
            throw new NotImplementedException();
        }

        public Supplier FetchById(int key)
        {
            throw new NotImplementedException();
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
