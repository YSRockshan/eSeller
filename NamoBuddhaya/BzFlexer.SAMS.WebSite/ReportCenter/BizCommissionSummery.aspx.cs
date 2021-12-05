using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
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
    public partial class BizCommissionSummery : System.Web.UI.Page
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
            GetDataToDropDownListSalesPerson();
            DataBindTodropDownListProductCategory();
            GetDataTodropDownListProduct();
            GetCommissionSummeryDetails();
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

        public void GetDataToDropDownListSalesPerson()
        {
            Biz_BranchSalesAgentService branchSelesRepService = new Biz_BranchSalesAgentService();
            List<Biz_Stakeholder> branchSelesRepList = new List<Biz_Stakeholder>();
            branchSelesRepList = null;

            if (dropDownListBranch.SelectedIndex > 0)
            {
                branchSelesRepList = branchSelesRepService.ReadBranchSalesAgentsByBranchWise(Convert.ToInt16(dropDownListBranch.SelectedValue));
            }
            else
            {
                branchSelesRepList = branchSelesRepService.ReadAllSalesPerson();
            }

            DataBindToDropDownListSalesPerson(branchSelesRepList);
        }

        public void DataBindToDropDownListSalesPerson(List<Biz_Stakeholder> branchSelesRepList)
        {
            dropDownListSalesPerson.DataSource = branchSelesRepList;
            dropDownListSalesPerson.DataTextField = "FullName";
            dropDownListSalesPerson.DataValueField = "Id";
            dropDownListSalesPerson.DataBind();
        }

        public void DataBindTodropDownListProductCategory()
        {
            Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

            dropDownListProductCategory.DataSource = null;
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
                dropDownListSubProductCategory.DataSource = null;
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

        public void GetDataTodropDownListProduct()
        {
            Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();
            List<Biz_Product> products = new List<Biz_Product>();

            if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                products = generalProductService.ReadGeneralProductByProductCat(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
            }
            if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex > 0)
            {
                products = generalProductService.ReadAllGeneralProductByProductCategoryAndSubProductCategory(Convert.ToInt16(dropDownListProductCategory.SelectedValue), Convert.ToInt16(dropDownListSubProductCategory.SelectedValue));
            }
            else if (dropDownListProductCategory.SelectedIndex < 1 && dropDownListSubProductCategory.SelectedIndex < 1)
            {
                products = generalProductService.ReadAllProduct();
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

        public void DataBindTodropDownListProduct(List<Biz_Product> products)
        {
            dropDownListProduct.DataSource = null;
            dropDownListProduct.DataSource = products;
            dropDownListProduct.DataValueField = "Id";
            dropDownListProduct.DataTextField = "Description";
            dropDownListProduct.DataBind();
        }

        //Clear Data
        public void CleardropDownListBranch()
        {
            dropDownListBranch.Items.Clear();
            dropDownListBranch.Items.Add("-Select-");
        }

        public void CleardropDownListSalesPerson()
        {
            dropDownListSalesPerson.Items.Clear();
            dropDownListSalesPerson.Items.Add("-Select-");
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

        public void CleardropDownListProduct()
        {
            dropDownListProduct.Items.Clear();
            dropDownListProduct.Items.Add("-Select-");
        }


        public void GetCommissionSummeryDetails()
        {
            List<Biz_MemberCommssionDetail> memberCommssionDetailList = new List<Biz_MemberCommssionDetail>();

            memberCommssionDetailList = new Biz_MemberCommssionDetailsService().ReadAllMemberCommssionDetails();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                memberCommssionDetailList = (from memberCommssionDetail in memberCommssionDetailList
                                             where
                                                 memberCommssionDetail.IdBranch ==
                                                 Convert.ToInt16(dropDownListBranch.SelectedValue)
                                             select memberCommssionDetail).ToList();
            }

            if (dropDownListSalesPerson.SelectedIndex > 0)
            {
                memberCommssionDetailList = (from memberCommssionDetail in memberCommssionDetailList
                                             where
                                                 memberCommssionDetail.IdSalesAgent ==
                                                 Convert.ToInt16(dropDownListSalesPerson.SelectedValue)
                                             select memberCommssionDetail).ToList();
            }

            if (dropDownListProductCategory.SelectedIndex > 0)
            {
                memberCommssionDetailList = (from memberCommssionDetail in memberCommssionDetailList
                                             where memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                                             select memberCommssionDetail).ToList();
            }

            if (dropDownListSubProductCategory.SelectedIndex > 0)
            {
                memberCommssionDetailList = (from memberCommssionDetail in memberCommssionDetailList
                                             where memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue)
                                             select memberCommssionDetail).ToList();
            }

            if (dropDownListProduct.SelectedIndex > 0)
            {
                memberCommssionDetailList = (from memberCommssionDetail in memberCommssionDetailList
                                             where memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.IdProduct == Convert.ToInt16(dropDownListProduct.SelectedValue)
                                             select memberCommssionDetail).ToList();
            }

            DataBindTogridViewSalesCommissionSummary(memberCommssionDetailList);
        }

        public void DataBindTogridViewSalesCommissionSummary(List<Biz_MemberCommssionDetail> memberCommssionDetailList)
        {
            DataTable dt = GridConvertDatatable(memberCommssionDetailList);
            Session[Key.CommissionSummary] = dt;
            gridViewSalesCommissionSummary.DataSource = null;
            gridViewSalesCommissionSummary.DataSource = dt;
            gridViewSalesCommissionSummary.DataBind();
            //report
            WebView.Home.Global.dtCommssion = dt;
        }

        public DataTable GridConvertDatatable(List<Biz_MemberCommssionDetail> memberCommssionDetailList)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("MemberCommssionDetailId");
            dt.Columns.Add("BranchId");
            dt.Columns.Add("Branch");
            dt.Columns.Add("SalesRepId");
            dt.Columns.Add("SalesPerson");
            dt.Columns.Add("Commission", typeof(decimal));
            dt.Columns.Add("TargetCommission", typeof(decimal));
            dt.Columns.Add("TotalCommission", typeof(decimal));
            dt.Columns.Add("CommissionDate");
            dt.Columns.Add("Seq");
            dt.Columns.Add("InvoiceNo");
            dt.Columns.Add("Product");
            dt.Columns.Add("ItemCode");
            dt.Columns.Add("ProductCategoryId");
            dt.Columns.Add("SubProductCategoryId");
            dt.Columns.Add("SalesTarget");


            foreach (Biz_MemberCommssionDetail memberCommssionDetail in memberCommssionDetailList)
            {
                DataRow dr;
                dr = dt.NewRow();

                dr[0] = memberCommssionDetail.Id;
                dr[1] = memberCommssionDetail.IdBranch;
                dr[2] = memberCommssionDetail.Biz_Branches != null ? memberCommssionDetail.Biz_Branches.Code : "";
                dr[3] = memberCommssionDetail.IdSalesAgent;
                dr[4] = memberCommssionDetail.Biz_Stakeholders != null ? memberCommssionDetail.Biz_Stakeholders.Initial.Trim() + " " + memberCommssionDetail.Biz_Stakeholders.LastName.Trim() : "";
                dr[5] = memberCommssionDetail.Commission;

                if (memberCommssionDetail.Commission != null)
                {
                    dr[5] = memberCommssionDetail.Commission;
                }
                if (memberCommssionDetail.Target_Commission != null)
                {
                    dr[6] = memberCommssionDetail.Target_Commission;
                }
                if (memberCommssionDetail.Total_Commission != null)
                {
                    dr[7] = memberCommssionDetail.Total_Commission;
                }

                dr[8] = memberCommssionDetail.Date_Commission.ToShortDateString();
                dr[9] = memberCommssionDetail.SequenceNumber;
                dr[10] = memberCommssionDetail.Biz_SalesTransactions != null ? memberCommssionDetail.Biz_SalesTransactions.Invoice_No : "";
                dr[11] = memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.Biz_Products != null ? memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.Biz_Products.Description : "";
                dr[12] = memberCommssionDetail.Biz_Invoices.Biz_InventoryItems != null ? memberCommssionDetail.Biz_Invoices.Biz_InventoryItems.CodeInventoryItem : "";
                dr[13] = memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.Biz_Products != null ? memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.Biz_Products.IdProductCategory : 0;
                dr[14] = memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.Biz_Products != null ? memberCommssionDetail.Biz_Invoices.Biz_BranchProducts.Biz_Products.IdSubProductCategory : 0;
                dr[15] = memberCommssionDetail.Biz_Invoices.Biz_SalesTargets != null ? memberCommssionDetail.Biz_Invoices.Biz_SalesTargets.Code : "-";

                dt.Rows.Add(dr);
            }
            return dt;
        }

        #endregion

        #region "operations"


        #endregion

        #region "Events"

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListSubProductCategory();
            DataBindTodropDownListSubProductCategory();
            GetCommissionSummeryDetails();
        }

        public void dropDownListSubProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListProduct();
            GetDataTodropDownListProduct();
            GetCommissionSummeryDetails();
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
            GetCommissionSummeryDetails();
            gridViewSalesCommissionSummary.PageIndex = e.NewPageIndex;
            gridViewSalesCommissionSummary.DataBind();
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListSalesPerson();
            GetDataToDropDownListSalesPerson();
            GetCommissionSummeryDetails();
        }

        public void dropDownListProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCommissionSummeryDetails();
        }

        public void dropDownListSalesPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetCommissionSummeryDetails();
        }

        public void buttonPrint_Click(object sender, EventArgs e)
        {
            if (gridViewSalesCommissionSummary.HeaderRow.Cells.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
              "window.open( '../ReportCenter/iReporter/iCommissionSummery.aspx' );", true);

            }
            else
            {
                FlashText1.Display("No Records to print", "okmessage");
            }
        }

        public void buttonCancel_Click(object sender, EventArgs e)
        {
            CleardropDownListBranch();
            DataBindTodropDownListBranch();
            CleardropDownListSalesPerson();
            GetDataToDropDownListSalesPerson();
            CleardropDownListProductCategory();
            DataBindTodropDownListProductCategory();
            CleardropDownListSubProductCategory();
            CleardropDownListProduct();
            GetDataTodropDownListProduct();
            GetCommissionSummeryDetails();
        }


        #endregion
    }
}