using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class EmergencyPurchaseManager:IBaseManager<EmergencyPurchase>
    {
        private string LastReferenceNumber
        {
            get { return Accessor.GetLastReferenceNumber(); }
        }

        public int ReferenceNumber
        {
            get { return string.IsNullOrEmpty(LastReferenceNumber) ? 10000 : int.Parse(LastReferenceNumber.Split('-')[1]); }
        }

        #region Accessor
        EmergencyPurchaseAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return EmergencyPurchaseAccessor.CreateInstance(); }
        }
        #endregion

        public int Identity
        {
            get; set;
        }

        public void Save(EmergencyPurchase emergencyPurchase)
        {
            if (emergencyPurchase.Id>0)
            {
                Accessor.Query.Update(emergencyPurchase);
            }
            else
            {
                Identity = Accessor.Query.InsertAndGetIdentity(emergencyPurchase);
            }
        }

        public void Save(List<EmergencyPurchase> emergencyPurchases)
        {
            foreach (var emergencyPurchase in emergencyPurchases)
            {
                Save(emergencyPurchase);
            }
        }

        public void Delete(EmergencyPurchase emergencyPurchase)
        {
            Accessor.Query.Delete(emergencyPurchase);
        }

        public void Delete(List<EmergencyPurchase> emergencyPurchases)
        {
            foreach (var emergencyPurchase in emergencyPurchases)
            {
                Delete(emergencyPurchase);
            }
        }

        public List<EmergencyPurchase> FetchAll()
        {
            return Accessor.Query.SelectAll<EmergencyPurchase>() ?? new List<EmergencyPurchase>();
        }

        public EmergencyPurchase FetchById(int key)
        {
            return Accessor.Query.SelectByKey<EmergencyPurchase>(key) ?? new EmergencyPurchase();
        }
    }
}
