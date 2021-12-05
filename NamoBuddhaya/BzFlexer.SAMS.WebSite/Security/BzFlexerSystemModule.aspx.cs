using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.Security
{
    public partial class BzFlexerSystemModule : System.Web.UI.Page
    {
        #region "Variables"

        private long selectSystemModuleId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSystemModule();
            }
        }



        #region "Load Data"

        public void LoadSystemModule()
        {
            Biz_SystemModuleService systemModuleService = new Biz_SystemModuleService();

            try
            {
                gridViewSystemModule.DataSource = systemModuleService.ReadAllSystemModule();
                gridViewSystemModule.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxModuleCodeAdd.Text = "";
            textBoxModuleDescriptionAdd.Text = "";
            textBoxModuleCodeEdit.Text = "";
            textBoxModuleDescriptionEdit.Text = "";
            ViewState["selectSystemModuleId"] = null;
            accordionInputs.SelectedIndex = 0;
            gridViewSystemModule.SelectedIndex = -1;
        }

        #endregion

        #region "Operations"

        public void AddSystemModule()
        {
            try
            {
                Biz_SystemModule systemModule = new Biz_SystemModule();
                Biz_SystemModuleService systemModuleService = new Biz_SystemModuleService();

                if (Page.IsValid)
                {
                    if (textBoxModuleCodeAdd.Text.Trim() != string.Empty)
                    {
                        systemModule.SystemModule_Code = textBoxModuleCodeAdd.Text.Trim().ToUpper();
                    }
                    if (textBoxModuleDescriptionAdd.Text.Trim() != string.Empty)
                    {
                        systemModule.Description = textBoxModuleDescriptionAdd.Text.Trim();
                    }
                    systemModule.DateCreated = DateTime.Now;
                    systemModule.DateModified = DateTime.Now;

                    systemModuleService.CreateSystemModule(systemModule);
                }
                 FlashText1.Display("Record Successfully Saved.", "okmessage");
            }
            catch (Exception exception)
            {
                 FlashText1.Display("Record Already Exists.", "okmessage");
            }
        }

        public void ModifySystemModule()
        {
            try
            {
                Biz_SystemModule systemModule = new Biz_SystemModule();
                Biz_SystemModuleService systemModuleService = new Biz_SystemModuleService();

                if (Page.IsValid)
                {
                    systemModule.Id = Convert.ToInt16(ViewState["selectSystemModuleId"]);
                    systemModule = systemModuleService.ReadSystemModuleById(systemModule.Id);

                    if (textBoxModuleCodeEdit.Text.Trim() != string.Empty)
                    {
                        systemModule.SystemModule_Code = textBoxModuleCodeEdit.Text.Trim().ToUpper();
                    }
                    if (textBoxModuleDescriptionEdit.Text.Trim() != string.Empty)
                    {
                        systemModule.Description = textBoxModuleDescriptionEdit.Text.Trim();
                    }

                    systemModule.DateModified = DateTime.Now;

                    systemModuleService.UpdateSystemModule(systemModule);

                }
                 FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                 FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteSystemModule()
        {
            try
            {
                Biz_SystemModuleService systemModuleService = new Biz_SystemModuleService();
                if (Page.IsValid)
                {
                    systemModuleService.DeleteSystemModule(Convert.ToInt16(ViewState["selectSystemModuleId"]));
                    LoadSystemModule();
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
            if (CheckMandatoryFieldsAdd())
            {
                AddSystemModule();
                ClearData();
                LoadSystemModule();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsModify())
            {
                ModifySystemModule();
                ClearData();
                LoadSystemModule();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsDelete())
            {
                DeleteSystemModule();
                ClearData();
                LoadSystemModule();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSystemModule();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSystemModule();
        }

        public void gridViewSystemModule_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSystemModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewSystemModule.SelectedRow;

            ViewState["selectSystemModuleId"] = row.Cells[1].Text.Trim();
            textBoxModuleCodeEdit.Text = row.Cells[2].Text.Trim();
            textBoxModuleDescriptionEdit.Text = row.Cells[3].Text.Trim();
            accordionInputs.SelectedIndex = 1;
        }

        public void gridViewSystemModule_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewSystemModule.PageIndex = e.NewPageIndex;
            gridViewSystemModule.DataBind();
            LoadSystemModule();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldsAdd()
        {
            if (textBoxModuleCodeAdd.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Module Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxModuleDescriptionAdd.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldsModify()
        {
            if (ViewState["selectSystemModuleId"] == null)
            {
                 FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxModuleCodeEdit.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Module Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxModuleDescriptionEdit.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldsDelete()
        {
            if (ViewState["selectSystemModuleId"] == null)
            {
                 FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}