using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using IM.BusinessLogic.DataManager;
using IM.Models;
using Web.Dashboard.ModelViews;



namespace Web.Dashboard.WRIreports
{
    public partial class recevingreport : System.Web.UI.Page
    {
        readonly ReceivingManager _receiving = new ReceivingManager();
        readonly ReceivingDetailManager _rdetail = new ReceivingDetailManager();

        public List<ReceivingItem> ReceivedItems()
        {
            var items = new List<ReceivingItem>();
            if (Session["RECEIVING_ITEMS"] != null)
            {
                items = (List<ReceivingItem>)Session["RECEIVING_ITEMS"];
            }
            else
            {
                Session["RECEIVING_ITEMS"] = items;
            }
            return items;
        } 

        

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                loadReport();
            }
        }
        private void loadReport()
        {




            DataTable dt = new DataTable();
            DateTime dtoday = new DateTime();
            string headerText = System.Configuration.ConfigurationManager.AppSettings["HeaderText"].ToString();
            string rptlogo = System.Configuration.ConfigurationManager.AppSettings["RptLogo"].ToString();

            ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local;
            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("rpt/receiving.rdlc");
            ReportDataSource datasource = new ReportDataSource("DataSet1", _receiving.FetchAll());

            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(datasource);

            Microsoft.Reporting.WebForms.ReportParameter[] ParameterCollection = new Microsoft.Reporting.WebForms.ReportParameter[3];
            ParameterCollection[0] = new Microsoft.Reporting.WebForms.ReportParameter();
            ParameterCollection[0].Name = "dateparam";
            ParameterCollection[0].Values.Add(dtoday.ToShortDateString());

            this.ReportViewer1.LocalReport.EnableExternalImages = true;
            string paths = @"file:\" + Server.MapPath(rptlogo);
            ParameterCollection[1] = new Microsoft.Reporting.WebForms.ReportParameter();
            ParameterCollection[1].Name = "imgpath";
            ParameterCollection[1].Values.Add(paths);

            ParameterCollection[2] = new Microsoft.Reporting.WebForms.ReportParameter();
            ParameterCollection[2].Name = "headertext";
            ParameterCollection[2].Values.Add(headerText);


            ReportViewer1.LocalReport.SetParameters(ParameterCollection);
            ReportViewer1.LocalReport.Refresh();
        
        }
    }
}