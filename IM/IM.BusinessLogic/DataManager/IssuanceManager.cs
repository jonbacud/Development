using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class IssuanceManager :IBaseManager<Issuance>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(Issuance issuance)
        {
            using (var db = new DbManager())
            {
                if (issuance.Id>0)
                {
                    Accessor.Query.Update(issuance);
                }
                else
                {
                    Identity = Accessor.Query.InsertAndGetIdentity(issuance);
                }
            }
        }

        public void Save(List<Issuance> issuances)
        {
            foreach (var issuance in issuances)
            {
                Save(issuance);
            }
        }

        public void Delete(Issuance issuance)
        {
            Accessor.Query.Delete(issuance);
        }

        public void Delete(List<Issuance> collection)
        {
            throw new NotImplementedException();
        }

        public List<Issuance> FetchAll()
        {
            return Accessor.Query.SelectAll<Issuance>() ?? new List<Issuance>();
        }

        public Issuance FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Issuance>(key) ?? new Issuance();
        }

        #region Accessor
        IssuanceAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return IssuanceAccessor.CreateInstance(); }
        }
        #endregion
    }
}
