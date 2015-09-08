using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class EmergencyPurchaseDetailManager:IBaseManager<EmergencyPurchaseDetail>
    {
        #region Accessor
        EmergencyPurchaseDetailAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return EmergencyPurchaseDetailAccessor.CreateInstance(); }
        }
        #endregion

        public int Identity
        {
            get; set;
        }

        public void Save(EmergencyPurchaseDetail emergencyPurchaseDetail)
        {
            if (emergencyPurchaseDetail.Id>0)
            {
                Accessor.Query.Update(emergencyPurchaseDetail);
            }
            else
            {
                Accessor.Query.Insert(emergencyPurchaseDetail);
            }
        }

        public void Save(List<EmergencyPurchaseDetail> emergencyPurchaseDetails)
        {
            foreach (var emergencyPurchaseDetail in emergencyPurchaseDetails)
            {
                Save(emergencyPurchaseDetail);
            }
        }

        public void Delete(EmergencyPurchaseDetail emergencyPurchaseDetail)
        {
            Accessor.Query.Delete(emergencyPurchaseDetail);
        }

        public void Delete(List<EmergencyPurchaseDetail> emergencyPurchaseDetails)
        {
            foreach (var emergencyPurchaseDetail in emergencyPurchaseDetails)
            {
                Delete(emergencyPurchaseDetail);
            }
        }

        public List<EmergencyPurchaseDetail> FetchAll()
        {
            return Accessor.Query.SelectAll<EmergencyPurchaseDetail>() ?? new List<EmergencyPurchaseDetail>();
        }

        public List<EmergencyPurchaseDetail> FetchAll(int emergencyPurchaseId)
        {
            return Accessor.Query.SelectAll<EmergencyPurchaseDetail>()
                .Where(epd => epd.EmergencyPurchaseId.Equals(emergencyPurchaseId))
                .ToList();
        }

        public EmergencyPurchaseDetail FetchById(int key)
        {
            return Accessor.Query.SelectByKey<EmergencyPurchaseDetail>(key) ?? new EmergencyPurchaseDetail();
        }
    }
}
