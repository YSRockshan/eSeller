using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Service.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.AgentManagement
{
    public partial class BzFlexerSalesAgentPosision : System.Web.UI.Page
    {
        #region "Variables"

        private long selectSalesRepPositionId;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSalesRepsPosition();
            }
        }

        #region "Load Data"

        public void LoadSalesRepsPosition()
        {
            try
            {
                Biz_SalesAgentPositionService salesAgentPositionService = new Biz_SalesAgentPositionService();
                Biz_SalesAgentPosition salesRepPosition = new Biz_SalesAgentPosition();

                gridViewSalesRepsPosition.DataSource = salesAgentPositionService.ReadAllsalesAgentPositions();
                gridViewSalesRepsPosition.DataBind();
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxSalesRepPositionCodeAdd.Text = "";
            textBoxSalesRepPositionDescriptionAdd.Text = "";
            textBoxSalesRepPositionModify.Text = "";
            textBoxSalesRepPositionDescriptionModify.Text = "";
            ViewState["selectSalesRepPositionId"] = "";
            gridViewSalesRepsPosition.SelectedIndex = -1;
            accordionInputs.SelectedIndex = 0;
        }

        #endregion

        #region "Operations"

        public void AddSalesRepsPosition()
        {
            try
            {
                Biz_SalesAgentPositionService Biz_SalesAgentPositionService = new Biz_SalesAgentPositionService();
                Biz_SalesAgentPosition salesRepPosition = new Biz_SalesAgentPosition();

                if (Page.IsValid)
                {
                    salesRepPosition.Code = textBoxSalesRepPositionCodeAdd.Text.Trim().ToUpper();
                    salesRepPosition.Description = textBoxSalesRepPositionDescriptionAdd.Text.Trim();
                    salesRepPosition.DateCreated = DateTime.Now;
                    salesRepPosition.DateModified = DateTime.Now;

                    Biz_SalesAgentPositionService.CreatesalesAgentPosition(salesRepPosition);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ModifySalesRepsPosition()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesAgentPositionService Biz_SalesAgentPositionService = new Biz_SalesAgentPositionService();
                    Biz_SalesAgentPosition salesAgentPosition = new Biz_SalesAgentPosition();


                    salesAgentPosition.Id = Convert.ToInt16(ViewState["selectId"]);
                    salesAgentPosition = Biz_SalesAgentPositionService.ReadSalesAgentPositionById(salesAgentPosition.Id);
                    salesAgentPosition.Code = textBoxSalesRepPositionModify.Text.Trim().ToUpper();
                    salesAgentPosition.Description = textBoxSalesRepPositionDescriptionModify.Text.Trim();
                    salesAgentPosition.DateModified = DateTime.Now;

                    Biz_SalesAgentPositionService.UpdatesalesAgentPosition(salesAgentPosition);
                   FlashText1.Display("Record Successfully Modified.", "okmessage");
                }
            }
            catch (Exception)
            {
               FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteSalesRepPosition()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SalesAgentPositionService Biz_SalesAgentPositionService = new Biz_SalesAgentPositionService();
                    Biz_SalesAgentPositionService.DeleteSalesAgentPositions(Convert.ToInt16(ViewState["selectId"]));
                   FlashText1.Display("Record Successfully Deleted.", "okmessage");
                }
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Deleting Failed.", "errormessage");
            }
        }


        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddSalesRepsPosition();
                ClearData();
                LoadSalesRepsPosition();
            }
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldModify())
            {
                ModifySalesRepsPosition();
                ClearData();
                LoadSalesRepsPosition();
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldDelete())
            {
                DeleteSalesRepPosition();
                ClearData();
                LoadSalesRepsPosition();
            }
        }

        public void buttonCancel1_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void gridViewSalesRepsPosition_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSalesRepsPosition_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewSalesRepsPosition.PageIndex = e.NewPageIndex;
            LoadSalesRepsPosition();
        }

        public void gridViewSalesRepsPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewSalesRepsPosition.SelectedRow;
            ViewState["selectId"] = row.Cells[1].Text.Trim();
            textBoxSalesRepPositionModify.Text = row.Cells[2].Text.Trim();
            textBoxSalesRepPositionDescriptionModify.Text = row.Cells[3].Text.Trim();
            accordionInputs.SelectedIndex = 1;
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (textBoxSalesRepPositionCodeAdd.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Code cannot be blank.", "errormessage");
                return false;
            }
            if (textBoxSalesRepPositionDescriptionAdd.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Description cannot be blank.", "errormessage");
                return false;
            }
            if (textBoxSalesRepPositionCodeAdd.Text.Trim() != string.Empty)
            {
                Biz_SalesAgentPositionService Biz_SalesAgentPositionService = new Biz_SalesAgentPositionService();
                List<Biz_SalesAgentPosition> salesAgentPositionList = new List<Biz_SalesAgentPosition>();

                salesAgentPositionList = Biz_SalesAgentPositionService.ReadSalesAgentPositionByCode(textBoxSalesRepPositionCodeAdd.Text.Trim());
                if (salesAgentPositionList.Count > 0)
                {
                   FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }

            }
            return true;
        }

        private Boolean CheckMandatoryFieldModify()
        {
            if (ViewState["selectId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxSalesRepPositionModify.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Code cannot be blank.", "errormessage");
                return false;
            }
            if (textBoxSalesRepPositionDescriptionModify.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Description cannot be blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFieldDelete()
        {
            if (ViewState["selectId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }


        #endregion
    }
}