using BzFlexer.SAMS.Biz.AgentManagement;
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
    public partial class BzFlexerPriceBook : System.Web.UI.Page
    {
        #region "Variables"

        private long selectPriceBookId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPriceBook();
                DataBindTodropDownListCurrencyAdd();
                DataBindToDropDownListCurrencyModify();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListCurrencyAdd()
        {
            try
            {
                Biz_CurrencyService currencyService = new Biz_CurrencyService();
                dropDownListCurrencyAdd.DataSource = currencyService.ReadAllCurrency();
                dropDownListCurrencyAdd.DataValueField = "Id";
                dropDownListCurrencyAdd.DataTextField = "Description";
                dropDownListCurrencyAdd.DataBind();
                dropDownListCurrencyAdd.SelectedIndex = 1;
            }
            catch (Exception exception)
            { }
        }

        public void DataBindToDropDownListCurrencyModify()
        {
            try
            {
                Biz_CurrencyService currencyService = new Biz_CurrencyService();
                DropDownListCurrencyModify.DataSource = currencyService.ReadAllCurrency();
                DropDownListCurrencyModify.DataValueField = "Id";
                DropDownListCurrencyModify.DataTextField = "Description";
                DropDownListCurrencyModify.DataBind();
                dropDownListCurrencyAdd.SelectedIndex = 1;
            }
            catch (Exception exception)
            { }
        }

        public void LoadPriceBook()
        {
            try
            {
                Biz_PriceBookService priceBookService = new Biz_PriceBookService();
                gridViewPriceBook.DataSource = priceBookService.ReadAllPriceBooks();
                gridViewPriceBook.DataBind();
            }
            catch (Exception exception)
            { }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxCode.Text = "";
            textBoxCodeModify.Text = "";
            textBoxDescription.Text = "";
            textBoxDescriptionModify.Text = "";
            ViewState["selectPriceBookId"] = "";
            gridViewPriceBook.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Operations"

        public void AddPriceBook()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_PriceBookService priceBookService = new Biz_PriceBookService();
                    Biz_PriceBook priceBook = new Biz_PriceBook();


                    priceBook.IdCurrency = Convert.ToInt16(dropDownListCurrencyAdd.SelectedValue);
                    priceBook.Code = textBoxCode.Text.Trim().ToUpper();
                    priceBook.Description = textBoxDescription.Text.Trim();
                    priceBook.DateCreated = DateTime.Now;
                    priceBook.DateModified = DateTime.Now;

                    priceBookService.CreatePriceBook(priceBook);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ModifyPriceBook()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_PriceBookService priceBookService = new Biz_PriceBookService();
                    Biz_PriceBook priceBook = new Biz_PriceBook();

                    priceBook.Id = Convert.ToInt16(ViewState["selectPriceBookId"]);
                    priceBook = priceBookService.ReadPriceBookById(Convert.ToInt16(priceBook.Id));

                    priceBook.IdCurrency = Convert.ToInt16(DropDownListCurrencyModify.SelectedValue);
                    priceBook.Code = textBoxCodeModify.Text.Trim().ToUpper();
                    priceBook.Description = textBoxDescriptionModify.Text.Trim();
                    priceBook.DateModified = DateTime.Now;

                    priceBookService.UpdatePriceBook(priceBook);
                   FlashText1.Display("Record Successfully Modified.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeletePriceBook()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_PriceBookService priceBookService = new Biz_PriceBookService();
                    priceBookService.DeletePriceBook(Convert.ToInt16(ViewState["selectPriceBookId"]));
                   FlashText1.Display("Record Successfully Deleted.", "okmessage");
                }
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
            if (CheckMandatoryFieldsAdd())
            {
                AddPriceBook();
                ClearData();
                LoadPriceBook();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsModify())
            {
                ModifyPriceBook();
                ClearData();
                LoadPriceBook();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsDelete())
            {
                DeletePriceBook();
                ClearData();
                LoadPriceBook();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadPriceBook();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadPriceBook();
        }

        public void gridViewPriceBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewPriceBook.SelectedRow;
            ViewState["selectPriceBookId"] = row.Cells[1].Text.Trim();
            textBoxCodeModify.Text = row.Cells[2].Text.Trim();
            textBoxDescriptionModify.Text = row.Cells[3].Text.Trim();
            DropDownListCurrencyModify.SelectedIndex = 1;
            accordionInputs.SelectedIndex = 1;
        }

        public void gridViewPriceBook_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewPriceBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewPriceBook.PageIndex = e.NewPageIndex;
            LoadPriceBook();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldsAdd()
        {
            if (textBoxCode.Text == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription.Text == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxCode.Text.Trim() != string.Empty)
            {
                Biz_PriceBookService priceBookService = new Biz_PriceBookService();
                List<Biz_PriceBook> priceBookList = new List<Biz_PriceBook>();

                priceBookList = priceBookService.ReadPriceBookByCode(textBoxCode.Text.Trim());
                if (priceBookList.Count > 0)
                {
                   FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }

            }
            return true;
        }

        private Boolean CheckMandatoryFieldsModify()
        {
            if (ViewState["selectPriceBookId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxCodeModify.Text == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescriptionModify.Text == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }

            return true;
        }

        private Boolean CheckMandatoryFieldsDelete()
        {
            if (ViewState["selectPriceBookId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}