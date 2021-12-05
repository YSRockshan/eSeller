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
    public partial class BzFlexerBudget : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSalesBudget();
                DataBindTodropDownListSalesForecastAdd();
                DataBindTodropDownListPeriodAdd();
                DataBindTodropDownListSalesForecastEdit();
                DataBindTodropDownListPeriodEdit();
            }
        }

        #region "Load Data"

        /// <summary>
        /// Data load to the sales forecast dropdownlist-Add
        /// </summary>
        public void DataBindTodropDownListSalesForecastAdd()
        {
            try
            {
                Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();
                dropDownListSalesForecastAdd.DataSource = salesForecastService.ReadAllSalesForecast();
                dropDownListSalesForecastAdd.DataValueField = "Id";
                dropDownListSalesForecastAdd.DataTextField = "Description";
                dropDownListSalesForecastAdd.DataBind();
            }
            catch (Exception exception)
            { }
        }

        /// <summary>
        /// Data load to the period dropdownlist-Add
        /// </summary>
        public void DataBindTodropDownListPeriodAdd()
        {
            try
            {
                Biz_PeriodService periodService = new Biz_PeriodService();
                dropDownListPeriodAdd.DataSource = periodService.ReadAllPeriod();
                dropDownListPeriodAdd.DataValueField = "Id";
                dropDownListPeriodAdd.DataTextField = "Description";
                dropDownListPeriodAdd.DataBind();
            }
            catch (Exception exception)
            { }
        }

        /// <summary>
        /// Data load to the sales forecast dropdownlist-Modify
        /// </summary>
        public void DataBindTodropDownListSalesForecastEdit()
        {
            try
            {
                Biz_SalesForecastService salesForecastService = new Biz_SalesForecastService();
                dropDownListSalesForecastEdit.DataSource = salesForecastService.ReadAllSalesForecast();
                dropDownListSalesForecastEdit.DataValueField = "Id";
                dropDownListSalesForecastEdit.DataTextField = "Description";
                dropDownListSalesForecastEdit.DataBind();
            }
            catch (Exception exception)
            { }
        }

        /// <summary>
        /// Data load to the period dropdownlist-Modify
        /// </summary>
        public void DataBindTodropDownListPeriodEdit()
        {
            try
            {
                Biz_PeriodService periodService = new Biz_PeriodService();
                dropDownListPeriodEdit.DataSource = periodService.ReadAllPeriod();
                dropDownListPeriodEdit.DataValueField = "Id";
                dropDownListPeriodEdit.DataTextField = "Description";
                dropDownListPeriodEdit.DataBind();
            }
            catch (Exception exception)
            { }
        }

        /// <summary>
        /// Data load to the Sales Budget datagrid
        /// </summary>
        public void LoadSalesBudget()
        {
            try
            {
                Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();
                gridViewSalesBudget.DataSource = salesBudgetService.ReadAllSalesBudgets();
                gridViewSalesBudget.DataBind();
            }
            catch (Exception exception)
            { }
        }

        #endregion

        #region "Display Handling"

        /// <summary>
        /// Clears the data.
        /// </summary>
        /// <remarks></remarks>
        public void ClearData()
        {
            dropDownListPeriodAdd.SelectedIndex = 0;
            dropDownListSalesForecastAdd.SelectedIndex = 0;
            dropDownListPeriodEdit.ClearSelection();
            dropDownListSalesForecastEdit.ClearSelection();

            textBoxSalesBudgetCodeAdd.Text = "";
            textBoxSalesBudgetEdit.Text = "";
            textBoxSalesBudgetDescriptionAdd.Text = "";
            textBoxSalesBudgetpDescriptionEdit.Text = "";
            hiddenFieldPeriodEdit.Value = "";
            hiddenFieldSalesForecastEdit.Value = "";
            ViewState["selectBudgetId"] = "";
            gridViewSalesBudget.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Operations"

        /// <summary>
        /// Sales Budget Add
        /// </summary>
        public void AddSalesBudget()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();
                    Biz_SalesBudget salesBudget = new Biz_SalesBudget();

                    salesBudget.IdPeriod = Convert.ToInt16(dropDownListPeriodAdd.SelectedValue);
                    salesBudget.IdSalesForecast = Convert.ToInt16(dropDownListSalesForecastAdd.SelectedValue);
                    salesBudget.Code = textBoxSalesBudgetCodeAdd.Text.Trim().ToUpper();
                    salesBudget.Description = textBoxSalesBudgetDescriptionAdd.Text.Trim();
                    salesBudget.DateCreated = DateTime.Now;
                    salesBudget.DateModified = DateTime.Now;

                    salesBudgetService.CreateSalesBudget(salesBudget);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");

                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        /// <summary>
        /// Sales Budget Modify
        /// </summary>
        public void ModifySalesBudget()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();
                    Biz_SalesBudget salesBudget = new Biz_SalesBudget();

                    salesBudget.Id = Convert.ToInt16(ViewState["selectBudgetId"]);
                    salesBudget = salesBudgetService.ReadSalesBudgetById(salesBudget.Id);

                    salesBudget.IdPeriod = Convert.ToInt16(hiddenFieldPeriodEdit.Value);
                    salesBudget.IdSalesForecast = Convert.ToInt16(hiddenFieldSalesForecastEdit.Value);
                    salesBudget.Code = textBoxSalesBudgetEdit.Text.Trim().ToUpper();
                    salesBudget.Description = textBoxSalesBudgetpDescriptionEdit.Text.Trim();
                    salesBudget.DateModified = DateTime.Now;

                    salesBudgetService.UpdateSalesBudget(salesBudget);
                   FlashText1.Display("Record Successfully Modified.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        /// <summary>
        /// Sales Budget Delete
        /// </summary>
        public void DeleteSalesBudget()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();
                    salesBudgetService.DeleteSalesBudgets(Convert.ToInt16(ViewState["selectBudgetId"]));
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
        /// <summary>
        /// Click Event Handling of buttonSave 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsAdd())
            {
                AddSalesBudget();
                ClearData();
                LoadSalesBudget();
            }
        }

        /// <summary>
        /// Click Event Handling buttonModify
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsModify())
            {
                ModifySalesBudget();
                ClearData();
                LoadSalesBudget();
            }
        }

        /// <summary>
        /// Click Event Handling buttonDelete 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsDelete())
            {
                DeleteSalesBudget();
                ClearData();
                LoadSalesBudget();
            }
        }

        /// <summary>
        /// Click Event Handling buttonCancel1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSalesBudget();
        }

        /// <summary>
        /// Click Event Handling buttonCancel2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSalesBudget();
        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of the gridViewSalesBudget control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        public void gridViewSalesBudget_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewSalesBudget.SelectedRow;
            ViewState["selectBudgetId"] = row.Cells[1].Text.Trim();
            textBoxSalesBudgetEdit.Text = row.Cells[2].Text.Trim();
            textBoxSalesBudgetpDescriptionEdit.Text = row.Cells[3].Text.Trim();

            Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();
            Biz_SalesBudget salesBudget = new Biz_SalesBudget();
            salesBudget = salesBudgetService.ReadSalesBudgetById(Convert.ToInt16(row.Cells[1].Text.Trim()));

            dropDownListPeriodEdit.SelectedItem.Text = new Biz_PeriodService().ReadPeriodById(salesBudget.IdPeriod).Description;
            hiddenFieldPeriodEdit.Value = new Biz_PeriodService().ReadPeriodById(salesBudget.IdPeriod).Id.ToString();
            dropDownListSalesForecastEdit.SelectedItem.Text =
                new Biz_SalesForecastService().ReadSalesForecastById(salesBudget.IdSalesForecast).Description;
            hiddenFieldSalesForecastEdit.Value =
                new Biz_SalesForecastService().ReadSalesForecastById(salesBudget.IdSalesForecast).Id.ToString();
            accordionInputs.SelectedIndex = 1;
        }

        /// <summary>
        /// Handles the RowCreated event of the gridViewSalesBudget control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewRowEventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        public void gridViewSalesBudget_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        /// <summary>
        /// Handles the PageIndexChanging event of the gridViewSalesBudget control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Web.UI.WebControls.GridViewPageEventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        public void gridViewSalesBudget_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadSalesBudget();
            gridViewSalesBudget.PageIndex = e.NewPageIndex;
            gridViewSalesBudget.DataBind();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the dropDownListSalesForecastEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        public void dropDownListSalesForecastEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            hiddenFieldSalesForecastEdit.Value = dropDownListSalesForecastEdit.SelectedValue;
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the dropDownListPeriodEdit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <remarks></remarks>
        public void dropDownListPeriodEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            hiddenFieldPeriodEdit.Value = dropDownListPeriodEdit.SelectedValue;
        }

        #endregion

        #region "Validations"

        /// <summary>
        /// Checks the mandatory fields add.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private Boolean CheckMandatoryFieldsAdd()
        {
            if (dropDownListSalesForecastAdd.SelectedValue == null)
            {
               FlashText1.Display("Sales Forecast Cannot be Blank.", "errormessage");
                return false;
            }
            if (dropDownListPeriodAdd.SelectedValue == null)
            {
               FlashText1.Display("Period Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesBudgetCodeAdd.Text == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesBudgetDescriptionAdd.Text == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesBudgetCodeAdd.Text.Trim() != string.Empty)
            {
                Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();
                List<Biz_SalesBudget> budgetList = new List<Biz_SalesBudget>();

                budgetList = salesBudgetService.ReadSalesBudgetByCode(textBoxSalesBudgetCodeAdd.Text.Trim());
                if (budgetList.Count > 0)
                {
                   FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// Checks the mandatory fields modify.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private Boolean CheckMandatoryFieldsModify()
        {
            if (ViewState["selectBudgetId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (dropDownListSalesForecastEdit.SelectedValue == null)
            {
               FlashText1.Display("Sales Forecast Cannot be Blank.", "errormessage");
                return false;
            }
            if (dropDownListPeriodEdit.SelectedValue == null)
            {
               FlashText1.Display("Period Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesBudgetEdit.Text == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesBudgetpDescriptionEdit.Text == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks the mandatory fields delete.
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        private Boolean CheckMandatoryFieldsDelete()
        {
            if (ViewState["selectBudgetId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}