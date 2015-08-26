using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ReturnReceivingManager:IBaseManager<ReturnReceiving>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(ReturnReceiving returnReceiving)
        {
            if (returnReceiving.Id>0)
            {
                Accessor.Query.Update(returnReceiving);
            }
            else
            {
                Identity = Accessor.Query.InsertAndGetIdentity(returnReceiving);
            }
        }

        public void Save(List<ReturnReceiving> returnReceivings)
        {
            foreach (var returnReceiving in returnReceivings)
            {
                Save(returnReceiving);
            }
        }

        public void Delete(ReturnReceiving returnReceiving)
        {
            Accessor.Query.Delete(returnReceiving);
        }

        public void Delete(List<ReturnReceiving> returnReceivings)
        {
            foreach (var returnReceiving in returnReceivings)
            {
                Delete(returnReceiving);
            }
        }

        public List<ReturnReceiving> FetchAll()
        {
            return Accessor.Query.SelectAll<ReturnReceiving>() ?? new List<ReturnReceiving>();
        }

        public ReturnReceiving FetchById(int key)
        {
            return Accessor.Query.SelectByKey<ReturnReceiving>(key) ?? new ReturnReceiving();
        }

        #region Accessor
        ReturnReceivingAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ReturnReceivingAccessor.CreateInstance(); }
        }
        #endregion
    }
}
