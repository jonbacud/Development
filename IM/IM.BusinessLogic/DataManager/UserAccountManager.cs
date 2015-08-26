using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;

namespace IM.BusinessLogic.DataManager
{
    public class UserAccountManager:IBaseManager<UserAccount>
    {
        public int Identity
        {
            get; set;
        }

        public void Save(UserAccount userAccount)
        {
            if (userAccount.UserId>0)
            {
                Accessor.Query.Update(userAccount);
            }
            else
            {
                Accessor.Query.Insert(userAccount);
            }
        }

        public void Save(List<UserAccount> userAccounts)
        {
            foreach (var userAccount in userAccounts)
            {
                Save(userAccount);
            }
        }

        public void Delete(UserAccount userAccount)
        {
            Accessor.Query.Delete(userAccount);
        }

        public void Delete(List<UserAccount> userAccounts)
        {
            foreach (var userAccount in userAccounts)
            {
                Delete(userAccount);
            }
        }

        public List<UserAccount> FetchAll()
        {
            return Accessor.Query.SelectAll<UserAccount>() ?? new List<UserAccount>();
        }

        public UserAccount FetchById(int key)
        {
            return Accessor.Query.SelectByKey<UserAccount>(key) ?? new UserAccount();
        }

        #region Accessor
        UserAccountAccessor Accessor
        {
            [System.Diagnostics.DebuggerStepThrough]
            get { return UserAccountAccessor.CreateInstance(); }
        }
        #endregion
    }
}
