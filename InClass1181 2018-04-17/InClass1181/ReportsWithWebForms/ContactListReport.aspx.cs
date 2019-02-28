using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ReportsWithWebForms
{
    public partial class ContactListReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://142.55.32.96/reportserver");
            ReportViewer1.ServerReport.ReportPath = "/Winter2018/AmandeepPatti/CustomerContactList";
        }
    }
}