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
    public partial class BzFlexerBranchPrizeBooks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListBranch();
                fillData();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListBranch()
        {
            Biz_BranchService _branchService = new Biz_BranchService();

            dropDownListBranch.DataSource = _branchService.ReadAllBranch();
            dropDownListBranch.DataValueField = "Id";
            dropDownListBranch.DataTextField = "Description";
            dropDownListBranch.DataBind();
        }

        public void fillData()
        {
            CleargridViewAllPriceBook();
            CleargridViewMappedPriceBook();
            LoadgridViewAllPriceBook();
            LoadgridViewMappedPriceBook();
        }

        public void CleargridViewAllPriceBook()
        {
            gridViewAllPriceBook.DataSource = null;
            gridViewAllPriceBook.DataBind();
        }

        public void CleargridViewMappedPriceBook()
        {
            gridViewMappedPriceBook.DataSource = null;
            gridViewMappedPriceBook.DataBind();
        }

        public void LoadgridViewAllPriceBook()
        {
            Biz_BranchPriceBookService branchPriceBookService = new Biz_BranchPriceBookService();
            List<Biz_PriceBook> priceBooks = new List<Biz_PriceBook>();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                priceBooks = branchPriceBookService.ReadUnMappedBranchPriceBookByBranchId(Convert.ToInt16(dropDownListBranch.SelectedValue));

                DataBindTogridViewAllPriceBook(priceBooks);
            }
            else
            {
                CleargridViewAllPriceBook();
            }
        }

        public void LoadgridViewMappedPriceBook()
        {
            Biz_BranchPriceBookService branchPriceBookService = new Biz_BranchPriceBookService();
            List<Biz_BranchPriceBook> branchPriceBooks = new List<Biz_BranchPriceBook>();

            if (dropDownListBranch.SelectedIndex > 0)
            {
                branchPriceBooks = branchPriceBookService.ReadMappedBranchPriceBookByBranchId(Convert.ToInt16(dropDownListBranch.SelectedValue));

                DataBindTogridViewMappedPriceBook(branchPriceBooks);
            }
            else
            {
                CleargridViewMappedPriceBook();
            }
        }

        public void DataBindTogridViewMappedPriceBook(List<Biz_BranchPriceBook> branchPriceBooks)
        {
            gridViewMappedPriceBook.DataSource = branchPriceBooks;
            gridViewMappedPriceBook.DataBind();
        }

        public void DataBindTogridViewAllPriceBook(List<Biz_PriceBook> priceBooks)
        {
            gridViewAllPriceBook.DataSource = priceBooks;
            gridViewAllPriceBook.DataBind();
        }

        #endregion

        #region "Operations"

        public void AddBranchPriceBook()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewAllPriceBook.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_BranchPriceBookService branchPriceBookService = new Biz_BranchPriceBookService();
                            Biz_BranchPriceBook branchPriceBook = new Biz_BranchPriceBook();

                            branchPriceBook.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                            branchPriceBook.IdPriceBook = Convert.ToInt16(gridViewRow.Cells[1].Text.Trim());
                            branchPriceBook.Status = "A";
                            branchPriceBook.DateEffect = DateTime.Now;
                            branchPriceBook.DateExpired = DateTime.Now;
                            branchPriceBook.DateCreated = DateTime.Now;
                            branchPriceBook.DateModified = DateTime.Now;

                            branchPriceBookService.CreateBranchPriceBook(branchPriceBook);
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

        public void RemoveBranchPriceBook()
        {
            try
            {
                if (Page.IsValid)
                {
                    foreach (GridViewRow gridViewRow in gridViewMappedPriceBook.Rows)
                    {
                        if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                        {
                            Biz_BranchPriceBookService branchPriceBookService = new Biz_BranchPriceBookService();
                            branchPriceBookService.DeleteBranchPriceBook(Convert.ToInt16(gridViewRow.Cells[1].Text.Trim()));
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
                AddBranchPriceBook();
                fillData();
            }
        }

        public void buttonRemove_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsRemove())
            {
                RemoveBranchPriceBook();
                fillData();
            }
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillData();
        }

        public void gridViewAllPriceBook_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewAllPriceBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadgridViewAllPriceBook();
            gridViewAllPriceBook.PageIndex = e.NewPageIndex;
            gridViewAllPriceBook.DataBind();
        }

        public void gridViewMappedPriceBook_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewMappedPriceBook_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            LoadgridViewMappedPriceBook();
            gridViewMappedPriceBook.PageIndex = e.NewPageIndex;
            gridViewMappedPriceBook.DataBind();
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

            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewAllPriceBook.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                 FlashText1.Display("Price Book(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldsRemove()
        {
            Boolean isSelect = false;
            foreach (GridViewRow gridViewRow in gridViewMappedPriceBook.Rows)
            {
                if (((CheckBox)gridViewRow.Cells[0].FindControl("checkBoxItem")).Checked)
                {
                    isSelect = true;
                    break;
                }
            }
            if (!isSelect)
            {
                 FlashText1.Display("Price Book(s) not Selected.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion

    }
}