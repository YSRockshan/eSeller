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
    public partial class BzFlexerSlabs : System.Web.UI.Page
    {
        private long selectSlabDetailId;
        private long selectCommissionSlabId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTogridViewCommissionSlab();
            }
        }

        #region "Load Data"

        public void DataBindTogridViewCommissionSlab()
        {
            Biz_SlabService slabService = new Biz_SlabService();
            gridViewCommissionSlab.DataSource = slabService.ReadAllSlabs();
            gridViewCommissionSlab.DataBind();
        }

        public void DataBindTogridViewSlabDetail()
        {
            Biz_SlabDetailService slabDetailService = new Biz_SlabDetailService();
            List<Biz_SlabDetail> slabDetails = new List<Biz_SlabDetail>();
            slabDetails = slabDetailService.ReadAllSlabDetails();
            if (ViewState["selectCommissionSlabId"] != null)
            {
                slabDetails =
                    (from slbdet in slabDetails
                     where slbdet.IdSlab == Convert.ToInt16(ViewState["selectCommissionSlabId"])
                     select slbdet).ToList();
            }
            else
            {
                slabDetails = null;
            }


            if (slabDetails.Count > 0)
            {
                //    Session[Global.KeySlabDetail] = slabDetails;
                LoadgridViewSlabDetail(slabDetails);
            }
            else
            {
                CleargridViewSlabDetail();
            }
        }

        public void LoadgridViewSlabDetail(List<Biz_SlabDetail> slabDetails)
        {
            gridViewSlabDetail.DataSource = slabDetails;
            gridViewSlabDetail.DataBind();
        }

        public void CleargridViewSlabDetail()
        {
            gridViewSlabDetail.DataSource = null;
            gridViewSlabDetail.DataBind();
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxSlabAdd.Text = "";
            textBoxSlabDescriptionAdd.Text = "";
            textBoxSlabCodeModify.Text = "";
            textBoxSlabDescriptionModify.Text = "";
            DataBindTogridViewCommissionSlab();
            gridViewCommissionSlab.SelectedIndex = -1;
            DataBindTogridViewSlabDetail();
        }

        #endregion

        #region "Operations"

        public void AddSlab()
        {
            try
            {
                Biz_SlabService slabService = new Biz_SlabService();
                Biz_Slab slab = new Biz_Slab();
                if (Page.IsValid)
                {
                    slab.Code = textBoxSlabAdd.Text.Trim().ToUpper();
                    slab.Description = textBoxSlabDescriptionAdd.Text.Trim();
                    slab.DateCreated = DateTime.Now;
                    slab.DateModified = DateTime.Now;

                    slabService.CreateSlab(slab);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ModifySlab()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SlabService slabService = new Biz_SlabService();
                    Biz_Slab slab = new Biz_Slab();
                    slab.Id = Convert.ToInt16(ViewState["selectCommissionSlabId"]);
                    slab = slabService.ReadSlabById(slab.Id);
                    slab.Code = textBoxSlabCodeModify.Text.Trim().ToUpper();
                    slab.Description = textBoxSlabDescriptionModify.Text.Trim();
                    slab.DateModified = DateTime.Now;

                    slabService.UpdateSlab(slab);
                   FlashText1.Display("Record Successfully Modified.", "okmessage");
                }
            }
            catch (Exception)
            {
               FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void DeleteSlab()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SlabService slabService = new Biz_SlabService();
                    slabService.DeleteSlab(Convert.ToInt16(ViewState["selectCommissionSlabId"]));
                   FlashText1.Display("Record Successfully Deleted.", "okmessage");
                }
            }
            catch (Exception)
            {
               FlashText1.Display("Record Deleting Failed.", "errormessage");
            }
        }

        public void DeleteSlabDetail()
        {
            try
            {
                Biz_SlabDetailService slabDetailService = new Biz_SlabDetailService();
                slabDetailService.DeleteSlabDetail(Convert.ToInt16(ViewState["selectSlabDetailId"]));
               FlashText1.Display("Record(s) Successfully Deleted.", "okmessage");
            }
            catch (Exception)
            {
               FlashText1.Display("Record(s) Deleting Failed.", "errormessage");
            }
        }

        public void ModifySlabDetal()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_SlabDetail slabDetail = new Biz_SlabDetail();
                    Biz_SlabDetailService slabDetailService = new Biz_SlabDetailService();
                    TextBox textBox;
                    for (int i = 0; i < gridViewSlabDetail.Rows.Count; i++)
                    {
                        slabDetail = slabDetailService.ReadSlabDetailById(Convert.ToInt16(gridViewSlabDetail.Rows[i].Cells[1].Text.Trim()));
                        slabDetail.Id = Convert.ToInt16(gridViewSlabDetail.Rows[i].Cells[1].Text.Trim());
                        slabDetail.IdSlab = Convert.ToInt16(textBoxSlabIdModify.Text);
                        slabDetail.Slab_From = Convert.ToDecimal(gridViewSlabDetail.Rows[i].Cells[3].Text.Trim());
                        textBox = (TextBox)
                                     gridViewSlabDetail.Rows[i].Cells[4].FindControl("textBoxSlabTo");
                        slabDetail.Slab_To = Convert.ToDecimal(textBox.Text);

                        textBox = (TextBox)
                                     gridViewSlabDetail.Rows[i].Cells[5].FindControl("textBoxCommissionRAte");
                        slabDetail.Rate = Convert.ToDecimal(textBox.Text);
                        slabDetail.Description = slabDetail.Slab_From.ToString() + " - " + slabDetail.Slab_To.ToString();
                        slabDetail.DateModified = DateTime.Now;
                        slabDetailService.UpdateSlabDetail(slabDetail);
                    }
                   FlashText1.Display("Record Successfully Modified.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }

        public void CreateNewDataRow()
        {
            List<Biz_SlabDetail> slabDetails = new List<Biz_SlabDetail>();
            slabDetails = new Biz_SlabDetailService().ReadAllSlabDetails();
            slabDetails = (from slabDet in slabDetails
                           where slabDet.IdSlab == Convert.ToInt16(ViewState["selectCommissionSlabId"])
                           select slabDet).ToList();
            Biz_SlabDetail slabDetail = new Biz_SlabDetail();
            if (slabDetails.Count > 0)
            {
                for (int i = 0; i < gridViewSlabDetail.Rows.Count; i++)
                {
                    TextBox textBox;
                    textBox = (TextBox)gridViewSlabDetail.Rows[i].Cells[4].FindControl("textBoxSlabTo");

                    slabDetail.Slab_To = Convert.ToDecimal(textBox.Text);
                }
                CreateEmptySlabDetailRow(slabDetail.Slab_To);

            }
            else
            {
                CreateEmptySlabDetailRow(0);
            }
        }

        public void CreateEmptySlabDetailRow(Decimal slabFrom)
        {
            try
            {
                Biz_SlabDetail slabDetail = new Biz_SlabDetail();
                Biz_SlabDetailService slabDetailService = new Biz_SlabDetailService();

                //if (textBoxSlabIdModify.Text != String.Empty)
                //{
                slabDetail.IdSlab = Convert.ToInt16(ViewState["selectCommissionSlabId"]);
                slabDetail.Slab_From = slabFrom + 1;
                slabDetail.Slab_To = 0;
                slabDetail.Description = slabDetail.Slab_From.ToString() + " - " + slabDetail.Slab_To.ToString();
                slabDetail.Rate = 0;
                slabDetail.DateCreated = DateTime.Now;
                slabDetail.DateModified = DateTime.Now;


                slabDetailService.CreateSlabDetail(slabDetail);
                //}
            }
            catch (Exception exception)
            {
            }
        }

        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldAdd())
            {
                AddSlab();
                ClearData();
            }
        }

        public void buttonEdit_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFiledModify())
            {
                ModifySlab();
                ClearData();
                DataBindTogridViewSlabDetail();
                accordionInputs.SelectedIndex = 1;
            }
        }

        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFiledDelete())
            {
                DeleteSlab();
                ClearData();
                DataBindTogridViewSlabDetail();
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

        public void buttonSlabDetailDelete_Click(object sender, EventArgs e)
        {
            DeleteSlabDetail();
            ClearData();
        }

        public void buttonSlabDetailCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void buttonSlabDetailAdd_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFiledModify())
            {
                CreateNewDataRow();
                DataBindTogridViewSlabDetail();
            }
        }

        public void buttonSlabDetailSave_Click(object sender, EventArgs e)
        {
            ModifySlabDetal();
            ClearData();
        }

        public void gridViewCommissionSlab_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewCommissionSlab_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewCommissionSlab.SelectedRow;

            ViewState["selectCommissionSlabId"] = row.Cells[1].Text.Trim();
            textBoxSlabCodeModify.Text = row.Cells[2].Text.Trim();
            textBoxSlabDescriptionModify.Text = row.Cells[3].Text.Trim();
            textBoxSlabIdModify.Text = row.Cells[1].Text.Trim();
            accordionInputs.SelectedIndex = 1;

            DataBindTogridViewSlabDetail();
        }

        public void gridViewSlabDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewSlabDetail.SelectedRow;
            ViewState["selectSlabDetailId"] = row.Cells[1].Text.Trim();
        }

        public void gridViewSlabDetail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void textBoxSlabTo_TextChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow gridViewRow in gridViewSlabDetail.Rows)
            {
                TextBox textBox = new TextBox();
                textBox = (TextBox)gridViewRow.Cells[4].FindControl("textBoxSlabTo");

                if (textBox != null)
                {
                    if (textBox.Text == String.Empty)
                    {
                        textBox.Text = gridViewRow.Cells[3].Text;
                    }
                    if (textBox.Text != String.Empty && Convert.ToDouble(textBox.Text) < Convert.ToDouble(gridViewRow.Cells[3].Text))
                    {
                        textBox.Text = gridViewRow.Cells[3].Text;
                       FlashText1.Display("[Slab To] should be greater than [Slab From]", "errormessage");
                    }
                }
            }
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldAdd()
        {
            if (textBoxSlabAdd.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSlabDescriptionAdd.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSlabAdd.Text.Trim() != string.Empty)
            {
                Biz_SlabService slabService = new Biz_SlabService();
                List<Biz_Slab> slabs = new List<Biz_Slab>();

                slabs = slabService.ReadSlabByCode(textBoxSlabAdd.Text.Trim());
                if (slabs.Count > 0)
                {
                   FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }
            }
            return true;
        }

        private Boolean CheckMandatoryFiledModify()
        {
            if (ViewState["selectCommissionSlabId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            if (textBoxSlabCodeModify.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Code Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxSlabDescriptionModify.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Description Cannot be Blank.", "errormessage");
                return false;
            }
            return true;
        }

        private Boolean CheckMandatoryFiledDelete()
        {
            if (ViewState["selectCommissionSlabId"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            else
            {
                List<Biz_SlabDetail> slabDetail = new List<Biz_SlabDetail>();
                Biz_SlabDetailService slabDetailService = new Biz_SlabDetailService();

                slabDetail = slabDetailService.ReadAllSlabDetails();
                slabDetail =
                    (from detail in slabDetail
                     where detail.IdSlab == Convert.ToInt16(ViewState["selectCommissionSlabId"])
                     select detail).ToList();
                if (slabDetail.Count > 0)
                {
                   FlashText1.Display("Slab Details exists with this Slab.", "errormessage");
                    return false;
                }
            }
            return true;
        }

        #endregion

    }
}