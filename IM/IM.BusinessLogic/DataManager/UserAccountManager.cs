using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.BusinessLogic.DataAccess;
using IM.Models;
using IM.BusinessLogic.common;
namespace IM.BusinessLogic.DataManager
{
    public class UserAccountManager:IBaseManager<UserAccount>
    {
        SecurityBO pwdProtect = new SecurityBO();
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

        public UserAccount FetchByUserNameAndPassword(string userName, string password)
        {
            string pwdencrypt = pwdProtect.EncrypText(password);
            return  Accessor.Query.SelectAll<UserAccount>()
                .FirstOrDefault(ua => ua.UserName.Equals(userName) && ua.Password.Equals(pwdencrypt) && ua.IsActive.Equals(true));
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
