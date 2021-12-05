using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebSite.Reference
{
    public partial class BizFlexerBranch : System.Web.UI.Page
    {
        #region "Variables"

        public string SelectBranchId;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBranch();
                textBoxBranchAdd.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxBranchDescriptionAdd.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
                textBoxBranchModify.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                textBoxBranchDescriptionModify.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
            }
        }

        #region "Load Data"

        private void LoadBranch()
        {
            Biz_BranchService branchService = new Biz_BranchService();
            try
            {
                gridViewBranch.DataSource = branchService.ReadAllBranch();
                gridViewBranch.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        public void SubmitCompleteBranch()
        {
            LoadBranch();
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Operations"

        public void AddBranch()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_Branch branch = new Biz_Branch();
                    Biz_BranchService branchService = new Biz_BranchService();

                    if (textBoxBranchAdd.Text.Trim() != string.Empty)
                    {
                        branch.Code = textBoxBranchAdd.Text.Trim().ToUpper();
                    }
                    if (textBoxBranchDescriptionAdd.Text.Trim() != string.Empty)
                    {
                        branch.Description = textBoxBranchDescriptionAdd.Text.Trim();
                    }

                    branch.DateCreated = DateTime.Now;
                    branch.DateModified = DateTime.Now;

                    branchService.CreateBranch(branch);
                }
                FlashText1.Display("Record Successfully saved.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ModifyBranch()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_BranchService branchService = new Biz_BranchService();
                    Biz_Branch branch = new Biz_Branch();

                    branch.Id = Convert.ToInt16(ViewState["SelectBranchId"]);
                    branch = branchService.ReadBranchById(branch.Id);

                    if (textBoxBranchModify.Text.Trim() != string.Empty)
                    {
                        branch.Code = textBoxBranchModify.Text.Trim().ToUpper();
                    }
                    if (textBoxBranchDescriptionModify.Text.Trim() != string.Empty)
                    {
                        branch.Description = textBoxBranchDescriptionModify.Text.Trim();
                    }
                    branch.DateModified = DateTime.Now;

                    branchService.UpdateBranch(branch);
                }
                FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteBranch()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_Branch branch = new Biz_Branch();
                    Biz_BranchService branchService = new Biz_BranchService();

                    branch.Id = Convert.ToInt16(ViewState["SelectBranchId"]);
                    branchService.DeleteBranches(branch.Id);
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
            textBoxBranchAdd.Text = "";
            textBoxBranchDescriptionAdd.Text = "";
            textBoxBranchModify.Text = "";
            textBoxBranchDescriptionModify.Text = "";
            ViewState["SelectBranchId"] = null;
            gridViewBranch.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryBranchAdd())
            {
                AddBranch();
                ClearData();
                SubmitCompleteBranch();
            }
        }

        public void buttonEdit_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryBranchModify())
            {
                ModifyBranch();
                ClearData();
                SubmitCompleteBranch();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryBranchDelete())
            {
                DeleteBranch();
                ClearData();
                SubmitCompleteBranch();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxBranchAdd.Focus();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            textBoxBranchAdd.Focus();
        }

        public void gridViewBranch_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewBranch.SelectedRow;

            ViewState["SelectBranchId"] = row.Cells[1].Text.Trim();

            textBoxBranchModify.Text = row.Cells[2].Text.Trim();
            textBoxBranchDescriptionModify.Text = row.Cells[3].Text.Trim();

            accordionInputs.SelectedIndex = 1;

        }

        public void gridViewBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadBranch();
            gridViewBranch.PageIndex = e.NewPageIndex;
            gridViewBranch.DataBind();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryBranchAdd()
        {
            if (textBoxBranchAdd.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Branch Code cannot be blank.", "errormessage");
                return false;
            }
            if (textBoxBranchDescriptionAdd.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description cannot be blank.", "errormessage");
                return false;
            }
            if (textBoxBranchAdd.Text.Trim() != string.Empty)
            {
                Biz_BranchService branchservice = new Biz_BranchService();
                List<Biz_Branch> BranchList = new List<Biz_Branch>();

                BranchList = branchservice.ReadBranchByBranhCode(textBoxBranchAdd.Text.Trim());
                if (BranchList.Count > 0)
                {
                    FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }

            }
            return true;
        }

        private Boolean CheckMandatoryBranchModify()
        {
            if (textBoxBranchModify.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Branch Code cannot be blank.", "errormessage");
                return false;
            }
            if (textBoxBranchDescriptionModify.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description cannot be blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryBranchDelete()
        {
            if (textBoxBranchModify.Text.Trim() == string.Empty)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}