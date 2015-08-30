using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class ReceivingManager :IBaseManager<Receiving>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(Receiving receiving)
        {
            if (receiving.Id>0)
            {
                Accessor.Query.Update(receiving);
            }
            else
            {
                Identity = Accessor.Query.InsertAndGetIdentity(receiving);
            }
        }

        public void Save(List<Receiving> receivings)
        {
            foreach (var receiving in receivings)
            {
                Save(receiving);
            }
        }

        public void Delete(Receiving receiving)
        {
            Accessor.Query.Delete(receiving);
        }

        public void Delete(List<Receiving> receivings)
        {
            foreach (var receiving in receivings)
            {
                Delete(receiving);
            }
        }

        public List<Receiving> FetchAll()
        {
            return Accessor.Query.SelectAll<Receiving>() ?? new List<Receiving>();
        }

        public Receiving FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Receiving>(key) ?? new Receiving();
        }

        public Receiving FetchById(Guid key)
        {
            return Accessor.Query.SelectAll<Receiving>().FirstOrDefault(r => r.Uid.Equals(key)) ?? new Receiving();
        }

        #region Accessor
        ReceivingDataAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return ReceivingDataAccessor.CreateInstance(); }
        }
        #endregion
    }
}
