using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.Service.Reports;
using BzFlexer.SAMS.WebSite.ReportCenter.iReporter;
using BzFlexer.SAMS.WebView.Home;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebSite.ReportCenter
{
    public partial class BizTargetSummery : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillData();
            }
        }

        #region "Load Data"

        public void fillData()
        {
            LoadEmployeeDetail();
            //DataBindTodropDownListBranch();
            //DataBindTodropDownListSalesTarget();
            //DataBindTodropDownListProductCategory();
            //GetSalesTargetDetail();
        }

        public void DataBindTodropDownListBranch()
        {
            //Biz_BranchService branchService = new Biz_BranchService();

            //dropDownListBranch.DataSource = branchService.ReadAllBranch();
            //dropDownListBranch.DataValueField = "Id";
            //dropDownListBranch.DataTextField = "Description";
            //dropDownListBranch.DataBind();
            //dropDownListBranch.SelectedIndex = 0;
        }

        public void DataBindTodropDownListSalesTarget()
        {
            //Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();

            //dropDownListSalesTarget.DataSource = salesTargetService.ReadAllSalesTargets();
            //dropDownListSalesTarget.DataTextField = "Description";
            //dropDownListSalesTarget.DataValueField = "Id";
            //dropDownListSalesTarget.DataBind();
        }

        public void DataBindTodropDownListProductCategory()
        {
            //Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

            //dropDownListProductCategory.DataSource = productCategoryService.ReadAllProductCategory();
            //dropDownListProductCategory.DataTextField = "Description";
            //dropDownListProductCategory.DataValueField = "Id";
            //dropDownListProductCategory.DataBind();
        }

        public void DataBindTodropDownListSubProductCategory()
        {
        //    Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();

        //    if (dropDownListProductCategory.SelectedIndex > 0)
        //    {
        //        dropDownListSubProductCategory.DataSource = subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
        //        dropDownListSubProductCategory.DataValueField = "Id";
        //        dropDownListSubProductCategory.DataTextField = "Description";
        //        dropDownListSubProductCategory.DataBind();
        //    }
        //    else
        //    {
        //        CleardropDownListSubProductCategory();
        //    }
        }

        public void CleardropDownListBranch()
        {
            //dropDownListBranch.Items.Clear();
            //dropDownListBranch.Items.Add("-Select-");
        }

        public void CleardropDownListSalesTarget()
        {
            //dropDownListSalesTarget.Items.Clear();
            //dropDownListSalesTarget.Items.Add("-Select-");
        }

        public void CleardropDownListProductCategory()
        {
            //dropDownListProductCategory.Items.Clear();
            //dropDownListProductCategory.Items.Add("-Select-");
        }

        public void CleardropDownListSubProductCategory()
        {
            //dropDownListSubProductCategory.Items.Clear();
            //dropDownListSubProductCategory.Items.Add("-Select-");
        }

        public void GetSalesTargetDetail()
        {
            //if (dropDownListBranch.SelectedIndex < 1 && dropDownListSalesTarget.SelectedIndex < 1 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            //{
            //    LoadAllSalesTargetDetail();
            //}
            //else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex < 1 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            //{
            //    LoadSalesTargetDetailByBranch();
            //}
            //else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            //{
            //    LoadSalesTargetDetailBySalesTarget();
            //}
            //else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex < 1)
            //{
            //    LoadSalesTargetDetailBySalesTargetAndProductCategory();
            //}
            //else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex > 0)
            //{
            //    LoadBranchSalesTargetDetailBySalesTargetAndProductCategoryAndSubProductCategory();
            //}
            //else
            //{
            //    CleargridViewSalesTargetSummary();
            //}
        }

        public void LoadAllSalesTargetDetail()
        {
            List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void LoadSalesTargetDetailByBranch()
        {
            //List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            //salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            //salesTargetDetailList = (from salesTargetDetail in salesTargetDetailList
            //                         where
            //                             salesTargetDetail.IdBranch ==
            //                             Convert.ToInt16(dropDownListBranch.SelectedValue)
            //                         select salesTargetDetail).ToList();

            //DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void LoadSalesTargetDetailBySalesTarget()
        {
            //List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            //salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            //salesTargetDetailList = (from salesTargetDetail in salesTargetDetailList
            //                         where salesTargetDetail.IdBranch ==
            //                             Convert.ToInt16(dropDownListBranch.SelectedValue) &&
            //                             salesTargetDetail.IdSalesTarget ==
            //                             Convert.ToInt16(dropDownListSalesTarget.SelectedValue)
            //                         select salesTargetDetail).ToList();

            //DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void LoadSalesTargetDetailBySalesTargetAndProductCategory()
        {
            //List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            //salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            //salesTargetDetailList = (from salesTargetDetail in salesTargetDetailList
            //                         where salesTargetDetail.IdBranch ==
            //                             Convert.ToInt16(dropDownListBranch.SelectedValue) &&
            //                             salesTargetDetail.IdSalesTarget ==
            //                             Convert.ToInt16(dropDownListSalesTarget.SelectedValue) && salesTargetDetail.Biz_InventoryItems.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue)
            //                         select salesTargetDetail).ToList();

            //DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void LoadBranchSalesTargetDetailBySalesTargetAndProductCategoryAndSubProductCategory()
        {
            //List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            //salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            //salesTargetDetailList = (from salesTargetDetail in salesTargetDetailList
            //                         where salesTargetDetail.IdBranch == Convert.ToInt16(dropDownListBranch.SelectedValue) &&
            //                             salesTargetDetail.IdSalesTarget == Convert.ToInt16(dropDownListSalesTarget.SelectedValue) &&
            //                             salesTargetDetail.Biz_InventoryItems.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue) &&
            //                             salesTargetDetail.Biz_InventoryItems.Biz_Products.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue)
            //                         select salesTargetDetail).ToList();

            //DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void CleargridViewSalesTargetSummary()
        {
            //gridViewSalesTargetSummary.DataSource = null;
            //gridViewSalesTargetSummary.DataBind();
        }

        public void DataBindTogridViewSalesTargetSummary(List<Biz_SalesTargetDetail> salesTargetDetailList)
        {
            //gridViewSalesTargetSummary.DataSource = salesTargetDetailList;
            //gridViewSalesTargetSummary.DataBind();
    


            //DataTable dt = GridConvertDatatable(salesTargetDetailList);
            //Session[Key.SalesTargetSummary] = dt;
            ////report
            //WebView.Home.Global.TargetRep = salesTargetDetailList;
          
          
            
        }

        public DataTable GridConvertDatatable(List<Biz_Stakeholder> stakeholderList)
        {
            DataTable dt = new DataTable(Key.SalesTargetSummary);

            dt.Columns.Add("Id");
            dt.Columns.Add("FullName");
            dt.Columns.Add("Biz_StakeholderTypes.Code");
            dt.Columns.Add("Status");
           

            foreach (Biz_Stakeholder stakeholder in stakeholderList)
            {
                DataRow dr;
                dr = dt.NewRow();

                dr[0] = stakeholder.Id;
                dr[1] = stakeholder.FullName;
                dr[2] = "A";
                dr[3] = stakeholder.Status;
                

                dt.Rows.Add(dr);
            }
            return dt;
        }


        #endregion

        #region "Events"

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSalesTargetDetail();
        }

        public void dropDownListSalesTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSalesTargetDetail();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListSubProductCategory();
            DataBindTodropDownListSubProductCategory();
            GetSalesTargetDetail();
        }

        public void dropDownListSubProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSalesTargetDetail();
        }

        public void gridViewSalesTargetSummary_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSalesTargetSummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GetSalesTargetDetail();
            //gridViewSalesTargetSummary.PageIndex = e.NewPageIndex;
            //gridViewSalesTargetSummary.DataBind();
            
        }
        private void BindGrid()
        {
            string strConnString = ConfigurationManager.ConnectionStrings["BizFlexerDTConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Id,Type,Value,Quantity FROM Biz_SalesTargetDetail"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            //gridViewSalesTargetSummary.DataSource = dt;
                            //gridViewSalesTargetSummary.DataBind();
                        }
                    }
                }
            }
        }
        public void buttonPrint_Click(object sender, EventArgs e)
        {
            if (gridViewEmployeeDetail.HeaderRow.Cells.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
              "window.open( '../ReportCenter/iReporter/iTargetSummery.aspx' );", true);

            }
            else
            {
                //FlashText1.Display("No Records to print", "okmessage");
            }
        }

        public void buttonCancel_Click(object sender, EventArgs e)
        {
            CleardropDownListBranch();
            CleardropDownListSalesTarget();
            CleardropDownListProductCategory();
            CleardropDownListSubProductCategory();
            DataBindTodropDownListBranch();
            DataBindTodropDownListSalesTarget();
            DataBindTodropDownListProductCategory();
            GetSalesTargetDetail();
        }

        public void LoadEmployeeDetail()
        {
            try
            {
                Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
                gridViewEmployeeDetail.DataSource = employeeDetailService.ReadAllEmplyeeDetail();
                DataTable dt = GridConvertDatatable(employeeDetailService.ReadAllEmplyeeDetail());
                gridViewEmployeeDetail.DataBind();

                Session[Key.SalesSummary] = dt;
                gridViewEmployeeDetail.DataSource = null;
                gridViewEmployeeDetail.DataSource = dt;
                gridViewEmployeeDetail.DataBind();
            }
            catch (Exception exception)
            {

            }
        }
        //public void DataBindTogridViewSalesSummary(List<Biz_Invoice> invoiceList)
        //{
        //    DataTable dt = GridConvertDatatable(invoiceList);
        //    Session[Key.SalesSummary] = dt;
        //    gridViewSalesSummary.DataSource = null;
        //    gridViewSalesSummary.DataSource = dt;
        //    gridViewSalesSummary.DataBind();
        //    //report
        //    WebView.Home.Global.dtSales = dt;
        //}

        #endregion
    }
}