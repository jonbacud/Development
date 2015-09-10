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
using Microsoft.Reporting.WebForms;


namespace Web.Dashboard.WRIreports
{
    public partial class recevingreport : System.Web.UI.Page
    {
        readonly ReceivingManager _receivingManager = new ReceivingManager();
        private readonly ItemClassificationManager _itemClassificationManager = new ItemClassificationManager();
        private readonly ReceivingManager _receivingmanger = new ReceivingManager();
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
            _receivingmanger.ReceivingReport(txtdatefrom.Text, txtdateto.Text, 0, txtItemDesc.Text, 0, "", txtbarcode.Text, sqldatasourceRcvRpt);
            sqldatasourceRcvRpt.DataBind();
            string datefrom;
            string lgPath = System.Configuration.ConfigurationManager.AppSettings["ReportHeader"].ToString();
            string paths = System.Configuration.ConfigurationManager.AppSettings["ReportLogo"].ToString();
            datefrom = txtdatefrom.Text + " - " + txtdateto.Text;


            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("/WRIreports/rpt/receiving.rdlc");

            ReportDataSource datasource = new ReportDataSource("DataSet1", sqldatasourceRcvRpt);

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);


            Microsoft.Reporting.WebForms.ReportParameter[] ParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];

            ParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter();
            ParameterCollection[0].Name = "headertext";
            ParameterCollection[0].Values.Add(lgPath);

            
            this.ReportViewer1.LocalReport.EnableExternalImages = true;
            ParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter();
            ParameterCollection[1].Name = "imgpath";
            ParameterCollection[1].Values.Add(paths);

            ParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter();
            ParameterCollection[2].Name = "dateparam";
            ParameterCollection[2].Values.Add(datefrom);

            ReportViewer1.LocalReport.SetParameters(ParameterCollection);
            ReportViewer1.LocalReport.Refresh();

        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {

            loadInformation();
        }
    }
}