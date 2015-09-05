using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class DonationDetailsManager : IBaseManager<DonationDetail>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(DonationDetail donationDetail)
        {
            if (donationDetail.Id>0)
            {
                Accessor.Query.Update(donationDetail);
            }
            else
            {
                Accessor.Query.Insert(donationDetail);
            }
        }

        public void Save(List<DonationDetail> donationDetails)
        {
            foreach (var donationDetail in donationDetails)
            {
                Save(donationDetail);
            }
        }

        public void Delete(DonationDetail donationDetail)
        {
            Accessor.Query.Delete(donationDetail);
        }

        public void Delete(List<DonationDetail> donationDetails)
        {
            foreach (var donationDetail in donationDetails)
            {
                Delete(donationDetail);
            }
        }

        public List<DonationDetail> FetchAll()
        {
            return Accessor.Query.SelectAll<DonationDetail>() ?? new List<DonationDetail>();
        }

        public DonationDetail FetchById(int key)
        {
            return Accessor.Query.SelectByKey<DonationDetail>(key) ?? new DonationDetail();
        }

        #region Accessor
        DonationDetailAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return DonationDetailAccessor.CreateInstance(); }
        }
        #endregion
    }
}
