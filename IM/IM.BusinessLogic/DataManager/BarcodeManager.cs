using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class BarcodeManager : IBaseManager<Barcode>
    {
        #region Accessor
        BarcodeAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return BarcodeAccessor.CreateInstance(); }
        }
        #endregion

        public int Identity
        {
            get; set;
        }

        public void Save(Barcode model)
        {
            throw new NotImplementedException();
        }

        public void Save(List<Barcode> collection)
        {
            throw new NotImplementedException();
        }

        public void Delete(Barcode model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<Barcode> collection)
        {
            throw new NotImplementedException();
        }

        public List<Barcode> FetchAll()
        {
            return Accessor.Query.SelectAll<Barcode>() ?? new List<Barcode>();
        }

        public Barcode FetchById(int key)
        {
            throw new NotImplementedException();
        }
    }
}
