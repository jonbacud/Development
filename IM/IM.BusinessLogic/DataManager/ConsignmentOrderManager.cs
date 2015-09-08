using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ConsignmentOrderManager:IBaseManager<ConsignmentOrder>
    {
        #region Accessor
        ConsignmentOrderAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ConsignmentOrderAccessor.CreateInstance(); }
        }
        #endregion

        public int Identity
        {
            get; set;
        }

        public void Save(ConsignmentOrder consignmentOrder)
        {
            if (consignmentOrder.Id>0)
            {
                Accessor.Query.Update(consignmentOrder);
            }
            else
            {
               Identity=Accessor.Query.InsertAndGetIdentity(consignmentOrder);
            }
        }

        public void Save(List<ConsignmentOrder> consignmentOrders)
        {
            foreach (var consignmentOrder in consignmentOrders)
            {
                Save(consignmentOrder);
            }
        }

        public void Delete(ConsignmentOrder consignmentOrder)
        {
            Accessor.Query.Delete(consignmentOrder);
        }

        public void Delete(List<ConsignmentOrder> consignmentOrders)
        {
            foreach (var consignmentOrder in consignmentOrders)
            {
                Delete(consignmentOrder);
            }
        }

        public List<ConsignmentOrder> FetchAll()
        {
            return Accessor.Query.SelectAll<ConsignmentOrder>() ?? new List<ConsignmentOrder>();
        }

        public ConsignmentOrder FetchById(int key)
        {
            return Accessor.Query.SelectByKey<ConsignmentOrder>(key) ?? new ConsignmentOrder();
        }
    }
}
