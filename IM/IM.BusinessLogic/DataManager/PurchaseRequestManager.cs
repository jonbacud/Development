using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class PurchaseRequestManager:IBaseManager<PurchaseRequest>
    {

        public int Identity
        {
            get; set;
        }

        public void Save(PurchaseRequest purchaseRequest)
        {
            if (purchaseRequest.Id>0)
            {
                Accessor.Query.Update(purchaseRequest);
            }
            else
            {
                Accessor.Query.Insert(purchaseRequest);
            }
        }

        public void Save(List<PurchaseRequest> purchaseRequests)
        {
            foreach (var purchaseRequest in purchaseRequests)
            {
                Save(purchaseRequest);
            }
        }

        public void Delete(PurchaseRequest purchaseRequest)
        {
            Accessor.Query.Delete(purchaseRequest);
        }

        public void Delete(List<PurchaseRequest> purchaseRequests)
        {
            foreach (var purchaseRequest in purchaseRequests)
            {
                Delete(purchaseRequest);
            }
        }

        public List<PurchaseRequest> FetchAll()
        {
            return Accessor.Query.SelectAll<PurchaseRequest>() ?? new List<PurchaseRequest>();
        }

        public PurchaseRequest FetchById(int key)
        {
            return Accessor.Query.SelectByKey<PurchaseRequest>(key) ?? new PurchaseRequest();
        }

        private string LastReferenceNumber
        {
            get { return Accessor.GetLastReferenceNumber(); }
        }

        public int ReferenceNumber
        {
            get { return string.IsNullOrEmpty(LastReferenceNumber) ? 10000 : int.Parse(LastReferenceNumber.Split('-')[1]); }
        }

        #region Accessor
        PurchaseRequestAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return PurchaseRequestAccessor.CreateInstance(); }
        }
        #endregion
    }
}
