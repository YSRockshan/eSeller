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
    public partial class BzFlexerStakeholderTypes : System.Web.UI.Page
    {
        #region "Variables"

        public string SelectStakeholderTypeId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadStakeholderType();
                textBoxStakeholderTypeAdd.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxStakeholderTypeDescriptionAdd.Attributes.Add("onchange", "javascript:this.valu=toTitleCase(this.value)");
                textBoxStakeholderTypeModify.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxStakeholderTypeDescriptionModify.Attributes.Add("onchange", "javascript:this.valu=toTitleCase(this.value)");
            }
        }

        #region "Load data"

        public void LoadStakeholderType()
        {
            Biz_StakeholderTypeService stakeholderTypeService = new Biz_StakeholderTypeService();

            try
            {
                gridViewStakeholderType.DataSource = stakeholderTypeService.ReadAllStakeholderType();
                gridViewStakeholderType.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Operations"

        public void AddStakeholderType()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_StakeholderType stakeholderType = new Biz_StakeholderType();
                    Biz_StakeholderTypeService stakeholderTypeService = new Biz_StakeholderTypeService();

                    if (textBoxStakeholderTypeAdd.Text.Trim() != string.Empty)
                    {
                        stakeholderType.Code = textBoxStakeholderTypeAdd.Text.Trim().ToUpper();
                    }
                    if (textBoxStakeholderTypeDescriptionAdd.Text.Trim() != string.Empty)
                    {
                        stakeholderType.Description = textBoxStakeholderTypeDescriptionAdd.Text.Trim();
                    }

                    stakeholderType.DateCreated = DateTime.Now;
                    stakeholderType.DateModified = DateTime.Now;

                    stakeholderTypeService.CreateStakeholderType(stakeholderType);
                }
                FlashText1.Display("Record successfully Saved.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Saving Failed.", "okmessage");
            }
        }

        public void ModifyStakeholderType()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_StakeholderType stakeholderType = new Biz_StakeholderType();
                    Biz_StakeholderTypeService stakeholderTypeService = new Biz_StakeholderTypeService();
                    stakeholderType.Id = Convert.ToInt16(ViewState["SelectStakeholderTypeId"]);
                    stakeholderType = stakeholderTypeService.ReadStakeholderTypeById(stakeholderType.Id);

                    if (textBoxStakeholderTypeModify.Text.Trim() != string.Empty)
                    {
                        stakeholderType.Code = textBoxStakeholderTypeModify.Text.Trim().ToUpper();
                    }
                    if (textBoxStakeholderTypeDescriptionModify.Text.Trim() != string.Empty)
                    {
                        stakeholderType.Description = textBoxStakeholderTypeDescriptionModify.Text.Trim();
                    }

                    stakeholderType.DateModified = DateTime.Now;
                    stakeholderTypeService.UpdateStakeholderType(stakeholderType);
                }
                FlashText1.Display("Record successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "errormessage");
            }

        }

        public void DeleteStakeholderType()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_StakeholderType stakeholderType = new Biz_StakeholderType();
                    Biz_StakeholderTypeService stakeholderTypeService = new Biz_StakeholderTypeService();

                    stakeholderType.Id = Convert.ToInt16(ViewState["SelectStakeholderTypeId"]);
                    stakeholderTypeService.DeleteStakeholderTypes(stakeholderType.Id);
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
            textBoxStakeholderTypeAdd.Text = "";
            textBoxStakeholderTypeDescriptionAdd.Text = "";
            textBoxStakeholderTypeModify.Text = "";
            textBoxStakeholderTypeDescriptionModify.Text = "";
            ViewState["SelectStakeholderTypeId"] = null;
            gridViewStakeholderType.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryStakeholderTypeAdd())
            {
                AddStakeholderType();
                ClearData();
                LoadStakeholderType();
            }
        }

        public void buttonEdit_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryStakeholderTypeModify())
            {
                ModifyStakeholderType();
                ClearData();
                LoadStakeholderType();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (ChekcMandatoryStakeholderTypeDelete())
            {
                DeleteStakeholderType();
                ClearData();
                LoadStakeholderType();
            }
        }

        public void buttonCancel1_click(object sender, EventArgs e)
        {
            ClearData();
            textBoxStakeholderTypeAdd.Focus();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxStakeholderTypeAdd.Focus();
        }

        public void gridViewStakeholderType_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewStakeholderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewStakeholderType.SelectedRow;

            ViewState["SelectStakeholderTypeId"] = row.Cells[1].Text.Trim();
            textBoxStakeholderTypeModify.Text = row.Cells[2].Text.Trim();
            textBoxStakeholderTypeDescriptionModify.Text = row.Cells[3].Text.Trim();

            accordionInputs.SelectedIndex = 1;
        }

        public void gridViewStakeholderType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadStakeholderType();
            gridViewStakeholderType.SelectedIndex = e.NewPageIndex;
            gridViewStakeholderType.DataBind();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryStakeholderTypeAdd()
        {
            if (textBoxStakeholderTypeAdd.Text != string.Empty)
            {
                Biz_StakeholderTypeService stakeholderTypeService = new Biz_StakeholderTypeService();
                List<Biz_StakeholderType> stakeholderTypeList = new List<Biz_StakeholderType>();

                stakeholderTypeList = stakeholderTypeService.ReadStakeholderTypeByCode(textBoxStakeholderTypeAdd.Text);
                if (stakeholderTypeList.Count > 0)
                {
                    FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }

            }
            if (textBoxStakeholderTypeAdd.Text == string.Empty)
            {
                FlashText1.Display("Stakeholder Type Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxStakeholderTypeDescriptionAdd.Text == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryStakeholderTypeModify()
        {
            if (ViewState["SelectStakeholderTypeId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxStakeholderTypeModify.Text == string.Empty)
            {
                FlashText1.Display("Stakeholder Type Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxStakeholderTypeDescriptionModify.Text == string.Empty)
            {
                FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean ChekcMandatoryStakeholderTypeDelete()
        {
            if (textBoxStakeholderTypeModify.Text.Trim() == string.Empty)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion

    }
}