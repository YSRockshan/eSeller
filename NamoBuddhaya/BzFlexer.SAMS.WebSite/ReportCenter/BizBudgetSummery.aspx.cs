using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.Service.Reports;
using BzFlexer.SAMS.WebView.Home;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class BizBudgetSummery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillData();
               // this.BindReport();
            }
        }

      

     

        #region "Load Data"

        public void fillData()
        {
            DataBindTodropDownListBranch();
            DataBindTodropDownListSalesBudget();
            DataBindTodropDownListProductCategory();
            GetSalesBudgetDetail();
        }

        public void DataBindTodropDownListBranch()
        {
            Biz_BranchService branchService = new Biz_BranchService();

            dropDownListBranch.DataSource = branchService.ReadAllBranch();
            dropDownListBranch.DataValueField = "Id";
            dropDownListBranch.DataTextField = "Description";
            dropDownListBranch.DataBind();
            dropDownListBranch.SelectedIndex = 0;
        }

        public void DataBindTodropDownListSalesBudget()
        {
            Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();

            dropDownListSalesBudget.DataSource = salesBudgetService.ReadAllSalesBudgets();
            dropDownListSalesBudget.DataTextField = "Description";
            dropDownListSalesBudget.DataValueField = "Id";
            dropDownListSalesBudget.DataBind();
        }

        public void DataBindTodropDownListProductCategory()
        {
            Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

            dropDownListProductCategory.DataSource = productCategoryService.ReadAllProductCategory();
            dropDownListProductCategory.DataTextField = "Description";
            dropDownListProductCategory.DataValueField = "Id";
            dropDownListProductCategory.DataBind();
        }

        public void DataBindTodropDownListSubProductCategory()
        {
            Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();

            if (dropDownListProductCategory.SelectedIndex > 0)
            {
                dropDownListSubProductCategory.DataSource = subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
                dropDownListSubProductCategory.DataValueField = "Id";
                dropDownListSubProductCategory.DataTextField = "Description";
                dropDownListSubProductCategory.DataBind();
            }
            else
            {
                CleardropDownListSubProductCategory();
            }
        }

        public void CleardropDownListBranch()
        {
            dropDownListBranch.Items.Clear();
            dropDownListBranch.Items.Add("-Select-");
        }

        public void CleardropDownListSalesBudget()
        {
            dropDownListSalesBudget.Items.Clear();
            dropDownListSalesBudget.Items.Add("-Select-");
        }

        public void CleardropDownListProductCategory()
        {
            dropDownListProductCategory.Items.Clear();
            dropDownListProductCategory.Items.Add("-Select-");
        }

        public void CleardropDownListSubProductCategory()
        {
            dropDownListSubProductCategory.Items.Clear();
            dropDownListSubProductCategory.Items.Add("-Select-");
        }

        public void GetSalesBudgetDetail()
        {
            if (dropDownListBranch.SelectedIndex < 1 && dropDownListSalesBudget.SelectedIndex < 1 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadAllSalesBudgetDetail();
            }
            else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesBudget.SelectedIndex < 1 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadSalesBudgetDetailByBranch();
            }
            else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesBudget.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadSalesBudgetDetailBySalesBudget();
            }
            else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesBudget.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadSalesBudgetDetailBySalesBudgetAndProductCategory();
            }
            else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesBudget.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex > 0)
            {
                LoadBranchSalesBudgetDetailBySalesBudgetAndProductCategoryAndSubProductCategory();
            }
            else
            {
                CleargridViewSalesBudgetSummary();
            }
        }

        public void LoadAllSalesBudgetDetail()
        {
            List<Biz_SalesBudgetDetail> salesBudgetDetailList = new List<Biz_SalesBudgetDetail>();
            salesBudgetDetailList = new Biz_BudgetSummeryService().ReadAllSalesBudgetDetail();

            DataBindTogridViewSalesBudgetSummary(salesBudgetDetailList);
        }

        public void LoadSalesBudgetDetailByBranch()
        {
            List<Biz_SalesBudgetDetail> salesBudgetDetailList = new List<Biz_SalesBudgetDetail>();
            salesBudgetDetailList = new Biz_BudgetSummeryService().ReadAllSalesBudgetDetail();

            salesBudgetDetailList = (from salesBudgetDetail in salesBudgetDetailList
                                     where
                                         salesBudgetDetail.IdBranch ==
                                         Convert.ToInt16(dropDownListBranch.SelectedValue)
                                     select salesBudgetDetail).ToList();
            DataBindTogridViewSalesBudgetSummary(salesBudgetDetailList);
        }

        public void LoadSalesBudgetDetailBySalesBudget()
        {
            List<Biz_SalesBudgetDetail> salesBudgetDetailList = new List<Biz_SalesBudgetDetail>();
            salesBudgetDetailList = new Biz_BudgetSummeryService().ReadAllSalesBudgetDetail();

            salesBudgetDetailList = (from salesBudgetDetail in salesBudgetDetailList
                                     where salesBudgetDetail.IdBranch ==
                                         Convert.ToInt16(dropDownListBranch.SelectedValue) &&
                                         salesBudgetDetail.IdSalesBudget ==
                                         Convert.ToInt16(dropDownListSalesBudget.SelectedValue)
                                     select salesBudgetDetail).ToList();

            DataBindTogridViewSalesBudgetSummary(salesBudgetDetailList);
        }

        public void LoadSalesBudgetDetailBySalesBudgetAndProductCategory()
        {
            List<Biz_SalesBudgetDetail> salesBudgetDetailList = new List<Biz_SalesBudgetDetail>();
            salesBudgetDetailList = new Biz_BudgetSummeryService().ReadAllSalesBudgetDetail();

            salesBudgetDetailList = (from salesBudgetDetail in salesBudgetDetailList
                                     where salesBudgetDetail.IdBranch ==
                                         Convert.ToInt16(dropDownListBranch.SelectedValue) &&
                                         salesBudgetDetail.IdSalesBudget ==
                                         Convert.ToInt16(dropDownListSalesBudget.SelectedValue) && salesBudgetDetail.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                                     select salesBudgetDetail).ToList();

            DataBindTogridViewSalesBudgetSummary(salesBudgetDetailList);
        }

        public void LoadBranchSalesBudgetDetailBySalesBudgetAndProductCategoryAndSubProductCategory()
        {
            List<Biz_SalesBudgetDetail> salesBudgetDetailList = new List<Biz_SalesBudgetDetail>();
            salesBudgetDetailList = new Biz_BudgetSummeryService().ReadAllSalesBudgetDetail();

            salesBudgetDetailList = (from salesBudgetDetail in salesBudgetDetailList
                                     where salesBudgetDetail.IdBranch == Convert.ToInt16(dropDownListBranch.SelectedValue) &&
                                         salesBudgetDetail.IdSalesBudget == Convert.ToInt16(dropDownListSalesBudget.SelectedValue) &&
                                         salesBudgetDetail.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue) &&
                                         salesBudgetDetail.Biz_Products.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue)
                                     select salesBudgetDetail).ToList();
            DataBindTogridViewSalesBudgetSummary(salesBudgetDetailList);

        }

        public void CleargridViewSalesBudgetSummary()
        {
            gridViewSalesBudgetSummary.DataSource = null;
            gridViewSalesBudgetSummary.DataBind();
        }

        public void DataBindTogridViewSalesBudgetSummary(List<Biz_SalesBudgetDetail> salesBudgetDetailList)
        {
            gridViewSalesBudgetSummary.DataSource = salesBudgetDetailList;
            gridViewSalesBudgetSummary.DataBind();

            DataTable dt = GridConvertDatatable(salesBudgetDetailList);
            Session[Key.SalesBudgetSummary] = dt;
            //report
            WebView.Home.Global.BudgetRep = salesBudgetDetailList;
        }

        public DataTable GridConvertDatatable(List<Biz_SalesBudgetDetail> salesBudgetDetailList)
        {
            DataTable dt = new DataTable(Key.SalesBudgetSummary);

            dt.Columns.Add("SalesBudget");
            dt.Columns.Add("Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Type");
            dt.Columns.Add("Value [LKR]");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("UnitofMeasure");
            dt.Columns.Add("Branch");

            foreach (Biz_SalesBudgetDetail salesBudgetDetail in salesBudgetDetailList)
            {
                DataRow dr;
                dr = dt.NewRow();

                dr[0] = salesBudgetDetail.Biz_SalesBudgets != null ? salesBudgetDetail.Biz_SalesBudgets.Description : "";
                dr[1] = salesBudgetDetail.Biz_Products != null ? salesBudgetDetail.Biz_Products.Code : "";
                dr[2] = salesBudgetDetail.Biz_Products != null ? salesBudgetDetail.Biz_Products.Description : "";
                dr[3] = salesBudgetDetail.Type == "V" ? "Value" : salesBudgetDetail.Type == "Q" ? "Quantity" : "";
                dr[4] = salesBudgetDetail.Value;
                dr[5] = salesBudgetDetail.Quantity;
                dr[6] = salesBudgetDetail.Biz_UnitOfMeasures != null ? salesBudgetDetail.Biz_UnitOfMeasures.Description : "";
                dr[7] = salesBudgetDetail.Biz_Branches != null ? salesBudgetDetail.Biz_Branches.Description : "";

                dt.Rows.Add(dr);
            }
            return dt;
        }
       
        #endregion

        #region "Events"

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSalesBudgetDetail();
        }

        public void dropDownListSalesBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSalesBudgetDetail();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListSubProductCategory();
            DataBindTodropDownListSubProductCategory();
            GetSalesBudgetDetail();
        }

        public void dropDownListSubProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSalesBudgetDetail();
        }

        public void gridViewSalesBudgetSummary_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSalesBudgetSummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GetSalesBudgetDetail();
            gridViewSalesBudgetSummary.PageIndex = e.NewPageIndex;
            gridViewSalesBudgetSummary.DataBind();
        }

        public void buttonPrint_Click(object sender, EventArgs e)
        {
            if (gridViewSalesBudgetSummary.HeaderRow.Cells.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
              "window.open( '../ReportCenter/iReporter/iBudgetSummery.aspx' );", true);

            }
            else
            {
                FlashText1.Display("No Records to print", "okmessage");
            }
        }

        public void buttonCancel_Click(object sender, EventArgs e)
        {
            CleardropDownListBranch();
            CleardropDownListSalesBudget();
            CleardropDownListProductCategory();
            CleardropDownListSubProductCategory();
            DataBindTodropDownListBranch();
            DataBindTodropDownListSalesBudget();
            DataBindTodropDownListProductCategory();
            GetSalesBudgetDetail();
        }

        #endregion
    }
}