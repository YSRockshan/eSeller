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
    public partial class BzFlexerProductCategories : System.Web.UI.Page
    {
        #region "Variables"

        private long SelectProductCategoryId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProductCategory();
                textBoxProductCategoryCode.Attributes.Add("onchange", "javascript:this.value=toUppserCase(this.value);");
                textBoxProductCatDescription.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
                textBoxProductCategoryCode2.Attributes.Add("onchange", "javascript:this.value=toUppserCase(this.value);");
                textBoxProductCatDescription2.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
            }
        }

        #region "Load Data"

        private void LoadProductCategory()
        {
            Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

            try
            {
                gridViewProductCategory.DataSource = productCategoryService.ReadAllProductCategory();
                gridViewProductCategory.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Operations"

        public void AddProductCategory()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_ProductCategory productCategory = new Biz_ProductCategory();
                    Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

                    if (textBoxProductCategoryCode.Text.Trim() != string.Empty)
                    {
                        productCategory.Code = textBoxProductCategoryCode.Text.Trim().ToUpper();
                    }
                    if (textBoxProductCatDescription.Text.Trim() != string.Empty)
                    {
                        productCategory.Description = textBoxProductCatDescription.Text.Trim();
                    }
                    productCategory.DateCreated = DateTime.Now;
                    productCategory.DateModified = DateTime.Now;

                    productCategoryService.CreateProductCategory(productCategory);
                }

                FlashText1.Display("Record successfully Saved.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Saving Failed.", "okmessage");
            }
        }

        public void ModifyProductCategory()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_ProductCategory productCategory = new Biz_ProductCategory();
                    Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

                    productCategory.Id = Convert.ToInt16(ViewState["SelectProductCategoryId"]);
                    productCategory = productCategoryService.ReadProductCategoryById(productCategory.Id);

                    if (textBoxProductCategoryCode2.Text.Trim() != string.Empty)
                    {
                        productCategory.Code = textBoxProductCategoryCode2.Text.Trim().ToUpper();
                    }
                    if (textBoxProductCatDescription2.Text.Trim() != string.Empty)
                    {
                        productCategory.Description = textBoxProductCatDescription2.Text.Trim();
                    }

                    productCategory.DateModified = DateTime.Now;
                    productCategoryService.UpdateProductCategory(productCategory);

                }
                FlashText1.Display("Record successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteProductCategory()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_ProductCategory productCategory = new Biz_ProductCategory();
                    Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();

                    productCategory.Id = Convert.ToInt16(ViewState["SelectProductCategoryId"]);
                    productCategoryService.DeleteProductCategories(productCategory.Id);
                }
                FlashText1.Display("Record successfully Deleted.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Deleting Failed.", "errormessage");
            }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxProductCategoryCode.Text = "";
            textBoxProductCatDescription.Text = "";
            textBoxProductCategoryCode2.Text = "";
            textBoxProductCatDescription2.Text = "";
            ViewState["SelectProductCategoryId"] = null;
            gridViewProductCategory.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryProductCategoryAdd())
            {
                AddProductCategory();
                ClearData();
                LoadProductCategory();

            }
        }

        public void buttonEdit_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryProductCategoryModify())
            {
                ModifyProductCategory();
                ClearData();
                LoadProductCategory();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandotaryProductCategoryDelete())
            {
                DeleteProductCategory();
                ClearData();
                LoadProductCategory();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxProductCategoryCode.Focus();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxProductCategoryCode.Focus();
        }

        public void gridViewProductCategory_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gridViewProductCategory.SelectedRow;

                ViewState["SelectProductCategoryId"] = row.Cells[1].Text.Trim();
                textBoxProductCategoryCode2.Text = row.Cells[2].Text.Trim();
                textBoxProductCatDescription2.Text = row.Cells[3].Text.Trim();
                accordionInputs.SelectedIndex = 1;
            }
            catch (Exception exception)
            {

            }

        }

        public void gridViewProductCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadProductCategory();
            gridViewProductCategory.PageIndex = e.NewPageIndex;
            gridViewProductCategory.DataBind();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryProductCategoryAdd()
        {
            if (textBoxProductCategoryCode.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Product Category Code cannot be blank.", "errormessage");
                return false;
            }
            if (textBoxProductCatDescription.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description cannot be blank.", "errormessage");
                return false;
            }
            if (textBoxProductCategoryCode.Text.Trim() != string.Empty)
            {
                Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();
                List<Biz_ProductCategory> productCategoryList = new List<Biz_ProductCategory>();

                productCategoryList = productCategoryService.ReadProductCategoryByCode(textBoxProductCategoryCode.Text.Trim());
                if (productCategoryList.Count > 0)
                {
                    FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }
            }
            return true;
        }

        private Boolean CheckMandatoryProductCategoryModify()
        {
            if (ViewState["SelectProductCategoryId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxProductCategoryCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Product Category Code cannot be blank.", "errormessage");
                return false;
            }
            if (textBoxProductCatDescription2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description cannot be blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandotaryProductCategoryDelete()
        {
            if (textBoxProductCategoryCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}