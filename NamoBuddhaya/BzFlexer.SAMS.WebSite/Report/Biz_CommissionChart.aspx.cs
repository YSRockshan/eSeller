using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.WebView.Home;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebSite.ReportCenter
{
    public partial class Biz_CommissionChart : System.Web.UI.Page
    {
        Dictionary<String, decimal> testMonth2 = new Dictionary<String, decimal>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillData();
            }
        }

        #region "Load Data"

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
            }

            DataBind();
        }
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // update chart rendering
        }
        protected override void OnDataBinding(EventArgs e)
        {

            Biz_CommissionChart.Titles.Add("Commission Summary");

            base.OnDataBinding(e);

            // define test data
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            //for (int i = 0; i < Convert.ToInt32(12); i++)
            //{
            //    DateTime date = new DateTime(2012, 1, 1);

            //    testMonth1.Add(date.AddMonths(i).ToString("MMM"), rnd.Next(1, 10));
            //    testMonth2.Add(date.AddMonths(i).ToString("MMM"), rnd.Next(1, 100));
            //}

            //testMonth2.Add("Namal", 10000);
            //testMonth2.Add("Kamal", 20000);
            //testMonth2.Add("Sunil", 30000);
            //testMonth2.Add("Jagath", 25000);
            //testMonth2.Add("Amal", 15000);
            //testMonth2.Add("Amila", 17000);
            //testMonth2.Add("Sarath", 13000);
            //testMonth2.Add("Nimal", 10000);

            testMonth2 = (Dictionary<String, decimal>)ViewState["CommissionVal"];

            CommissionChart.Series["Testing"].Points.DataBind(testMonth2, "Key", "Value", string.Empty);
            CommissionChart.DataBind();

        }


        public void fillData()
        {
            DataBindTodropDownListBranch();
            GetDataTogridViewSalesCommissionSummary();
        }

        public void DataBindTodropDownListBranch()
        {
            Biz_BranchService branchService = new Biz_BranchService();

            dropDownListBranch.DataSource = null;
            dropDownListBranch.DataSource = branchService.ReadAllBranch();
            dropDownListBranch.DataValueField = "Id";
            dropDownListBranch.DataTextField = "Description";
            dropDownListBranch.DataBind();
            dropDownListBranch.SelectedIndex = 0;
        }

        public void GetDataTogridViewSalesCommissionSummary()
        {
            List<Biz_MemberCommssionDetail> memberCommssionDetails = new List<Biz_MemberCommssionDetail>();
            List<Biz_BranchSalesAgent> branchSalesAgents = new List<Biz_BranchSalesAgent>();
            memberCommssionDetails = new Biz_MemberCommssionDetailsService().ReadAllMemberCommssionDetails();
            branchSalesAgents = new Biz_BranchSalesAgentService().ReadAllBranchSelesAgents();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                memberCommssionDetails = (from memberCommssionDetail in memberCommssionDetails
                                          where
                                              memberCommssionDetail.IdBranch ==
                                              Convert.ToInt16(dropDownListBranch.SelectedValue)
                                          select memberCommssionDetail).ToList();

                branchSalesAgents = (from branchSalesAgent in branchSalesAgents
                                   where branchSalesAgent.IdBranch == Convert.ToInt16(dropDownListBranch.SelectedValue)
                                   select branchSalesAgent).ToList();
            }
            if (textBoxDateFrom.Text != string.Empty && textBoxDateTo.Text != string.Empty)
            {
                memberCommssionDetails = (from memberCommssionDetail in memberCommssionDetails
                                          where
                                              memberCommssionDetail.Date_Commission >= Convert.ToDateTime(textBoxDateFrom.Text) && memberCommssionDetail.Date_Commission <= Convert.ToDateTime(textBoxDateTo.Text)
                                          select memberCommssionDetail).ToList();
            }
            List<long> stkIdList = (from id in branchSalesAgents select id.IdStakeholder).ToList();

            Session[Key.CommissionChartSummary] = memberCommssionDetails;
            if (dropDownListBranch.SelectedIndex > 0)
            {
                CreateDataTable(stkIdList, false);
            }
            else
            {
                CreateDataTable(stkIdList, true);
            }

        }

        public void CreateDataTable(List<long> stkIdList, bool isAll)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("SalesAgentId");
            dt.Columns.Add("SalesPerson");
            dt.Columns.Add("TotalCommission", typeof(decimal));


            if (isAll)
            {
                stkIdList = (from id in stkIdList select id).Distinct().ToList();
            }



            foreach (long i in stkIdList)
            {
                List<Biz_MemberCommssionDetail> memberCommssionDetailList = (List<Biz_MemberCommssionDetail>)Session[Key.CommissionChartSummary];

                memberCommssionDetailList = (from memberCommssionDetail in memberCommssionDetailList
                                             where memberCommssionDetail.IdSalesAgent == i
                                             select memberCommssionDetail).Distinct().ToList();


                if (memberCommssionDetailList.Sum(P => P.Total_Commission) > 0)
                {
                    DataRow dr;
                    dr = dt.NewRow();

                    Biz_Stakeholder stakeholder = new Biz_EmployeeDetailService().ReadEmployeeDetailById(i);

                    dr[0] = i;
                    dr[1] = stakeholder.Initial.Trim() + " " + stakeholder.LastName.Trim();
                    dr[2] = memberCommssionDetailList.Sum(P => P.Total_Commission);

                    dt.Rows.Add(dr);
                    testMonth2.Add(stakeholder.Initial.Trim() + " " + stakeholder.LastName.Trim(), Convert.ToDecimal(memberCommssionDetailList.Sum(P => P.Total_Commission)));
                }
            }

            ViewState["CommissionVal"] = testMonth2;

            DataBindTogridViewSalesCommissionSummary(dt);
        }

        public void DataBindTogridViewSalesCommissionSummary(DataTable dt)
        {
            gridViewSalesCommissionSummary.DataSource = dt;
            gridViewSalesCommissionSummary.DataBind();
        }

        #endregion

        #region "Event"

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataTogridViewSalesCommissionSummary();
        }

        public void gridViewSalesTCommssionSummary_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSalesCommissionSummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GetDataTogridViewSalesCommissionSummary();
            gridViewSalesCommissionSummary.PageIndex = e.NewPageIndex;
            gridViewSalesCommissionSummary.DataBind();
        }

        #endregion
    }
}