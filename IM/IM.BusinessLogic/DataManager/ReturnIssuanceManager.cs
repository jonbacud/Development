using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ReturnIssuanceManager : IBaseManager<ReturnIssuance>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(ReturnIssuance returnIssuance)
        {
            if (returnIssuance.Id>0)
            {
                Accessor.Query.Update(returnIssuance);
            }
            else
            {
                Identity = Accessor.Query.InsertAndGetIdentity(returnIssuance);
            }
        }

        public void Save(List<ReturnIssuance> returnIssuances)
        {
            foreach (var returnIssuance in returnIssuances)
            {
                Save(returnIssuance);
            }
        }

        public void Delete(ReturnIssuance returnIssuance)
        {
            Accessor.Query.Delete(returnIssuance);
        }

        public void Delete(List<ReturnIssuance> returnIssuances)
        {
            foreach (var returnIssuance in returnIssuances)
            {
                Delete(returnIssuance);
            }
        }

        public List<ReturnIssuance> FetchAll()
        {
            return Accessor.Query.SelectAll<ReturnIssuance>() ?? new List<ReturnIssuance>();
        }

        public ReturnIssuance FetchById(int key)
        {
            return Accessor.Query.SelectByKey<ReturnIssuance>(key) ?? new ReturnIssuance();
        }

        #region Accessor
        ReturnIssuanceAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ReturnIssuanceAccessor.CreateInstance(); }
        }
        #endregion
    }
}
