using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Service.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.AgentManagement
{
    public partial class BzFlexerSalesForecast : System.Web.UI.Page
    {
        #region "Variables"

        private long selectSalesForecastId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSalesForecast();
                DataBindTodropDownListPeriodAdd();
                DataBindTodropDownListPeriodEdit();
            }
        }

        #region "LoadData"

        public void LoadSalesForecast()
        {
            try
            {
                Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();

                gridViewSalesForecast.DataSource = salesForecastService.ReadAllSalesForecast();
                gridViewSalesForecast.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        public void DataBindTodropDownListPeriodAdd()
        {
            try
            {
                Biz_PeriodService periodService = new Biz_PeriodService();
                dropDownListPeriodAdd.DataSource = periodService.ReadAllPeriod();
                dropDownListPeriodAdd.DataValueField = "Id";
                dropDownListPeriodAdd.DataTextField = "Description";
                dropDownListPeriodAdd.DataBind();
                dropDownListPeriodAdd.SelectedIndex = 0;
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTodropDownListPeriodEdit()
        {
            try
            {
                Biz_PeriodService periodService = new Biz_PeriodService();
                dropDownListPeriodEdit.DataSource = periodService.ReadAllPeriod();
                dropDownListPeriodEdit.DataValueField = "Id";
                dropDownListPeriodEdit.DataTextField = "Description";
                dropDownListPeriodEdit.DataBind();
                dropDownListPeriodEdit.SelectedIndex = 0;
            }
            catch (Exception exception)
            { }
        }

        #endregion

        #region "Operations"

        public void AddSalesForecast()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();
                    Biz_SalesForecast salesForecast = new Biz_SalesForecast();

                    salesForecast.Code = textBoxSalesforecastCodeAdd.Text.Trim().ToUpper();
                    salesForecast.Description = textBoxSalesforecastDescriptionAdd.Text.Trim();
                    salesForecast.IdPeriod = Convert.ToInt16(dropDownListPeriodAdd.SelectedValue);
                    salesForecast.DateCreated = DateTime.Now;
                    salesForecast.DateModified = DateTime.Now;

                    salesForecastService.CreateSalesForecast(salesForecast);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ModifySalesForecast()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();
                    Biz_SalesForecast salesForecast = new Biz_SalesForecast();

                    salesForecast.Id = Convert.ToInt16(ViewState["selectSalesForecastId"]);
                    salesForecast = salesForecastService.ReadSalesForecastById(salesForecast.Id);

                    salesForecast.Code = textBoxSalesforecastEdit.Text.Trim().ToUpper();
                    salesForecast.Description = textBoxSalesforecastpDescriptionEdit.Text.Trim();
                    salesForecast.IdPeriod = Convert.ToInt16(dropDownListPeriodEdit.SelectedValue);
                    salesForecast.DateModified = DateTime.Now;

                    salesForecastService.UpdateSalesForecast(salesForecast);
                   FlashText1.Display("Record Successfully Modified.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteSalesForecast()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();
                    salesForecastService.DeleteSalesForecast(Convert.ToInt16(ViewState["selectSalesForecastId"]));
                   FlashText1.Display("Record Successfully Deleted.", "okmessage");
                }
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
            dropDownListPeriodAdd.SelectedItem.Text = "-Select-";
            dropDownListPeriodEdit.SelectedItem.Text = "-Select-";
            textBoxSalesforecastCodeAdd.Text = "";
            textBoxSalesforecastDescriptionAdd.Text = "";
            textBoxSalesforecastEdit.Text = "";
            textBoxSalesforecastpDescriptionEdit.Text = "";
            accordionInputs.SelectedIndex = 0;
            gridViewSalesForecast.SelectedIndex = -1;
        }

        #endregion

        #region "Events"

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSalesForecast();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSalesForecast();
        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddSalesForecast();
                ClearData();
                LoadSalesForecast();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldModify())
            {
                ModifySalesForecast();
                ClearData();
                LoadSalesForecast();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldDelete())
            {
                DeleteSalesForecast();
                ClearData();
                LoadSalesForecast();
            }
        }

        public void gridViewSalesForecast_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSalesForecast_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewSalesForecast.PageIndex = e.NewPageIndex;
            LoadSalesForecast();
        }

        public void gridViewSalesForecast_SelectedIndexChanged(object sender, EventArgs e)
        {
            Biz_SalesForecast salesForecast = new Biz_SalesForecast();
            Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();
            Biz_Period period = new Biz_Period();
            Biz_PeriodService periodService = new Biz_PeriodService();

            GridViewRow row = gridViewSalesForecast.SelectedRow;
            ViewState["selectSalesForecastId"] = row.Cells[1].Text.Trim();
            textBoxSalesforecastEdit.Text = row.Cells[2].Text.Trim();
            textBoxSalesforecastpDescriptionEdit.Text = row.Cells[3].Text.Trim();

            salesForecast = salesForecastService.ReadSalesForecastById(Convert.ToInt16(ViewState["selectSalesForecastId"]));
            period = periodService.ReadPeriodById(salesForecast.IdPeriod);

            dropDownListPeriodEdit.SelectedItem.Text = period.Description;
            accordionInputs.SelectedIndex = 1;
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (dropDownListPeriodAdd.SelectedValue == string.Empty)
            {
               FlashText1.Display("Period should be Selected.", "errormessage");
                return false;
            }
            if (textBoxSalesforecastCodeAdd.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Code Cannot be a Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesforecastDescriptionAdd.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Description Cannot be a Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesforecastCodeAdd.Text.Trim() != string.Empty)
            {
                Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();
                List<Biz_SalesForecast> salesForecasts = salesForecastService.ReadSalesForecastByCode(textBoxSalesforecastCodeAdd.Text.Trim());

                if (salesForecasts.Count > 0)
                {
                   FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }
            }
            return true;
        }

        private Boolean CheckMandatoryFieldModify()
        {
            if (ViewState["selectSalesForecastId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (dropDownListPeriodEdit.SelectedValue == string.Empty)
            {
               FlashText1.Display("Period should be Selected.", "errormessage");
                return false;
            }
            if (textBoxSalesforecastEdit.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Code Cannot be a Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesforecastpDescriptionEdit.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Description Cannot be a Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldDelete()
        {
            if (ViewState["selectSalesForecastId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }

            return true;
        }

        #endregion

    }
}