using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLToolkit.Data;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class IssuanceDetailManager:IBaseManager<IssuanceDetail>
    {

        public int Identity
        {
            get; set;
        }

        public void Save(IssuanceDetail issuanceDetail)
        {
            using (DbManager db = new DbManager())
            {
                if (issuanceDetail.Id>0)
                {
                    Accessor.Query.Update(db, issuanceDetail);
                }
                else
                {
                    Identity = Accessor.Query.InsertAndGetIdentity(db, issuanceDetail);
                }
            }
        }

        public void Save(List<IssuanceDetail> issuanceDetails)
        {
            foreach (var issuanceDetail in issuanceDetails)
            {
                Save(issuanceDetail);
            }
        }

        public void Delete(IssuanceDetail model)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<IssuanceDetail> collection)
        {
            throw new NotImplementedException();
        }

        public List<IssuanceDetail> FetchAll()
        {
            return Accessor.Query.SelectAll<IssuanceDetail>() ?? new List<IssuanceDetail>();
        }

        public IssuanceDetail FetchById(int key)
        {
            return Accessor.Query.SelectByKey<IssuanceDetail>(key) ?? new IssuanceDetail();
        }

        #region Accessor
        IssuanceDetailAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return IssuanceDetailAccessor.CreateInstance(); }
        }
        #endregion
    }
}
