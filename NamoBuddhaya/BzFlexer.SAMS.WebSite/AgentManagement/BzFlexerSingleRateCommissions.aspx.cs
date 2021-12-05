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
    public partial class BzFlexerSingleRateCommissions : System.Web.UI.Page
    {
        #region "Variables"

        private long selectSingleRate;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataBindTodropDownListCommission();
                DataBindTogridViewSingleRate();
                //LoadHiddenField();
            }
        }

        #region "Load Data"

        public void DataBindTodropDownListCommission()
        {
            Biz_CommissionsService commissionService = new Biz_CommissionsService();
            List<Biz_Commission> commissions = new List<Biz_Commission>();
            commissions = commissionService.ReadAllCommissions();
            commissions = (from com in commissions where com.Mode == "S" select com).ToList();
            dropDownListCommission.DataSource = commissions;
            dropDownListCommission.DataValueField = "Id";
            dropDownListCommission.DataTextField = "Description";
            dropDownListCommission.DataBind();
        }

        public void DataBindTogridViewSingleRate()
        {
            Biz_SingleRateService singleRateService = new Biz_SingleRateService();
            List<Biz_SingleRate> singleRates = new List<Biz_SingleRate>();
            singleRates = singleRateService.ReadAllSingleRates();

            if (dropDownListCommission.SelectedIndex > 0)
            {
                singleRates =
                    (from sr in singleRates
                     where sr.IdCommssion == Convert.ToInt16(dropDownListCommission.SelectedValue)
                     select sr).ToList();
                LoadSingleRateComission(singleRates);
            }
            else
            {
                CleargridViewSingleRate();
            }
        }

        //public void LoadHiddenField()
        //{
        //    if (radioButtonListRateMode.SelectedIndex == 0)
        //    {
        //        hiddenFieldSingleRate.Value = "T";
        //    }
        //    else
        //    {
        //        hiddenFieldSingleRate.Value = "S";
        //    }
        //}

        public void CleargridViewSingleRate()
        {
            gridViewSingleRate.DataSource = null;
            gridViewSingleRate.DataBind();
        }

        public void LoadSingleRateComission(List<Biz_SingleRate> singleRates)
        {
            gridViewSingleRate.DataSource = singleRates;
            gridViewSingleRate.DataBind();
        }

        #endregion

        #region "Display Handling"

        public void ClearData()
        {
            textBoxRate.Text = "";
            ViewState["selectSingleRate"] = "";
            //radioButtonListRateMode.SelectedIndex = 0;
            //hiddenFieldSingleRate.Value = "T";
            hiddenFieldstatus.Value = "";
            gridViewSingleRate.SelectedIndex = -1;
        }

        #endregion

        #region "Operations"

        public void AddSingleRate()
        {
            try
            {
                Biz_SingleRateService singleRateService = new Biz_SingleRateService();
                Biz_SingleRate singleRate = new Biz_SingleRate();

                if (Page.IsValid)
                {
                    singleRate.IdCommssion = Convert.ToInt16(dropDownListCommission.SelectedValue);
                    //if (radioButtonListRateMode.SelectedIndex == 0)
                    //{
                    //    singleRate.RateMode = "T";
                    //}
                    //else if (radioButtonListRateMode.SelectedIndex == 1)
                    //{
                    //    singleRate.RateMode = "S";
                    //}
                    singleRate.Rate_Mode = "T";
                    singleRate.Rate = Convert.ToInt16(textBoxRate.Text.Trim());
                    singleRate.Status = "A";
                    singleRate.DateCreated = DateTime.Now;
                    singleRate.DateModified = DateTime.Now;

                    singleRateService.CreateSingleRate(singleRate);
                   FlashText1.Display("Record Successfully Saved.", "okmessage");
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Saving Failed.", "errormessage");
            }
        }

        public void ActiveOrInactiveSingleRate()
        {
            try
            {
                Biz_SingleRateService singleRateService = new Biz_SingleRateService();
                Biz_SingleRate singleRate = new Biz_SingleRate();

                if (Page.IsValid)
                {
                    singleRate = singleRateService.ReadSingleRateById(Convert.ToInt16(ViewState["selectSingleRate"]));
                    if (hiddenFieldstatus.Value == "A")
                    {
                        singleRate.Status = "I";
                    }
                    else
                    {
                        singleRate.Status = "A";
                    }

                    singleRate.DateModified = DateTime.Now;

                    singleRateService.UpdateSingleRate(singleRate);

                    if (hiddenFieldstatus.Value == "A")
                    {
                       FlashText1.Display("Record Successfully Inactivated.", "okmessage");
                    }
                    else
                    {
                       FlashText1.Display("Record Successfully Activated.", "okmessage");
                    }
                }
            }
            catch (Exception exception)
            {
               FlashText1.Display("Record Modifing Failed.", "errormessage");
            }
        }


        #endregion

        #region "Events"

        public void buttonSave_Click(object sender, EventArgs e)
        {
            if (CheckAddValue())
            {
                AddSingleRate();
                DataBindTogridViewSingleRate();
                ClearData();
            }
        }

        public void buttonActInct_Click(object sender, EventArgs e)
        {
            if (CheckModifyValue())
            {
                ActiveOrInactiveSingleRate();
                DataBindTogridViewSingleRate();
                ClearData();
            }
        }

        public void buttonCancel_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        public void dropDownListCommission_SelectedIndexChanged(object sender, EventArgs e)
        {
            CleargridViewSingleRate();
            DataBindTogridViewSingleRate();
        }

        public void gridViewSingleRate_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        public void gridViewSingleRate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataBindTogridViewSingleRate();
            gridViewSingleRate.PageIndex = e.NewPageIndex;
            gridViewSingleRate.DataBind();
        }

        public void gridViewSingleRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewSingleRate.SelectedRow;
            ViewState["selectSingleRate"] = row.Cells[1].Text.Trim();
            Biz_SingleRate singleRate = new Biz_SingleRate();
            singleRate = new Biz_SingleRateService().ReadSingleRateById(Convert.ToInt16(ViewState["selectSingleRate"]));
            //hiddenFieldSingleRate.Value = singleRate.RateMode.Trim();
            if (singleRate != null && singleRate.Status != "")
            {
                hiddenFieldstatus.Value = singleRate.Status.Trim();
                textBoxRate.Text = singleRate.Rate.ToString();
            }

            //if (hiddenFieldSingleRate.Value == "T")
            //{
            //    radioButtonListRateMode.SelectedIndex = 0;
            //}
            //else
            //{
            //    radioButtonListRateMode.SelectedIndex = 1;
            //}

        }

        //public void radioButtonListRateMode_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (radioButtonListRateMode.SelectedIndex == 0)
        //    {
        //        hiddenFieldSingleRate.Value = "T";
        //    }
        //    else
        //    {
        //        hiddenFieldSingleRate.Value = "S";
        //    }
        //}


        #endregion

        #region "Validations"

        private Boolean CheckAddValue()
        {
            if (textBoxRate.Text.Trim() == string.Empty)
            {
               FlashText1.Display("Rate Cannot be Blank.", "errormessage");
                return false;
            }

            if (textBoxRate.Text.Trim() != string.Empty)
            {
                List<Biz_SingleRate> singleRates = new List<Biz_SingleRate>();
                List<Biz_SingleRate> singleRate = new  List<Biz_SingleRate>();
                singleRates = new Biz_SingleRateService().ReadAllSingleRates();
                singleRate =
                    (from rate in singleRates
                     where
                         rate.IdCommssion == Convert.ToInt16(dropDownListCommission.SelectedValue) &&
                          rate.Status.Trim() == "A"
                     select rate).ToList();

                if (singleRate.Count > 0)
                {
                   FlashText1.Display("A Active Rate is Already Exists with this Commission .",
                                          "errormessage");
                    return false;
                }
            }

            return true;
        }

        private Boolean CheckModifyValue()
        {
            if (ViewState["selectSingleRate"] == null)
            {
               FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }

            if (hiddenFieldstatus.Value.Trim() == "I")
            {
                List<Biz_SingleRate> singleRates = new List<Biz_SingleRate>();
                List<Biz_SingleRate> singleRate = new  List<Biz_SingleRate>();
                singleRates = new Biz_SingleRateService().ReadAllSingleRates();
                singleRate =
                    (from rate in singleRates
                     where rate.IdCommssion == Convert.ToInt16(dropDownListCommission.SelectedValue.Trim()) && rate.Status.Trim() == "A"
                     select rate).ToList();

                if (singleRate.Count > 0)
                {
                   FlashText1.Display("A Active Rate is Already Exists with this Commission.", "errormessage");
                    return false;
                }
            }
            return true;
        }

        #endregion

    }
}