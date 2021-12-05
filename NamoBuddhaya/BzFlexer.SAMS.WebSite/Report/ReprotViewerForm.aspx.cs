using BzFlexer.SAMS.WebView.Home;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace BzFlexer.SAMS.WebSite.Report
{
    public partial class ReprotViewerForm : System.Web.UI.Page
    {
        private int intZoom = 100;
        private String strCaption;
        private String strMainForm;
        //private Collection<SalesForce> salesForces;
        DataTable dataTable = new DataTable("Header");
        DataTable dataTableObject = new DataTable("Object");
        DataRow dr;
        private static int count = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("ObjRpt");
                ViewState["formName"] = String.IsNullOrEmpty(Request.QueryString.Get("mainform"))
                                             ? String.Empty
                                             : Request.QueryString.Get("mainform");
                ViewState["transactionNo"] = String.IsNullOrEmpty(Request.QueryString.Get("tranno"))
                                          ? String.Empty
                                          : Request.QueryString.Get("tranno");
                ViewState["mode"] = String.IsNullOrEmpty(Request.QueryString.Get("mod"))
                                          ? String.Empty
                                          : Request.QueryString.Get("mod");
                ViewState["transactionType"] = String.IsNullOrEmpty(Request.QueryString.Get("ttype"))
                                           ? String.Empty
                                           : Request.QueryString.Get("ttype");
                ViewState["document"] = String.IsNullOrEmpty(Request.QueryString.Get("doc"))
                                           ? String.Empty
                                           : Request.QueryString.Get("doc");
                ViewState["businessUnit"] = String.IsNullOrEmpty(Request.QueryString.Get("busUnit"))
                                          ? String.Empty
                                          : Request.QueryString.Get("busUnit");
                ViewState["businessUnitName"] = String.IsNullOrEmpty(Request.QueryString.Get("busUName"))
                                          ? String.Empty
                                          : Request.QueryString.Get("busUName");
                ViewState["businessUnitCode"] = String.IsNullOrEmpty(Request.QueryString.Get("busUCode"))
                                          ? String.Empty
                                          : Request.QueryString.Get("busUCode");

                ViewState["fromDate"] = String.IsNullOrEmpty(Request.QueryString.Get("fromdt"))
                                           ? String.Empty
                                           : Request.QueryString.Get("fromdt");
                ViewState["toDate"] = String.IsNullOrEmpty(Request.QueryString.Get("todt"))
                                         ? String.Empty
                                         : Request.QueryString.Get("todt");
                ViewState["reqmode"] = String.IsNullOrEmpty(Request.QueryString.Get("reqmode"))
                                           ? String.Empty
                                           : Request.QueryString.Get("reqmode");
                dr = dataTable.NewRow();

                dataTable.Columns.Clear();
                dataTableObject.Columns.Clear();
                count = 0;
                CreateColumn(ViewState["formName"].ToString(), "formName");
                CreateColumn(ViewState["transactionNo"].ToString(), "transactionNo");
                CreateColumn(ViewState["mode"].ToString(), "mode");
                CreateColumn(ViewState["transactionType"].ToString(), "transactionType");
                CreateColumn(ViewState["document"].ToString(), "document");
                CreateColumn(ViewState["businessUnit"].ToString(), "businessUnit");
                CreateColumn(ViewState["businessUnitName"].ToString(), "businessUnitName");
                CreateColumn(ViewState["businessUnitCode"].ToString(), "businessUnitCode");
                CreateColumn(ViewState["fromDate"].ToString(), "fromDate");
                CreateColumn(ViewState["toDate"].ToString(), "toDate");
                CreateColumn(ViewState["reqmode"].ToString(), "reqmode");
                dataTable.Rows.Add(dr);

            }
            GetMainData(ViewState["formName"].ToString());
        }

        protected void CreateColumn(String Column, String ColumnName)
        {
            String value = "";
            if (!String.IsNullOrEmpty(Column))
            {
                value = Column;
            }
            dataTable.Columns.Add(new DataColumn(ColumnName, typeof(String)));

            dr[count] = Column;
            count++;
        }

        protected void GetMainData(String pageName)
        {
            DataSet dataSet = new DataSet();
            if (pageName == "ForecastSummeryForm")
            {
                SalesForecastSummaryReport salesForecastSummaryReport = new SalesForecastSummaryReport();
                this.Title = "Sales Forecasting Summary";
                if (Session["ObjRpt"] == null)
                {
                    dataSet.Clear();
                    //Collection<SalesForecastDetail> salesForecastDetails = new Collection<SalesForecastDetail>();
                    //SalesSummaryService summaryService = new SalesSummaryService();
                    //summaryService.GetAllSalesSummary();

                    //dataTableObject = summaryService.GetAllSalesSummary();
                    if (Session[Key.SalesForecastSummary] != null)
                    {
                        dataTableObject = (DataTable)Session[Key.SalesForecastSummary];
                    }
                    dataSet.Tables.Add(dataTable.Copy());
                    dataSet.Tables.Add(dataTableObject.Copy());
                    //dataSet.WriteXmlSchema("E:/E-RM/Source/Jayadi.ERM/Jayadi.ERM.Web/Report/SalesForecastSummaryReport.xsd");

                    SendPrintData(dataSet, salesForecastSummaryReport);
                }
                else
                {
                    CrystalReportViewer1.ReportSource = (SalesForecastSummaryReport)Session["ObjRpt"];
                }
            }
            else if (pageName == "BudgetSummeryForm")
            {
                SalesBudgetSummaryReport salesBudgetSummaryReport = new SalesBudgetSummaryReport();
                this.Title = "Sales Budgeting Summary";
                if (Session["ObjRpt"] == null)
                {
                    dataSet.Clear();
                    //Collection<SalesForecastDetail> salesForecastDetails = new Collection<SalesForecastDetail>();
                    //SalesSummaryService summaryService = new SalesSummaryService();
                    //summaryService.GetAllSalesSummary();

                    //dataTableObject = summaryService.GetAllSalesSummary();
                    if (Session[Key.SalesBudgetSummary] != null)
                    {
                        dataTableObject = (DataTable)Session[Key.SalesBudgetSummary];
                    }
                    dataSet.Tables.Add(dataTable.Copy());
                    dataSet.Tables.Add(dataTableObject.Copy());
                    //dataSet.WriteXmlSchema("E:/E-RM/Source/Jayadi.ERM/Jayadi.ERM.Web/Report/SalesBudgetSummaryReport.xsd");

                    SendPrintData(dataSet, salesBudgetSummaryReport);
                }
                else
                {
                    CrystalReportViewer1.ReportSource = (SalesBudgetSummaryReport)Session["ObjRpt"];
                }
            }
            else if (pageName == "TargetSummeryForm")
            {
                SalesTargetSummaryReport salesTargetSummaryReport = new SalesTargetSummaryReport();
                this.Title = "Sales Target Summary";
                if (Session["ObjRpt"] == null)
                {
                    dataSet.Clear();
                    //Collection<SalesForecastDetail> salesForecastDetails = new Collection<SalesForecastDetail>();
                    //SalesSummaryService summaryService = new SalesSummaryService();
                    //summaryService.GetAllSalesSummary();

                    //dataTableObject = summaryService.GetAllSalesSummary();
                    if (Session[Key.SalesTargetSummary] != null)
                    {
                        dataTableObject = (DataTable)Session[Key.SalesTargetSummary];
                    }
                    dataSet.Tables.Add(dataTable.Copy());
                    dataSet.Tables.Add(dataTableObject.Copy());
                    //dataSet.WriteXmlSchema("E:/E-RM/Source/Jayadi.ERM/Jayadi.ERM.Web/Report/SalesTargetSummaryReport.xsd");

                    SendPrintData(dataSet, salesTargetSummaryReport);
                }
                else
                {
                    CrystalReportViewer1.ReportSource = (SalesTargetSummaryReport)Session["ObjRpt"];
                }
            }
            else if (pageName == "SalesSummeryForm")
            {
                SalesSummaryReport salesSummaryReport = new SalesSummaryReport();
                this.Title = "Sales Summary";
                if (Session["ObjRpt"] == null)
                {
                    dataSet.Clear();
                    //Collection<SalesForecastDetail> salesForecastDetails = new Collection<SalesForecastDetail>();
                    //SalesSummaryService summaryService = new SalesSummaryService();
                    //summaryService.GetAllSalesSummary();

                    //dataTableObject = summaryService.GetAllSalesSummary();
                    if (Session[Key.SalesSummary] != null)
                    {
                        dataTableObject = (DataTable)Session[Key.SalesSummary];
                    }
                    dataSet.Tables.Add(dataTable.Copy());
                    dataSet.Tables.Add(dataTableObject.Copy());
                    //dataSet.WriteXmlSchema("E:/E-RM/Source/Jayadi.ERM/Jayadi.ERM.Web/Report/SalesSummaryReport.xsd");

                    SendPrintData(dataSet, salesSummaryReport);
                }
                else
                {
                    CrystalReportViewer1.ReportSource = (SalesSummaryReport)Session["ObjRpt"];
                }
            }
            else if (pageName == "CommissionSummeryForm")
            {
                CommissionSummeryReport commissionSummeryReport = new CommissionSummeryReport();
                this.Title = "Commission Summery";
                if (Session["ObjRpt"] == null)
                {
                    dataSet.Clear();
                    //Collection<SalesForecastDetail> salesForecastDetails = new Collection<SalesForecastDetail>();
                    //SalesSummaryService summaryService = new SalesSummaryService();
                    //summaryService.GetAllSalesSummary();

                    //dataTableObject = summaryService.GetAllSalesSummary();
                    if (Session[Key.CommissionSummary] != null)
                    {
                        dataTableObject = (DataTable)Session[Key.CommissionSummary];
                    }
                    dataSet.Tables.Add(dataTable.Copy());
                    dataSet.Tables.Add(dataTableObject.Copy());
                    //dataSet.WriteXmlSchema("E:/E-RM/Source/Jayadi.ERM/Jayadi.ERM.Web/Report/CommissionSummeryReport.xsd");

                    SendPrintData(dataSet, commissionSummeryReport);
                }
                else
                {
                    CrystalReportViewer1.ReportSource = (CommissionSummeryReport)Session["ObjRpt"];
                }
            }
            else if (pageName == "InvoiceForm")
            {
                InvoiceFormReport invoiceFormReport = new InvoiceFormReport();
                this.Title = "Invoice";
                if (Session["ObjRpt"] == null)
                {
                    dataSet.Clear();
                    //Collection<SalesForecastDetail> salesForecastDetails = new Collection<SalesForecastDetail>();
                    //SalesSummaryService summaryService = new SalesSummaryService();
                    //summaryService.GetAllSalesSummary();

                    //dataTableObject = summaryService.GetAllSalesSummary();
                    if (Session[Key.InvoiceDetail] != null)
                    {
                        dataTableObject = (DataTable)Session[Key.InvoiceDetail];
                    }
                    dataSet.Tables.Add(dataTable.Copy());
                    dataSet.Tables.Add(dataTableObject.Copy());
                    //dataSet.WriteXmlSchema("E:/E-RM/Source/Jayadi.ERM/Jayadi.ERM.Web/Report/InvoiceFormReport.xsd");

                    SendPrintData(dataSet, invoiceFormReport);
                }
                else
                {
                    CrystalReportViewer1.ReportSource = (InvoiceFormReport)Session["ObjRpt"];
                }
            }
        }

        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                // HERE IS WHERE THE ERROR IS THROWN FOR NULLABLE TYPES
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }

        //protected void CrystalReportViewer1_ViewZoom(object source, CrystalDecisions.Web.ZoomEventArgs e)
        //{

        //}
        protected void SendPrintData(DataSet dataSetSend, ReportClass report)
        {

            report.SetDataSource(dataSetSend);
            Session["ObjRpt"] = report;
            CrystalReportViewer1.ReportSource = report;
            // DirectCast(objRpt, SalesForcesReport).PrintOptions.PaperSize = PaperSize.PaperB5;

        }
    }
}