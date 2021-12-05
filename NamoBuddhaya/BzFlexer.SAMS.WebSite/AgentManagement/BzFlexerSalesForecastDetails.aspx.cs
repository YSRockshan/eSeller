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
    public partial class BzFlexerSalesForecastDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListSalesForecast();
                DataBindTodropDownListProductCategory();
                LoadGridData();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListSalesForecast()
        {
            try
            {
                Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();
                dropDownListSalesForecast.DataSource = salesForecastService.ReadAllSalesForecast();
                dropDownListSalesForecast.DataValueField = "Id";
                dropDownListSalesForecast.DataTextField = "Description";
                dropDownListSalesForecast.DataBind();
                dropDownListSalesForecast.SelectedIndex = 0;
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
                if (dropDownListProductCategory.SelectedValue != "")
                {
                    Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();
                    dropDownListSubProductCategory.DataSource = subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
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
            DataBindTogridViewAllProductsBySalesForecastId();
            DataBindTogridViewMappedProductsBySalesForecastId();
        }

        public void DataBindTogridViewAllProductsBySalesForecastId()
        {
            Biz_SalesForecastDetailsService salesForecastDetailService = new Biz_SalesForecastDetailsService();
            List<Biz_Product> products = new List<Biz_Product>();

            if (dropDownListSalesForecast.SelectedIndex > 0)
            {
                products =
                    salesForecastDetailService.ReadUnMappedtProduct(
                        Convert.ToInt16(dropDownListSalesForecast.SelectedValue));
                if (dropDownListProductCategory.SelectedIndex > 0)
                {
                    products = (from prd in products where prd.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue) select prd).ToList();
                }
                if (dropDownListSubProductCategory.SelectedIndex > 0)
                {
                    products = (from prd in products where prd.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue) select prd).ToList();
                }

                DataBindTogridViewAllProducts(products);
            }
            else
            {
                ClearMappedSalesForecastProducts();
                CleargridViewAllProducts();
            }
        }

        public void DataBindTogridViewMappedProductsBySalesForecastId()
        {
            Biz_SalesForecastDetailsService salesForecastDetailService = new Biz_SalesForecastDetailsService();
            List<Biz_SalesForecastDetail> salesForecastDetails = new List<Biz_SalesForecastDetail>();

            if (dropDownListSalesForecast.SelectedIndex > 0)
            {
                salesForecastDetails =
                    salesForecastDetailService.ReadMappedSalesForecastDetail(
                        Convert.ToInt16(dropDownListSalesForecast.SelectedValue));
                if (dropDownListProductCategory.SelectedIndex > 0)
                {
                    salesForecastDetails = (from sfd in salesForecastDetails where sfd.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue) select sfd).ToList();
                }
                if (dropDownListSubProductCategory.SelectedIndex > 0)
                {
                    salesForecastDetails = (from sfd in salesForecastDetails where sfd.Biz_Products.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue) select sfd).ToList();
                }

                LoadMappedSalesForecastProducts(salesForecastDetails);

            }
            else
            {
                ClearMappedSalesForecastProducts();
                CleargridViewAllProducts();
            }
        }

        public void CleargridViewAllProducts()
        {
            gridViewAllProducts.DataSource = null;
            gridViewAllProducts.DataBind();
        }

        public void ClearMappedSalesForecastProducts()
        {
            gridViewMappedProducts.DataSource = null;
            gridViewMappedProducts.DataBind();
        }

        public void DataBindTogridViewAllProducts(List<Biz_Product> products)
        {
            try
            {
                gridViewAllProducts.DataSource = products;
                gridViewAllProducts.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        public void LoadMappedSalesForecastProducts(List<Biz_SalesForecastDetail> salesForecastDetails)
        {
            try
            {
                gridViewMappedProducts.DataSource = salesForecastDetails;
                gridViewMappedProducts.DataBind();
                SelectUnitofMeasureValue();
            }
            catch (Exception exception)
            {

            }
        }

        public void SelectUnitofMeasureValue()
        {
            try
            {
                for (int i = 0; i < gridViewMappedProducts.Rows.Count + 1; i++)
                {
                    Biz_SalesForecastDetail salesForecastDetail = new Biz_SalesForecastDetail();
                    salesForecastDetail =
                        new Biz_SalesForecastDetailsService().ReadSalesForecastDetailbyId(Convert.ToInt16(gridViewMappedProducts.Rows[i].Cells[1].Text.Trim()));
                    var unitofmeasureId = salesForecastDetail.IdUnitOfMeasure;

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
            catch (Exception)
            { }
        }

        #endregion

        #region "Operations"

        public void AddSalesForecastDetail()
        {
            try
            {
                Biz_SalesForecastDetailsService salesForecastDetailService = new Biz_SalesForecastDetailsService();
                Biz_SalesForecastDetail salesForecastDetail = new Biz_SalesForecastDetail();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllProducts.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            salesForecastDetail.IdProduct =
                                Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            salesForecastDetail.IdSalesForecast =
                                Convert.ToInt16(dropDownListSalesForecast.SelectedValue);
                            salesForecastDetail.Type = "0";
                            salesForecastDetail.Value = 0;
                            salesForecastDetail.Quantity = 0;
                            salesForecastDetail.IdUnitOfMeasure = null;
                            salesForecastDetail.DateCreated = DateTime.Now;
                            salesForecastDetail.DateModified = DateTime.Now;

                            salesForecastDetailService.CrateSalesForecastDetail(salesForecastDetail);
                           FlashText1.Display("Record(s) Successfully Added.", "okmessage");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Adding Failed.", "errormessage");
            }
        }

        public void ModifySalesForecastDetail()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesForecastDetailsService salesForecastDetailService = new Biz_SalesForecastDetailsService();
                    Biz_SalesForecastDetail salesForecastDetail = new Biz_SalesForecastDetail();

                    DropDownList downList;
                    TextBox textBox;
                    Label label;
                    for (int i = 0; i < gridViewMappedProducts.Rows.Count; i++)
                    {

                        salesForecastDetail =
                            salesForecastDetailService.ReadSalesForecastDetailbyId(
                                Convert.ToInt16(gridViewMappedProducts.Rows[i].Cells[1].Text.Trim()));
                        salesForecastDetail.IdSalesForecast =
                            Convert.ToInt16(gridViewMappedProducts.Rows[i].Cells[1].Text.Trim());
                        if (dropDownListSalesForecast.SelectedIndex > 0)
                        {
                            salesForecastDetail.IdSalesForecast =
                                Convert.ToInt16(dropDownListSalesForecast.SelectedValue);
                        }

                        label = (Label)gridViewMappedProducts.Rows[i].Cells[7].FindControl("LabelProductId");
                        if (label != null)
                        {
                            if (label.Text != String.Empty)
                            {
                                salesForecastDetail.IdProduct = Convert.ToInt16((label.Text.Trim()));
                            }
                        }

                        downList =
                            (DropDownList)
                            gridViewMappedProducts.Rows[i].Cells[3].FindControl("dropDownListType");
                        if (downList.SelectedIndex > 0)
                        {
                            salesForecastDetail.Type = downList.SelectedValue;
                            if (downList.SelectedValue == "V")
                            {
                                textBox =
                                    (TextBox)
                                    gridViewMappedProducts.Rows[i].Cells[4].FindControl("textBoxValue");
                                if (textBox != null)
                                {
                                    if (textBox.Text != string.Empty && textBox.Text.Trim() != "0")
                                    {
                                        salesForecastDetail.Value = Convert.ToDecimal(textBox.Text);
                                    }
                                }
                            }
                            if (downList.SelectedValue == "Q")
                            {
                                textBox =
                                    (TextBox)
                                    gridViewMappedProducts.Rows[i].Cells[5].FindControl("textBoxQuantity");
                                if (textBox != null)
                                {
                                    if (textBox.Text != string.Empty && textBox.Text.Trim() != "0")
                                    {
                                        salesForecastDetail.Quantity = Convert.ToDecimal(textBox.Text);
                                    }
                                }

                                downList =
                                    (DropDownList)
                                    gridViewMappedProducts.Rows[i].Cells[6].FindControl(
                                        "dropDownListUnitOfMeasure");
                                if (downList != null)
                                {
                                    if (downList.SelectedIndex > 0)
                                    {
                                        salesForecastDetail.IdUnitOfMeasure =
                                            Convert.ToInt16(downList.SelectedValue);
                                    }
                                }
                            }
                        }
                        salesForecastDetail.DateModified = DateTime.Now;
                        salesForecastDetailService.UpdateSalesForecastDetail(salesForecastDetail);
                    }
                   FlashText1.Display("Record(s) Successfully Saved.", "okmessage");
                }

            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Saving Failed.", "errormessage");
            }
        }

        public void DeleteSalesForecastDetail()
        {
            try
            {
                Biz_SalesForecastDetailsService salesForecastDetailService = new Biz_SalesForecastDetailsService();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedProducts.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            salesForecastDetailService.DeleteSalesForecastingDetail(Convert.ToInt16(gridViewRow.Cells[1].Text.Trim()));
                           FlashText1.Display("Record(s) Successfully Removed.", "okmessage");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record(s) Removing Faailed.", "errormessage");
            }
        }

        #endregion

        #region "Events"

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsAdd())
            {
                AddSalesForecastDetail();
                LoadGridData();
            }
        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsModify())
            {
                ModifySalesForecastDetail();
                LoadGridData();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsRemove())
            {
                DeleteSalesForecastDetail();
                LoadGridData();
            }
        }

        public void dropDownListSalesForecast_SelectedIndexChanged(object sender, EventArgs e)
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

        public void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in ((GridView)((CheckBox)sender).Parent.Parent.Parent.Parent).Rows)
            {
                ((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked = ((CheckBox)sender).Checked;
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

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldsAdd()
        {
            if (dropDownListSalesForecast.SelectedValue == "")
            {
               FlashText1.Display("Sales Forecast is not Selected.", "errormessage");
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

        private Boolean CheckMandatoryFieldsModify()
        {

            Biz_SalesBudgetDetail salesBudgetDetail = new Biz_SalesBudgetDetail();
            DropDownList downList;
            TextBox textBox;

            for (int i = 0; i < gridViewMappedProducts.Rows.Count; i++)
            {
                downList =
                    (DropDownList)
                    gridViewMappedProducts.Rows[i].Cells[3].FindControl("dropDownListType");
                if (downList.SelectedIndex > 0)
                {
                    salesBudgetDetail.Type = downList.SelectedValue;
                    if (downList.SelectedValue == "V")
                    {
                        textBox =
                            (TextBox)
                            gridViewMappedProducts.Rows[i].Cells[4].FindControl("textBoxValue");
                        if (textBox.Text == string.Empty || textBox.Text.Trim() == "0")
                        {
                           FlashText1.Display("Value Cannot be Blank.", "errormessage");
                            return false;
                        }
                    }
                    if (downList.SelectedValue == "Q")
                    {
                        textBox =
                            (TextBox)
                            gridViewMappedProducts.Rows[i].Cells[5].FindControl("textBoxQuantity");
                        if (textBox.Text == string.Empty || textBox.Text.Trim() == "0")
                        {
                           FlashText1.Display("Quantity Cannot be Blank.", "errormessage");
                            return false;
                        }

                        downList =
                            (DropDownList)
                            gridViewMappedProducts.Rows[i].Cells[6].FindControl(
                                "dropDownListUnitOfMeasure");
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

        private Boolean CheckMandatoryFieldsRemove()
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