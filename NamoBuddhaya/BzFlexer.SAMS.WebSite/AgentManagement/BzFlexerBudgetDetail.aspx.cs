using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.AgentManagement
{
    public partial class BzFlexerBudgetDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListBranch();
                DataBindTodropDownListSalesBudget();
                DataBindTodropDownListProductCategory();
                LoadGridData();
            }
        }

        #region "Load Data"

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
            { }
        }

        public void DataBindTodropDownListSalesBudget()
        {
            try
            {
                Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();
                dropDownListSalesBudget.DataSource = salesBudgetService.ReadAllSalesBudgets();
                dropDownListSalesBudget.DataValueField = "Id";
                dropDownListSalesBudget.DataTextField = "Description";
                dropDownListSalesBudget.DataBind();
                dropDownListSalesBudget.SelectedIndex = 0;
            }
            catch (Exception exception)
            { }
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
                dropDownListProductCategory.SelectedIndex = 0;
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTodropDownListSubProductCategory()
        {
            try
            {
                Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();
                if (dropDownListProductCategory.SelectedValue != "")
                {
                    dropDownListSubProductCategory.DataSource =
                        subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
                    dropDownListSubProductCategory.DataValueField = "Id";
                    dropDownListSubProductCategory.DataTextField = "Description";
                    dropDownListSubProductCategory.DataBind();
                    dropDownListSubProductCategory.SelectedIndex = 0;
                }
            }
            catch (Exception exception)
            { }
        }

        public void LoadGridData()
        {
            DataBindTogridViewAllProductByBranchIDAnndSalesBudgetId();
        }

        public void DataBindTogridViewAllProductByBranchIDAnndSalesBudgetId()
        {
            Biz_SalesBudgetDetailsService salesBudgetDetailService = new Biz_SalesBudgetDetailsService();
            List<Biz_Product> products = new List<Biz_Product>();

            if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesBudget.SelectedIndex > 0)
            {
                products = salesBudgetDetailService.ReadUnmappedProductBybranchIdsalesBudgetId(Convert.ToInt16(dropDownListBranch.SelectedValue), Convert.ToInt16(dropDownListSalesBudget.SelectedValue));
                if (dropDownListProductCategory.SelectedIndex > 0)
                {
                    products = (from prd in products where prd.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue) select prd).ToList();
                }
                if (dropDownListSubProductCategory.SelectedIndex > 0)
                {
                    products = (from prd in products where prd.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue) select prd).ToList();
                }
                DataBindTogridViewMappedProducts();
                DataBindgridViewAllProducts(products);
            }
            else
            {
                CleargridViewAllProducts();
                CleardgridViewMappedProducts();
            }

        }

        public void CleargridViewAllProducts()
        {
            gridViewAllProducts.DataSource = null;
            gridViewAllProducts.DataBind();
        }

        public void CleardgridViewMappedProducts()
        {
            gridViewMappedProducts.DataSource = null;
            gridViewMappedProducts.DataBind();
        }

        public void DataBindTogridViewMappedProducts()
        {
            try
            {
                Biz_SalesBudgetDetailsService salesBudgetDetailService = new Biz_SalesBudgetDetailsService();
                gridViewMappedProducts.DataSource = salesBudgetDetailService.ReadSalesBudgetDetailbyBranchBudget(
                        Convert.ToInt16(dropDownListBranch.SelectedValue),
                        Convert.ToInt16(dropDownListSalesBudget.SelectedValue)); ;
                gridViewMappedProducts.DataBind();
                SelectUnitofMeasureValue();
            }
            catch (Exception exception)
            { }
        }

        public void DataBindgridViewAllProducts(List<Biz_Product> products)
        {
            try
            {
                gridViewAllProducts.DataSource = products;
                gridViewAllProducts.DataBind();
            }
            catch (Exception exception)
            { }
        }

        public void SelectUnitofMeasureValue()
        {
            try
            {
                for (int i = 0; i < gridViewMappedProducts.Rows.Count + 1; i++)
                {
                    Biz_SalesBudgetDetail salesBudgetDetail = new Biz_SalesBudgetDetail();
                    salesBudgetDetail =
                        new Biz_SalesBudgetDetailsService().ReadSalesBudgetDetailbyId(Convert.ToInt16(gridViewMappedProducts.Rows[i].Cells[1].Text.Trim()));
                    var unitofmeasureId = salesBudgetDetail.IdUnitOfMeasure;

                    DropDownList downList;
                    downList = (DropDownList)
                                gridViewMappedProducts.Rows[i].Cells[3].FindControl("dropDownListType");

                    if (downList.SelectedValue == "Q")
                    {
                        downList =
                            (DropDownList)
                            gridViewMappedProducts.Rows[i].Cells[6].FindControl(
                                "dropDownListUnitOfMeasure");

                        downList.SelectedValue = unitofmeasureId.ToString();
                    }
                }

            }
            catch (Exception exception)
            { }
        }

        #endregion

        #region "Operations"

        public void AddSalesBudgetDetail()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllProducts.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_SalesBudgetDetailsService salesBudgetDetailService = new Biz_SalesBudgetDetailsService();
                            Biz_SalesBudgetDetail salesBudgetDetail = new Biz_SalesBudgetDetail();

                            salesBudgetDetail.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                            salesBudgetDetail.IdSalesBudget = Convert.ToInt16(dropDownListSalesBudget.SelectedValue);
                            salesBudgetDetail.IdProduct = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            salesBudgetDetail.Type = "0";
                            salesBudgetDetail.Value = 0;
                            salesBudgetDetail.Quantity = 0;
                            salesBudgetDetail.IdUnitOfMeasure = 0;
                            salesBudgetDetail.DateCreated = DateTime.Now;
                            salesBudgetDetail.DateModified = DateTime.Now;

                            salesBudgetDetailService.CreateSalesBudgetDetail(salesBudgetDetail);
                            FlashText1.Display("Record(s) Successfully Added.", "okmessage");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Adding Failed.", "okmessage");
            }
        }

        public void ModifySalesBudgetDetail()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesBudgetDetailsService salesBudgetDetailService = new Biz_SalesBudgetDetailsService();
                    Biz_SalesBudgetDetail salesBudgetDetail = new Biz_SalesBudgetDetail();
                    DropDownList downList;
                    TextBox textBox;
                    Label label;
                    for (int i = 0; i < gridViewMappedProducts.Rows.Count; i++)
                    {

                        salesBudgetDetail =
                            salesBudgetDetailService.ReadSalesBudgetDetailbyId(Convert.ToInt16(gridViewMappedProducts.Rows[i].Cells[1].Text.Trim()));
                        salesBudgetDetail.Id =
                            Convert.ToInt16(gridViewMappedProducts.Rows[i].Cells[1].Text.Trim());
                        if (dropDownListSalesBudget.SelectedIndex > 0)
                        {
                            salesBudgetDetail.IdSalesBudget = Convert.ToInt16(dropDownListSalesBudget.SelectedValue);
                        }
                        if (dropDownListBranch.SelectedIndex > 0)
                        {
                            salesBudgetDetail.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                        }
                        label = (Label)gridViewMappedProducts.Rows[i].Cells[7].FindControl("LabelProductId");
                        if (label != null)
                        {
                            if (label.Text != String.Empty)
                            {
                                salesBudgetDetail.IdProduct = Convert.ToInt16((label.Text.Trim()));
                            }
                        }

                        downList = (DropDownList)gridViewMappedProducts.Rows[i].Cells[3].FindControl("dropDownListType");
                        if (downList.SelectedIndex > 0)
                        {
                            salesBudgetDetail.Type = downList.SelectedValue;
                            if (downList.SelectedValue == "V")
                            {
                                textBox = (TextBox)gridViewMappedProducts.Rows[i].Cells[4].FindControl("textBoxValue");
                                if (textBox != null)
                                {
                                    if (textBox.Text != string.Empty && textBox.Text.Trim() != "0")
                                    {
                                        salesBudgetDetail.Value = Convert.ToDecimal(textBox.Text);
                                    }
                                }
                            }
                            if (downList.SelectedValue == "Q")
                            {
                                textBox = (TextBox)gridViewMappedProducts.Rows[i].Cells[5].FindControl("textBoxQuantity");
                                if (textBox != null)
                                {
                                    if (textBox.Text != string.Empty && textBox.Text.Trim() != "0")
                                    {
                                        salesBudgetDetail.Quantity = Convert.ToDecimal(textBox.Text);
                                    }
                                }

                                downList =
                                    (DropDownList)
                                    gridViewMappedProducts.Rows[i].Cells[6].FindControl("dropDownListUnitOfMeasure");
                                if (downList != null)
                                {
                                    if (downList.SelectedIndex > 0)
                                    {
                                        salesBudgetDetail.IdUnitOfMeasure = Convert.ToInt16(downList.SelectedValue);
                                    }
                                }
                            }
                        }
                        salesBudgetDetail.DateModified = DateTime.Now;
                        salesBudgetDetailService.UpdateSalesBudgetDetail(salesBudgetDetail);

                    }
                   FlashText1.Display("Record(s) Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Saving Failed.", "errormessage");
            }
        }

        public void DeleteSalesBudgetDetail()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedProducts.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_SalesBudgetDetailsService salesBudgetDetailService = new Biz_SalesBudgetDetailsService();
                            salesBudgetDetailService.DeleteSalesBudgetDetails(Convert.ToInt16(gridViewRow.Cells[1].Text.Trim()));
                           FlashText1.Display("Record(s) Successfully Deleted.", "okmessage");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Deleting Failed.", "errormessage");
            }
        }

        #endregion

        #region "Events"

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddSalesBudgetDetail();
                LoadGridData();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldRemove())
            {
                DeleteSalesBudgetDetail();
                LoadGridData();
            }
        }

        public void buttonSave_lick(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldModify())
            {
                ModifySalesBudgetDetail();
                LoadGridData();
            }
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        public void dropDownListSalesBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindTodropDownListSubProductCategory();
            LoadGridData();
        }

        public void dropDownListSubProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        public void gridViewAllProducts_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedProducts_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
        }

        public void TextBox_TextChange(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text != String.Empty)
            {
                textBox.Text = String.Format("{0:0.00}", textBox.Text);
            }

        }

        public void dropDownListType_SelectedIndexChanged(object sender, EventArgs e)
        {
            TextBox textBox;
            TextBox textBoxnull;
            DropDownList downList = (DropDownList)sender;
            GridViewRow gridViewRow = (GridViewRow)(((DropDownList)sender).Parent.Parent);

            textBox = (TextBox)gridViewRow.Cells[4].FindControl("textBoxValue");
            if (textBox != null)
            {
                textBox.Enabled = false;
            }
            textBox = (TextBox)gridViewRow.Cells[5].FindControl("textBoxQuantity");
            if (textBox != null)
            {
                textBox.Enabled = false;
            }
            DropDownList downListUOM;
            downListUOM = (DropDownList)gridViewRow.Cells[6].FindControl("dropDownListUnitOfMeasure");
            if (downListUOM != null)
            {
                downListUOM.Enabled = false;
            }
            if (downList.SelectedValue == "V")
            {
                textBoxnull = (TextBox)gridViewRow.Cells[5].FindControl("textBoxQuantity");
                textBoxnull.Text = string.Empty;
                downListUOM.SelectedIndex = 0;
                textBox = (TextBox)gridViewRow.Cells[4].FindControl("textBoxValue");
                if (textBox != null)
                {
                    textBox.Enabled = true;
                }

            }
            if (downList.SelectedValue == "Q")
            {
                textBoxnull = (TextBox)gridViewRow.Cells[4].FindControl("textBoxValue");
                textBoxnull.Text = string.Empty;
                textBox = (TextBox)gridViewRow.Cells[5].FindControl("textBoxQuantity");
                if (textBox != null)
                {
                    textBox.Enabled = true;
                }
                downListUOM = (DropDownList)gridViewRow.Cells[6].FindControl("dropDownListUnitOfMeasure");
                if (downListUOM != null)
                {
                    downListUOM.Enabled = true;
                }
            }
        }

        public void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in ((GridView)((CheckBox)sender).Parent.Parent.Parent.Parent).Rows)
            {
                ((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked = ((CheckBox)sender).Checked;
            }
        }

        public void gridViewMappedProducts_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ((TextBox)e.Row.Cells[4].FindControl("textBoxValue")).Attributes.Add("style", "text-align:right");
                ((TextBox)e.Row.Cells[4].FindControl("textBoxValue")).Attributes.Add("onkeypress", "javascript:return handleNumbersOnly(event,this)");
                ((TextBox)e.Row.Cells[5].FindControl("textBoxQuantity")).Attributes.Add("style", "text-align:right");
                ((TextBox)e.Row.Cells[5].FindControl("textBoxQuantity")).Attributes.Add("onkeypress", "javascript:return handleNumbersOnly(event,this)");
            }
            foreach (GridViewRow gridViewRow in gridViewMappedProducts.Rows)
            {
                DropDownList downList =
                    ((DropDownList)gridViewRow.Cells[6].FindControl("DropDownListUnitOfMeasure"));
                if (downList != null)
                {

                    Biz_UnitOfMeasureService unitOfMeasureService = new Biz_UnitOfMeasureService();
                    downList.DataSource = unitOfMeasureService.ReadAllUnitOfMeasure();
                    downList.DataValueField = "Id";
                    downList.DataTextField = "Description";
                    downList.DataBind();
                }
            }

        }

        public void gridViewAllProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadGridData();
            gridViewAllProducts.PageIndex = e.NewPageIndex;
            gridViewAllProducts.DataBind();
        }

        public void gridViewMappedProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadGridData();
            gridViewMappedProducts.PageIndex = e.NewPageIndex;
            gridViewMappedProducts.DataBind();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (dropDownListBranch.SelectedValue == string.Empty)
            {
               FlashText1.Display("Branch is not Selected.", "errormessage");
                return false;
            }
            if (dropDownListSalesBudget.SelectedValue == string.Empty)
            {
               FlashText1.Display("Sales Budget is not Selected.", "errormessage");
                return false;
            }

            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewAllProducts.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
               FlashText1.Display("Product(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldModify()
        {
            Biz_SalesBudgetDetail salesBudgetDetail = new Biz_SalesBudgetDetail();
            DropDownList downList;
            TextBox textBox;

            for (int i = 0; i < gridViewMappedProducts.Rows.Count; i++)
            {
                downList = (DropDownList)gridViewMappedProducts.Rows[i].Cells[3].FindControl("dropDownListType");
                if (downList.SelectedIndex > 0)
                {
                    salesBudgetDetail.Type = downList.SelectedValue;
                    if (downList.SelectedValue == "V")
                    {
                        textBox = (TextBox)gridViewMappedProducts.Rows[i].Cells[4].FindControl("textBoxValue");
                        if (textBox.Text == string.Empty || textBox.Text.Trim() == "0")
                        {
                           FlashText1.Display("Value Cannot be Blank.", "errormessage");
                            return false;
                        }
                    }
                    if (downList.SelectedValue == "Q")
                    {
                        textBox = (TextBox)gridViewMappedProducts.Rows[i].Cells[5].FindControl("textBoxQuantity");
                        if (textBox.Text == string.Empty || textBox.Text.Trim() == "0")
                        {
                           FlashText1.Display("Quantity Cannot be Blank.", "errormessage");
                            return false;
                        }

                        downList =
                            (DropDownList)
                            gridViewMappedProducts.Rows[i].Cells[6].FindControl("dropDownListUnitOfMeasure");
                        if (downList != null)
                        {
                            if (downList.SelectedIndex < 1)
                            {
                               FlashText1.Display("No Unit of Measure is Selected.", "errormessage");
                                return false;
                            }
                        }
                    }
                }
                if (downList.SelectedIndex < 1)
                {
                   FlashText1.Display("No Type is Selected.", "errormessage");
                    return false;
                }
            }
            return true;
        }

        private Boolean CheckMandatoryFieldRemove()
        {

            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewMappedProducts.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
               FlashText1.Display("Product(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion

    }
}