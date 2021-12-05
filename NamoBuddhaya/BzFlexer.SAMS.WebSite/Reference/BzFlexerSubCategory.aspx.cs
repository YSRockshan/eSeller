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
    public partial class BzFlexerSubCategory : System.Web.UI.Page
    {
        #region "Variables"

        private long SelectSubProductCategoryId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindToProductCategory();
                LoadSubProductCategory();
                textBoxSubProCatCode.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxDescription.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
                textBoxSubProCatCode2.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxDescription2.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
            }
        }

        #region "Load Data"

        public void DataBindToProductCategory()
        {
            Biz_ProductCategoryService productCategoryService = new Biz_ProductCategoryService();
            dropDownListProductCategory.DataSource = productCategoryService.ReadAllProductCategory();
            dropDownListProductCategory.DataValueField = "Id";
            dropDownListProductCategory.DataTextField = "Description";
            dropDownListProductCategory.DataBind();
            dropDownListProductCategory.SelectedIndex = 0;
        }

        public void LoadSubProductCategory()
        {
            Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();

            try
            {
                if (dropDownListProductCategory.SelectedValue != "")
                {
                    gridViewSubProductCat.DataSource = subProductCategoryService.ReadAllSubProductCategoryByProductId(Convert.ToInt16(dropDownListProductCategory.SelectedValue));
                    gridViewSubProductCat.DataBind();
                }
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Operations"

        public void AddSubProductCategory()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SubProductCategory subProductCategory = new Biz_SubProductCategory();
                    Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();

                    if (dropDownListProductCategory.SelectedValue != null)
                    {
                        subProductCategory.IdProductCategory = Convert.ToInt16(dropDownListProductCategory.SelectedValue);
                    }
                    if (textBoxSubProCatCode.Text.Trim() != string.Empty)
                    {
                        subProductCategory.Code = textBoxSubProCatCode.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription.Text.Trim() != string.Empty)
                    {
                        subProductCategory.Description = textBoxDescription.Text.Trim();
                    }

                    subProductCategory.DateCreated = DateTime.Now;
                    subProductCategory.DateModified = DateTime.Now;

                    subProductCategoryService.CreateSubProductCategory(subProductCategory);
                }
                FlashText1.Display("Record successfully Saved.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Saving Failed.", "okmessage");
            }
        }

        public void ModifySubProductCategory()
        {
            try
            {
                Biz_SubProductCategory subProductCategory = new Biz_SubProductCategory();
                Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();

                if (Page.IsValid)
                {
                    subProductCategory.Id = Convert.ToInt16(ViewState["SelectSubProductCategoryId"]);
                    subProductCategory = subProductCategoryService.ReadSubProductCategoryById(subProductCategory.Id);

                    if (textBoxSubProCatCode2.Text.Trim() != string.Empty)
                    {
                        subProductCategory.Code = textBoxSubProCatCode2.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription2.Text.Trim() != string.Empty)
                    {
                        subProductCategory.Description = textBoxDescription2.Text.Trim();
                    }

                    subProductCategory.IdProductCategory = Convert.ToInt16(dropDownListProductCategory.SelectedValue);
                    subProductCategory.DateModified = DateTime.Now;

                    subProductCategoryService.UpdateSubProductCategory(subProductCategory);
                }
                FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteSubProductCategory()
        {
            try
            {
                Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();

                if (Page.IsValid)
                {
                    subProductCategoryService.DeleteSubProductCategory(Convert.ToInt16(ViewState["SelectSubProductCategoryId"]));
                }
                FlashText1.Display("Record Successfully Deleted.", "okmessage");
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
            textBoxSubProCatCode.Text = "";
            textBoxDescription.Text = "";
            textBoxSubProCatCode2.Text = "";
            textBoxDescription2.Text = "";
            ViewState["SelectSubProductCategoryId"] = null;
            gridViewSubProductCat.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatorySubProductCategoryAdd())
            {
                AddSubProductCategory();
                ClearData();
                LoadSubProductCategory();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatorySubProductCategoryModify())
            {
                ModifySubProductCategory();
                ClearData();
                LoadSubProductCategory();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatorySubProductCategoryDelete())
            {
                DeleteSubProductCategory();
                ClearData();
                LoadSubProductCategory();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxSubProCatCode.Focus();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxSubProCatCode.Focus();
        }

        public void dropDownListProductCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubProductCategory();
        }

        public void gridViewSubProductCat_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSubProductCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = gridViewSubProductCat.SelectedRow;

                ViewState["SelectSubProductCategoryId"] = row.Cells[1].Text.Trim();
                textBoxSubProCatCode2.Text = row.Cells[2].Text.Trim();
                textBoxDescription2.Text = row.Cells[3].Text.Trim();
                accordionInputs.SelectedIndex = 1;
            }
            catch (Exception exception)
            { }

        }

        public void gridViewSubProductCat_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewSubProductCat.PageIndex = e.NewPageIndex;
            gridViewSubProductCat.DataBind();
            LoadSubProductCategory();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatorySubProductCategoryAdd()
        {
            if (dropDownListProductCategory.SelectedValue == null)
            {
                FlashText1.Display("Please Select the Product Category.", "errormessage");
                return false;
            }
            if (textBoxSubProCatCode.Text.Trim() != string.Empty)
            {
                Biz_SubProductCategoryService subProductCategoryService = new Biz_SubProductCategoryService();
                List<Biz_SubProductCategory> subProductCategoryList = new List<Biz_SubProductCategory>();

                subProductCategoryList = subProductCategoryService.ReadSubProductCategoryByCode(Convert.ToInt16(dropDownListProductCategory.SelectedValue), textBoxSubProCatCode.Text.Trim());

                if (subProductCategoryList.Count > 0)
                {
                    FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }
            }
            if (textBoxSubProCatCode.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Sub Product Category Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatorySubProductCategoryModify()
        {
            if (dropDownListProductCategory.SelectedValue == null)
            {
                FlashText1.Display("Please Select the Product Category.", "errormessage");
                return false;
            }
            if (ViewState["SelectSubProductCategoryId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }

            if (textBoxSubProCatCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Sub Product Category Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatorySubProductCategoryDelete()
        {
            if (ViewState["SelectSubProductCategoryId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}