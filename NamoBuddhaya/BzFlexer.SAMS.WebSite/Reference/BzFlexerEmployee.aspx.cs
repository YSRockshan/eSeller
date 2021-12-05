using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.Service.Security;
using BzFlexer.SAMS.WebView.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.Reference
{
    public partial class BzFlexerEmployee : System.Web.UI.Page
    {
        #region "Variables"

        private long SelectStakeholderId;
        public long SaveFlag;
        private string ActiveInactiveFlag;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                textBoxFullName.Attributes.Add("onkeyup", "javascript:return onChangeFullName(event)");
                textBoxFullName.Attributes.Add("onKeyPress", "javascript:return validateCodeForSymbols(event)");
                textBoxLastName.Attributes.Add("onKeyPress", "javascript:return validateCodeForSymbols(event)");
                textBoxInitials.Attributes.Add("onKeyPress", "javascript:return validateCodeForSymbols(event)");
                textBoxInitials.Attributes.Add("onKeyPress", "javascript:this.value=toUpperCase(this.value);");
                LoadEmployeeDetail();
                DataBindtoBranch();
                DataBindtoStakeholderType();
                DisableInputFields();
            }
        }

        #region "Load Data"
        /// <summary>
        /// Get Employee Detail
        /// </summary>
        public void LoadEmployeeDetail()
        {
            try
            {
                Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
                gridViewEmployeeDetail.DataSource = employeeDetailService.ReadAllEmplyeeDetail();
                gridViewEmployeeDetail.DataBind();
            }
            catch (Exception exception)
            {

            }
        }
        /// <summary>
        /// Get Data and bind to Branch
        /// </summary>
        public void DataBindtoBranch()
        {
            try
            {
                Biz_BranchService branchService = new Biz_BranchService();
                dropDownListBranch.DataSource = branchService.ReadAllBranch();
                dropDownListBranch.DataValueField = "Id";
                dropDownListBranch.DataTextField = "Description";
                dropDownListBranch.DataBind();
                dropDownListBranch.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }
        /// <summary>
        /// Get Data and Bind to Stakeholder Type
        /// </summary>
        public void DataBindtoStakeholderType()
        {
            try
            {
                Biz_StakeholderTypeService stakeholderTypeService = new Biz_StakeholderTypeService();
                dropDownListStakeholderType.DataSource = stakeholderTypeService.ReadAllStakeholderType();
                dropDownListStakeholderType.DataValueField = "Id";
                dropDownListStakeholderType.DataTextField = "Description";
                dropDownListStakeholderType.DataBind();
                dropDownListStakeholderType.SelectedIndex = 0;
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region "Operations"

        /// <summary>
        /// Employee Detail Save
        /// </summary>
        public void SaveEmployeeDetail()
        {
            try
            {
                Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
                Biz_Stakeholder stakeholder = new Biz_Stakeholder();

                if (Page.IsValid)
                {
                    // Save Stakeholder Details
                    stakeholder.Title = dropDownListTitle.SelectedValue.ToString();
                    stakeholder.FullName = textBoxFullName.Text.Trim();
                    stakeholder.LastName = textBoxLastName.Text.Trim();
                    stakeholder.Initial = textBoxInitials.Text.Trim();
                    stakeholder.Contact_Address = textBoxAddress.Text.Trim();
                    stakeholder.Lane = textBoxLane.Text.Trim();
                    stakeholder.Road = textBoxRoad.Text.Trim();
                    stakeholder.Town = textBoxTown.Text.Trim();
                    stakeholder.Gender = radioButtonListGender.SelectedValue.ToString();
                    stakeholder.DOB = Convert.ToDateTime(textBoxDateOfBirth.Text.Trim());
                    stakeholder.NIC = textBoxNicNo.Text.Trim();
                    stakeholder.Passport = textBoxPassportNo.Text.Trim();
                    stakeholder.Maritual_Status = dropDownListMaritualStatus.SelectedValue.ToString();
                    stakeholder.Designation = textBoxDesignation.Text.Trim();
                    stakeholder.EPF_No = textBoxEpfNo.Text.Trim();
                    stakeholder.ETF_No = textBoxEtfNo.Text.Trim();
                    stakeholder.Telephone = textBoxHomeTelepnone.Text.Trim();
                    stakeholder.Mobile = textBoxMobile.Text.Trim();
                    stakeholder.Email_Address = textBoxEmail.Text.Trim();
                    stakeholder.Office_No = textBoxOfficeTelephone.Text.Trim();
                    stakeholder.IdCurrentBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                    stakeholder.IdStakeholderType = Convert.ToInt16(dropDownListStakeholderType.SelectedValue);
                    stakeholder.Status = dropDownListEmployeeStatus.SelectedValue;
                    stakeholder.DateCreated = DateTime.Now;
                    stakeholder.DateModified = DateTime.Now;

                    employeeDetailService.CreateEmployeeDetail(stakeholder);

                    // Save Default StakeholderType Stakeholder Details

                    Biz_StakeholderTypeStakeholderService stakeholderTypeStakeholderService = new Biz_StakeholderTypeStakeholderService();
                    Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder = new Biz_StakeholderTypeStakeholder();

                    stakeholderTypeStakeholder.IdStakeholder = stakeholder.Id;
                    stakeholderTypeStakeholder.IdStakeholderType = Convert.ToInt16(dropDownListStakeholderType.SelectedValue);
                    stakeholderTypeStakeholder.Status = dropDownListEmployeeStatus.SelectedValue;
                    stakeholderTypeStakeholder.DateCreated = DateTime.Now;
                    stakeholderTypeStakeholder.DateModified = DateTime.Now;
                    stakeholderTypeStakeholder.DateEffect = DateTime.Now;

                    stakeholderTypeStakeholderService.CreateStakeholderTypeStakeholder(stakeholderTypeStakeholder);

                    // Save First Password History

                    Biz_PasswordHistoryService passwordHistoryService = new Biz_PasswordHistoryService();
                    Biz_PasswordHistory passwordHistory = new Biz_PasswordHistory();

                    passwordHistory.IdStakeholder = stakeholder.Id;
                    passwordHistory.Status = dropDownListEmployeeStatus.SelectedValue;
                    passwordHistory.User_Name = textBoxEmail.Text.Trim();
                    passwordHistory.New_Password = Global.Encrypt("abc123");
                    passwordHistory.sys_DateCreation = DateTime.Now;
                    passwordHistory.sys_DateLastModification = DateTime.Now;
                    passwordHistory.EffectiveDate = DateTime.Now;

                    passwordHistoryService.CreatePasswordHistory(passwordHistory);

                    // Save First Stakeholder Branch

                   Biz_StakeholderBranchService stakeholderBranchService = new Biz_StakeholderBranchService();
                    Biz_StakeholderBranch stakeholderBranch = new Biz_StakeholderBranch();

                    stakeholderBranch.IdStakeholder = stakeholder.Id;
                    stakeholderBranch.IdBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                    stakeholderBranch.DateCreated = DateTime.Now;
                    stakeholderBranch.DateModified = DateTime.Now;

                    stakeholderBranchService.AddStakeholderBranch(stakeholderBranch);
                }
                ClearData();
                FlashText1.Display("Record Successfully Saved.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Saving Failed.", "okmessage");
            }
        }

        /// <summary>
        /// Modify Employee Detail
        /// </summary>
        public void ModifyEmployeeDetail()
        {
            try
            {
                Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
                Biz_Stakeholder stakeholder = new Biz_Stakeholder();

                stakeholder.Id = Convert.ToInt16(ViewState["SelectStakeholderId"]);
                stakeholder = employeeDetailService.ReadEmployeeDetailById(stakeholder.Id);

                if (Page.IsValid)
                {
                    // Modify Stakeholder Details
                    stakeholder.Title = dropDownListTitle.SelectedValue.ToString();
                    stakeholder.FullName = textBoxFullName.Text.Trim();
                    stakeholder.LastName = textBoxLastName.Text.Trim();
                    stakeholder.Initial = textBoxInitials.Text.Trim();
                    stakeholder.Contact_Address = textBoxAddress.Text.Trim();
                    stakeholder.Lane = textBoxLane.Text.Trim();
                    stakeholder.Road = textBoxRoad.Text.Trim();
                    stakeholder.Town = textBoxTown.Text.Trim();
                    stakeholder.Gender = radioButtonListGender.SelectedValue.ToString();
                    stakeholder.DOB = Convert.ToDateTime(textBoxDateOfBirth.Text.Trim());
                    stakeholder.NIC = textBoxNicNo.Text.Trim();
                    stakeholder.Passport = textBoxPassportNo.Text.Trim();
                    stakeholder.Maritual_Status = dropDownListMaritualStatus.SelectedValue.ToString();
                    stakeholder.Designation = textBoxDesignation.Text.Trim();
                    stakeholder.EPF_No = textBoxEpfNo.Text.Trim();
                    stakeholder.ETF_No = textBoxEtfNo.Text.Trim();
                    stakeholder.Telephone = textBoxHomeTelepnone.Text.Trim();
                    stakeholder.Mobile = textBoxMobile.Text.Trim();
                    stakeholder.Email_Address = textBoxEmail.Text.Trim();
                    stakeholder.Office_No = textBoxOfficeTelephone.Text.Trim();
                    stakeholder.IdCurrentBranch = Convert.ToInt16(dropDownListBranch.SelectedValue);
                    stakeholder.IdStakeholderType = Convert.ToInt16(dropDownListStakeholderType.SelectedValue);
                    stakeholder.Status = dropDownListEmployeeStatus.SelectedValue;
                    stakeholder.DateModified = DateTime.Now;

                    employeeDetailService.UpdateEmployeeDetail(stakeholder);
                }
                ClearData();
                FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "okmessage");
            }
        }

        /// <summary>
        /// Delete Employee Detail
        /// </summary>
        public void DeleteEmployeeDetail()
        {
            try
            {
                if (Page.IsValid)
                {
                    Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();

                    employeeDetailService.DeleteEmployeeDetail(Convert.ToInt16(ViewState["SelectStakeholderId"]));
                }
                FlashText1.Display("Record Successfully Deleted.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Deleting Failed.", "errormessage");
            }
        }

        /// <summary>
        /// Active/ Inactive Employee
        /// </summary>
        public void ActiveInactiveEmployeeDetail()
        {
            try
            {
                Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
                Biz_Stakeholder stakeholder = new Biz_Stakeholder();

                if (Page.IsValid)
                {
                    stakeholder.Id = Convert.ToInt16(ViewState["SelectStakeholderId"]);
                    stakeholder = employeeDetailService.ReadEmployeeDetailById(stakeholder.Id);
                    if (stakeholder.Status.Trim() == "A")
                    {
                        stakeholder.Status = "I";
                        ActiveInactiveFlag = "I";
                    }
                    else if (stakeholder.Status.Trim() == "I")
                    {
                        stakeholder.Status = "A";
                        ActiveInactiveFlag = "A";
                    }
                    employeeDetailService.UpdateEmployeeDetail(stakeholder);
                }
                if (ActiveInactiveFlag == "I")
                {
                    FlashText1.Display("Stakeholder Successfully Inactivated.", "okmessage");
                }
                else
                {
                    FlashText1.Display("Stakeholder Successfully Activated.", "okmessage");
                }
            }
            catch (Exception exception)
            {
                FlashText1.Display("Stakeholder Status updating Failed.", "okmessage");
            }
        }

        #endregion

        #region "Display Handling"

        /// <summary>
        /// Clear Data on textboxes
        /// </summary>
        public void ClearData()
        {
            dropDownListTitle.SelectedIndex = -1;
            textBoxFullName.Text = "";
            textBoxLastName.Text = "";
            textBoxInitials.Text = "";
            textBoxAddress.Text = "";
            textBoxLane.Text = "";
            textBoxRoad.Text = "";
            textBoxTown.Text = "";
            radioButtonListGender.SelectedIndex = 0;
            textBoxDateOfBirth.Text = "";
            textBoxNicNo.Text = "";
            textBoxPassportNo.Text = "";
            dropDownListMaritualStatus.SelectedIndex = -1;
            textBoxDesignation.Text = "";
            textBoxEpfNo.Text = "";
            textBoxEtfNo.Text = "";
            textBoxHomeTelepnone.Text = "";
            textBoxMobile.Text = "";
            textBoxEmail.Text = "";
            textBoxOfficeTelephone.Text = "";
            dropDownListBranch.SelectedIndex = -1;
            dropDownListStakeholderType.SelectedIndex = -1;
            dropDownListEmployeeStatus.SelectedIndex = -1;
            gridViewEmployeeDetail.SelectedIndex = -1;
            DisableInputFields();
        }
        /// <summary>
        /// Disable Data Input textboxes,dropdownlists 
        /// </summary>
        private void DisableInputFields()
        {
            dropDownListTitle.Enabled = false;
            textBoxFullName.Enabled = false;
            textBoxLastName.Enabled = false;
            textBoxInitials.Enabled = false;
            textBoxAddress.Enabled = false;
            textBoxLane.Enabled = false;
            textBoxRoad.Enabled = false;
            textBoxTown.Enabled = false;
            radioButtonListGender.Enabled = false;
            textBoxDateOfBirth.Enabled = false;
            textBoxNicNo.Enabled = false;
            textBoxPassportNo.Enabled = false;
            dropDownListMaritualStatus.Enabled = false;
            textBoxDesignation.Enabled = false;
            textBoxEpfNo.Enabled = false;
            textBoxEtfNo.Enabled = false;
            textBoxHomeTelepnone.Enabled = false;
            textBoxMobile.Enabled = false;
            textBoxEmail.Enabled = false;
            textBoxOfficeTelephone.Enabled = false;
            dropDownListBranch.Enabled = false;
            dropDownListStakeholderType.Enabled = false;
            dropDownListEmployeeStatus.Enabled = false;
        }
        /// <summary>
        /// Enable Data Input textboxes,dropdownlists 
        /// </summary>
        private void EnableInputFields()
        {
            dropDownListTitle.Enabled = true;
            textBoxFullName.Enabled = true;
            textBoxLastName.Enabled = true;
            textBoxInitials.Enabled = true;
            textBoxAddress.Enabled = true;
            textBoxLane.Enabled = true;
            textBoxRoad.Enabled = true;
            textBoxTown.Enabled = true;
            radioButtonListGender.Enabled = true;
            textBoxDateOfBirth.Enabled = true;
            textBoxNicNo.Enabled = true;
            textBoxPassportNo.Enabled = true;
            dropDownListMaritualStatus.Enabled = true;
            textBoxDesignation.Enabled = true;
            textBoxEpfNo.Enabled = true;
            textBoxEtfNo.Enabled = true;
            textBoxHomeTelepnone.Enabled = true;
            textBoxMobile.Enabled = true;
            textBoxEmail.Enabled = true;
            textBoxOfficeTelephone.Enabled = true;
            dropDownListBranch.Enabled = true;
            dropDownListStakeholderType.Enabled = true;
            dropDownListEmployeeStatus.Enabled = false;
            gridViewEmployeeDetail.Enabled = true;
        }

        #endregion

        #region "Events"

        /// <summary>
        /// Add Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonAdd_Click(object sender, EventArgs e)
        {
            ClearData();
            EnableInputFields();
            dropDownListEmployeeStatus.SelectedValue = "A";
            ViewState["SaveFlag"] = 1;
        }

        /// <summary>
        /// Modify Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (RecordSelected())
            {
                EnableInputFields();
                gridViewEmployeeDetail.Enabled = false;
                dropDownListBranch.Enabled = false;
                dropDownListStakeholderType.Enabled = false;
                ViewState["SaveFlag"] = 2;
            }
        }

        /// <summary>
        /// Delete Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonDelete_Click(object sender, EventArgs e)
        {
            if (RecordSelected())
            {
                DeleteEmployeeDetail();
                ClearData();
                LoadEmployeeDetail();
            }
        }

        /// <summary>
        /// Cancel Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            gridViewEmployeeDetail.Enabled = true;
            LoadEmployeeDetail();
        }

        /// <summary>
        /// Save Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonSave_Click(object sender, EventArgs e)
        {

            if (Convert.ToInt16(ViewState["SaveFlag"]) == 1)
            {
                if (CheckMandatoryFieldsAdd())
                {
                    SaveEmployeeDetail();
                }
            }
            else
            {
                ModifyEmployeeDetail();
            }
            gridViewEmployeeDetail.Enabled = true;
            LoadEmployeeDetail();

        }

        /// <summary>
        /// Active/Inactive Button Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void buttonActiveInactive_Click(object sender, EventArgs e)
        {
            if (RecordSelected())
            {
                ActiveInactiveEmployeeDetail();
                ClearData();
                LoadEmployeeDetail();
            }
        }

        /// <summary>
        /// Row Ceating gridview Employee Detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void gridViewEmployeeDetail_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.Cells.Count > 1)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        /// <summary>
        /// Selected Index Changing gridview Employee Detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void gridViewEmployeeDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gridViewEmployeeDetail.SelectedRow;
            ViewState["SelectStakeholderId"] = row.Cells[1].Text.Trim();
            Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
            Biz_Stakeholder stakeholder = new Biz_Stakeholder();

            stakeholder.Id = Convert.ToInt16(ViewState["SelectStakeholderId"]);
            stakeholder = employeeDetailService.ReadEmployeeDetailById(stakeholder.Id);

            if (stakeholder != null)
            {
                dropDownListTitle.Text = stakeholder.Title.Trim();
                textBoxFullName.Text = stakeholder.FullName;
                textBoxLastName.Text = stakeholder.LastName;
                textBoxInitials.Text = stakeholder.Initial;
                textBoxAddress.Text = stakeholder.Contact_Address;
                textBoxLane.Text = stakeholder.Lane;
                textBoxRoad.Text = stakeholder.Road;
                textBoxTown.Text = stakeholder.Town;
                radioButtonListGender.SelectedValue = stakeholder.Gender.Trim();
                textBoxDateOfBirth.Text = stakeholder.DOB.ToShortDateString();
                textBoxNicNo.Text = stakeholder.NIC;
                textBoxPassportNo.Text = stakeholder.Passport;
                dropDownListMaritualStatus.Text = stakeholder.Maritual_Status;
                textBoxDesignation.Text = stakeholder.Designation;
                textBoxEpfNo.Text = stakeholder.EPF_No;
                textBoxEtfNo.Text = stakeholder.ETF_No;
                textBoxHomeTelepnone.Text = stakeholder.Telephone;
                textBoxMobile.Text = stakeholder.Mobile;
                textBoxEmail.Text = stakeholder.Email_Address;
                textBoxOfficeTelephone.Text = stakeholder.Office_No;
                dropDownListBranch.SelectedValue = stakeholder.IdCurrentBranch.ToString();
                dropDownListStakeholderType.SelectedValue = stakeholder.IdStakeholderType.ToString();
                dropDownListEmployeeStatus.Text = stakeholder.Status.Trim();
            }

        }

        /// <summary>
        /// Page Index changing gridview Employee Detail
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void gridViewEmployeeDetail_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridViewEmployeeDetail.PageIndex = e.NewPageIndex;
            gridViewEmployeeDetail.DataBind();
            LoadEmployeeDetail();
        }

        #endregion

        #region "Validations"

        /// <summary>
        /// Check Record is selected
        /// </summary>
        /// <returns></returns>
        private Boolean RecordSelected()
        {
            if (ViewState["SelectStakeholderId"] == null)
            {
                FlashText1.Display("No Record is Selected.", "errormessage");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Check Mandatory Fields Values add
        /// </summary>
        /// <returns></returns>
        private Boolean CheckMandatoryFieldsAdd()
        {
            if (dropDownListTitle.Text == string.Empty)
            {
                FlashText1.Display("Title Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxFullName.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Full Name Cannot be Blank.", "errormessage");
                return false;
            }
            else if (textBoxLastName.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Last Name Cannot be Blank.", "errormessage");
                return false;
            }
            else if (textBoxInitials.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Initials Cannot be Blank.", "errormessage");
                return false;
            }
            else if (textBoxAddress.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Contact Address Cannot be Blank.", "errormessage");
                return false;
            }
            else if (textBoxNicNo.Text.Trim() == string.Empty)
            {
                FlashText1.Display("NIC No Cannot be Blank.", "errormessage");
                return false;
            }
            else if (textBoxNicNo.Text.Trim().Length != 10)
            {
                FlashText1.Display("Length of NIC No. is Invalid.", "errormessage");
                return false;
            }
            else if (textBoxNicNo.Text.Trim().Substring(9, 1) != "V" & textBoxNicNo.Text.Trim().Substring(9, 1) != "X")
            {
                FlashText1.Display("Last Character of NIC No is Invalid.", "errormessage");
                return false;
            }
            else if (textBoxDateOfBirth.Text.Trim() == string.Empty)
            {
                FlashText1.Display("Date of Birth Cannot be Blank.", "errormessage");
                return false;
            }
            else if (DateTime.Parse(textBoxDateOfBirth.Text.Trim()) > DateTime.Today)
            {
                FlashText1.Display("Date of Birth Cannot be Grater than Current Date.", "errormessage");
                return false;
            }
            else if (Int16.Parse(textBoxNicNo.Text.Trim().Substring(0, 2)) != Convert.ToInt16(DateTime.Parse(textBoxDateOfBirth.Text.Trim()).Year.ToString().Substring(2, 2)))
            {
                FlashText1.Display("NIC No is Not Match with the Date of Birth.", "errormessage");
                return false;
            }
            else if (radioButtonListGender.SelectedIndex == 0)
            {
                if (!(Convert.ToInt16(textBoxNicNo.Text.Trim().Substring(2, 3)) > 030 && Convert.ToInt16(textBoxNicNo.Text.Trim().Substring(2, 3)) < 366))
                {
                    FlashText1.Display("Gender is Not Match with the NIC No.", "errormessage");
                    return false;
                }
            }
            else if (radioButtonListGender.SelectedIndex == 1)
            {
                if (!(Convert.ToInt16(textBoxNicNo.Text.Trim().Substring(2, 3)) > 500 && Convert.ToInt16(textBoxNicNo.Text.Trim().Substring(2, 3)) < 866))
                {
                    FlashText1.Display("Gender is Not Match with the NIC No.", "errormessage");
                    return false;
                }
            }
            if (textBoxEmail.Text == string.Empty)
            {
                FlashText1.Display("Email Address be Blank.", "errormessage");
                return false;
            }
            else if (!ValidateEmailAddress(textBoxEmail.Text.Trim()))
            {
                FlashText1.Display("Email Address is Invalid.", "errormessage");
                return false;
            }
            if (dropDownListBranch.Text == string.Empty)
            {
                FlashText1.Display("Branch Cannot be Blank.", "errormessage");
                return false;
            }
            if (dropDownListStakeholderType.Text == string.Empty)
            {
                FlashText1.Display("Stakeholder Type Cannot be Blank.", "errormessage");
                return false;
            }
            if (textBoxNicNo.Text.Trim() != string.Empty)
            {
                Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
                List<Biz_Stakeholder> stakeholderList = new List<Biz_Stakeholder>();
                stakeholderList = employeeDetailService.ReadEmployeeDetailByNicNo(textBoxNicNo.Text.Trim());
                if (stakeholderList.Count > 0)
                {
                    FlashText1.Display("Stakeholder already exists with this NIC No.", "errormessage");
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// E-mail Address Validation
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        private Boolean ValidateEmailAddress(string emailAddress)
        {
            bool isMatch = false;
            try
            {
                string strEmailFormat = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                Regex reEmailFormat = new Regex(strEmailFormat);

                isMatch = reEmailFormat.IsMatch(emailAddress);
            }
            catch (Exception)
            {
                return false;
            }
            return isMatch;
        }

        #endregion
    }
}