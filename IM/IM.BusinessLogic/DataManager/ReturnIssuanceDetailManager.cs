using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public  class ReturnIssuanceDetailManager :IBaseManager<ReturnIssuanceDetail>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(ReturnIssuanceDetail returnIssuanceDetail)
        {
            if (returnIssuanceDetail.Id>0)
            {
                Accessor.Query.Update(returnIssuanceDetail);
            }
            else
            {
                Accessor.Query.Insert(returnIssuanceDetail);
            }
        }

        public void Save(List<ReturnIssuanceDetail> returnIssuanceDetails)
        {
            foreach (var returnIssuanceDetail in returnIssuanceDetails)
            {
                Save(returnIssuanceDetail);
            }
        }

        public void Delete(ReturnIssuanceDetail returnIssuanceDetail)
        {
            Accessor.Query.Delete(returnIssuanceDetail);
        }

        public void Delete(List<ReturnIssuanceDetail> returnIssuanceDetails)
        {
            foreach (var returnIssuanceDetail in returnIssuanceDetails)
            {
                Delete(returnIssuanceDetail);
            }
        }

        public List<ReturnIssuanceDetail> FetchAll()
        {
            return Accessor.Query.SelectAll<ReturnIssuanceDetail>() ?? new List<ReturnIssuanceDetail>();
        }

        public ReturnIssuanceDetail FetchById(int key)
        {
            return Accessor.Query.SelectByKey<ReturnIssuanceDetail>(key) ?? new ReturnIssuanceDetail();
        }

        #region Accessor
        ReturnIssuanceDetailAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ReturnIssuanceDetailAccessor.CreateInstance(); }
        }
        #endregion
    }
}
