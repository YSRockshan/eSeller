using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.WebView.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.AgentManagement
{
    public partial class BzFlexerCommissionsCal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textBoxMessage.Visible = false;
            filldata();
            CleargridViewCommissionProcess();
        }

        #region "Load Data"

        public void filldata()
        {
            textBoxTransactionDate.Text = DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" +
                                          DateTime.Now.Year.ToString();
            //comDate = DateTime.Parse(textBoxTransactionDate.Text);
        }

        public void FillDatatogridViewCommissionProcess()
        {
            List<Biz_Invoice> invoices = new List<Biz_Invoice>();
            List<Biz_Invoice> invoiceList = new List<Biz_Invoice>();
            invoices = new Biz_InvoiceService().ReadAllInvoices();
            invoiceList = (from invoice in invoices
                           where invoice.Status != "P"
                           select invoice).ToList();

            Session[Key.CommissionList] = invoiceList;
            gridViewCommissionProcess.DataSource = invoiceList;
            gridViewCommissionProcess.DataBind();

        }

        public void CleargridViewCommissionProcess()
        {
            gridViewCommissionProcess.DataSource = null;
            gridViewCommissionProcess.DataBind();
        }

        #endregion

        #region "Operations"

        public void ProcessCommission()
        {
            try
            {
                if (Page.IsValid)
                {
                    List<Biz_Invoice> invoiceTobeProcess = new List<Biz_Invoice>();
                    invoiceTobeProcess = (List<Biz_Invoice>)Session[Key.CommissionList];

                    textBoxMessage.Visible = true;
                    textBoxMessage.Text = "Please Wait....";

                    //Member wise Commission Detail Update
                    foreach (Biz_Invoice invoice in invoiceTobeProcess)
                    {
                        Biz_MemberCommssionDetail memberCommssionDetail = new Biz_MemberCommssionDetail();
                        Biz_MemberCommssionDetailsService memberCommssionDetailService = new Biz_MemberCommssionDetailsService();

                        memberCommssionDetail.IdSalesTransaction = invoice.IdSalesTransaction;
                        memberCommssionDetail.IdSalesAgent = invoice.IdSalesPerson;
                        memberCommssionDetail.Commission = invoice.Commission_Value;
                        memberCommssionDetail.Date_Commission = DateTime.Now.Date;
                        memberCommssionDetail.IdBranch = Convert.ToInt16(invoice.IdBranch);
                        memberCommssionDetail.SequenceNumber = invoice.serialNo;
                        memberCommssionDetail.IdInvoice = invoice.Id;

                        if (invoice.IdSalesTarget != null)
                        {
                            Biz_SalesTarget salesTargets = new Biz_SalesTarget();
                            salesTargets = new Biz_SalesTargetService().ReadSalesTargetById(Convert.ToInt16(invoice.IdSalesTarget));
                            if (salesTargets.IdCommssion != null)
                            {
                                Biz_Commission commission = new Biz_Commission();
                                commission = new Biz_CommissionsService().ReadCommissionById(Convert.ToInt16(salesTargets.IdCommssion));
                                if (commission.Mode.Trim() == "S")
                                {
                                    Biz_SingleRate singleRate = new Biz_SingleRate();
                                    singleRate = new Biz_SingleRateService().ReadSingleRateByCommissionId(commission.Id);
                                    if (singleRate != null)
                                    {
                                        memberCommssionDetail.Target_Commission = invoice.Total_Value * singleRate.Rate / 100;
                                    }
                                    else
                                    {
                                        memberCommssionDetail.Target_Commission = null;
                                    }

                                }
                                else
                                {
                                    Biz_MultipleRate multipleRates = new Biz_MultipleRate();
                                    multipleRates = new Biz_MultipleRatesService().ReadMultipleRateByCommssionId(Convert.ToInt16(salesTargets.IdCommssion));
                                    if (multipleRates != null)
                                    {
                                        List<Biz_SlabDetail> slabDetails = new List<Biz_SlabDetail>();
                                        slabDetails = new Biz_SlabDetailService().ReadSlabDetailBySlabId(multipleRates.IdSlab);
                                        foreach (Biz_SlabDetail slabDetail in slabDetails)
                                        {
                                            if ((invoice.Total_Value / invoice.Quantity) >= slabDetail.Slab_From && (invoice.Total_Value / invoice.Quantity) <= slabDetail.Slab_To)
                                            {
                                                memberCommssionDetail.Target_Commission = invoice.Total_Value * slabDetail.Rate / 100;
                                            }
                                        }

                                    }
                                    else
                                    {
                                        memberCommssionDetail.Target_Commission = null;
                                    }
                                }
                            }
                        }
                        else
                        {
                            memberCommssionDetail.Target_Commission = null;
                        }

                        memberCommssionDetail.Total_Commission = Convert.ToDecimal(memberCommssionDetail.Commission) +
                                                                Convert.ToDecimal(memberCommssionDetail.Target_Commission);

                        memberCommssionDetail.DateCreated = DateTime.Now;
                        memberCommssionDetail.DateModified = DateTime.Now;

                        memberCommssionDetailService.CreateMemberCommssionDetail(memberCommssionDetail);

                        // Invoice Update as Processed (P)

                        Biz_Invoice modifyInvoice = new Biz_Invoice();
                        Biz_InvoiceService invoiceService = new Biz_InvoiceService();
                        modifyInvoice = invoiceService.ReadInvoiceById(invoice.Id);
                        modifyInvoice.Status = "P";
                        modifyInvoice.DateModified = DateTime.Now;

                        invoiceService.UpdateInvoice(modifyInvoice);


                    }
                }
                textBoxMessage.Visible = false;
               FlashText1.Display("Commission Calculation Process Completed...", "okmessage");

            }
            catch (Exception exception)
            {
               FlashText1.Display("Commission Calculation Process Failed...", "okmessage");
            }

        }

        #endregion


        #region "Events"

        public void gridViewCommissionProcess_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewCommissionProcess.PageIndex = e.NewPageIndex;
            gridViewCommissionProcess.DataBind();
        }

        public void gridViewCommissionProcess_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void buttonQuery_Click(object sender, EventArgs e)
        {
            FillDatatogridViewCommissionProcess();
        }

        public void buttonProcess_Click(object sender, EventArgs e)
        {
            if (Session[Key.CommissionList] != null)
            {
                ProcessCommission();
            }
            else
            {
               FlashText1.Display("No Data to Process.", "errormessage");
            }
        }

        #endregion
    }
}