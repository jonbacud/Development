using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class RequisitionManager :IBaseManager<Requisition>
    {

        public int Identity { get; set; }

        public void Save(Requisition requisition)
        {
            using (var db = new DbManager())
            {
                if (requisition.Id>0)
                {
                    Accessor.Query.Update(db, requisition);
                }
                else
                {
                   Identity=Accessor.Query.InsertAndGetIdentity(db, requisition);
                }
            }
        }

        public void Save(List<Requisition> requisitions)
        {
            foreach (var requisition in requisitions)
            {
                Save(requisition);
            }
        }

        public void Delete(Requisition requisition)
        {
            Accessor.Query.Delete(requisition);
        }

        public void Delete(List<Requisition> requisitions)
        {
            foreach (var requisition in requisitions)
            {
                Delete(requisition);
            }
        }

        public List<Requisition> FetchAll()
        {
            return Accessor.Query.SelectAll<Requisition>() ?? new List<Requisition>();
        }

        public Requisition FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Requisition>(key);
        }

        #region Accessor
        RequisitionAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return RequisitionAccessor.CreateInstance(); }
        }
        #endregion
    }
}
