using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.Reference
{
    public partial class BzFlexerBranch : System.Web.UI.Page
    {
        #region "Variables"

        public string SelectBranchId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadBranch();
                txtBranchAdd.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                txtBranchDescriptionAdd.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
                txtBranchModify.Attributes.Add("onchange", "javascript:this.value=toUpperCase(this.value);");
                txtBranchDescriptionModify.Attributes.Add("onchange", "javascript:this.value=toTitleCase(this.value);");
            }

        }
        #region "Load Data"

        private void LoadBranch()
        {
            Biz_BranchService _branchService = new Biz_BranchService();
            try
            {
                gridViewBranch.DataSource = _branchService.ReadAllBranch();
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
                    Biz_Branch branches = new Biz_Branch();
                    Biz_BranchService branchServices = new Biz_BranchService();

                    if (txtBranchAdd.Text.Trim() != string.Empty)
                    {
                        branches.Code = txtBranchAdd.Text.Trim().ToUpper();
                    }
                    if (txtBranchDescriptionAdd.Text.Trim() != string.Empty)
                    {
                        branches.Description = txtBranchDescriptionAdd.Text.Trim();
                    }

                    branches.DateCreated = DateTime.Now;
                    branches.DateModified = DateTime.Now;

                    branchServices.CreateBranch(branches);
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
                    Biz_BranchService branchServices = new Biz_BranchService();
                    Biz_Branch branches = new Biz_Branch();

                    branches.Id = Convert.ToInt16(ViewState["SelectBranchId"]);
                    branches = branchServices.ReadBranchById(branches.Id);

                    if (txtBranchModify.Text.Trim() != string.Empty)
                    {
                        branches.Code = txtBranchModify.Text.Trim().ToUpper();
                    }
                    if (txtBranchDescriptionModify.Text.Trim() != string.Empty)
                    {
                        branches.Description = txtBranchDescriptionModify.Text.Trim();
                    }
                    branches.DateModified = DateTime.Now;

                    branchServices.UpdateBranch(branches);
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
                    Biz_Branch branches = new Biz_Branch();
                    Biz_BranchService branchServices = new Biz_BranchService();

                    branches.Id = Convert.ToInt16(ViewState["SelectBranchId"]);
                    branchServices.DeleteBranches(branches.Id);
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
            txtBranchAdd.Text = "";
            txtBranchDescriptionAdd.Text = "";
            txtBranchModify.Text = "";
            txtBranchDescriptionModify.Text = "";
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
            txtBranchAdd.Focus();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
            txtBranchAdd.Focus();
        }

        public void GWBranch_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void GWBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewBranch.SelectedRow;

            ViewState["SelectBranchId"] = row.Cells[1].Text.Trim();

            txtBranchModify.Text = row.Cells[2].Text.Trim();
            txtBranchDescriptionModify.Text = row.Cells[3].Text.Trim();

            accordionInputs.SelectedIndex = 1;

        }

        public void GWBranch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadBranch();
            gridViewBranch.PageIndex = e.NewPageIndex;
            gridViewBranch.DataBind();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryBranchAdd()
        {
            if (txtBranchAdd.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Branch Code cannot be blank.", "errormessage");
                return false;
            }
            if (txtBranchDescriptionAdd.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description cannot be blank.", "errormessage");
                return false;
            }
            if (txtBranchAdd.Text.Trim() != string.Empty)
            {
                Biz_BranchService branchservices = new Biz_BranchService();
                List<Biz_Branch> _branchList = new List<Biz_Branch>();

                _branchList = branchservices.ReadBranchByBranhCode(txtBranchAdd.Text.Trim());
                if (_branchList.Count > 0)
                {
                    FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }

            }
            return true;
        }

        private Boolean CheckMandatoryBranchModify()
        {
            if (txtBranchModify.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Branch Code cannot be blank.", "errormessage");
                return false;
            }
            if (txtBranchDescriptionModify.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Description cannot be blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryBranchDelete()
        {
            if (txtBranchModify.Text.Trim() == string.Empty)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion

    }
}