using AjaxControlToolkit;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebSite.ReportCenter
{
    public partial class ReportHome : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[WebView.Home.Global.BizLoginUserStakeholderId] != null)
            {
                string frmName = "BzFlexerHome";
                int exsist = 0;
                //frmName = Page.AppRelativeVirtualPath.Substring(9);
                //frmName = frmName.Substring(0, frmName.LastIndexOf("."));
                Biz_SystemModule systemModule = new Biz_SystemModuleService().ReadSystemModuleByCode("RPTCN");
                long id = systemModule.Id;
                exsist = new Biz_SecurityGroupScreenService().CheckExistingScreens(id,
                                                                     Convert.ToInt64(Session[WebView.Home.Global.BizLoginUserStakeholderId]),
                                                                     frmName,
                                                                     Convert.ToInt16(Session[WebView.Home.Global.BizCurrentBranchId]));
                if (exsist == 0 && frmName != "BzFlexerHome")
                {
                    Response.Redirect("~/ReportCenter/BzFlexerHome.aspx");
                }
                else
                    LoadNavigationMenu();
            }

            if (!IsPostBack)
            {
                try
                {
                    //LoadNavigationMenu();
                    if (Session["MyAccordion.SelectedIndex"] != null)
                    {
                        accordionModuleMenu.SelectedIndex = (int)Session["MyAccordion.SelectedIndex"];
                    }
                    if (Session["AccordionSubMenu.SelectedIndex"] != null && Session["SelectedSubMenuAccordionId"] != null)
                    {
                        ((Accordion)(accordionModuleMenu.FindControl(Session["SelectedSubMenuAccordionId"].ToString()))).SelectedIndex = (int)Session["AccordionSubMenu.SelectedIndex"];
                    }
                }
                catch (Exception exception)
                {
                    accordionModuleMenu.SelectedIndex = -1;
                    //((Accordion)((LinkButton)sender).Parent.Parent.Parent).SelectedIndex = -1;
                    //throw;
                }
            }

            String[] arrayTreePrograms = new string[1];
            arrayTreePrograms[0] = " ";

            //Response.Write(Page.Request.RawUrl + "," + Page.Request.Path + "," + Page.Request.CurrentExecutionFilePath + "," + Page.Request.AppRelativeCurrentExecutionFilePath);
            if (arrayTreePrograms.Contains(Page.Request.AppRelativeCurrentExecutionFilePath))
            {
                tabContainerMenuTree.ActiveTabIndex = 1;
            }
            else if (tabContainerMenuTree.Tabs.Count > 1)
            {
                tabContainerMenuTree.Tabs.RemoveAt(1);
            }
        }

        protected void MenuLinkButton_OnClick(object sender, EventArgs e)
        {
            Session["MyAccordion.SelectedIndex"] = accordionModuleMenu.SelectedIndex;
            Response.Redirect(((LinkButton)sender).CommandArgument);
        }

        protected void SubMenuLinkButton_OnClick(object sender, EventArgs e)
        {
            Session["MyAccordion.SelectedIndex"] = accordionModuleMenu.SelectedIndex;
            Session["SelectedSubMenuAccordionId"] = ((Accordion)((LinkButton)sender).Parent.Parent.Parent).ID;
            //Session["AccordionSubMenu.SelectedIndex"] = ((Accordion)((LinkButton)sender).Parent.Parent.Parent).SelectedIndex;
            Session["AccordionSubMenu.SelectedIndex"] =
                ((Accordion)((LinkButton)sender).Parent.Parent.Parent).Panes.IndexOf(
                    (AccordionPane)((LinkButton)sender).Parent.Parent);
            Response.Redirect(((LinkButton)sender).CommandArgument);
        }

        private void LoadNavigationMenu()
        {
            accordionModuleMenu.Panes.Clear();

            List<Biz_Screen> bizScreens = new List<Biz_Screen>();
            Biz_SecurityGroupScreenService securityGroupScreenService = new Biz_SecurityGroupScreenService();
            Biz_SystemModule systemModule = new Biz_SystemModuleService().ReadSystemModuleByCode("RPTCN");
            long id = systemModule.Id;
            bizScreens = securityGroupScreenService.ReadNavigationMenu(id,
                                                                        Convert.ToInt64(Session[WebView.Home.Global.BizLoginUserStakeholderId]),
                                                                        Convert.ToInt64(Session[WebView.Home.Global.BizCurrentBranchId]));
            FillNavigationMenu(bizScreens);
        }

        private void FillNavigationMenu(List<Biz_Screen> sourceList)
        {
            List<Biz_Screen> o =
                new List<Biz_Screen>(
                    sourceList.Where(
                        x => (x.IdParentScreen == null) || (x.IdParentScreen == 0)).ToList());

            LiteralControl literalControl;

            foreach (Biz_Screen orig in o)
            {
                AccordionPane accordionPane = new AccordionPane();

                literalControl = new LiteralControl();

                accordionPane.ID = orig.Id.ToString();

                literalControl.Text = orig.Description;
                accordionPane.HeaderContainer.Controls.Add(literalControl);

                if (String.IsNullOrEmpty(orig.ProgramFile_Name))
                {
                    //CREATE BULLETED LIST OF CHILDREN

                    System.Web.UI.WebControls.BulletedList blMenu = new System.Web.UI.WebControls.BulletedList();
                    blMenu.DisplayMode = BulletedListDisplayMode.HyperLink;
                    blMenu.CssClass = "form";

                    List<Biz_Screen> l1 = new List<Biz_Screen>(
                sourceList.Where(
                    x =>
                    orig.Id.ToString() == 0.ToString()
                        ? x.IdParentScreen == null
                        : (x.IdParentScreen != null) && (x.IdParentScreen.ToString() == orig.Id.ToString())).ToList());

                    Accordion accordion = new Accordion();
                    accordion.ID = "test" + orig.Id.ToString();
                    accordion.ContentCssClass = "accordionContent";
                    accordion.HeaderSelectedCssClass = "accordionHeaderSelected";
                    accordion.HeaderCssClass = "accordionHeader";
                    accordion.SelectedIndex = -1;

                    AccordionPane newAcPane;
                    LiteralControl lc;
                    LinkButton linkButton;

                    //CREATES LIST ITEMS WITHIN BULLETED LIST FOR CHILDREN
                    foreach (Biz_Screen orig1 in l1)
                    {

                        if (String.IsNullOrEmpty(orig1.ProgramFile_Name))
                        {

                            List<Biz_Screen> l2 = new List<Biz_Screen>(
                                sourceList.Where(
                                    x =>
                                    orig1.Id.ToString() == 0.ToString()
                                        ? x.IdParentScreen == null
                                        : (x.IdParentScreen != null) && (x.IdParentScreen.ToString() == orig1.Id.ToString())).ToList());

                            System.Web.UI.WebControls.BulletedList blSubMenu = new System.Web.UI.WebControls.BulletedList();
                            blSubMenu.DisplayMode = BulletedListDisplayMode.HyperLink;
                            blSubMenu.CssClass = "form";

                            newAcPane = new AccordionPane();
                            lc = new LiteralControl();


                            newAcPane.ID = orig1.Id.ToString();

                            lc.Text = orig1.Description;
                            newAcPane.HeaderContainer.Controls.Add(lc);
                            LinkButton linkSubButton;

                            foreach (Biz_Screen orig2 in l2)
                            {
                                //blSubMenu.Items.Insert(0,
                                //            (new ListItem(orig2.Description,
                                //                          orig2.ProgramFileName + ".aspx")));
                                //blSubMenu.Items[blSubMenu.Items.Count-1].Attributes.CssStyle.Add("formfield","formfield");

                                linkSubButton = new LinkButton();
                                linkSubButton.Text = orig2.Description;
                                linkSubButton.CommandArgument = orig2.ProgramFile_Name + ".aspx";
                                linkSubButton.Click += MenuLinkButton_OnClick;
                                newAcPane.ContentContainer.Controls.Add(linkSubButton);
                                newAcPane.ContentContainer.Controls.Add(new LiteralControl("<br />"));

                            }
                            //newAcPane.ContentContainer.Controls.Add(blSubMenu);
                            accordion.Panes.Add(newAcPane);

                        }
                        else
                        {
                            //blMenu.Items.Insert(0,
                            //                (new ListItem(orig1.Description,
                            //                              orig1.ProgramFileName + ".aspx")));


                            linkButton = new LinkButton();
                            linkButton.Text = orig1.Description;
                            linkButton.CommandArgument = orig1.ProgramFile_Name + ".aspx";
                            linkButton.Click += new EventHandler(MenuLinkButton_OnClick);
                            accordionPane.ContentContainer.Controls.Add(linkButton);
                            accordionPane.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                        }

                    }
                    //ADDS BULLETED LIST TO PANE (CONTAINER)
                    try
                    {
                        accordionPane.ContentContainer.Controls.Add(accordion);
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        accordionPane.ContentContainer.Controls.Add(blMenu);
                    }
                    catch (Exception)
                    {
                    }
                    accordionModuleMenu.Panes.Add(accordionPane);
                }
            }
        }
    }
}