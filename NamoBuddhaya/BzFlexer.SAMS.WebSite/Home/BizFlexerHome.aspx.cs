using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.Home
{
    public partial class BizFlexerHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void buttonReferenceData_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Reference/BzFlexerHome.aspx");
        }

        public void buttonSecurity_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Security/BzFlexerHome.aspx");
        }

        public void buttonSalesAgent_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AgentManagement/BzFlexerHome.aspx");
        }

        public void buttonReport_Click(object sender, EventArgs e)
        {
          
            Response.Redirect("~/ReportCenter/BzFlexerHome.aspx");
        }
    }
}