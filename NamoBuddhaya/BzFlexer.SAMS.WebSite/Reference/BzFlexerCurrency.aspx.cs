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
    public partial class BzFlexerCurrency : System.Web.UI.Page
    {
        #region "Variables"

        private long SelectCurrencyId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCurrency();
                textBoxCurrencyCode.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxDescription.Attributes.Add("onchange", "javascript:this.value=toTitlecase(this.value);");
                textBoxCurrencyCode2.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxDescription2.Attributes.Add("onchange", "javascript:this.value=toTitlecase(this.value);");
            }
        }

        #region "Load Data"

        public void LoadCurrency()
        {
            Biz_CurrencyService currencyService = new Biz_CurrencyService();

            try
            {
                gridViewCurrency.DataSource = currencyService.ReadAllCurrency();
                gridViewCurrency.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Operation"

        public void AddCurrency()
        {
            try
            {
                if (Page.IsValid)
                {

                    Biz_Currency currency = new Biz_Currency();
                    Biz_CurrencyService currencyService = new Biz_CurrencyService();

                    if (textBoxCurrencyCode.Text.Trim() != String.Empty)
                    {
                        currency.Code = textBoxCurrencyCode.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription.Text.Trim() != String.Empty)
                    {
                        currency.Description = textBoxDescription.Text.Trim();
                    }
                    currency.DateCreated = DateTime.Now;
                    currency.DateModified = DateTime.Now;

                    currencyService.CreateCurrency(currency);
                }
                FlashText1.Display("Record Successfully Saved.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Already Exists.", "okmessage");
            }
        }

        public void ModifyCurrency()
        {
            try
            {
                if (Page.IsValid)
                {

                    Biz_Currency currency = new Biz_Currency();
                    Biz_CurrencyService currencyService = new Biz_CurrencyService();

                    currency.Id = Convert.ToInt16(ViewState["SelectCurrencyId"]);
                    currency = currencyService.ReadCurrencyById(currency.Id);

                    if (textBoxCurrencyCode2.Text.Trim() != string.Empty)
                    {
                        currency.Code = textBoxCurrencyCode2.Text.Trim().ToUpper();
                    }
                    if (textBoxDescription2.Text.Trim() != string.Empty)
                    {
                        currency.Description = textBoxDescription2.Text.Trim();
                    }
                    currency.DateModified = DateTime.Now;

                    currencyService.UpdateCurrency(currency);
                }
                FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteCurrency()
        {
            try
            {
                if (Page.IsValid)
                {

                    Biz_Currency currency = new Biz_Currency();
                    Biz_CurrencyService currencyService = new Biz_CurrencyService();

                    currency.Id = Convert.ToInt16(ViewState["SelectCurrencyId"]);
                    currencyService.DeleteCurrency(currency.Id);
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
            textBoxCurrencyCode.Text = "";
            textBoxDescription.Text = "";
            textBoxCurrencyCode2.Text = "";
            textBoxDescription2.Text = "";
            ViewState["SelectCurrencyId"] = null;
            gridViewCurrency.SelectedIndex = -1;
            accordianInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryCurrencyAdd())
            {
                AddCurrency();
                ClearData();
                LoadCurrency();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryCurrencyModify())
            {
                ModifyCurrency();
                ClearData();
                LoadCurrency();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryCurrencyDelete())
            {
                DeleteCurrency();
                ClearData();
                LoadCurrency();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxCurrencyCode.Focus();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxCurrencyCode.Focus();
        }

        public void gridViewCurrency_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewCurrency.SelectedRow;

            ViewState["SelectCurrencyId"] = row.Cells[1].Text.Trim();
            textBoxCurrencyCode2.Text = row.Cells[2].Text.Trim();
            textBoxDescription2.Text = row.Cells[3].Text.Trim();

            accordianInputs.SelectedIndex = 1;

        }

        public void gridViewCurrency_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadCurrency();
            gridViewCurrency.PageIndex = e.NewPageIndex;
            gridViewCurrency.DataBind();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryCurrencyAdd()
        {
            if (textBoxCurrencyCode.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Currency Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxCurrencyCode.Text.Trim() != string.Empty)
            {
                Biz_CurrencyService currencyService = new Biz_CurrencyService();
                List<Biz_Currency> currencyList = new List<Biz_Currency>();

                currencyList = currencyService.ReadCurrencyByCode(textBoxCurrencyCode.Text.Trim());
                if (currencyList.Count > 0)
                {
                    FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }

            }
            return true;
        }

        private Boolean CheckMandatoryCurrencyModify()
        {
            if (ViewState["SelectCurrencyId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxCurrencyCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Currency Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxDescription2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryCurrencyDelete()
        {
            if (textBoxCurrencyCode2.Text.Trim() == string.Empty)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}