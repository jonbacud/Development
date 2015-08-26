using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ReturnReceivingDetailManager:IBaseManager<ReturnReceivingDetail>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(ReturnReceivingDetail returnReceivingDetail)
        {
            if (returnReceivingDetail.Id>0)
            {
                Accessor.Query.Update(returnReceivingDetail);
            }
            else
            {
                Accessor.Query.Insert(returnReceivingDetail);
            }
        }

        public void Save(List<ReturnReceivingDetail> returnReceivingDetails)
        {
            foreach (var returnReceivingDetail in returnReceivingDetails)
            {
                Save(returnReceivingDetail);
            }
        }

        public void Delete(ReturnReceivingDetail returnReceivingDetail)
        {
            Accessor.Query.Delete(returnReceivingDetail);
        }

        public void Delete(List<ReturnReceivingDetail> returnReceivingDetails)
        {
            foreach (var returnReceivingDetail in returnReceivingDetails)
            {
                Delete(returnReceivingDetail);
            }
        }

        public List<ReturnReceivingDetail> FetchAll()
        {
            return Accessor.Query.SelectAll<ReturnReceivingDetail>() ?? new List<ReturnReceivingDetail>();
        }

        public ReturnReceivingDetail FetchById(int key)
        {
            return Accessor.Query.SelectByKey<ReturnReceivingDetail>(key) ?? new ReturnReceivingDetail();
        }

        #region Accessor
        ReturnReceivingDetailAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ReturnReceivingDetailAccessor.CreateInstance(); }
        }
        #endregion
    }
}
