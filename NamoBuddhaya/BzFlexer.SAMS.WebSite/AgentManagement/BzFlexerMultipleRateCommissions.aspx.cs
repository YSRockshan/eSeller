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
    public partial class BzFlexerMultipleRateCommissions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListCommission();
                DataBindTodropDownListSlab();
                DataBindTogridViewMultipleRate();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListCommission()
        {
            Biz_CommissionsService commissionService = new Biz_CommissionsService();
            List<Biz_Commission> commissions = new List<Biz_Commission>();
            commissions = commissionService.ReadAllCommissions();
            commissions = (from com in commissions where com.Mode == "M" select com).ToList();
            dropDownListCommission.DataSource = commissions;
            dropDownListCommission.DataValueField = "Id";
            dropDownListCommission.DataTextField = "Description";
            dropDownListCommission.DataBind();
        }

        public void DataBindTodropDownListSlab()
        {
            Biz_SlabService slabService = new Biz_SlabService();
            dropDownListSlab.DataSource = slabService.ReadAllSlabs();
            dropDownListSlab.DataValueField = "Id";
            dropDownListSlab.DataTextField = "Description";
            dropDownListSlab.DataBind();
        }

        public void DataBindTogridViewMultipleRate()
        {
            Biz_SlabDetailService slabDetailService = new Biz_SlabDetailService();
            List<Biz_SlabDetail> slabDetails = new List<Biz_SlabDetail>();
            slabDetails = slabDetailService.ReadAllSlabDetails();
            if (dropDownListSlab.SelectedIndex > 0)
            {
                slabDetails =
                    (from slbdet in slabDetails
                     where slbdet.IdSlab == Convert.ToInt16(dropDownListSlab.SelectedValue)
                     select slbdet).ToList();
                LoadDataTogridViewMultipleRate(slabDetails);
            }
            else
            {
                CleargridViewMultipleRate();
            }
        }

        public void CleargridViewMultipleRate()
        {
            gridViewMultipleRate.DataSource = null;
            gridViewMultipleRate.DataBind();
        }

        public void LoadDataTogridViewMultipleRate(List<Biz_SlabDetail> slabDetails)
        {
            gridViewMultipleRate.DataSource = slabDetails;
            gridViewMultipleRate.DataBind();
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            dropDownListCommission.SelectedValue = "";
            dropDownListSlab.SelectedValue = "";
            CleargridViewMultipleRate();
        }

        #endregion

        #region "Operations"

        public void SaveMultipleRateCommision()
        {
            try
            {
                Biz_MultipleRate multipleRate = new Biz_MultipleRate();
                Biz_MultipleRatesService multipleRateService = new Biz_MultipleRatesService();

                if (Page.IsValid)
                {
                    multipleRate.IdCommission = Convert.ToInt16(dropDownListCommission.SelectedValue);
                    multipleRate.IdSlab = Convert.ToInt16(dropDownListSlab.SelectedValue);
                    multipleRate.Status = "A";
                    multipleRate.DateCreated = DateTime.Now;
                    multipleRate.DateModified = DateTime.Now;

                    multipleRateService.CreateMultipleRate(multipleRate);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckMandatoryFieldsAdd())
            {
                SaveMultipleRateCommision();
            }
        }

        public void buttonCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void dropDownListSlab_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataBindTogridViewMultipleRate();
        }

        public void gridViewMultipleRate_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void dropDownListCommission_SelectedIndexChanged(object sender, EventArgs e)
        {
            Biz_MultipleRate multipleRate = new Biz_MultipleRate();
            Biz_MultipleRatesService multipleRateService = new Biz_MultipleRatesService();

            if (dropDownListCommission.SelectedIndex > 0)
            {
                multipleRate.IdCommission = Convert.ToInt16(dropDownListCommission.SelectedValue);
                multipleRate = multipleRateService.ReadMultipleRateByCommssionId(multipleRate.IdCommission);
                if (multipleRate != null)
                {
                    hiddenFieldSlabEdit.Value = multipleRate.IdSlab.ToString();
                }
                else
                {
                    hiddenFieldSlabEdit.Value = "";
                }

                if (hiddenFieldSlabEdit.Value != "")
                {
                    dropDownListSlab.SelectedValue = hiddenFieldSlabEdit.Value;
                    DataBindTogridViewMultipleRate();
                }
                else
                {
                    dropDownListSlab.SelectedValue = "";
                    CleargridViewMultipleRate();
                }
            }
        }

        #endregion

        #region "Validations"

        private Boolean CheckMandatoryFieldsAdd()
        {
            if (dropDownListCommission.SelectedIndex < 1)
            {
               FlashText1.Display("No Commission is Selected.", "errormessage");
                return false;
            }
            if (dropDownListSlab.SelectedIndex < 1)
            {
               FlashText1.Display("No Slab is Selected.", "errormessage");
                return false;
            }
            if (dropDownListSlab.SelectedIndex > 0)
            {
                Biz_MultipleRatesService multipleRateService = new Biz_MultipleRatesService();
                List<Biz_MultipleRate> multipleRates = new List<Biz_MultipleRate>();
                List<Biz_MultipleRate> multipleRate = new List<Biz_MultipleRate>();
                multipleRates = multipleRateService.ReadAllMultipleRates();
                multipleRate = (from rate in multipleRates
                                where
                                    rate.IdCommission == Convert.ToInt16(dropDownListCommission.SelectedValue) &&
                                    rate.IdSlab == Convert.ToInt16(dropDownListSlab.SelectedValue)
                                select rate).ToList();
                if (multipleRate.Count > 0)
                {
                   FlashText1.Display("Record Already Exists.", "errormessage");
                    return false;
                }
            }

            return true;
        }

        #endregion
    }
}