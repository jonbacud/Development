using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class DonationManager: IBaseManager<Donation>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(Donation donation)
        {
            if (donation.Id>0)
            {
                Accessor.Query.Update(donation);
            }
            else
            {
                Identity = Accessor.Query.InsertAndGetIdentity(donation);
            }
        }

        public void Save(List<Donation> donations)
        {
            foreach (var donation in donations)
            {
                Save(donation);
            }
        }

        public void Delete(Donation donation)
        {
            Accessor.Query.Delete(donation);
        }

        public void Delete(List<Donation> donations)
        {
            foreach (var donation in donations)
            {
                Delete(donation);
            }
        }

        public List<Donation> FetchAll()
        {
            return Accessor.Query.SelectAll<Donation>() ?? new List<Donation>();
        }

        public Donation FetchById(int key)
        {
            return Accessor.Query.SelectByKey<Donation>(key);
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
        DonationAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return DonationAccessor.CreateInstance(); }
        }
        #endregion
    }
}
