using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.Service.Reports;
using BzFlexer.SAMS.WebView.Home;
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
    public partial class BizSalesSummery : System.Web.UI.Page
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
            GetDataTodropDownListSalesPerson();
            DataBindTodropDownListProductCategory();
            DataBindTodropDownListSubProductCat();
            GetDataTodropDownListProduct();
            DataBindTodropDownListSalesTarget();
            GetSalesSummaryDetails();
        }

        public void ClearData()
        {
            CleardropDownListBranch();
            CleardropDownListSalesPerson();
            CleardropDownListProductCategory();
            CleardropDownListSubProductCat();
            CleardropDownListProduct();
            CleardropDownListSalesTarget();
        }

        public void DataBindTodropDownListBranch()
        {
            try
            {
                Biz_BranchService branchService = new Biz_BranchService();

                dropDownListBranch.DataSource = branchService.ReadAllBranch();
                dropDownListBranch.DataValueField = "Id";
                dropDownListBranch.DataTextField = "Description";
                dropDownListBranch.DataBind();
                dropDownListBranch.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }

        public void CleardropDownListBranch()
        {
            dropDownListBranch.Items.Clear();
            dropDownListBranch.Items.Add("-Select-");
        }

        public void GetDataTodropDownListSalesPerson()
        {
            Biz_BranchSalesAgentService branchSelesRepService = new Biz_BranchSalesAgentService();
            List<Biz_Stakeholder> branchSelesRepList = new List<Biz_Stakeholder>();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                branchSelesRepList = branchSelesRepService.ReadBranchSalesAgentsByBranchWise(Convert.ToInt16(dropDownListBranch.SelectedValue));
            }
            else
            {
                branchSelesRepList = branchSelesRepService.ReadAllSalesPerson();
            }

            DataBindTodropDownListSalesPerson(branchSelesRepList);

        }

        public void DataBindTodropDownListSalesPerson(List<Biz_Stakeholder> branchSelesRepList)
        {
            dropDownListSalesPerson.DataSource = branchSelesRepList;
            dropDownListSalesPerson.DataTextField = "FullName";
            dropDownListSalesPerson.DataValueField = "Id";
            dropDownListSalesPerson.DataBind();
        }

        public void CleardropDownListSalesPerson()
        {
            dropDownListSalesPerson.Items.Clear();
            dropDownListSalesPerson.Items.Add("-Select-");
        }

        public void DataBindTodropDownListProductCategory()
        {
            try
            {
                Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

                dropDownListProductCategory.DataSource = productCategoryService.ReadAllProductCategory();
                dropDownListProductCategory.DataValueField = "Id";
                dropDownListProductCategory.DataTextField = "Description";
                dropDownListProductCategory.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        public void CleardropDownListProductCategory()
        {
            dropDownListProductCategory.Items.Clear();
            dropDownListProductCategory.Items.Add("-Select-");
        }

        public void DataBindTodropDownListSubProductCat()
        {
            try
            {
                Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();

                if (dropDownListProductCategory.SelectedIndex > 0)
                {
                    dropDownListSubProductCat.DataSource = subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
                    dropDownListSubProductCat.DataValueField = "Id";
                    dropDownListSubProductCat.DataTextField = "Description";
                    dropDownListSubProductCat.DataBind();
                }
                else
                {
                    CleardropDownListSubProductCat();
                }
            }
            catch (Exception exception)
            {

            }
        }

        public void CleardropDownListSubProductCat()
        {
            dropDownListSubProductCat.Items.Clear();
            dropDownListSubProductCat.Items.Add("-Select-");
        }

        public void GetDataTodropDownListProduct()
        {
            Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();
            List<Biz_Product> products = new List<Biz_Product>();

            products = generalProductService.ReadAllProduct();
            if (dropDownListBranch.SelectedIndex > 0)
            {
                products = new Biz_InventoryItemService().ReadProductByBranchId(Convert.ToInt16(dropDownListBranch.SelectedValue));
            }
            if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCat.SelectedIndex < 1)
            {
                products = (from product in products
                            where
                                product.Id == Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                            select product).ToList();
            }
            if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCat.SelectedIndex > 0)
            {
                products = (from product in products
                            where
                                product.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue) && product.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCat.SelectedValue)
                            select product).ToList();
            }

            if (products != null)
            {
                CleardropDownListProduct();
                DataBindTodropDownListProduct(products);
            }
            else
            {
                CleardropDownListProduct();
            }
        }

        public void CleardropDownListProduct()
        {
            dropDownListProduct.Items.Clear();
            dropDownListProduct.Items.Add("-Select-");
        }

        public void DataBindTodropDownListProduct(List<Biz_Product> products)
        {
            dropDownListProduct.DataSource = products;
            dropDownListProduct.DataValueField = "Id";
            dropDownListProduct.DataTextField = "Description";
            dropDownListProduct.DataBind();
        }

        public void DataBindTodropDownListSalesTarget()
        {
            List<Biz_SalesTarget> salesTargets = new List<Biz_SalesTarget>();
            salesTargets = new Biz_SalesTargetService().ReadAllSalesTargets();

            dropDownListSalesTarget.DataSource = salesTargets;
            dropDownListSalesTarget.DataTextField = "Description";
            dropDownListSalesTarget.DataValueField = "Id";
            dropDownListSalesTarget.DataBind();
        }

        public void CleardropDownListSalesTarget()
        {
            dropDownListSalesTarget.Items.Clear();
            dropDownListSalesTarget.Items.Add("-Select-");
        }

        public void GetSalesSummaryDetails()
        {
            List<Biz_Invoice> invoiceList = new List<Biz_Invoice>();

            invoiceList = new Biz_SalesSummeryService().ReadAllSalesSummary();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                invoiceList =
                    (from invoice in invoiceList
                     where invoice.IdBranch == Convert.ToInt16(dropDownListBranch.SelectedValue)
                     select invoice).ToList();
            }
            if (dropDownListSalesPerson.SelectedIndex > 0)
            {
                invoiceList =
                    (from invoice in invoiceList
                     where invoice.IdSalesPerson == Convert.ToInt16(dropDownListSalesPerson.SelectedValue)
                     select invoice).ToList();
            }
            if (dropDownListProductCategory.SelectedIndex > 0)
            {
                invoiceList =
                    (from invoice in invoiceList
                     where invoice.Biz_BranchProducts.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                     select invoice).ToList();
            }
            if (dropDownListSubProductCat.SelectedIndex > 0)
            {
                invoiceList =
                    (from invoice in invoiceList
                     where invoice.Biz_BranchProducts.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListSubProductCat.SelectedValue)
                     select invoice).ToList();
            }
            if (dropDownListProduct.SelectedIndex > 0)
            {
                invoiceList =
                    (from invoice in invoiceList
                     where invoice.Biz_BranchProducts.Biz_Products.Id == Convert.ToInt16(dropDownListProduct.SelectedValue)
                     select invoice).ToList();
            }
            if (dropDownListSalesTarget.SelectedIndex > 0)
            {
                invoiceList =
                    (from invoice in invoiceList
                     where invoice.IdSalesTarget == Convert.ToInt16(dropDownListSalesTarget.SelectedValue)
                     select invoice).ToList();
            }

            DataBindTogridViewSalesSummary(invoiceList);
        }

        public void DataBindTogridViewSalesSummary(List<Biz_Invoice> invoiceList)
        {
            DataTable dt = GridConvertDatatable(invoiceList);
            Session[Key.SalesSummary] = dt;
            gridViewSalesSummary.DataSource = null;
            gridViewSalesSummary.DataSource = dt;
            gridViewSalesSummary.DataBind();
            //report
            WebView.Home.Global.dtSales = dt;
        }

        public DataTable GridConvertDatatable(List<Biz_Invoice> invoices)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("InvoiceId");
            dt.Columns.Add("Branch");
            dt.Columns.Add("Product");
            dt.Columns.Add("ItemCode");
            dt.Columns.Add("PriceBook");
            dt.Columns.Add("SalesTarget");
            dt.Columns.Add("Gross", typeof(decimal));
            dt.Columns.Add("Discount", typeof(decimal));
            dt.Columns.Add("Net", typeof(decimal));
            dt.Columns.Add("InvoiceNo");
            dt.Columns.Add("Commission", typeof(decimal));


            foreach (Biz_Invoice invoice in invoices)
            {
                DataRow dr;
                dr = dt.NewRow();

                dr[0] = invoice.Id;
                dr[1] = invoice.Biz_Branches != null ? invoice.Biz_Branches.Code : "";
                dr[2] = invoice.Biz_BranchProducts.Biz_Products != null ? invoice.Biz_BranchProducts.Biz_Products.Description : "";
                dr[3] = invoice.Biz_InventoryItems != null ? invoice.Biz_InventoryItems.CodeInventoryItem : "";
                dr[4] = invoice.Biz_BranchPriceBooks.Biz_PriceBooks != null ? invoice.Biz_BranchPriceBooks.Biz_PriceBooks.Code : "";
                dr[5] = invoice.Biz_SalesTargets != null ? invoice.Biz_SalesTargets.Code : "-";
                dr[6] = invoice.Total_Value;
                dr[7] = invoice.Discount_Value;
                dr[8] = invoice.Total_Value - invoice.Discount_Value;
                dr[9] = invoice.Biz_SalesTransactions != null ? invoice.Biz_SalesTransactions.Invoice_No : "";
                dr[10] = invoice.Commission_Value;

                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion

        #region "Events"

        public void gridViewSalesSummary_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSalesSummary_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GetSalesSummaryDetails();
            gridViewSalesSummary.PageIndex = e.NewPageIndex;
            gridViewSalesSummary.DataBind();
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CleardropDownListSalesPerson();
                GetDataTodropDownListSalesPerson();
                GetSalesSummaryDetails();
            }
            catch (Exception exception)
            { }
        }

        public void dropDownListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetSalesSummaryDetails();
            }
            catch (Exception exception)
            { }
        }

        public void dropDownListSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetSalesSummaryDetails();
            }
            catch (Exception exception)
            { }
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CleardropDownListSubProductCat();
                DataBindTodropDownListSubProductCat();
                GetSalesSummaryDetails();
            }
            catch (Exception exception)
            { }
        }

        public void dropDownListSubProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CleardropDownListProduct();
                GetDataTodropDownListProduct();
                GetSalesSummaryDetails();
            }
            catch (Exception exception)
            { }
        }

        public void dropDownListSalesTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GetSalesSummaryDetails();
            }
            catch (Exception exception)
            { }
        }

        public void buttonPrint_Click(object sender, EventArgs e)
        {
            if (gridViewSalesSummary.HeaderRow.Cells.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
              "window.open( '../ReportCenter/iReporter/iSalesSummery.aspx' );", true);

            }
            else
            {
                FlashText1.Display("No Records to print", "okmessage");
            }
        }

        public void buttonCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            fillData();
        }

        #endregion

    }
}