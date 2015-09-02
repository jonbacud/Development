using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IM.BusinessLogic.DataManager;

namespace Web.Dashboard
{
    public partial class Login : System.Web.UI.Page
    {
        UserAccountManager _userAccountManager = new UserAccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            var userAccount = _userAccountManager.FetchByUserNameAndPassword(txtUserName.Text, txtPassword.Text);
            if (userAccount == null) return;
            if (userAccount.UserId <= 0) return;
            Session["USER_ACCOUNT"] = userAccount;
            Response.Redirect("/Default");
        }
    }
}