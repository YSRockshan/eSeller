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
    public partial class BzFlexerMemberSalesAgentPosition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListBranch();
                DataBindTodropDownListSalesRepPosition();
                fillData();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListBranch()
        {
            Biz_BranchService branchService = new Biz_BranchService();
            dropDownListBranch.DataSource = branchService.ReadAllBranch();
            dropDownListBranch.DataValueField = "Id";
            dropDownListBranch.DataTextField = "Description";
            dropDownListBranch.DataBind();
        }

        public void DataBindTodropDownListSalesRepPosition()
        {
            Biz_SalesAgentPositionService salesRepPositionService = new Biz_SalesAgentPositionService();
            dropDownListSalesRepPosition.DataSource = salesRepPositionService.ReadAllsalesAgentPositions();
            dropDownListSalesRepPosition.DataValueField = "Id";
            dropDownListSalesRepPosition.DataTextField = "Description";
            dropDownListSalesRepPosition.DataBind();
        }

        public void fillData()
        {
            CleargridViewAllStakeholders();
            CleargridViewMappedStakeholders();
            LoadMappedSalesRepresentatives();
            LoadUnMappedSalesRepresentatives();
        }

        public void LoadMappedSalesRepresentatives()
        {
            Biz_MemberSalesAgentPositionService AgentPositionService = new Biz_MemberSalesAgentPositionService();
            List<Biz_MemberSalesAgentPosition> AgentPosition = new List<Biz_MemberSalesAgentPosition>();

            if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesRepPosition.SelectedIndex > 0)
            {
                AgentPosition = AgentPositionService.MappedSalesAgents(Convert.ToInt16(dropDownListBranch.SelectedValue), Convert.ToInt16(dropDownListSalesRepPosition.SelectedValue));
                DataBindTogridViewMappedStakeholders(AgentPosition);
            }
            else
            {
                CleargridViewMappedStakeholders();
            }
        }

        public void DataBindTogridViewMappedStakeholders(List<Biz_MemberSalesAgentPosition> SalesAgentPosition)
        {
            gridViewMappedStakeholders.DataSource = SalesAgentPosition;
            gridViewMappedStakeholders.DataBind();
        }

        public void DataBindTogridViewAllStakeholders(List<Biz_BranchSalesAgent> branchSelesAgent)
        {
            gridViewAllStakeholders.DataSource = branchSelesAgent;
            gridViewAllStakeholders.DataBind();
        }

        public void CleargridViewMappedStakeholders()
        {
            gridViewMappedStakeholders.DataSource = null;
            gridViewMappedStakeholders.DataBind();
        }

        public void LoadUnMappedSalesRepresentatives()
        {
            Biz_MemberSalesAgentPositionService AgentPositionService = new Biz_MemberSalesAgentPositionService();
            List<Biz_BranchSalesAgent> branchSelesReps = new List<Biz_BranchSalesAgent>();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                branchSelesReps = AgentPositionService.UnMappedSalesAgents(Convert.ToInt16(dropDownListBranch.SelectedValue));
            }
            if (dropDownListBranch.SelectedIndex > 0 && dropDownListSalesRepPosition.SelectedIndex > 0)
            {
                branchSelesReps = AgentPositionService.UnMappedSalesAgents(Convert.ToInt16(dropDownListBranch.SelectedValue), Convert.ToInt16(dropDownListSalesRepPosition.SelectedValue));
            }

            DataBindTogridViewAllStakeholders(branchSelesReps);

            //if (dropDownListBranch.SelectedIndex  > 0)
            //{
            //    branchSelesReps =
            //        (from brnRep in branchSelesReps
            //         where brnRep.BranchId == Convert.ToInt16(dropDownListBranch.SelectedValue)
            //         select brnRep).ToList();
            //}
            //else
            //{
            //    CleargridViewAllStakeholders();
            //}
        }

        public void CleargridViewAllStakeholders()
        {
            gridViewAllStakeholders.DataSource = null;
            gridViewAllStakeholders.DataBind();
        }

        #endregion

        #region "Operations"

        public void AddBranchSalesRepPositions()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllStakeholders.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_MemberSalesAgentPositionService memberSalesRepPositionService = new Biz_MemberSalesAgentPositionService();
                            Biz_MemberSalesAgentPosition memberSalesRepPosition = new Biz_MemberSalesAgentPosition();

                            memberSalesRepPosition.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                            memberSalesRepPosition.IdSalesAgentPosition = Convert.ToInt16(dropDownListSalesRepPosition.SelectedValue);
                            memberSalesRepPosition.IdSalesAgent = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            memberSalesRepPosition.DateCreated = DateTime.Now;
                            memberSalesRepPosition.DateModified = DateTime.Now;

                            memberSalesRepPositionService.CreateMemberSalesAgentPosition(memberSalesRepPosition);
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

        public void RemoveBranchSalesRepPositions()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedStakeholders.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_MemberSalesAgentPositionService memberSalesRepPositionService = new Biz_MemberSalesAgentPositionService();
                            memberSalesRepPositionService.DeleteMemberSalesAgentPosition(Convert.ToInt16(gridViewRow.Cells[1].Text.Trim()));
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
                AddBranchSalesRepPositions();
                fillData();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsRemove())
            {
                RemoveBranchSalesRepPositions();
                fillData();
            }
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillData();
        }

        public void dropDownListSalesRepPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillData();
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

        public void checkBoxHeader_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in ((GridView)((CheckBox)sender).Parent.Parent.Parent.Parent).Rows)
            {
                ((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked = ((CheckBox)sender).Checked;
            }
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
            if (dropDownListSalesRepPosition.SelectedIndex < 1)
            {
               FlashText1.Display("No Sales Representatives Position is Selected.", "errormessage");
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
               FlashText1.Display("Sales Representative(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldsRemove()
        {
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
               FlashText1.Display("Sales Representative(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion

    }
}