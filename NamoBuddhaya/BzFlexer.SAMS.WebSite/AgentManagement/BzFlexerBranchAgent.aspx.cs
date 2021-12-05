using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Reference;
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
    public partial class BzFlexerBranchAgent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListBranch();
                LoadDataGrid();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListBranch()
        {
            Biz_BranchService branchServices = new Biz_BranchService();

            dropDownListBranch.DataSource = branchServices.ReadAllBranch();
            dropDownListBranch.DataValueField = "Id";
            dropDownListBranch.DataTextField = "Description";
            dropDownListBranch.DataBind();
        }

        public void LoadDataGrid()
        {
            LoadDataTogridViewAllStakeholders();
            DataBindTogridViewMappedStakeholdersByBranchID();
        }

        public void LoadDataTogridViewAllStakeholders()



        {
            Biz_BranchSalesAgentService branchSalesAgentService = new Biz_BranchSalesAgentService();
            List <Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholders = new List<Biz_StakeholderTypeStakeholder>();
            List<Biz_BranchSalesAgent> branchSelesAgent = new List<Biz_BranchSalesAgent>();

            stakeholderTypeStakeholders = branchSalesAgentService.ReadAllSalesAgents();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                branchSelesAgent = branchSalesAgentService.ReadSalesAgentByBranchId(Convert.ToInt16(dropDownListBranch.SelectedValue));
                stakeholderTypeStakeholders = (from stktpsh in stakeholderTypeStakeholders
                                               where
                                                   !(from branchSelesRep in branchSelesAgent
                                                     select branchSelesRep.IdStakeholder).Contains(stktpsh.IdStakeholder)
                                               select stktpsh).ToList();
            }

            DataBindTogridViewAllStakeholders(stakeholderTypeStakeholders);

        }

        public void DataBindTogridViewMappedStakeholdersByBranchID()
        {
            Biz_BranchSalesAgentService Biz_BranchSalesAgentService = new Biz_BranchSalesAgentService();
             List<Biz_BranchSalesAgent> branchSelesReps = new List<Biz_BranchSalesAgent>();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                branchSelesReps =
                    Biz_BranchSalesAgentService.ReadSalesAgentByBranchId(
                        Convert.ToInt16(dropDownListBranch.SelectedValue));
                DataBindTogridViewMappedStakeholders(branchSelesReps);

            }
            else
            {
                CleargridViewMappedStakeholders();
            }
        }


        public void DataBindTogridViewAllStakeholders(List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholdersList)
        {
            gridViewAllStakeholders.DataSource = stakeholderTypeStakeholdersList;
            gridViewAllStakeholders.DataBind();
        }

        public void DataBindTogridViewMappedStakeholders( List<Biz_BranchSalesAgent> branchSelesReps)
        {
            gridViewMappedStakeholders.DataSource = branchSelesReps;
            gridViewMappedStakeholders.DataBind();

        }

        public void CleargridViewMappedStakeholders()
        {
            gridViewMappedStakeholders.DataSource = null;
            gridViewMappedStakeholders.DataBind();
        }

        #endregion

        #region "Properties"

        public void AddBranchSalesRep()
        {
            try
            {
                foreach (GridViewRow gridViewRow in gridViewAllStakeholders.Rows)
                {
                    if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                    {
                        if (Page.IsValid)
                        {
                            Biz_BranchSalesAgentService Biz_BranchSalesAgentService =
                                new Biz_BranchSalesAgentService();
                            Biz_BranchSalesAgent branchSelesAgent = new Biz_BranchSalesAgent();

                            branchSelesAgent.IdStakeholderTypeStakeholder = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            branchSelesAgent.IdSalesAgent =
                                new Biz_StakeholderTypeStakeholderService().ReadStakeholderTypeStakeholderById(
                                    Convert.ToInt16(gridViewRow.Cells[1].Text.Trim())).IdStakeholder;
                            branchSelesAgent.Status =
                                new Biz_StakeholderTypeStakeholderService().ReadStakeholderTypeStakeholderById(
                                    Convert.ToInt16(gridViewRow.Cells[1].Text.Trim())).Status;

                            long stkId = new Biz_StakeholderTypeStakeholderService().ReadStakeholderTypeStakeholderById(
                                    Convert.ToInt16(gridViewRow.Cells[1].Text.Trim())).IdStakeholder;

                            branchSelesAgent.IdStakeholder = stkId;
                            branchSelesAgent.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                            branchSelesAgent.DateEffect = DateTime.Now;
                            branchSelesAgent.DateExpired = null;
                            branchSelesAgent.DateCreated = DateTime.Now;
                            branchSelesAgent.DateModified = DateTime.Now;

                            Biz_BranchSalesAgentService.CreateBranchSelesAgent(branchSelesAgent);

                            Biz_StakeholderBranchService stakeholderBranchService = new Biz_StakeholderBranchService();
                            Biz_StakeholderBranch stakeholderBranch = new Biz_StakeholderBranch();

                            stakeholderBranch.IdStakeholder = stkId;
                            stakeholderBranch.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                            stakeholderBranch.DateCreated = DateTime.Now;
                            stakeholderBranch.DateModified = DateTime.Now;

                            stakeholderBranchService.AddStakeholderBranch(stakeholderBranch);

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

        public void RemoveBranchSalesRep()
        {
            try
            {
                foreach (GridViewRow gridViewRow in gridViewMappedStakeholders.Rows)
                {
                    if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                    {
                        if (Page.IsValid)
                        {
                            Biz_BranchSalesAgentService Biz_BranchSalesAgentService = new Biz_BranchSalesAgentService();
                            Biz_BranchSalesAgent branchSalesAgent = new Biz_BranchSalesAgent();
                            branchSalesAgent = Biz_BranchSalesAgentService.ReadBranchSelesAgentById(Convert.ToInt16(gridViewRow.Cells[1].Text.Trim()));
                            Biz_StakeholderBranchService stakeholderBranchService = new Biz_StakeholderBranchService();
                            stakeholderBranchService.DeleteStakeholderByStakeholderAndBranch(branchSalesAgent.IdStakeholder, branchSalesAgent.IdBranch);

                            Biz_BranchSalesAgentService.DeleteBranchSelesAgent(Convert.ToInt16(gridViewRow.Cells[1].Text.Trim()));

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

        public void gridViewAllStakeholders_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewgridViewMappedStakeholders_RowCreated(object sender, GridViewRowEventArgs e)
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

        public void buttonAdd_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddBranchSalesRep();
                LoadDataGrid();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldDelete())
            {
                RemoveBranchSalesRep();
                LoadDataGrid();
            }
        }

        public void gridViewAllStakeholders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadDataGrid();
            gridViewAllStakeholders.PageIndex = e.NewPageIndex;
            gridViewAllStakeholders.DataBind();
        }

        public void gridViewMappedStakeholders_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadDataGrid();
            gridViewMappedStakeholders.PageIndex = e.NewPageIndex;
            gridViewMappedStakeholders.DataBind();
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGrid();
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (dropDownListBranch.SelectedIndex < 1)
            {
               FlashText1.Display("No Brach is Selected.", "errormessage");
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
               FlashText1.Display("Stakeholder(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldDelete()
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
               FlashText1.Display("Stakeholder(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion

    }
}