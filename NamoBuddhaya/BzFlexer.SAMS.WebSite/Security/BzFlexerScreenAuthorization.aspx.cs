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
    public partial class BzFlexerScreenAuthorization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListsecurityGroup();
                DataBindTodropdropDownListSystemModule();
                //EmptyData();
                LoadAccessibleScreen();
                LoadAllScreen();
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

        public void DataBindTodropdropDownListSystemModule()
        {
            Biz_SystemModuleService systemModuleService = new Biz_SystemModuleService();
            dropDownListSystemModule.DataSource = systemModuleService.ReadAllSystemModule();
            dropDownListSystemModule.DataValueField = "Id";
            dropDownListSystemModule.DataTextField = "Description";
            dropDownListSystemModule.DataBind();
            dropDownListSystemModule.SelectedIndex = 0;
        }

        public void LoadAllScreen()
        {
            try
            {
                Biz_ScreenService screenService = new Biz_ScreenService();
                Biz_SecurityGroupScreenService securityGroupScreenService = new Biz_SecurityGroupScreenService();


                if (dropDownListsecurityGroup.SelectedValue != "" && dropDownListSystemModule.SelectedValue != "")
                {
                    gridViewAllScreens.DataSource = securityGroupScreenService.ReadUnmappedScreen(
                        Convert.ToInt16(dropDownListsecurityGroup.SelectedValue),
                        Convert.ToInt16(dropDownListSystemModule.SelectedValue));
                    gridViewAllScreens.DataBind();

                }
                if ((dropDownListsecurityGroup.SelectedValue == "" && dropDownListSystemModule.SelectedValue == "") || (dropDownListsecurityGroup.SelectedValue != "" && dropDownListSystemModule.SelectedValue == ""))
                {

                    List<Biz_SecurityGroupScreen> securityGroupScreenList = null;
                    List<Biz_Screen> screenList = null;

                    gridViewAllScreens.DataSource = screenList;
                    gridViewAllScreens.DataBind();

                    gridViewMappedScreens.DataSource = securityGroupScreenList;
                    gridViewMappedScreens.DataBind();
                }
                if (dropDownListsecurityGroup.SelectedValue == "" && dropDownListSystemModule.SelectedValue != "")
                {

                    gridViewAllScreens.DataSource = screenService.ReadScreenByModuleCode(Convert.ToInt16(dropDownListSystemModule.SelectedValue));
                    gridViewAllScreens.DataBind();
                }

            }
            catch (Exception exception)
            {

            }
        }

        public void LoadAccessibleScreen()
        {
            if (dropDownListsecurityGroup.SelectedValue != "" && dropDownListSystemModule.SelectedValue != "")
            {
                Biz_SecurityGroupScreenService securityGroupScreenService = new Biz_SecurityGroupScreenService();

                gridViewMappedScreens.DataSource =
                    securityGroupScreenService.ReadAccessibleScreenBySecurityGroupIdAndModuleId(Convert.ToInt16(dropDownListsecurityGroup.SelectedValue), Convert.ToInt16(dropDownListSystemModule.SelectedValue));
                gridViewMappedScreens.DataBind();
            }
        }

        //public void EmptyData()
        //{
        //    if ((dropDownListsecurityGroup.SelectedValue == "" && dropDownListSystemModule.SelectedValue == "") || (dropDownListsecurityGroup.SelectedValue != "" && dropDownListSystemModule.SelectedValue == ""))
        //    {

        //        ScreenService screenService = new ScreenService();
        //        List<SecurityGroupScreen> securityGroupScreenList = null;
        //        List<Screen> screenList = null;

        //        gridViewAllScreens.DataSource = screenList;
        //        gridViewAllScreens.DataBind();

        //        gridViewMappedScreens.DataSource = securityGroupScreenList;
        //        gridViewMappedScreens.DataBind();
        //    }
        //    if (dropDownListsecurityGroup.SelectedValue == "" && dropDownListSystemModule.SelectedValue != "")
        //    {
        //        ScreenService screenService = new ScreenService();

        //        gridViewAllScreens.DataSource = screenService.GetScreenByModuleCode(Convert.ToInt16(dropDownListSystemModule.SelectedValue));
        //        gridViewAllScreens.DataBind();
        //    }
        //}

        #endregion

        #region "Operations"

        public void AddSecurityGroupScreen()
        {
            try
            {
                Biz_SecurityGroupScreenService securityGroupScreenService = new Biz_SecurityGroupScreenService();
                Biz_SecurityGroupScreen securityGroupScreen = new Biz_SecurityGroupScreen();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllScreens.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            securityGroupScreen = new Biz_SecurityGroupScreen();
                            securityGroupScreen.IdSecurityGroup = Convert.ToInt16(dropDownListsecurityGroup.SelectedValue);
                            securityGroupScreen.IdModule = Convert.ToInt16(dropDownListSystemModule.SelectedValue);
                            securityGroupScreen.IdScreen = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            securityGroupScreen.DateCreated = DateTime.Now;
                            securityGroupScreen.DateModified = DateTime.Now;

                            securityGroupScreenService.CreateSecurityGroupScreen(securityGroupScreen);
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

        public void RemoveSecurityGroupScreen()
        {
            try
            {
                Biz_SecurityGroupScreenService securityGroupScreenService = new Biz_SecurityGroupScreenService();
                Biz_SecurityGroupScreen securityGroupScreen = new Biz_SecurityGroupScreen();

                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedScreens.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            securityGroupScreen.Id = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            securityGroupScreenService.RemoveSecurityGroupScreens(securityGroupScreen.Id);
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
            if (CheckMandatorySecurityGroupScreenAdd())
            {
                AddSecurityGroupScreen();
                LoadAccessibleScreen();
                LoadAllScreen();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryBranchProductRemove())
            {
                RemoveSecurityGroupScreen();
                LoadAccessibleScreen();
                LoadAllScreen();
            }
        }

        public void gridViewAllScreens_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewAllScreens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewAllScreens.PageIndex = e.NewPageIndex;
            LoadAllScreen();
        }

        public void gridViewMappedScreens_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedScreens_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewMappedScreens.PageIndex = e.NewPageIndex;
            LoadAccessibleScreen();
        }

        public void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in ((GridView)((CheckBox)sender).Parent.Parent.Parent.Parent).Rows)
            {
                ((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked = ((CheckBox)sender).Checked;
            }
        }

        public void labelSystemModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EmptyData();
            LoadAccessibleScreen();
            LoadAllScreen();
        }

        public void dropDownListsecurityGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //EmptyData();
            LoadAccessibleScreen();
            LoadAllScreen();
        }

        #endregion

        #region "Validations"

        public Boolean CheckMandatorySecurityGroupScreenAdd()
        {
            if (dropDownListsecurityGroup.SelectedValue == string.Empty)
            {
                 FlashText1.Display("Security Group not Selected.", "errormessage");
                return false;
            }
            if (dropDownListSystemModule.SelectedValue == string.Empty)
            {
                 FlashText1.Display("System Module not Selected.", "errormessage");
                return false;
            }

            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewAllScreens.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                 FlashText1.Display("Screen(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        public Boolean CheckMandatoryBranchProductRemove()
        {
            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewMappedScreens.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                 FlashText1.Display("Screen(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}