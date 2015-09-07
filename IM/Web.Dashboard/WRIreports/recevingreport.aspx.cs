using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit.HtmlEditor.ToolbarButtons;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;


namespace Web.Dashboard.WRIreports
{
    public partial class recevingreport : System.Web.UI.Page
    {
        readonly ReceivingManager _receivingManager = new ReceivingManager();
        private readonly ItemClassificationManager _itemClassificationManager = new ItemClassificationManager();
        UserAccountManager _userAccountManager = new UserAccountManager();

        public UserAccount Uaccount
        {
            get
            {
                return (UserAccount)Session["USER_ACCOUNT"];
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadddropdown();
            }
        }

        private void loadddropdown()
        {
            DDLClassifications.DataSource = _itemClassificationManager.FetchAll(Uaccount.DeaprtmentId);
            DDLClassifications.DataTextField = "ClassificationName";
            DDLClassifications.DataValueField = "Id";
            DDLClassifications.DataBind();

            
        }
        private void loadInformation()
        { 
        
        }
    }
}