using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
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

        public void Save(Barcode barcode)
        {
            using (DbManager db = new DbManager() )
            {
                if (barcode.Id>0)
                {
                    Accessor.Query.Update(db, barcode);
                }
                else
                {
                    Accessor.Query.Insert(db, barcode);
                }
            }
        }

        public void Save(List<Barcode> barcodes)
        {
            foreach (var barcode in barcodes)
            {
                Save(barcode);
            }
        }

        public void Delete(Barcode barcode)
        {
            using (DbManager db = new DbManager())
            {
                Accessor.Query.Delete(db, barcode);
            }
        }

        public void Delete(List<Barcode> barcodes)
        {
            foreach (var barcode in barcodes)
            {
                Delete(barcode);
            }
        }

        public List<Barcode> FetchAll()
        {
            return Accessor.Query.SelectAll<Barcode>() ?? new List<Barcode>();
        }

        public Barcode FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Barcode>(key) ?? new Barcode();
        }
    }
}
