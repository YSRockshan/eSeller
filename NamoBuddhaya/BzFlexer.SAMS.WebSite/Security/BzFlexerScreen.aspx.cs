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
    public partial class BzFlexerScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindToDropDownListSystemModule();
                LoadProgramTree();
            }
        }

        #region "Load Data"

        public void DataBindToDropDownListSystemModule()
        {
            Biz_SystemModuleService systemModuleService = new Biz_SystemModuleService();
            dropDownListSystemModule.DataSource = systemModuleService.ReadAllSystemModule();
            dropDownListSystemModule.DataTextField = "Description";
            dropDownListSystemModule.DataValueField = "Id";
            dropDownListSystemModule.DataBind();
            dropDownListSystemModule.SelectedIndex = 0;
        }

        public void LoadProgramTree()
        {
            treeViewProgramTree.Nodes.Clear();

            List<Biz_Screen> ermScreenList = new List<Biz_Screen>();
            Biz_ScreenService screenService = new Biz_ScreenService();

            ermScreenList = screenService.ReadAllScreenByModuleId(Convert.ToInt16(dropDownListSystemModule.SelectedValue));
            TreeNode newNode = new TreeNode("Menu Options", 0.ToString());

            treeViewProgramTree.Nodes.Add(newNode);
            FillTree(ermScreenList, newNode);
            newNode.Expand();

        }

        private void FillTree(List<Biz_Screen> sourceList, TreeNode parentTreeNode)
        {
            List<Biz_Screen> o;
            // Get all children of the current parent
            if (parentTreeNode.Value == "0")
            {
                o = new List<Biz_Screen>(
              sourceList.Where(
                  x => x.IdParentScreen == null || x.IdParentScreen == 0)
                       //parentTreeNode.Value == 0.ToString()
                       //    ? x.ParentScreenId == null
                       //    : (x.ParentScreenId != null) &&
                       //      (x.ParentScreenId.ToString().Trim() == "0"))
                       .OrderBy(
                    x => x.Sequence_No)
                  .ToList());
            }
            else
            {
                o = new List<Biz_Screen>(
            sourceList.Where(
                x => (x.IdParentScreen != null) &&
                      (x.IdParentScreen.ToString().Trim() == parentTreeNode.Value))
                       .OrderBy(
                    x => x.Sequence_No)
                .ToList());
            }
            foreach (Biz_Screen orig in o)
            {
                TreeNode newNode = new TreeNode(orig.Description, orig.Id.ToString());
                if (parentTreeNode == null)
                {
                    treeViewProgramTree.Nodes.Add(newNode);
                }
                else if (parentTreeNode.Value == 0.ToString())
                {
                    treeViewProgramTree.Nodes.Add(newNode);
                }
                else
                {
                    parentTreeNode.ChildNodes.Add(newNode);
                }
                // parentTreeNode.ChildNodes.Add(newNode);
                newNode.Collapse();
                FillTree(sourceList, newNode);
            }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxScreenDescription.Text = "";
            textBoxProgramFile.Text = "";
            textBoxSequence.Text = "";
            textBoxScreenDescription2.Text = "";
            textBoxProgramFile2.Text = "";
            textBoxSequence2.Text = "";
            hiddenFieldScreenId.Value = "";
            hiddenFieldParentScreenId.Value = "";
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Operations"

        public void AddScreen()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_Screen screen = new Biz_Screen();
                    Biz_ScreenService screenService = new Biz_ScreenService();

                    if (dropDownListSystemModule.SelectedValue != "")
                    {
                        screen.IdBizModule = Convert.ToInt16(dropDownListSystemModule.SelectedValue.Trim());
                    }
                    if (textBoxProgramFile.Text.Trim() != string.Empty)
                    {
                        screen.ProgramFile_Name = textBoxProgramFile.Text.Trim();
                    }
                    if (textBoxScreenDescription.Text.Trim() != string.Empty)
                    {
                        screen.Description = textBoxScreenDescription.Text.Trim();
                    }
                    if (textBoxSequence.Text.Trim() != string.Empty)
                    {
                        screen.Sequence_No = Convert.ToInt16(textBoxSequence.Text.Trim());
                    }
                    screen.IdParentScreen = Convert.ToInt16(hiddenFieldScreenId.Value.Trim());
                    screen.DateCreated = DateTime.Now;
                    screen.DateModified = DateTime.Now;

                    screenService.CreateScreen(screen);
                     FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
                 FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ModifyScreen()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_Screen screen = new Biz_Screen();
                    Biz_ScreenService screenService = new Biz_ScreenService();

                    screen.Id = Convert.ToInt16(hiddenFieldScreenId.Value);
                    screen = screenService.ReadScreenByScreenID(screen.Id);

                    if (dropDownListSystemModule.SelectedValue != "")
                    {
                        screen.IdBizModule = Convert.ToInt16(dropDownListSystemModule.SelectedValue.Trim());
                    }
                    if (textBoxProgramFile2.Text.Trim() != string.Empty)
                    {
                        screen.ProgramFile_Name = textBoxProgramFile2.Text.Trim();
                    }
                    if (textBoxScreenDescription2.Text.Trim() != string.Empty)
                    {
                        screen.Description = textBoxScreenDescription2.Text.Trim();
                    }
                    if (textBoxSequence2.Text.Trim() != string.Empty)
                    {
                        screen.Sequence_No = Convert.ToInt16(textBoxSequence2.Text.Trim());
                    }

                    screen.IdParentScreen = Convert.ToInt16(hiddenFieldParentScreenId.Value.Trim());
                    screen.DateModified = DateTime.Now;

                    screenService.UpdateScreen(screen);
                     FlashText1.Display("Record Successfully Modified.", "okmessage");
                }
            }
            catch (Exception exception)
            {
                 FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteScreen()
        {
            try
            {
                Biz_ScreenService screenService = new Biz_ScreenService();
                screenService.DeleteScreen(Convert.ToInt16(hiddenFieldScreenId.Value.Trim()));
                 FlashText1.Display("Record Successfully Deleted.", "okmessage");
            }
            catch (Exception exception)
            {
                 FlashText1.Display("Record Deleting Failed.", "errormessage");
            }
        }

        #endregion

        #region "Events

        public void buttonSaveAdd_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddScreen();
                ClearData();
                LoadProgramTree();
            }
        }

        public void buttonSaveEdit_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldModify())
            {
                ModifyScreen();
                ClearData();
                LoadProgramTree();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldDelete())
            {
                DeleteScreen();
                ClearData();
                LoadProgramTree();
            }
        }

        public void buttonCancelAdd_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadProgramTree();
        }

        public void buttonCancelEdit_Click(object sender, EventArgs e)
        {
            ClearData();
            LoadProgramTree();
        }

        public void dropDownListSystemModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearData();
            LoadProgramTree();
        }

        public void treeViewProgramTreeNode_Click(object sender, EventArgs e)
        {
            Biz_ScreenService screenService = new Biz_ScreenService();
            Biz_Screen bizScreen = screenService.ReadScreenByScreenID(Convert.ToInt64(treeViewProgramTree.SelectedValue));

            if (bizScreen != null)
            {
                hiddenFieldScreenId.Value = treeViewProgramTree.SelectedValue;
                if (bizScreen.IdParentScreen == null)
                {
                    hiddenFieldParentScreenId.Value = "0";
                }
                else
                {
                    hiddenFieldParentScreenId.Value = bizScreen.IdParentScreen.ToString();
                }
                textBoxScreenDescription2.Text = bizScreen.Description;
                textBoxProgramFile2.Text = bizScreen.ProgramFile_Name;
                textBoxSequence2.Text = bizScreen.Sequence_No.ToString();
                if (string.IsNullOrEmpty(bizScreen.ProgramFile_Name))
                {
                    accordionPaneAdd.Visible = true;
                    accordionInputs.SelectedIndex = 0;
                }
                else
                {
                    accordionPaneAdd.Visible = false;
                    accordionInputs.SelectedIndex = 1;
                }
            }
            else
            {
                hiddenFieldScreenId.Value = "0";
            }
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (hiddenFieldScreenId.Value.Trim() == String.Empty)
            {
                 FlashText1.Display("A parent [Menu Option] should be selected to add a sub level", "errormessage");
                return false;
            }
            if (dropDownListSystemModule.SelectedValue == "")
            {
                 FlashText1.Display("Please select the System Module.", "okmessage");
                return false;
            }
            if (textBoxScreenDescription.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Screen Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxProgramFile.Text.Trim() != String.Empty)
            {
                Biz_ScreenService screenService = new Biz_ScreenService();
                List<Biz_Screen> screenList = new List<Biz_Screen>();

                screenList = screenService.ReadScreenByModuleCodeAndProFile(Convert.ToInt16(dropDownListSystemModule.SelectedValue), textBoxProgramFile.Text.Trim());

                if (screenList.Count > 0)
                {
                     FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }
            }
            if (textBoxSequence.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Sequence Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldModify()
        {
            if (hiddenFieldScreenId.Value.Trim() == String.Empty)
            {
                 FlashText1.Display("A Menu Option should be selected to modify.", "errormessage");
                return false;
            }
            if (dropDownListSystemModule.SelectedValue == "")
            {
                 FlashText1.Display("Please select the System Module.", "okmessage");
                return false;
            }
            if (textBoxScreenDescription2.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Screen Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSequence2.Text.Trim() == string.Empty)
            {
                 FlashText1.Display("Sequence Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldDelete()
        {
            if (hiddenFieldScreenId.Value.Trim() == String.Empty)
            {
                 FlashText1.Display("Menu Option should be selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}