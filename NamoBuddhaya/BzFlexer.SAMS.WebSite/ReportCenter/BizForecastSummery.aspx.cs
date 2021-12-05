using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.Service.Reports;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebSite.ReportCenter
{
    public partial class BizForecastSummery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListSalesForecast();
                DataBindTodropDownListProductCategory();
                GetSalesForecastDetail();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListSalesForecast()
        {
            Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();

            dropDownListSalesForecast.DataSource = salesForecastService.ReadAllSalesForecast();
            dropDownListSalesForecast.DataTextField = "Description";
            dropDownListSalesForecast.DataValueField = "Id";
            dropDownListSalesForecast.DataBind();
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

        public void CleardropDownListSalesForecast()
        {
            dropDownListSalesForecast.Items.Clear();
            dropDownListSalesForecast.Items.Add("-Select-");
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

        public void GetSalesForecastDetail()
        {
            if (dropDownListSalesForecast.SelectedIndex < 1 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadAllSalesForecastDetail();
            }
            else if (dropDownListSalesForecast.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadSalesForecastDetailBySalesForecast();
            }
            else if (dropDownListSalesForecast.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                LoadSalesForecastDetailBySalesForecastAndProductCategory();
            }
            else if (dropDownListSalesForecast.SelectedIndex > 0 && dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex > 0)
            {
                LoadBranchSalesForecastDetailBySalesForecastAndProductCategoryAndSubProductCategory();
            }
            else
            {
                CleargridViewSalesForecastSummary();
            }
        }

        public void LoadAllSalesForecastDetail()
        {
            List<Biz_SalesForecastDetail> salesForecastDetailList = new List<Biz_SalesForecastDetail>();
            salesForecastDetailList = new Biz_ForecastSummeryService().GetAllSalesForecastDetail();

            DataBindTogridViewSalesForecastSummary(salesForecastDetailList);

        }

        public void LoadSalesForecastDetailBySalesForecast()
        {
            List<Biz_SalesForecastDetail> salesForecastDetailList = new List<Biz_SalesForecastDetail>();
            salesForecastDetailList = new Biz_ForecastSummeryService().GetAllSalesForecastDetail();

            salesForecastDetailList = (from salesForecastDetail in salesForecastDetailList
                                       where
                                           salesForecastDetail.IdSalesForecast ==
                                           Convert.ToInt16(dropDownListSalesForecast.SelectedValue)
                                       select salesForecastDetail).ToList();

            DataBindTogridViewSalesForecastSummary(salesForecastDetailList);
        }

        public void LoadSalesForecastDetailBySalesForecastAndProductCategory()
        {
            List<Biz_SalesForecastDetail> salesForecastDetailList = new List<Biz_SalesForecastDetail>();
            salesForecastDetailList = new Biz_ForecastSummeryService().GetAllSalesForecastDetail();

            salesForecastDetailList = (from salesForecastDetail in salesForecastDetailList
                                       where
                                           salesForecastDetail.IdSalesForecast ==
                                           Convert.ToInt16(dropDownListSalesForecast.SelectedValue) && salesForecastDetail.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                                       select salesForecastDetail).ToList();

            DataBindTogridViewSalesForecastSummary(salesForecastDetailList);
        }

        public void LoadBranchSalesForecastDetailBySalesForecastAndProductCategoryAndSubProductCategory()
        {
            List<Biz_SalesForecastDetail> salesForecastDetailList = new List<Biz_SalesForecastDetail>();
            salesForecastDetailList = new Biz_ForecastSummeryService().GetAllSalesForecastDetail();

            salesForecastDetailList = (from salesForecastDetail in salesForecastDetailList
                                       where
                                           salesForecastDetail.IdSalesForecast == Convert.ToInt16(dropDownListSalesForecast.SelectedValue) &&
                                           salesForecastDetail.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue) &&
                                           salesForecastDetail.Biz_Products.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue)
                                       select salesForecastDetail).ToList();

            DataBindTogridViewSalesForecastSummary(salesForecastDetailList);
        }

        public void DataBindTogridViewSalesForecastSummary(List<Biz_SalesForecastDetail> salesForecastDetailList)
        {
            gridViewSalesForecastSummary.DataSource = salesForecastDetailList;
            gridViewSalesForecastSummary.DataBind();

            DataTable dt = GridConvertDatatable(salesForecastDetailList);
            Session["SalesForecastSummary"] = dt;
            //report
            WebView.Home.Global.ForecastRep = salesForecastDetailList;
        }

        public void CleargridViewSalesForecastSummary()
        {
            gridViewSalesForecastSummary.DataSource = null;
            gridViewSalesForecastSummary.DataBind();
        }

        public DataTable GridConvertDatatable(List<Biz_SalesForecastDetail> salesForecastDetailList)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();

            dt.Columns.Add("salesForecast");
            dt.Columns.Add("Code");
            dt.Columns.Add("Description");
            dt.Columns.Add("Type");
            dt.Columns.Add("Value [LKR]");
            dt.Columns.Add("Quantity");
            dt.Columns.Add("UnitofMeasure");

            foreach (Biz_SalesForecastDetail salesForecastDetail in salesForecastDetailList)
            {
                DataRow dr;
                dr = dt.NewRow();

                dr[0] = salesForecastDetail.Biz_SalesForecasts != null ? salesForecastDetail.Biz_SalesForecasts.Description : "";
                dr[1] = salesForecastDetail.Biz_Products != null ? salesForecastDetail.Biz_Products.Code : "";
                dr[2] = salesForecastDetail.Biz_Products != null ? salesForecastDetail.Biz_Products.Description : "";
                dr[3] = salesForecastDetail.Type == "V" ? "Value" : salesForecastDetail.Type == "Q" ? "Quantity" : "";
                dr[4] = salesForecastDetail.Value;
                dr[5] = salesForecastDetail.Quantity;
                dr[6] = salesForecastDetail.Biz_UnitOfMeasures != null ? salesForecastDetail.Biz_UnitOfMeasures.Description : "";

                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
            string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            ds.WriteXmlSchema(path + @"\Forecast.xml");
            return dt;
        }

        #endregion

        #region "Events"

        public void dropDownListSalesForecast_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSalesForecastDetail();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListSubProductCategory();
            DataBindTodropDownListSubProductCategory();
            GetSalesForecastDetail();
        }

        public void dropDownListSubProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetSalesForecastDetail();
        }

        public void gridViewSalesForecastSummary_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSalesForecastSummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GetSalesForecastDetail();
            gridViewSalesForecastSummary.PageIndex = e.NewPageIndex;
            gridViewSalesForecastSummary.DataBind();
        }

        public void buttonPrint_Click(object sender, EventArgs e)
        {
            if (gridViewSalesForecastSummary.HeaderRow.Cells.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
              "window.open( '../ReportCenter/iReporter/iForecastSummery.aspx' );", true);

            }
            else
            {
                FlashText1.Display("No Records to print", "okmessage");
            }
        }

        public void buttonCancel_Click(object sender, EventArgs e)
        {
            CleardropDownListSalesForecast();
            CleardropDownListProductCategory();
            CleardropDownListSubProductCategory();
            DataBindTodropDownListSalesForecast();
            DataBindTodropDownListProductCategory();
            GetSalesForecastDetail();
        }

        #endregion
    }
}