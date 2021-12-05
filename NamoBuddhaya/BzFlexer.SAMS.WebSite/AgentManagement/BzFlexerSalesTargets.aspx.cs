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
    public partial class BzFlexerSalesTargets : System.Web.UI.Page
    {
        #region "Variables"

        private long selectTargetId;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSalesTarget();
                DataBindTodropDownListSalesBudgetAdd();
                DataBindTodropDownListPeriodAdd();
                DataBindTodropDownListSalesBudgetEdit();
                DataBindTodropDownListPeriodEdit();
                DataBindTodropDownListCommissionAdd();
                DataBindTodropDownListCommissionModify();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListSalesBudgetAdd()
        {
            try
            {
                Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();
                dropDownListSalesBudgetAdd.DataSource = salesBudgetService.ReadAllSalesBudgets();
                dropDownListSalesBudgetAdd.DataValueField = "Id";
                dropDownListSalesBudgetAdd.DataTextField = "Description";
                dropDownListSalesBudgetAdd.DataBind();
            }
            catch (Exception exception)
            { }
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
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTodropDownListCommissionModify()
        {
            try
            {
                Biz_CommissionsService commissionService = new Biz_CommissionsService();
                dropDownListCommissionModify.DataSource = commissionService.ReadAllCommissions();
                dropDownListCommissionModify.DataValueField = "Id";
                dropDownListCommissionModify.DataTextField = "Description";
                dropDownListCommissionModify.DataBind();
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTodropDownListSalesBudgetEdit()
        {
            try
            {
                Biz_SalesBudgetService salesBudgetService = new Biz_SalesBudgetService();
                dropDownListSalesBudgetEdit.DataSource = salesBudgetService.ReadAllSalesBudgets();
                dropDownListSalesBudgetEdit.DataValueField = "Id";
                dropDownListSalesBudgetEdit.DataTextField = "Description";
                dropDownListSalesBudgetEdit.DataBind();
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
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTodropDownListCommissionAdd()
        {
            try
            {
                Biz_CommissionsService commissionService = new Biz_CommissionsService();
                dropDownListCommissionAdd.DataSource = commissionService.ReadAllCommissions();
                dropDownListCommissionAdd.DataValueField = "Id";
                dropDownListCommissionAdd.DataTextField = "Description";
                dropDownListCommissionAdd.DataBind();
            }
            catch (Exception exception)
            { }
        }

        public void LoadSalesTarget()
        {
            try
            {
                Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();
                gridViewSalesTarget.DataSource = salesTargetService.ReadAllSalesTargets();
                gridViewSalesTarget.DataBind();
            }
            catch (Exception exception)
            { }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            dropDownListPeriodAdd.SelectedIndex = 0;
            dropDownListSalesBudgetAdd.SelectedIndex = 0;
            dropDownListCommissionAdd.SelectedIndex = 0;
            dropDownListPeriodEdit.ClearSelection();
            dropDownListSalesBudgetEdit.ClearSelection();
            dropDownListSalesBudgetEdit.ClearSelection();

            textBoxSalesTargetCodeAdd.Text = "";
            textBoxSalesTargetEdit.Text = "";
            textBoxSalesTargetDescriptionAdd.Text = "";
            textBoxSalesTargetpDescriptionEdit.Text = "";
            hiddenFieldPeriodEdit.Value = "";
            hiddenFieldSalesBudgetEdit.Value = "";
            hiddenFieldCommssionModify.Value = "";
            ViewState["selectTargetId"] = "";
            gridViewSalesTarget.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Operations"

        public void AddSalesTarget()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();
                    Biz_SalesTarget salesTarget = new Biz_SalesTarget();

                    salesTarget.IdPeriod = Convert.ToInt16(dropDownListPeriodAdd.SelectedValue);
                    salesTarget.IdSalesBudget = Convert.ToInt16(dropDownListSalesBudgetAdd.SelectedValue);
                    salesTarget.Code = textBoxSalesTargetCodeAdd.Text.Trim().ToUpper();
                    salesTarget.IdCommssion = Convert.ToInt16(dropDownListCommissionAdd.SelectedValue);
                    salesTarget.Description = textBoxSalesTargetDescriptionAdd.Text.Trim();
                    salesTarget.DateCreated = DateTime.Now;
                    salesTarget.DateModified = DateTime.Now;

                    salesTargetService.CreateSalesTarget(salesTarget);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ModifySalesTarget()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();
                    Biz_SalesTarget salesTarget = new Biz_SalesTarget();

                    salesTarget.Id = Convert.ToInt16(ViewState["selectTargetId"]);
                    salesTarget = salesTargetService.ReadSalesTargetById(Convert.ToInt16(salesTarget.Id));

                    salesTarget.IdPeriod = Convert.ToInt16(hiddenFieldPeriodEdit.Value);
                    salesTarget.IdSalesBudget = Convert.ToInt16(hiddenFieldSalesBudgetEdit.Value);
                    salesTarget.Code = textBoxSalesTargetEdit.Text.Trim().ToUpper();
                    salesTarget.Description = textBoxSalesTargetpDescriptionEdit.Text.Trim();
                    salesTarget.IdCommssion = Convert.ToInt16(hiddenFieldCommssionModify.Value);
                    salesTarget.DateModified = DateTime.Now;

                    salesTargetService.UpdateSalesTarget(salesTarget);
                   FlashText1.Display("Record Successfully Modified.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteSalesTarget()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();
                    salesTargetService.DeleteSalesTarget(Convert.ToInt16(ViewState["selectTargetId"]));
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
                AddSalesTarget();
                ClearData();
                LoadSalesTarget();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsModify())
            {
                ModifySalesTarget();
                ClearData();
                LoadSalesTarget();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsDelete())
            {
                DeleteSalesTarget();
                ClearData();
                LoadSalesTarget();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSalesTarget();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSalesTarget();
        }

        public void gridViewSalesTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewSalesTarget.SelectedRow;
            ViewState["selectTargetId"] = row.Cells[1].Text.Trim();
            textBoxSalesTargetEdit.Text = row.Cells[2].Text.Trim();
            textBoxSalesTargetpDescriptionEdit.Text = row.Cells[3].Text.Trim();

            Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();
            Biz_SalesTarget salesTarget = new Biz_SalesTarget();
            salesTarget = salesTargetService.ReadSalesTargetById(Convert.ToInt16(row.Cells[1].Text.Trim()));

            dropDownListPeriodEdit.SelectedItem.Text = new Biz_PeriodService().ReadPeriodById(salesTarget.IdPeriod).Description;
            hiddenFieldPeriodEdit.Value = new Biz_PeriodService().ReadPeriodById(salesTarget.IdPeriod).Id.ToString();
            dropDownListSalesBudgetEdit.SelectedItem.Text =
                new Biz_SalesBudgetService().ReadSalesBudgetById(Convert.ToInt16(salesTarget.IdSalesBudget)).Description;
            hiddenFieldSalesBudgetEdit.Value =
                new Biz_SalesBudgetService().ReadSalesBudgetById(Convert.ToInt16(salesTarget.IdSalesBudget)).Id.ToString();
            dropDownListCommissionModify.SelectedItem.Text =
                new Biz_CommissionsService().ReadCommissionById(Convert.ToInt16(salesTarget.IdCommssion)).Description;
            hiddenFieldCommssionModify.Value =
                new Biz_CommissionsService().ReadCommissionById(Convert.ToInt16(salesTarget.IdCommssion)).Id.ToString();
            accordionInputs.SelectedIndex = 1;
        }

        public void gridViewSalesTarget_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSalesTarget_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewSalesTarget.PageIndex = e.NewPageIndex;
            LoadSalesTarget();
        }

        public void dropDownListSalesBudgetEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            hiddenFieldSalesBudgetEdit.Value = dropDownListSalesBudgetEdit.SelectedValue;
        }

        public void dropDownListPeriodEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            hiddenFieldPeriodEdit.Value = dropDownListPeriodEdit.SelectedValue;
        }

        public void dropDownListCommissionModify_SelectedIndexChanged(object sender, EventArgs e)
        {
            hiddenFieldCommssionModify.Value = dropDownListCommissionModify.SelectedValue;
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldsAdd()
        {
            if (dropDownListSalesBudgetAdd.SelectedValue == null)
            {
               FlashText1.Display("Sales Budget Cannot be Blank.", "errormessage");
                return false;
            }
            if (dropDownListPeriodAdd.SelectedValue == null)
            {
               FlashText1.Display("Period Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesTargetCodeAdd.Text == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesTargetDescriptionAdd.Text == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (dropDownListCommissionAdd.SelectedValue == null)
            {
               FlashText1.Display("Commission Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesTargetCodeAdd.Text.Trim() != string.Empty)
            {
                Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();
                List<Biz_SalesTarget> targetList = new List<Biz_SalesTarget>();

                targetList = salesTargetService.ReadSalesTargetByCode(textBoxSalesTargetCodeAdd.Text.Trim());
                if (targetList.Count > 0)
                {
                   FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }

            }
            return true;
        }

        private Boolean CheckMandatoryFieldsModify()
        {
            if (ViewState["selectTargetId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (dropDownListSalesBudgetEdit.SelectedValue == null)
            {
               FlashText1.Display("Sales Budget Cannot be Blank.", "errormessage");
                return false;
            }
            if (dropDownListPeriodEdit.SelectedValue == null)
            {
               FlashText1.Display("Period Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesTargetEdit.Text == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSalesTargetpDescriptionEdit.Text == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (dropDownListCommissionModify.SelectedValue == null)
            {
               FlashText1.Display("Commission Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldsDelete()
        {
            if (ViewState["selectTargetId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}