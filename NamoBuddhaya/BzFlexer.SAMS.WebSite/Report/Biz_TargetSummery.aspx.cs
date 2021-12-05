using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.Service.Reports;
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
    public partial class Biz_TargetSummery : System.Web.UI.Page
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
            DataBindTodropDownListBranch();
            DataBindTodropDownListSalesTarget();
            DataBindTodropDownListProductCategory();
            GetBiz_SalesTargetDetail();
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

        public void DataBindTodropDownListSalesTarget()
        {
            Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();

            dropDownListSalesTarget.DataSource = salesTargetService.ReadAllSalesTargets();
            dropDownListSalesTarget.DataTextField = "Description";
            dropDownListSalesTarget.DataValueField = "Id";
            dropDownListSalesTarget.DataBind();
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

        public void CleardropDownListSalesTarget()
        {
            dropDownListSalesTarget.Items.Clear();
            dropDownListSalesTarget.Items.Add("-Select-");
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

        public void GetBiz_SalesTargetDetail()
        {
            if (dropDownListBranch.SelectedIndex < 1 && dropDownListSalesTarget.SelectedIndex < 1 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadAllSalesTargetDetail();
            }
            else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex < 1 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadSalesTargetDetailByBranch();
            }
            else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadBiz_SalesTargetDetailBySalesTarget();
            }
            else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadBiz_SalesTargetDetailBySalesTargetAndProductCategory();
            }
            else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex > 0)
            {
                LoadBranchBiz_SalesTargetDetailBySalesTargetAndProductCategoryAndSubProductCategory();
            }
            else
            {
                CleargridViewSalesTargetSummary();
            }
        }

        public void LoadAllSalesTargetDetail()
        {
            List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void LoadSalesTargetDetailByBranch()
        {
            List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            salesTargetDetailList = (from salesTargetDetail in salesTargetDetailList
                                     where
                                         salesTargetDetail.IdBranch ==
                                         Convert.ToInt16(dropDownListBranch.SelectedValue)
                                     select salesTargetDetail).ToList();

            DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void LoadBiz_SalesTargetDetailBySalesTarget()
        {
            List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            salesTargetDetailList = (from salesTargetDetail in salesTargetDetailList
                                     where salesTargetDetail.IdBranch ==
                                         Convert.ToInt16(dropDownListBranch.SelectedValue) &&
                                         salesTargetDetail.IdSalesTarget ==
                                         Convert.ToInt16(dropDownListSalesTarget.SelectedValue)
                                     select salesTargetDetail).ToList();

            DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void LoadBiz_SalesTargetDetailBySalesTargetAndProductCategory()
        {
            List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            salesTargetDetailList = (from salesTargetDetail in salesTargetDetailList
                                     where salesTargetDetail.IdBranch ==
                                         Convert.ToInt16(dropDownListBranch.SelectedValue) &&
                                         salesTargetDetail.IdSalesTarget ==
                                         Convert.ToInt16(dropDownListSalesTarget.SelectedValue) && salesTargetDetail.Biz_InventoryItems.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                                     select salesTargetDetail).ToList();

            DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void LoadBranchBiz_SalesTargetDetailBySalesTargetAndProductCategoryAndSubProductCategory()
        {
            List<Biz_SalesTargetDetail> salesTargetDetailList = new List<Biz_SalesTargetDetail>();
            salesTargetDetailList = new Biz_TargetSummeryService().ReadAllSalesTargetDetail();

            salesTargetDetailList = (from salesTargetDetail in salesTargetDetailList
                                     where salesTargetDetail.IdBranch == Convert.ToInt16(dropDownListBranch.SelectedValue) &&
                                         salesTargetDetail.IdSalesTarget == Convert.ToInt16(dropDownListSalesTarget.SelectedValue) &&
                                         salesTargetDetail.Biz_InventoryItems.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue) &&
                                         salesTargetDetail.Biz_InventoryItems.Biz_Products.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue)
                                     select salesTargetDetail).ToList();

            DataBindTogridViewSalesTargetSummary(salesTargetDetailList);
        }

        public void CleargridViewSalesTargetSummary()
        {
            gridViewSalesTargetSummary.DataSource = null;
            gridViewSalesTargetSummary.DataBind();
        }

        public void DataBindTogridViewSalesTargetSummary( List<Biz_SalesTargetDetail>salesTargetDetailList)
        {
            gridViewSalesTargetSummary.DataSource = salesTargetDetailList;
            gridViewSalesTargetSummary.DataBind();

            DataTable dt = GridConvertDatatable(salesTargetDetailList);
            Session[Key.SalesTargetSummary] = dt;
        }

        public DataTable GridConvertDatatable( List<Biz_SalesTargetDetail>salesTargetDetailList)
        {
            DataTable dt = new DataTable(Key.SalesTargetSummary);

            dt.Columns.Add("SalesTarget");
            dt.Columns.Add("Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Type");
            dt.Columns.Add("Value [LKR]");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("UnitofMeasure");
            dt.Columns.Add("Branch");

            foreach (Biz_SalesTargetDetail salesTargetDetail in salesTargetDetailList)
            {
                DataRow dr;
                dr = dt.NewRow();

                dr[0] = salesTargetDetail.Biz_SalesTargets != null ? salesTargetDetail.Biz_SalesTargets.Description : "";
                dr[1] = salesTargetDetail.Biz_InventoryItems != null ? salesTargetDetail.Biz_InventoryItems.CodeInventoryItem : "";
                dr[2] = salesTargetDetail.Biz_InventoryItems != null ? salesTargetDetail.Biz_InventoryItems.Description : "";
                dr[3] = salesTargetDetail.Type == "V" ? "Value" : salesTargetDetail.Type == "Q" ? "Quantity" : "";
                dr[4] = salesTargetDetail.Value;
                dr[5] = salesTargetDetail.Quantity;
                dr[6] = salesTargetDetail.Biz_UnitOfMeasures != null ? salesTargetDetail.Biz_UnitOfMeasures.Description : "";
                dr[7] = salesTargetDetail.Biz_Branches != null ? salesTargetDetail.Biz_Branches.Description : "";

                dt.Rows.Add(dr);
            }
            return dt;
        }


        #endregion

        #region "Events"

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBiz_SalesTargetDetail();
        }

        public void dropDownListSalesTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBiz_SalesTargetDetail();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListSubProductCategory();
            DataBindTodropDownListSubProductCategory();
            GetBiz_SalesTargetDetail();
        }

        public void dropDownListSubProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetBiz_SalesTargetDetail();
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
            GetBiz_SalesTargetDetail();
            gridViewSalesTargetSummary.PageIndex = e.NewPageIndex;
            gridViewSalesTargetSummary.DataBind();
        }

        public void buttonPrint_Click(object sender, EventArgs e)
        {
            if (gridViewSalesTargetSummary.HeaderRow.Cells.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
              "window.open( '../ReprotViewerForm.aspx?mainform=TargetSummeryForm&busUnit=" + Session[WebView.Home.Global.BizLoginBranchName] +
              "&busUName=" + Session[WebView.Home.Global.BizLoginUserStakeholderName] + "&busUCode=" + Session[WebView.Home.Global.BizLoginBranchCode] +
              "', null, 'height=600,width=1100,status=yes,toolbar=no,menubar=no,location=no' );", true);
            }
            else
            {
                FlashText1.Display("No Records to print", "okmessage");
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
            GetBiz_SalesTargetDetail();
        }

        #endregion
    }
}