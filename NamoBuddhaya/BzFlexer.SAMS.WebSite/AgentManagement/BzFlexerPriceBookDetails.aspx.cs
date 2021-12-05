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
    public partial class BzFlexerPriceBookDetails : System.Web.UI.Page
    {
        #region "Variables"

        private long selectPriceBookDetailId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListPriceBook();
                DataBindTodropDownListProductCategory();
                fillData();
            }
        }

        #region "Load Data"

        public void fillData()
        {
            GetDataTodropDownListProduct();
            GetDataTodropDownListProductEdit();
            DataBindTodropDownListUnitofMeasure();
            DataBindTodropDownListUnitofMeasureEdit();
            GetDataToDropDownLisrCurrencies();
            GetDataTogridViewPriceBookDetail();
        }

        public void DataBindTodropDownListPriceBook()
        {
            Biz_PriceBookService priceBookService = new Biz_PriceBookService();
            dropDownListPriceBook.DataSource = priceBookService.ReadAllPriceBooks();
            dropDownListPriceBook.DataTextField = "Description";
            dropDownListPriceBook.DataValueField = "Id";
            dropDownListPriceBook.DataBind();
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
            List<Biz_SubProductCategory> subProductCategories = new List<Biz_SubProductCategory>();
            subProductCategories = subProductCategoryService.ReadAllSubProductCategory();
            if (dropDownListProductCategory.SelectedIndex > 0)
            {
                subProductCategories = (from subprocat in subProductCategories
                                        where
                                            subprocat.IdProductCategory ==
                                            Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                                        select subprocat).ToList();
                GetdropDownListSubProductCategory(subProductCategories);
            }
            else
            {
                CleardropDownListSubProductCategory();
            }
        }

        public void GetdropDownListSubProductCategory(List<Biz_SubProductCategory> subProductCategories)
        {
            dropDownListSubProductCategory.DataSource = subProductCategories;
            dropDownListSubProductCategory.DataTextField = "Description";
            dropDownListSubProductCategory.DataValueField = "Id";
            dropDownListSubProductCategory.DataBind();
        }

        public void CleardropDownListSubProductCategory()
        {
            dropDownListSubProductCategory.Items.Clear();
            dropDownListSubProductCategory.Items.Add("-Select-");
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
            dropDownListProduct.DataSource = products;
            dropDownListProduct.DataValueField = "Id";
            dropDownListProduct.DataTextField = "Description";
            dropDownListProduct.DataBind();
        }

        public void CleardropDownListProduct()
        {
            dropDownListProduct.Items.Clear();
            dropDownListProduct.Items.Add("-Select-");
        }

        public void GetDataTodropDownListProductEdit()
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
                CleardropDownListProductEdit();
                DataBindTodropDownListProductEdit(products);
            }
            else
            {
                CleardropDownListProductEdit();
            }
        }

        public void DataBindTodropDownListProductEdit(List<Biz_Product> products)
        {
            dropDownListProductEdit.DataSource = products;
            dropDownListProductEdit.DataValueField = "Id";
            dropDownListProductEdit.DataTextField = "Description";
            dropDownListProductEdit.DataBind();
        }

        public void CleardropDownListProductEdit()
        {
            dropDownListProductEdit.Items.Clear();
            dropDownListProductEdit.Items.Add("-Select-");
        }

        public void DataBindTodropDownListUnitofMeasure()
        {
            dropDownListUnitofMeasure.DataSource = new Biz_UnitOfMeasureService().ReadAllUnitOfMeasure();
            dropDownListUnitofMeasure.DataValueField = "Id";
            dropDownListUnitofMeasure.DataTextField = "Description";
            dropDownListUnitofMeasure.DataBind();
        }

        public void DataBindTodropDownListUnitofMeasureEdit()
        {
            dropDownListUnitofMeasureEdit.DataSource = new Biz_UnitOfMeasureService().ReadAllUnitOfMeasure();
            dropDownListUnitofMeasureEdit.DataValueField = "Id";
            dropDownListUnitofMeasureEdit.DataTextField = "Description";
            dropDownListUnitofMeasureEdit.DataBind();
        }

        public void GetDataToDropDownLisrCurrencies()
        {
            List<Biz_Currency> currencies = new List<Biz_Currency>();
            currencies = new Biz_CurrencyService().ReadAllCurrency();
            DataBindTodropDownListCurrency1(currencies);
            DataBindTodropDownListCurrency2(currencies);
            DataBindTodropDownListCurrency1Edit(currencies);
            DataBindTodropDownListCurrency2Edit(currencies);
        }

        public void DataBindTodropDownListCurrency1(List<Biz_Currency> currencies)
        {
            dropDownListCurrency1.DataSource = currencies;
            dropDownListCurrency1.DataValueField = "Id";
            dropDownListCurrency1.DataTextField = "Code";
            dropDownListCurrency1.DataBind();
            dropDownListCurrency1.SelectedItem.Value = "LKR";
            dropDownListCurrency1.Enabled = false;
        }

        public void DataBindTodropDownListCurrency2(List<Biz_Currency> currencies)
        {
            dropDownListCurrency2.DataSource = currencies;
            dropDownListCurrency2.DataValueField = "Id";
            dropDownListCurrency2.DataTextField = "Code";
            dropDownListCurrency2.DataBind();
            dropDownListCurrency2.SelectedItem.Value = "LKR";
            dropDownListCurrency2.Enabled = false;
        }

        public void DataBindTodropDownListCurrency1Edit(List<Biz_Currency> currencies)
        {
            dropDownListCurrency1Edit.DataSource = currencies;
            dropDownListCurrency1Edit.DataValueField = "Id";
            dropDownListCurrency1Edit.DataTextField = "Code";
            dropDownListCurrency1Edit.DataBind();
            dropDownListCurrency1Edit.SelectedItem.Value = "LKR";
            dropDownListCurrency1Edit.Enabled = false;
        }

        public void DataBindTodropDownListCurrency2Edit(List<Biz_Currency> currencies)
        {
            dropDownListCurrency2Edit.DataSource = currencies;
            dropDownListCurrency2Edit.DataValueField = "Id";
            dropDownListCurrency2Edit.DataTextField = "Code";
            dropDownListCurrency2Edit.DataBind();
            dropDownListCurrency2Edit.SelectedItem.Value = "LKR";
            dropDownListCurrency2Edit.Enabled = false;
        }

        public void GetDataTogridViewPriceBookDetail()
        {
            try
            {
                Biz_PriceBookDetailsService priceBookDetailService = new Biz_PriceBookDetailsService();
                List<Biz_PriceBookDetail> priceBookDetails = new List<Biz_PriceBookDetail>();
                priceBookDetails = priceBookDetailService.ReadAllPriceBookDetails();

                if (dropDownListPriceBook.SelectedIndex > 0)
                {
                    priceBookDetails = (from detail in priceBookDetails
                                        where detail.IdPriceBook == Convert.ToInt16(dropDownListPriceBook.SelectedValue)
                                        select detail).ToList();
                    if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex < 1)
                    {
                        priceBookDetails = (from detail in priceBookDetails
                                            where detail.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue)
                                            select detail).ToList();
                    }
                    else if (dropDownListProductCategory.SelectedIndex > 0 && dropDownListSubProductCategory.SelectedIndex > 0)
                    {
                        priceBookDetails = (from detail in priceBookDetails
                                            where detail.Biz_Products.IdProductCategory == Convert.ToInt16(dropDownListProductCategory.SelectedValue) && detail.Biz_Products.IdSubProductCategory == Convert.ToInt16(dropDownListSubProductCategory.SelectedValue)
                                            select detail).ToList();
                    }
                    DataBindTogridViewPriceBookDetail(priceBookDetails);
                }
                else
                {
                    CleargridViewPriceBookDetail();
                }
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTogridViewPriceBookDetail(List<Biz_PriceBookDetail> priceBookDetails)
        {
            gridViewPriceBookDetail.DataSource = priceBookDetails;
            gridViewPriceBookDetail.DataBind();
        }

        public void CleargridViewPriceBookDetail()
        {
            gridViewPriceBookDetail.DataSource = null;
            gridViewPriceBookDetail.DataBind();
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            dropDownListProduct.SelectedIndex = 0;
            dropDownListProductEdit.SelectedIndex = 0;
            dropDownListUnitofMeasure.SelectedIndex = 0;
            dropDownListUnitofMeasureEdit.SelectedIndex = 0;
            textBoxPricePerUnit.Text = "";
            textBoxDiscountRate.Text = Convert.ToString(0.00);
            textBoxDiscount.Text = Convert.ToString(0.00);
            textBoxCostPerUnit.Text = Convert.ToString(0.00);
            textBoxCommissionRate.Text = Convert.ToString(0.00);
            textBoxCommission.Text = Convert.ToString(0.00);
            textBoxPricePerUnitEdit.Text = Convert.ToString(0.00);
            textBoxDiscountRateEdit.Text = Convert.ToString(0.00);
            textBoxDiscountEdit.Text = Convert.ToString(0.00);
            textBoxCostPerUnitEdit.Text = Convert.ToString(0.00);
            textBoxCommisionRateEdit.Text = Convert.ToString(0.00);
            textBoxCommissionEdit.Text = Convert.ToString(0.00);
            ViewState["selectPriceBookDetailId"] = "";
            gridViewPriceBookDetail.SelectedIndex = -1;
        }

        #endregion

        #region "Operations"

        public void AddPriceBookDetails()
        {
            try
            {
                Biz_PriceBookDetailsService priceBookDetailService = new Biz_PriceBookDetailsService();
                Biz_PriceBookDetail priceBookDetail = new Biz_PriceBookDetail();

                if (Page.IsValid)
                {
                    priceBookDetail.IdPriceBook = Convert.ToInt16(dropDownListPriceBook.SelectedValue);
                    priceBookDetail.IdProduct = Convert.ToInt16(dropDownListProduct.SelectedValue);
                    priceBookDetail.IdUnitOfMeasure = Convert.ToInt16(dropDownListUnitofMeasure.SelectedValue);
                    priceBookDetail.PricePer_Unit = Convert.ToDecimal(textBoxPricePerUnit.Text);
                    priceBookDetail.Discount_Rate = Convert.ToDecimal(textBoxDiscountRate.Text);
                    priceBookDetail.CostPer_Unit = Convert.ToDecimal(textBoxCostPerUnit.Text);
                    priceBookDetail.Commission_Rate = Convert.ToDecimal(textBoxCommissionRate.Text);
                    priceBookDetail.DateCreated = DateTime.Now;
                    priceBookDetail.DateModified = DateTime.Now;

                    priceBookDetailService.CreatePriceBookDetail(priceBookDetail);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "okmessage");
            }
        }

        public void ModifyPriceBookDetails()
        {
            try
            {
                Biz_PriceBookDetailsService priceBookDetailService = new Biz_PriceBookDetailsService();
                Biz_PriceBookDetail priceBookDetail = new Biz_PriceBookDetail();

                if (Page.IsValid)
                {
                    priceBookDetail.Id = Convert.ToInt16(ViewState["selectPriceBookDetailId"]);
                    priceBookDetail = priceBookDetailService.ReadPriceBookDetailById(priceBookDetail.Id);
                    priceBookDetail.IdPriceBook = Convert.ToInt16(dropDownListPriceBook.SelectedValue);
                    priceBookDetail.IdProduct = Convert.ToInt16(dropDownListProductEdit.SelectedValue);
                    priceBookDetail.IdUnitOfMeasure = Convert.ToInt16(dropDownListUnitofMeasureEdit.SelectedValue);
                    priceBookDetail.PricePer_Unit = Convert.ToDecimal(textBoxPricePerUnitEdit.Text);
                    priceBookDetail.Discount_Rate = Convert.ToDecimal(textBoxDiscountRateEdit.Text);
                    priceBookDetail.CostPer_Unit = Convert.ToDecimal(textBoxCostPerUnitEdit.Text);
                    priceBookDetail.Commission_Rate = Convert.ToDecimal(textBoxCommisionRateEdit.Text);
                    priceBookDetail.DateModified = DateTime.Now;

                    priceBookDetailService.UpdatePriceBookDetail(priceBookDetail);
                   FlashText1.Display("Record Successfully Modified.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Modifing Failed.", "okmessage");
            }
        }

        public void DeletePriceBookDetails()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_PriceBookDetailsService priceBookDetailService = new Biz_PriceBookDetailsService();
                    priceBookDetailService.DeletePriceBookDetail(Convert.ToInt16(ViewState["selectPriceBookDetailId"]));
                   FlashText1.Display("Record Successfully Deleted.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Deleting Failed.", "okmessage");
            }
        }

        #endregion

        #region "Events"

        public void dropDownListPriceBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataTogridViewPriceBookDetail();
            DataBindTodropDownListProductCategory();
            DataBindTodropDownListSubProductCategory();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleardropDownListSubProductCategory();
            CleardropDownListProduct();
            CleardropDownListProductEdit();
            fillData();
            DataBindTodropDownListSubProductCategory();
        }

        public void dropDownListSubProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetDataTogridViewPriceBookDetail();
            CleardropDownListProduct();
            GetDataTodropDownListProduct();
            CleardropDownListProductEdit();
            GetDataTodropDownListProductEdit();
        }

        public void gridViewPriceBookDetail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewPriceBookDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GetDataTogridViewPriceBookDetail();
            gridViewPriceBookDetail.PageIndex = e.NewPageIndex;
            gridViewPriceBookDetail.DataBind();
        }

        public void gridViewPriceBookDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewPriceBookDetail.SelectedRow;
            ViewState["selectPriceBookDetailId"] = row.Cells[1].Text;
            textBoxPricePerUnitEdit.Text = Convert.ToString(row.Cells[4].Text);

            Biz_PriceBookDetail priceBookDetail = new Biz_PriceBookDetail();
            priceBookDetail = new Biz_PriceBookDetailsService().ReadPriceBookDetailById(Convert.ToInt16(ViewState["selectPriceBookDetailId"]));
            priceBookDetail.Biz_Products = new Biz_GeneralProductService().ReadProductById(Convert.ToInt16(priceBookDetail.IdProduct));
            var dicountRate = priceBookDetail.Discount_Rate;
            textBoxDiscountRateEdit.Text = dicountRate.ToString();
            var discount = Convert.ToDecimal(textBoxPricePerUnitEdit.Text) * Convert.ToDecimal(priceBookDetail.Discount_Rate) / 100;
            textBoxDiscountEdit.Text = Convert.ToString(Math.Round(discount, 2));
            textBoxCostPerUnitEdit.Text = Convert.ToString(priceBookDetail.CostPer_Unit);
            var commissionRate = priceBookDetail.Commission_Rate;
            textBoxCommisionRateEdit.Text = commissionRate.ToString();
            var commission = Convert.ToDecimal(textBoxPricePerUnitEdit.Text) *
                             Convert.ToDecimal(priceBookDetail.Commission_Rate) / 100;
            textBoxCommissionEdit.Text = Convert.ToString(Math.Round(commission, 2));
            dropDownListProductEdit.SelectedValue = priceBookDetail.IdProduct.ToString();
            dropDownListProductCategory.SelectedValue = priceBookDetail.Biz_Products.IdProductCategory.ToString();
            DataBindTodropDownListSubProductCategory();
            dropDownListSubProductCategory.SelectedValue = priceBookDetail.Biz_Products.IdSubProductCategory.ToString();
            DataBindTodropDownListUnitofMeasureEdit();
            dropDownListUnitofMeasureEdit.SelectedValue = priceBookDetail.IdUnitOfMeasure.ToString();
            accordionInputs.SelectedIndex = 1;
        }

        public void textBoxPricePerUnit_TextChanged(object sender, EventArgs e)
        {
            textBoxCostPerUnit.Text = Convert.ToString(Convert.ToDecimal(textBoxPricePerUnit.Text));
        }

        public void textBoxDiscountRate_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBoxDiscountRate.Text) > 0)
            {
                var discount = Convert.ToDecimal(textBoxPricePerUnit.Text) * Convert.ToDecimal(textBoxDiscountRate.Text) /
                               100;
                textBoxDiscount.Text = Convert.ToString(Math.Round(discount, 2));
            }
            else
            {
                textBoxDiscountRate.Text = Convert.ToString(0.00);
                textBoxDiscount.Text = Convert.ToString(0.00);
            }
            textBoxCostPerUnit.Text = Convert.ToString(Convert.ToDecimal(textBoxPricePerUnit.Text) -
                                      Convert.ToDecimal(textBoxDiscount.Text));
        }

        public void textBoxCommissionRate_TextChanged(object sender, EventArgs e)
        {
            try { 
            if (Convert.ToDecimal(textBoxCommissionRate.Text) > 0)
            {
                var commission = Convert.ToDecimal(textBoxCostPerUnit.Text) *
                                 Convert.ToDecimal(textBoxCommissionRate.Text) / 100;
                textBoxCommission.Text = Convert.ToString(Math.Round(commission, 2));
            }
            else
            {
                textBoxCommissionRate.Text = Convert.ToString(0.00);
                textBoxCommission.Text = Convert.ToString(0.00);
            }
        }
            catch (Exception exception)
            { }
}

        public void textBoxPricePerUnitEdit_TextChanged(object sender, EventArgs e)
        {
            textBoxCostPerUnitEdit.Text = Convert.ToString(Convert.ToDecimal(textBoxPricePerUnitEdit.Text));
        }

        public void textBoxDiscountRateEdit_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBoxDiscountRateEdit.Text) > 0)
            {
                var discount = Convert.ToDecimal(textBoxPricePerUnitEdit.Text) * Convert.ToDecimal(textBoxDiscountRateEdit.Text) /
                               100;
                textBoxDiscountEdit.Text = Convert.ToString(Math.Round(discount, 2));
            }
            else
            {
                textBoxDiscountRateEdit.Text = Convert.ToString(0.00);
                textBoxDiscountEdit.Text = Convert.ToString(0.00);
            }
            textBoxCostPerUnitEdit.Text = Convert.ToString(Convert.ToDecimal(textBoxPricePerUnitEdit.Text) -
                                      Convert.ToDecimal(textBoxDiscountEdit.Text));
        }

        public void textBoxCommisionRateEdit_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(textBoxCommisionRateEdit.Text) > 0)
            {
                var commission = Convert.ToDecimal(textBoxCostPerUnitEdit.Text) *
                                 Convert.ToDecimal(textBoxCommisionRateEdit.Text) / 100;
                textBoxCommissionEdit.Text = Convert.ToString(Math.Round(commission, 2));
            }
            else
            {
                textBoxCommisionRateEdit.Text = Convert.ToString(0.00);
                textBoxCommissionEdit.Text = Convert.ToString(0.00);
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void buttonSave_Click(object ssender, EventArgs e)
        {
            if (CheckMandatioryFieldAdd())
            {
                AddPriceBookDetails();
                ClearData();
                fillData();
            }
        }

        public void buttonModify_Click(object ssender, EventArgs e)
        {
            if (CheckMandatioryFieldModify())
            {
                ModifyPriceBookDetails();
                ClearData();
                fillData();
            }
        }

        public void buttonDelete_Click(object ssender, EventArgs e)
        {
            if (CheckMandatioryFieldDelete())
            {
                DeletePriceBookDetails();
                ClearData();
                fillData();
            }
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatioryFieldAdd()
        {
            if (dropDownListPriceBook.SelectedIndex < 1)
            {
               FlashText1.Display("No PriceBook is Selected.", "errormessage");
                return false;
            }
            if (dropDownListProduct.SelectedIndex < 1)
            {
               FlashText1.Display("No Product is Selected.", "errormessage");
                return false;
            }
            if (dropDownListUnitofMeasure.SelectedIndex < 1)
            {
               FlashText1.Display("No Unit of Measure is Selected.", "errormessage");
                return false;
            }
            if (textBoxPricePerUnit.Text == string.Empty)
            {
               FlashText1.Display("Price per Unit Cannot be a Blank.", "errormessage");
                return false;
            }
            if (textBoxCostPerUnit.Text == string.Empty)
            {
               FlashText1.Display("Cost per Unit Cannot be a Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatioryFieldModify()
        {
            if (ViewState["selectPriceBookDetailId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (dropDownListPriceBook.SelectedIndex < 1)
            {
               FlashText1.Display("No PriceBook is Selected.", "errormessage");
                return false;
            }
            if (dropDownListProductEdit.SelectedIndex < 1)
            {
               FlashText1.Display("No Product is Selected.", "errormessage");
                return false;
            }
            if (dropDownListUnitofMeasureEdit.SelectedIndex < 1)
            {
               FlashText1.Display("No Unit of Measure is Selected.", "errormessage");
                return false;
            }
            if (textBoxPricePerUnitEdit.Text == string.Empty)
            {
               FlashText1.Display("Price per Unit Cannot be a Blank.", "errormessage");
                return false;
            }
            if (textBoxCostPerUnitEdit.Text == string.Empty)
            {
               FlashText1.Display("Cost per Unit Cannot be a Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatioryFieldDelete()
        {
            if (ViewState["selectPriceBookDetailId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}