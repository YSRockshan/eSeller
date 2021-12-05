using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Service.AgentManagement;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.AgentManagement
{
    public partial class BzFlexerSalesTargetAssignment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListBranch();
                DataBindTodropDownListSalesTarget();
                FillData();
            }
        }

        #region "Load Data"

        public void FillData()
        {
            CleargridViewMappedSalesRep();
            CleargridViewAllSalesRep();
            LoadgridViewAllBranchSalesRep();
            LoadgridViewMappedSalesRep();
        }

        public void DataBindTodropDownListBranch()
        {
            try
            {
                Biz_BranchService branchService = new Biz_BranchService();
                dropDownListBranch.DataSource = branchService.ReadAllBranch();
                dropDownListBranch.DataValueField = "Id";
                dropDownListBranch.DataTextField = "Description";
                dropDownListBranch.DataBind();
            }
            catch (Exception exception)
            { }
        }

        public void DataBindTodropDownListSalesTarget()
        {
            try
            {
                Biz_SalesTargetService salesTargetService = new Biz_SalesTargetService();
                dropDownListSalesTarget.DataSource = salesTargetService.ReadAllSalesTargets();
                dropDownListSalesTarget.DataValueField = "Id";
                dropDownListSalesTarget.DataTextField = "Description";
                dropDownListSalesTarget.DataBind();
            }
            catch (Exception exception)
            { }
        }

        public void LoadgridViewAllBranchSalesRep()
        {
            Biz_MemberSalesTargetService memberSalesTargetService = new Biz_MemberSalesTargetService();
            List<Biz_BranchSalesAgent> branchSelesReps = new List<Biz_BranchSalesAgent>();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                branchSelesReps =
                    memberSalesTargetService.ReadUnMappedMemberSalesTarget(
                        Convert.ToInt16(dropDownListBranch.SelectedValue));
            }

            if (branchSelesReps != null)
            {
                DataBindTogridViewAllSalesRep(branchSelesReps);
            }
            else
            {
                CleargridViewAllSalesRep();
            }
        }

        public void LoadgridViewMappedSalesRep()
        {
            Biz_MemberSalesTargetService memberSalesTargetService = new Biz_MemberSalesTargetService();
            List<Biz_MemberSalesTarget> memberSalesTargets = new List<Biz_MemberSalesTarget>();

            if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex < 1)
            {
                memberSalesTargets = memberSalesTargetService.ReadMappedMemberSalesTarget(Convert.ToInt16(dropDownListBranch.SelectedValue));
            }
            else if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesTarget.SelectedIndex > 0)
            {
                memberSalesTargets = memberSalesTargetService.ReadMappedMemberSalesTarget(Convert.ToInt16(dropDownListBranch.SelectedValue), Convert.ToInt16(dropDownListSalesTarget.SelectedValue));
            }

            if (memberSalesTargets != null)
            {
                DataBindTogridViewMappedSalesRep(memberSalesTargets);
            }
            else
            {
                CleargridViewMappedSalesRep();
            }
        }

        public void DataBindTogridViewAllSalesRep(List<Biz_BranchSalesAgent> branchSelesReps)
        {
            gridViewAllBranchSalesRep.DataSource = branchSelesReps;
            gridViewAllBranchSalesRep.DataBind();
        }

        public void DataBindTogridViewMappedSalesRep(List<Biz_MemberSalesTarget> memberSalesTargets)
        {
            gridViewMappedSalesRep.DataSource = memberSalesTargets;
            gridViewMappedSalesRep.DataBind();
        }

        public void CleargridViewMappedSalesRep()
        {
            gridViewMappedSalesRep.DataSource = null;
            gridViewMappedSalesRep.DataBind();
        }

        public void CleargridViewAllSalesRep()
        {
            gridViewAllBranchSalesRep.DataSource = null;
            gridViewAllBranchSalesRep.DataBind();
        }

        #endregion

        #region "Operations"

        public void AddMemberSalesTargets()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllBranchSalesRep.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_MemberSalesTargetService memberSalesTargetService = new Biz_MemberSalesTargetService();
                            Biz_MemberSalesTarget memberSalesTarget = new Biz_MemberSalesTarget();

                            memberSalesTarget.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                            memberSalesTarget.IdSalesTarget = Convert.ToInt16(dropDownListSalesTarget.SelectedValue);
                            memberSalesTarget.IdSalesAgent = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            memberSalesTarget.DateCreated = DateTime.Now;
                            memberSalesTarget.DateModified = DateTime.Now;

                            memberSalesTargetService.CreateMemberSalesTarget(memberSalesTarget);
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

        public void RemoveMemberSalesTarget()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedSalesRep.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_MemberSalesTargetService memberSalesTargetService = new Biz_MemberSalesTargetService();
                            memberSalesTargetService.DeleteMemberSalesTargets(Convert.ToInt16(gridViewRow.Cells[1].Text.Trim()));
                           FlashText1.Display("Record(s) Successfully Deleted.", "okmessage");
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
            if (CheckMandatoryFieldsAdd())
            {
                AddMemberSalesTargets();
                LoadgridViewAllBranchSalesRep();
                LoadgridViewMappedSalesRep();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsRemove())
            {
                RemoveMemberSalesTarget();
                LoadgridViewAllBranchSalesRep();
                LoadgridViewMappedSalesRep();
            }
        }

        public void gridViewAllBranchSalesRep_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedSalesRep_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewAllBranchSalesRep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadgridViewAllBranchSalesRep();
            gridViewAllBranchSalesRep.PageIndex = e.NewPageIndex;
            gridViewAllBranchSalesRep.DataBind();
        }

        public void gridViewMappedSalesRep_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadgridViewMappedSalesRep();
            gridViewMappedSalesRep.PageIndex = e.NewPageIndex;
            gridViewMappedSalesRep.DataBind();
        }

        public void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in ((GridView)((CheckBox)sender).Parent.Parent.Parent.Parent).Rows)
            {
                ((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked = ((CheckBox)sender).Checked;
            }
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        public void dropDownListSalesTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillData();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldsAdd()
        {
            if (dropDownListBranch.SelectedIndex < 1)
            {
               FlashText1.Display("No Branch is Selected.", "errormessage");
                return false;
            }
            if (dropDownListSalesTarget.SelectedIndex < 1)
            {
               FlashText1.Display("No Sales Target is Selected.", "errormessage");
                return false;
            }
            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewAllBranchSalesRep.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
               FlashText1.Display("Sales Representative(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldsRemove()
        {
            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewMappedSalesRep.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
               FlashText1.Display("Sales Representative(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}