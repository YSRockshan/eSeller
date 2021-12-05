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
    public partial class BzFlexerAccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListsecurityGroup();
                //DataBindTodropDownListStakeholderType();
                LoadMappedStakeholders();
                LoadUnMappedStakeholders();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListsecurityGroup()
        {
            Biz_SecurityGroupService securityGroupService = new Biz_SecurityGroupService();
            dropDownListsecurityGroup.DataSource = securityGroupService.ReadAllSecurityGroup();
            dropDownListsecurityGroup.DataValueField = "Id";
            dropDownListsecurityGroup.DataTextField = "Description";
            dropDownListsecurityGroup.DataBind();
            dropDownListsecurityGroup.SelectedIndex = 0;
        }

        public void DataBindTodropDownListStakeholderType()
        {
            if (dropDownListsecurityGroup.SelectedIndex > 0)
            {
                Biz_StakeholderSecurityGroupService stakeholderSecurityGroupService = new Biz_StakeholderSecurityGroupService();

                dropDownListStakeholderType.DataSource =
                    stakeholderSecurityGroupService.DataBindTodropDownListStakeholderTypes(Convert.ToInt16(dropDownListsecurityGroup.SelectedValue));
                dropDownListStakeholderType.DataValueField = "Id";
                dropDownListStakeholderType.DataTextField = "Description";
                dropDownListStakeholderType.DataBind();
                dropDownListStakeholderType.SelectedIndex = 0;
            }
        }

        public void CleardropDownListStakeholderType()
        {
            dropDownListStakeholderType.Items.Clear();
            dropDownListStakeholderType.Items.Add("-Select-");
        }

        public void CleargridViewAllStakeholders()
        {
            gridViewAllStakeholders.DataSource = null;
            gridViewAllStakeholders.DataBind();
        }

        public void CleargridViewMappedStakeholders()
        {
            gridViewMappedStakeholders.DataSource = null;
            gridViewMappedStakeholders.DataBind();
        }

        public void LoadMappedStakeholders()
        {
            try
            {
                if (dropDownListsecurityGroup.SelectedIndex > 0 && dropDownListStakeholderType.SelectedIndex > 0)
                {
                    Biz_StakeholderSecurityGroupService stakeholderSecurityGroupService = new Biz_StakeholderSecurityGroupService();
                    gridViewMappedStakeholders.DataSource = stakeholderSecurityGroupService.ReadMappedStakeholders(Convert.ToInt16(dropDownListsecurityGroup.SelectedValue), Convert.ToInt16(dropDownListStakeholderType.SelectedValue));
                    gridViewMappedStakeholders.DataBind();
                }
                else
                {
                    CleargridViewMappedStakeholders();
                }
            }
            catch (Exception exception)
            {

            }

        }

        public void LoadUnMappedStakeholders()
        {
            if (dropDownListsecurityGroup.SelectedIndex > 0 && dropDownListStakeholderType.SelectedIndex > 0)
            {
                Biz_StakeholderSecurityGroupService stakeholderSecurityGroupService = new Biz_StakeholderSecurityGroupService();

                gridViewAllStakeholders.DataSource = stakeholderSecurityGroupService.ReadUnMappedStakeholders(Convert.ToInt16(dropDownListsecurityGroup.SelectedValue), Convert.ToInt16(dropDownListStakeholderType.SelectedValue));
                gridViewAllStakeholders.DataBind();
            }
            else
            {
                CleargridViewAllStakeholders();
            }
        }

        #endregion

        #region "Operations"

        public void AddSecurityGroupStakeholder()
        {
            try
            {
                Biz_StakeholderSecurityGroupService stakeholderSecurityGroupService = new Biz_StakeholderSecurityGroupService();
                Biz_StakeholderSecurityGroup stakeholderSecurityGroup = new Biz_StakeholderSecurityGroup();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllStakeholders.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {

                            stakeholderSecurityGroup.IdSecurityGroup = Convert.ToInt16(dropDownListsecurityGroup.SelectedValue);
                            stakeholderSecurityGroup.IdStakeholderType =
                                Convert.ToInt16(dropDownListStakeholderType.SelectedValue);
                            stakeholderSecurityGroup.IdStakeholder = Convert.ToInt16(gridViewRow.Cells[1].Text);
                            stakeholderSecurityGroup.IdStatus = 1;
                            stakeholderSecurityGroup.DateCreated = DateTime.Now;
                            stakeholderSecurityGroup.DateModified = DateTime.Now;
                            stakeholderSecurityGroup.DateEffect = DateTime.Now;
                            stakeholderSecurityGroup.DateExpired = DateTime.Now;

                            stakeholderSecurityGroupService.AddSecurityGroupStakeholder(stakeholderSecurityGroup);
                             FlashText1.Display("Record(s) Successfully Added.", "okmessage");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                 FlashText1.Display("Record(s) Adding Failed.", "errormessage");

            }

        }

        public void RemoveSecurityGroupStakeholder()
        {
            try
            {
                Biz_StakeholderSecurityGroupService stakeholderSecurityGroupService = new Biz_StakeholderSecurityGroupService();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedStakeholders.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            stakeholderSecurityGroupService.RemoveStakeholderSecurityGroup(Convert.ToInt16(gridViewRow.Cells[1].Text));
                             FlashText1.Display("Record(s) Successfully Removed.", "okmessage");

                        }
                    }
                }
            }
            catch (Exception exception)
            {
                 FlashText1.Display("Record(s) Removing Failed.", "errormessage");

            }
        }

        #endregion

        #region "Events"

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddSecurityGroupStakeholder();
                LoadMappedStakeholders();
                LoadUnMappedStakeholders();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldRemove())
            {
                RemoveSecurityGroupStakeholder();
                LoadMappedStakeholders();
                LoadUnMappedStakeholders();
            }
        }

        public void dropDownListsecurityGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropDownListsecurityGroup.SelectedIndex > 0)
            {
                CleardropDownListStakeholderType();
                DataBindTodropDownListStakeholderType();
            }
            else
            {
                CleardropDownListStakeholderType();
            }
        }

        public void dropDownListStakeholderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMappedStakeholders();
            LoadUnMappedStakeholders();
        }

        public void gridViewAllStakeholders_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedStakeholders_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewAllStakeholders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewAllStakeholders.PageIndex = e.NewPageIndex;
            LoadUnMappedStakeholders();
        }

        public void gridViewMappedStakeholders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewMappedStakeholders.PageIndex = e.NewPageIndex;
            LoadMappedStakeholders();
        }

        public void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in ((GridView)((CheckBox)sender).Parent.Parent.Parent.Parent).Rows)
            {
                ((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked = ((CheckBox)sender).Checked;
            }
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (dropDownListsecurityGroup.SelectedValue == string.Empty)
            {
                 FlashText1.Display("Security Group not Selected.", "errormessage");
                return false;
            }
            if (dropDownListStakeholderType.SelectedValue == string.Empty)
            {
                 FlashText1.Display("Stakeholder Type not Selected.", "errormessage");
                return false;
            }

            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewAllStakeholders.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                 FlashText1.Display("Stakeholder Type(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldRemove()
        {
            if (dropDownListsecurityGroup.SelectedValue == string.Empty)
            {
                 FlashText1.Display("Security Group not Selected.", "errormessage");
                return false;
            }
            if (dropDownListStakeholderType.SelectedValue == string.Empty)
            {
                 FlashText1.Display("Stakeholder Type not Selected.", "errormessage");
                return false;
            }
            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewMappedStakeholders.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                 FlashText1.Display("Stakeholder Type(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion

    }
}