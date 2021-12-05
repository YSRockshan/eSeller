using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.Security
{
    public partial class BzFlexerShTypeSecurityGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                DataBindTodropDownListsecurityGroup();
                LoadMappedSecurityGroupStakeholderType();
                LoadUnMappedSecurityGroupStakeholderType();
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
        public void buttonPrint_Click(object sender, EventArgs e)
        {
            if (gridViewMappedStakeholderType.HeaderRow.Cells.Count > 0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW",
              "window.open( '../Security/Rep/ReportShTypeSecurityGroup.aspx' );", true);

            }
            else
            {
                FlashText1.Display("No Records to print", "okmessage");
            }
        }
        public void LoadMappedSecurityGroupStakeholderType()
        {
            Biz_StakeholderTypeSecurityGroupService stakeholderTypeSecurityGroupService = new Biz_StakeholderTypeSecurityGroupService();


            try
            {
                if (dropDownListsecurityGroup.SelectedValue != "")
                {
                    gridViewMappedStakeholderType.DataSource =
                        stakeholderTypeSecurityGroupService.ReadMappedSecurityGroupStakeholderType(
                            Convert.ToInt16(dropDownListsecurityGroup.SelectedValue));
                    gridViewMappedStakeholderType.DataBind();

                    //report
                    WebView.Home.Global.UCSC = stakeholderTypeSecurityGroupService.ReadMappedSecurityGroupStakeholderType(
                            Convert.ToInt16(dropDownListsecurityGroup.SelectedValue));
                }
                if (dropDownListsecurityGroup.SelectedValue == "")
                {
                    List<Biz_StakeholderTypeSecurityGroup> stakeholderTypeSecurityGroups = null;

                    gridViewMappedStakeholderType.DataSource = stakeholderTypeSecurityGroups;
                    gridViewMappedStakeholderType.DataBind();
                }
            }
            catch (Exception exception)
            {

            }


        }

        public void LoadUnMappedSecurityGroupStakeholderType()
        {
            try
            {
                if (dropDownListsecurityGroup.SelectedValue != "")
                {
                    Biz_StakeholderTypeSecurityGroupService stakeholderTypeSecurityGroupService = new Biz_StakeholderTypeSecurityGroupService();

                    gridViewAllStakeholderType.DataSource =
                        stakeholderTypeSecurityGroupService.ReadUnMappedSecurityGroupStakeholderType(Convert.ToInt16(dropDownListsecurityGroup.SelectedValue));
                    gridViewAllStakeholderType.DataBind();
                }
                if (dropDownListsecurityGroup.SelectedValue == "")
                {
                    Biz_StakeholderTypeService stakeholderTypeService = new Biz_StakeholderTypeService();

                    gridViewAllStakeholderType.DataSource = stakeholderTypeService.ReadAllStakeholderType();
                    gridViewAllStakeholderType.DataBind();
                }
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Operations"

        public void AddStakeholderTypeSecurityGroup()
        {
            try
            {
                Biz_StakeholderTypeSecurityGroupService stakeholderTypeSecurityGroupService = new Biz_StakeholderTypeSecurityGroupService();
                Biz_StakeholderTypeSecurityGroup stakeholderTypeSecurityGroup = new Biz_StakeholderTypeSecurityGroup();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllStakeholderType.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            stakeholderTypeSecurityGroup.IdSecurityGroup =
                               Convert.ToInt16(dropDownListsecurityGroup.SelectedValue);
                            stakeholderTypeSecurityGroup.IdStakeholderType = Convert.ToInt16(gridViewRow.Cells[1].Text);
                            stakeholderTypeSecurityGroup.DateCreated = DateTime.Now;
                            stakeholderTypeSecurityGroup.DateModified = DateTime.Now;
                            stakeholderTypeSecurityGroup.DateEffect = DateTime.Now;
                            stakeholderTypeSecurityGroup.DateExpired = DateTime.Now;

                            stakeholderTypeSecurityGroupService.AddStakeholderTypeSecurityGroup(stakeholderTypeSecurityGroup);
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

        public void RemoveStakeholderTypeSecurityGroup()
        {
            try
            {
                Biz_StakeholderTypeSecurityGroupService stakeholderTypeSecurityGroupService = new Biz_StakeholderTypeSecurityGroupService();
                Biz_StakeholderTypeSecurityGroup stakeholderTypeSecurityGroup = new Biz_StakeholderTypeSecurityGroup();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedStakeholderType.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            stakeholderTypeSecurityGroup.IdStakeholderType = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            stakeholderTypeSecurityGroupService.RemoveStakeholderTypeSecurityGroup(stakeholderTypeSecurityGroup.IdStakeholderType);
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
            if (checkMandatoryFieldAdd())
            {
                AddStakeholderTypeSecurityGroup();
                LoadMappedSecurityGroupStakeholderType();
                LoadUnMappedSecurityGroupStakeholderType();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (checkMandatoryFieldRemove())
            {
                RemoveStakeholderTypeSecurityGroup();
                LoadMappedSecurityGroupStakeholderType();
                LoadUnMappedSecurityGroupStakeholderType();
            }

        }

        public void gridViewAllStakeholderType_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedStakeholderType_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewAllStakeholderType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewAllStakeholderType.PageIndex = e.NewPageIndex;
            LoadUnMappedSecurityGroupStakeholderType();
        }

        public void gridViewMappedStakeholderType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewMappedStakeholderType.PageIndex = e.NewPageIndex;
            LoadMappedSecurityGroupStakeholderType();
        }

        public void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in ((GridView)((CheckBox)sender).Parent.Parent.Parent.Parent).Rows)
            {
                ((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked = ((CheckBox)sender).Checked;
            }
        }

        public void dropDownListsecurityGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMappedSecurityGroupStakeholderType();
            LoadUnMappedSecurityGroupStakeholderType();
        }


        #endregion

        #region "Validations"

        private Boolean checkMandatoryFieldAdd()
        {
            if (dropDownListsecurityGroup.SelectedValue == string.Empty)
            {
                 FlashText1.Display("Security Group not Selected.", "errormessage");
                return false;
            }

            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewAllStakeholderType.Rows)
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

        private Boolean checkMandatoryFieldRemove()
        {
            if (dropDownListsecurityGroup.SelectedValue == string.Empty)
            {
                 FlashText1.Display("Security Group not Selected.", "errormessage");
                return false;
            }
            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewMappedStakeholderType.Rows)
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