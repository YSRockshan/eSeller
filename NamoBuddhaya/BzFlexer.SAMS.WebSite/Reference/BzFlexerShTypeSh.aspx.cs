using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.Reference
{
    public partial class BzFlexerShTypeSh : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListStakeholderType();
                LoadGridData();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListStakeholderType()
        {
            Biz_StakeholderTypeService stakeholderTypeService = new Biz_StakeholderTypeService();

            dropDownListStakeholderType.DataSource = stakeholderTypeService.ReadAllStakeholderType();
            dropDownListStakeholderType.DataValueField = "Id";
            dropDownListStakeholderType.DataTextField = "Description";
            dropDownListStakeholderType.DataBind();
        }

        public void LoadGridData()
        {
            LoadGridViewAllStakeholder();
            LoadgridViewMappedStakeholder();
        }

        public void LoadGridViewAllStakeholder()
        {
            Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
            List<Biz_Stakeholder> stakeholders = new List<Biz_Stakeholder>();
            Biz_StakeholderTypeStakeholderService stakeholderTypeStakeholderService = new Biz_StakeholderTypeStakeholderService();

            if (dropDownListStakeholderType.SelectedIndex > 0)
            {
                stakeholders = stakeholderTypeStakeholderService.ReadUnmappedStakeholderByStakeholderTypetId(Convert.ToInt16(dropDownListStakeholderType.SelectedValue));
                gridViewAllStakeholder.DataSource = stakeholders;
                gridViewAllStakeholder.DataBind();
            }
            else
            {
                gridViewAllStakeholder.DataSource = employeeDetailService.ReadAllEmplyeeDetail();
                gridViewAllStakeholder.DataBind();

            }
        }


        public void LoadgridViewMappedStakeholder()
        {
            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholders = new List<Biz_StakeholderTypeStakeholder>();
            Biz_StakeholderTypeStakeholderService stakeholderTypeStakeholderService = new Biz_StakeholderTypeStakeholderService();

            if (dropDownListStakeholderType.SelectedIndex > 0)
            {
                stakeholderTypeStakeholders =
                    stakeholderTypeStakeholderService.ReadMappedStakeholderTypeStakeholder(
                        Convert.ToInt16(dropDownListStakeholderType.SelectedValue));
                DataBindTogridViewMappedStakeholder(stakeholderTypeStakeholders);
            }
            else
            {
                CleargridViewMappedStakeholder();
            }
        }

        public void DataBindToGridViewAllStakeholder(List<Biz_Stakeholder> stakeholderList)
        {
            gridViewAllStakeholder.DataSource = stakeholderList;
            gridViewAllStakeholder.DataBind();
        }

        public void DataBindTogridViewMappedStakeholder(List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholders)
        {
            try
            {
                gridViewMappedStakeholder.DataSource = stakeholderTypeStakeholders;
                gridViewMappedStakeholder.DataBind();
            }
            catch (Exception exception)
            { }
        }

        public void CleargridViewMappedStakeholder()
        {
            gridViewMappedStakeholder.DataSource = null;
            gridViewMappedStakeholder.DataBind();
        }

        #endregion

        #region "Operations"

        public void AddStakeholderTypeStakeholder()
        {
            try
            {
                foreach (GridViewRow gridViewRow in gridViewAllStakeholder.Rows)
                {
                    if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                    {
                        if (Page.IsValid)
                        {
                            Biz_StakeholderTypeStakeholderService stakeholderTypeStakeholderService =
                                new Biz_StakeholderTypeStakeholderService();
                            Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder = new Biz_StakeholderTypeStakeholder();

                            stakeholderTypeStakeholder.IdStakeholder = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            stakeholderTypeStakeholder.IdStakeholderType =
                                Convert.ToInt16(dropDownListStakeholderType.SelectedValue);
                            stakeholderTypeStakeholder.DateCreated = DateTime.Now;
                            stakeholderTypeStakeholder.DateModified = DateTime.Now;
                            stakeholderTypeStakeholder.DateEffect = DateTime.Now;
                            stakeholderTypeStakeholder.Status =
                                new Biz_EmployeeDetailService().ReadEmployeeDetailById(
                                    Convert.ToInt16(gridViewRow.Cells[1].Text.Trim())).Status;

                            stakeholderTypeStakeholderService.CreateStakeholderTypeStakeholder(stakeholderTypeStakeholder);
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

        public void RemoveStakeholderTypeStakeholder()
        {
            try
            {
                foreach (GridViewRow gridViewRow in gridViewMappedStakeholder.Rows)
                {
                    if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                    {
                        if (Page.IsValid)
                        {
                            Biz_StakeholderTypeStakeholderService stakeholderTypeStakeholderService = new Biz_StakeholderTypeStakeholderService();
                            stakeholderTypeStakeholderService.DeleteStakeholderTypeStakeholder(Convert.ToInt16(gridViewRow.Cells[1].Text.Trim()));
                            FlashText1.Display("Record(s) Successfully Removed.", "errormessage");
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
                AddStakeholderTypeStakeholder();
                LoadGridData();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldDelete())
            {
                RemoveStakeholderTypeStakeholder();
                LoadGridData();
            }
        }

        public void dropDownListStakeholderType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGridData();
        }

        public void gridViewAllStakeholder_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedStakeholder_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedStakeholder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadGridData();
            gridViewMappedStakeholder.PageIndex = e.NewPageIndex;
            gridViewMappedStakeholder.DataBind();
        }

        public void gridViewAllStakeholder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadGridData();
            gridViewAllStakeholder.PageIndex = e.NewPageIndex;
            gridViewAllStakeholder.DataBind();
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
            if (dropDownListStakeholderType.SelectedIndex < 1)
            {
                FlashText1.Display("No Stakeholder Type is Selected.", "errormessage");
                return false;
            }
            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewAllStakeholder.Rows)
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
            foreach (GridViewRow gridViewRow in gridViewMappedStakeholder.Rows)
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