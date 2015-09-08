using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ConsignmentOrderDetailManager:IBaseManager<ConsignmentOrderDetail>
    {
        #region Accessor
        ConsignmentOrderDetailAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ConsignmentOrderDetailAccessor.CreateInstance(); }
        }
        #endregion

        public int Identity
        {
            get; set;
        }

        public void Save(ConsignmentOrderDetail consignmentOrderDetail)
        {
            if (consignmentOrderDetail.Id>0)
            {
                Accessor.Query.Update(consignmentOrderDetail);
            }
            else
            {
                Accessor.Query.Insert(consignmentOrderDetail);
            }
        }

        public void Save(List<ConsignmentOrderDetail> consignmentOrderDetails)
        {
            foreach (var consignmentOrderDetail in consignmentOrderDetails)
            {
                Save(consignmentOrderDetail);
            }
        }

        public void Delete(ConsignmentOrderDetail consignmentOrder)
        {
            Accessor.Query.Delete(consignmentOrder);
        }

        public void Delete(List<ConsignmentOrderDetail> consignmentOrderDetails)
        {
            foreach (var consignmentOrderDetail in consignmentOrderDetails)
            {
                Delete(consignmentOrderDetail);
            }
        }

        public List<ConsignmentOrderDetail> FetchAll()
        {
            return Accessor.Query.SelectAll<ConsignmentOrderDetail>() ?? new List<ConsignmentOrderDetail>();
        }

        public List<ConsignmentOrderDetail> FetchAll(int consignmentOrderId)
        {
            return Accessor.Query.SelectAll<ConsignmentOrderDetail>()
                .Where(cod => cod.ConsignmentId.Equals(consignmentOrderId))
                .ToList();
        }

        public ConsignmentOrderDetail FetchById(int key)
        {
            return Accessor.Query.SelectByKey<ConsignmentOrderDetail>(key) ?? new ConsignmentOrderDetail();
        }
    }
}
