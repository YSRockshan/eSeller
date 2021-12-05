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
    public partial class BzFlexerSecurityGroup : System.Web.UI.Page
    {
        #region "Variables"

        private long SelectSecurityGroupId;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSecurityGroup();
                textBoxSecurityUsrGrpCodeAdd.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxSecurityUsrGrpDescriptionAdd.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
                textBoxSecurityUsrGrpEdit.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxSecurityUsrGrpDescriptionEdit.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
            }
        }

        #region "Load Data"

        public void LoadSecurityGroup()
        {
            Biz_SecurityGroupService securityGroupService = new Biz_SecurityGroupService();
            try
            {
                gridViewSecurityUserGroup.DataSource = securityGroupService.ReadAllSecurityGroup();
                gridViewSecurityUserGroup.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxSecurityUsrGrpCodeAdd.Text = "";
            textBoxSecurityUsrGrpDescriptionAdd.Text = "";
            textBoxSecurityUsrGrpEdit.Text = "";
            textBoxSecurityUsrGrpDescriptionEdit.Text = "";
            ViewState["SelectSecurityGroupId"] = "";
            gridViewSecurityUserGroup.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Operations"

        public void AddSecurityGroup()
        {
            try
            {
                Biz_SecurityGroupService securityGroupService = new Biz_SecurityGroupService();
                Biz_SecurityGroup securityGroup = new Biz_SecurityGroup();

                if (Page.IsValid)
                {
                    if (textBoxSecurityUsrGrpCodeAdd.Text.Trim() != string.Empty)
                    {
                        securityGroup.Code = textBoxSecurityUsrGrpCodeAdd.Text.Trim().ToUpper();
                    }
                    if (textBoxSecurityUsrGrpDescriptionAdd.Text.Trim() != string.Empty)
                    {
                        securityGroup.Description = textBoxSecurityUsrGrpDescriptionAdd.Text.Trim();
                    }

                    securityGroup.DateCreated = DateTime.Now;
                    securityGroup.DateModified = DateTime.Now;

                    securityGroupService.CreateSecurityGroup(securityGroup);
                }
                 FlashText1.Display("Record Successfully Saved.", "okmessage");
            }
            catch (Exception exception)
            {
                 FlashText1.Display("Record Saving Failed.", "okmessage");
            }
        }

        public void ModifySecurityGroup()
        {
            try
            {
                Biz_SecurityGroupService securityGroupService = new Biz_SecurityGroupService();
                Biz_SecurityGroup securityGroup = new Biz_SecurityGroup();

                if (Page.IsValid)
                {
                    securityGroup.Id = Convert.ToInt16(ViewState["SelectSecurityGroupId"]);
                    securityGroup = securityGroupService.ReadSecurityGroupById(securityGroup.Id);

                    if (textBoxSecurityUsrGrpEdit.Text.Trim() != string.Empty)
                    {
                        securityGroup.Code = textBoxSecurityUsrGrpEdit.Text.Trim().ToUpper();
                    }
                    if (textBoxSecurityUsrGrpDescriptionEdit.Text.Trim() != string.Empty)
                    {
                        securityGroup.Description = textBoxSecurityUsrGrpDescriptionEdit.Text.Trim();
                    }

                    securityGroup.DateModified = DateTime.Now;
                    securityGroupService.UpdateSecurityGroup(securityGroup);
                }
                 FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                 FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteSecurityGroup()
        {
            try
            {
                Biz_SecurityGroupService securityGroupService = new Biz_SecurityGroupService();

                if (Page.IsValid)
                {
                    securityGroupService.DeleteSecurityGroup(Convert.ToInt16(ViewState["SelectSecurityGroupId"]));
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
            if (CheckMandatorySecurityGroupAdd())
            {
                AddSecurityGroup();
                ClearData();
                LoadSecurityGroup();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatorySecurityGroupModify())
            {
                ModifySecurityGroup();
                ClearData();
                LoadSecurityGroup();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatorySecurityGroupDelete())
            {
                DeleteSecurityGroup();
                ClearData();
                LoadSecurityGroup();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSecurityGroup();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadSecurityGroup();
        }

        public void gridViewSecurityUserGroup_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSecurityUserGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewSecurityUserGroup.SelectedRow;

            ViewState["SelectSecurityGroupId"] = row.Cells[1].Text.Trim();
            textBoxSecurityUsrGrpEdit.Text = row.Cells[2].Text.Trim();
            textBoxSecurityUsrGrpDescriptionEdit.Text = row.Cells[3].Text.Trim();
            accordionInputs.SelectedIndex = 1;
        }

        public void gridViewSecurityUserGroup_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewSecurityUserGroup.PageIndex = e.NewPageIndex;
            gridViewSecurityUserGroup.DataBind();
            LoadSecurityGroup();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatorySecurityGroupAdd()
        {
            if (textBoxSecurityUsrGrpCodeAdd.Text.Trim() != string.Empty)
            {
                Biz_SecurityGroupService securityGroupService = new Biz_SecurityGroupService();
                List<Biz_SecurityGroup> securityGroupList = null;
                securityGroupList = securityGroupService.ReadSecurityGroupByCode(textBoxSecurityUsrGrpCodeAdd.Text.Trim());

                if (securityGroupList.Count > 0)
                {
                     FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }
            }
            if (textBoxSecurityUsrGrpCodeAdd.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Security User Group Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSecurityUsrGrpDescriptionAdd.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatorySecurityGroupModify()
        {
            if (ViewState["SelectSecurityGroupId"] == null)
            {
                 FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxSecurityUsrGrpEdit.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Security User Group Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSecurityUsrGrpDescriptionEdit.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatorySecurityGroupDelete()
        {
            if (textBoxSecurityUsrGrpEdit.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}