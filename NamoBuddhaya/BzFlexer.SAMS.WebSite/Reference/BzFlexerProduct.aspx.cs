using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.Reference
{
    public partial class BzFlexerProduct : System.Web.UI.Page
    {
        #region "Variables"

        private long SlectProductId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillData();
                textBoxProductCode.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxDescription.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
                textBoxProductCode2.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxDescription2.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
            }
        }

        #region "Load Data"

        public void FillData()
        {
            DataBindtoProductCategory();
            DataBindtoSubProductCategory();
            LoadGeneralProduct();
            DataBindtoUnitOfMeasureType();
            DataBindtoUnitOfMeasureType2();
            loadEmptyData();
        }

        public void loadEmptyData()
        {
            List<Biz_Product> productList = null;
            gridViewGeneralProduct.DataSource = productList;
            gridViewGeneralProduct.DataBind();
        }

        public void DataBindtoProductCategory()
        {
            try
            {
                Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();
                dropDownListProductCat.DataSource = productCategoryService.ReadAllProductCategory();
                dropDownListProductCat.DataValueField = "Id";
                dropDownListProductCat.DataTextField = "Description";
                dropDownListProductCat.DataBind();
                dropDownListProductCat.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }

        public void DataBindtoSubProductCategory()
        {
            try
            {
                Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();
                dropDownListSubProductCat.DataSource = subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCat.SelectedValue));
                dropDownListSubProductCat.DataValueField = "Id";
                dropDownListSubProductCat.DataTextField = "Description";
                dropDownListSubProductCat.DataBind();
                dropDownListSubProductCat.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }

        public void LoadGeneralProduct()
        {
            try
            {
                Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();

                if (dropDownListProductCat.SelectedValue != "" && dropDownListSubProductCat.SelectedValue == "")
                {
                    gridViewGeneralProduct.DataSource = generalProductService.ReadGeneralProductByProductCat(Convert.ToInt16(dropDownListProductCat.SelectedValue));
                    gridViewGeneralProduct.DataBind();
                }

                if (dropDownListProductCat.SelectedValue != "" && dropDownListSubProductCat.SelectedValue != "")
                {
                    gridViewGeneralProduct.DataSource = generalProductService.ReadAllGeneralProductByProductCategoryAndSubProductCategory(Convert.ToInt16(dropDownListProductCat.SelectedValue), Convert.ToInt16(dropDownListSubProductCat.SelectedValue));
                    gridViewGeneralProduct.DataBind();
                }
            }
            catch (Exception exception)
            {

            }
        }

        public void DataBindtoUnitOfMeasureType()
        {
            try
            {
                Biz_UnitOfMeasureTypeService unitOfMeasureTypeService = new Biz_UnitOfMeasureTypeService();
                dropDownListUnitofMeasureType.DataSource = unitOfMeasureTypeService.ReadAllUnitOfMeasureType();
                dropDownListUnitofMeasureType.DataValueField = "Id";
                dropDownListUnitofMeasureType.DataTextField = "Description";
                dropDownListUnitofMeasureType.DataBind();
                dropDownListUnitofMeasureType.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }

        public void DataBindtoUnitOfMeasureType2()
        {
            try
            {
                Biz_UnitOfMeasureTypeService unitOfMeasureTypeService = new Biz_UnitOfMeasureTypeService();
                dropDownListUnitofMeasureType2.DataSource = unitOfMeasureTypeService.ReadAllUnitOfMeasureType();
                dropDownListUnitofMeasureType2.DataValueField = "Id";
                dropDownListUnitofMeasureType2.DataTextField = "Description";
                dropDownListUnitofMeasureType2.DataBind();
                dropDownListUnitofMeasureType2.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxProductCode.Text = "";
            textBoxDescription.Text = "";
            textBoxMoreDetail.Text = "";
            textBoxProductCode2.Text = "";
            textBoxDescription2.Text = "";
            textBoxMoreDetail2.Text = "";
            ViewState["SlectProductId"] = null;
            gridViewGeneralProduct.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Operations"

        public void AddGeneralProduct()
        {
            try
            {
                Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();
                Biz_Product product = new Biz_Product();

                if (Page.IsValid)
                {
                    if (dropDownListProductCat.SelectedValue != null)
                    {
                        product.IdProductCategory = Convert.ToInt16(dropDownListProductCat.SelectedValue);
                    }
                    if (dropDownListSubProductCat.SelectedValue != null)
                    {
                        product.IdSubProductCategory = Convert.ToInt16(dropDownListSubProductCat.SelectedValue);
                    }
                    if (textBoxProductCode.Text.Trim() != string.Empty)
                    {
                        product.Code = textBoxProductCode.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription.Text.Trim() != string.Empty)
                    {
                        product.Description = textBoxDescription.Text.Trim();
                    }
                    if (textBoxMoreDetail.Text.Trim() != string.Empty)
                    {
                        product.More_Details = textBoxMoreDetail.Text.Trim();
                    }
                    if (dropDownListUnitofMeasureType.SelectedValue != null)
                    {
                        product.IdUnitOfMeasureType = Convert.ToInt16(dropDownListUnitofMeasureType.SelectedValue);
                    }

                    product.DateCreated = DateTime.Now;
                    product.DateModified = DateTime.Now;

                    generalProductService.CreateGeneralProduct(product);
                }
                FlashText1.Display("Record successfully Saved.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Saving Failed.", "okmessage");
            }
        }

        public void ModifyGeneralProduct()
        {
            try
            {
                Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();
                Biz_Product product = new Biz_Product();

                if (Page.IsValid)
                {
                    product.Id = Convert.ToInt16(ViewState["SlectProductId"]);
                    product = generalProductService.ReadProductById(product.Id);

                    if (dropDownListProductCat.SelectedValue != null)
                    {
                        product.IdProductCategory = Convert.ToInt16(dropDownListProductCat.SelectedValue);
                    }
                    if (dropDownListSubProductCat.SelectedValue != null)
                    {
                        product.IdSubProductCategory = Convert.ToInt16(dropDownListSubProductCat.SelectedValue);
                    }
                    if (textBoxProductCode2.Text.Trim() != string.Empty)
                    {
                        product.Code = textBoxProductCode2.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription2.Text.Trim() != string.Empty)
                    {
                        product.Description = textBoxDescription2.Text.Trim();
                    }
                    if (textBoxMoreDetail2.Text.Trim() != string.Empty)
                    {
                        product.More_Details = textBoxMoreDetail2.Text.Trim();
                    }
                    if (dropDownListUnitofMeasureType.SelectedValue != null)
                    {
                        product.IdUnitOfMeasureType = Convert.ToInt16(dropDownListUnitofMeasureType.SelectedValue);
                    }

                    product.DateModified = DateTime.Now;

                    generalProductService.UpdateGeneralProduct(product);
                }
                FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteGeneralProduct()
        {
            try
            {
                Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();

                if (Page.IsValid)
                {
                    generalProductService.DeleteGeneralProducts(Convert.ToInt16(ViewState["SlectProductId"]));
                }
                FlashText1.Display("Record Successfully Deleted.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Deleting Failed.", "errormessage");
            }
        }

        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryProductAdd())
            {
                AddGeneralProduct();
                ClearData();
                LoadGeneralProduct();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryProductModify())
            {
                ModifyGeneralProduct();
                ClearData();
                LoadGeneralProduct();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryProductDelete())
            {
                DeleteGeneralProduct();
                ClearData();
                LoadGeneralProduct();
            }

        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            FillData();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            FillData();
        }

        public void dropDownListProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (dropDownListProductCat.SelectedValue != null)
                {
                    ClearData();
                    DataBindtoSubProductCategory();
                    LoadGeneralProduct();
                }
                if (dropDownListProductCat.SelectedValue == "")
                {
                    dropDownListSubProductCat.Items.Clear();
                    dropDownListSubProductCat.Items.Add("-Select-");
                    loadEmptyData();
                }
            }
            catch (Exception exception)
            {

            }
        }

        public void dropDownListSubProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData();
            LoadGeneralProduct();
        }

        public void gridViewGeneralProduct_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[4].Visible = false;
                e.Row.Cells[5].Visible = false;
            }
        }

        public void gridViewGeneralProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gridViewGeneralProduct.SelectedRow;
                ViewState["SlectProductId"] = row.Cells[1].Text.Trim();
                textBoxProductCode2.Text = row.Cells[2].Text.Trim();
                textBoxDescription2.Text = row.Cells[3].Text.Trim();
                textBoxMoreDetail2.Text = row.Cells[4].Text.Trim();
                dropDownListUnitofMeasureType2.SelectedValue = row.Cells[5].Text.Trim();
                accordionInputs.SelectedIndex = 1;
            }
            catch (Exception exception)
            {

            }
        }

        public void gridViewGeneralProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewGeneralProduct.PageIndex = e.NewPageIndex;
            gridViewGeneralProduct.DataBind();
            LoadGeneralProduct();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryProductAdd()
        {
            if (dropDownListProductCat.SelectedValue == null)
            {
                FlashText1.Display("Please Select the Product Category.", "errormessage");
                return false;
            }
            if (dropDownListSubProductCat.SelectedValue == null)
            {
                FlashText1.Display("Please Select the Sub Product Category.", "errormessage");
                return false;
            }
            if (textBoxProductCode.Text.Trim() != string.Empty)
            {
                Biz_GeneralProductService generalProductService = new Biz_GeneralProductService();
                List<Biz_Product> productList = new List<Biz_Product>();
                productList =
                    generalProductService.ReadGeneralProductByProductCodeAndProductCategoryAndSubProdctCategory(
                        Convert.ToInt16(dropDownListProductCat.SelectedValue),
                        Convert.ToInt16(dropDownListSubProductCat.SelectedValue),
                textBoxProductCode.Text.Trim());
                if (productList.Count > 0)
                {
                    FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }
            }
            if (textBoxProductCode.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Product Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }

            return true;
        }

        private Boolean CheckMandatoryProductModify()
        {
            if (ViewState["SlectProductId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxProductCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Product Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryProductDelete()
        {
            if (ViewState["SlectProductId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion

    }
}