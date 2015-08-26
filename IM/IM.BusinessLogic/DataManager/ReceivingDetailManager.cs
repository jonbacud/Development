using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ReceivingDetailManager: IBaseManager<ReceivingDetail>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(ReceivingDetail receivingDetail)
        {
            throw new NotImplementedException();
        }

        public void Save(List<ReceivingDetail> receivingDetails)
        {
            throw new NotImplementedException();
        }

        public void Delete(ReceivingDetail receivingDetail)
        {
            throw new NotImplementedException();
        }

        public void Delete(List<ReceivingDetail> receivingDetails)
        {
            throw new NotImplementedException();
        }

        public List<ReceivingDetail> FetchAll()
        {
            throw new NotImplementedException();
        }

        public ReceivingDetail FetchById(int key)
        {
            throw new NotImplementedException();
        }
        #region Accessor
        ReceivingDetailAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ReceivingDetailAccessor.CreateInstance(); }
        }
        #endregion
    }
}
