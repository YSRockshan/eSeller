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
    public partial class BzFlexerCommissions : System.Web.UI.Page
    {
        #region "Variables"

        private long selectCommissionId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTogridViewCommission();
                textBoxCommissionAdd.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxCommissionDescriptionAdd.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
                textBoxCommissionModify.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxCommissionDescriptionModify.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
            }
        }

        #region "Load Data"

        public void DataBindTogridViewCommission()
        {
            Biz_CommissionsService commissionService = new Biz_CommissionsService();
            gridViewCommission.DataSource = commissionService.ReadAllCommissions();
            gridViewCommission.DataBind();
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxCommissionAdd.Text = "";
            textBoxCommissionDescriptionAdd.Text = "";
            textBoxCommissionDescriptionModify.Text = "";
            textBoxCommissionModify.Text = "";
            hiddenFieldCommssionModeEdit.Value = null;
            gridViewCommission.SelectedIndex = -1;
            radioButtonListCommissionMode.SelectedIndex = 0;
            radioButtonListCommissionModeEdit.SelectedIndex = 0;
            accordionInputs.SelectedIndex = 0;
            ViewState["selectCommissionId"] = "";
        }

        #endregion

        #region "Operations"

        public void AddCommission()
        {
            try
            {
                Biz_CommissionsService commissionService = new Biz_CommissionsService();
                Biz_Commission commission = new Biz_Commission();

                if (Page.IsValid)
                {
                    commission.Code = textBoxCommissionAdd.Text.Trim().ToUpper();
                    commission.Description = textBoxCommissionDescriptionAdd.Text.Trim();
                    if (radioButtonListCommissionMode.SelectedIndex == 0)
                    {
                        commission.Mode = "S";
                    }
                    else
                    {
                        commission.Mode = "M";
                    }
                    commission.Status = "A";
                    commission.DateCreated = DateTime.Now;
                    commission.DateModified = DateTime.Now;

                    commissionService.CreateCommission(commission);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ModifyCommission()
        {
            try
            {
                Biz_CommissionsService commissionService = new Biz_CommissionsService();
                Biz_Commission commission = new Biz_Commission();

                if (Page.IsValid)
                {
                    commission.Id = Convert.ToInt16(ViewState["selectCommissionId"]);
                    commission = commissionService.ReadCommissionById(commission.Id);
                    commission.Code = textBoxCommissionModify.Text.Trim().ToUpper();
                    commission.Description = textBoxCommissionDescriptionModify.Text.Trim();
                    if (radioButtonListCommissionModeEdit.SelectedIndex == 0)
                    {
                        commission.Mode = "S";
                    }
                    else
                    {
                        commission.Mode = "M";
                    }
                    commission.Status = "A";
                    commission.DateModified = DateTime.Now;

                    commissionService.UpdateCommission(commission);
                   FlashText1.Display("Record Successfully Modified.", "okmessage");

                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteCommission()
        {
            try
            {
                Biz_CommissionsService commissionService = new Biz_CommissionsService();
                if (Page.IsValid)
                {
                    commissionService.DeleteCommissions(Convert.ToInt16(ViewState["selectCommissionId"]));
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
                AddCommission();
                DataBindTogridViewCommission();
                ClearData();
            }
        }

        public void buttonEdit_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsModify())
            {
                ModifyCommission();
                DataBindTogridViewCommission();
                ClearData();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsDelete())
            {
                DeleteCommission();
                DataBindTogridViewCommission();
                ClearData();
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

        public void gridViewCommission_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewCommission_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataBindTogridViewCommission();
            gridViewCommission.PageIndex = e.NewPageIndex;
            gridViewCommission.DataBind();
        }

        public void gridViewCommission_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewCommission.SelectedRow;
            ViewState["selectCommissionId"] = row.Cells[1].Text.Trim();
            textBoxCommissionModify.Text = row.Cells[2].Text.Trim();
            textBoxCommissionDescriptionModify.Text = row.Cells[3].Text.Trim();
            accordionInputs.SelectedIndex = 1;
            hiddenFieldCommssionModeEdit.Value =
                new Biz_CommissionsService().ReadCommissionById(Convert.ToInt16(ViewState["selectCommissionId"])).Mode;
            if (hiddenFieldCommssionModeEdit.Value == "S")
            {
                radioButtonListCommissionModeEdit.SelectedIndex = 0;
            }
            else
            {
                radioButtonListCommissionModeEdit.SelectedIndex = 1;
            }
        }

        #endregion

        #region "Validation"

        private Boolean CheckMandatoryFieldsAdd()
        {
            if (textBoxCommissionAdd.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }

            if (textBoxCommissionDescriptionAdd.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }

            if (textBoxCommissionAdd.Text.Trim() != string.Empty)
            {
                List<Biz_Commission> commissions = new List<Biz_Commission>();
                commissions = new Biz_CommissionsService().ReadCommissionByCode(textBoxCommissionAdd.Text.Trim());

                if (commissions.Count > 0)
                {
                   FlashText1.Display("Record Already Exists.", "okmessage");
                    return false;
                }
            }

            return true;
        }

        private Boolean CheckMandatoryFieldsModify()
        {
            if (ViewState["selectCommissionId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }

            if (textBoxCommissionModify.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }

            if (textBoxCommissionDescriptionModify.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }

            return true;
        }

        private Boolean CheckMandatoryFieldsDelete()
        {
            if (ViewState["selectCommissionId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }

            return true;
        }

        #endregion
    }
}