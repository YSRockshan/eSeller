using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using BzFlexer.SAMS.Data.Reference;
using CrystalDecisions.CrystalReports.Engine;
using BzFlexer.SAMS.Biz.Reference;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = new List<Biz_Branch>()
            {new Biz_Branch(){
                Id=1,Code="123",Description="ff"
            },new Biz_Branch(){
                Id=2,Code="55",Description="kug"
            } };
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("CrystalReport2.rpt"));
            CrystalReportViewer1.ReportSource = data;
        }
    }



}