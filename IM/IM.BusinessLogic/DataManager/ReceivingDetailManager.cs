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
            if (receivingDetail.Id>0)
            {
                Accessor.Query.Update(receivingDetail);
            }
            else
            {
                Accessor.Query.Insert(receivingDetail);
            }
        }

        public void Save(List<ReceivingDetail> receivingDetails)
        {
            foreach (var receivingDetail in receivingDetails)
            {
                Save(receivingDetail);
            }
        }

        public void Delete(ReceivingDetail receivingDetail)
        {
            Accessor.Query.Delete(receivingDetail);
        }

        public void Delete(List<ReceivingDetail> receivingDetails)
        {
            foreach (var receivingDetail in receivingDetails)
            {
                Delete(receivingDetail);
            }
        }

        public List<ReceivingDetail> FetchAll()
        {
            return Accessor.Query.SelectAll<ReceivingDetail>() ?? new List<ReceivingDetail>();
        }

        public List<ReceivingDetail> FetchAllByReceivingId(int receivingId)
        {
            return Accessor.Query.SelectAll<ReceivingDetail>()
                .Where(rd => rd.ReceivingId.Equals(receivingId))
                .ToList();
        }

        public ReceivingDetail FetchById(int key)
        {
            return Accessor.Query.SelectByKey<ReceivingDetail>(key) ?? new ReceivingDetail();
        }

        public ReceivingDetail FetchById(Guid key)
        {
            return Accessor.Query.SelectAll<ReceivingDetail>().FirstOrDefault(rd => rd.Uid.Equals(key));
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
