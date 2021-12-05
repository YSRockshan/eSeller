using BzFlexer.SAMS.WebView.Home;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Service.Reference;
using BzFlexer.SAMS.Service.Security;
using BzFlexer.SAMS.WebView.BoostUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebSite.Home
{
    public partial class MyAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                textBoxFullName.Attributes.Add("onkeyup", "javascript:return onChangeFullName(event)");
                textBoxFullName.Attributes.Add("onKeyPress", "javascript:return validateCodeForSymbols(event)");
                textBoxLastName.Attributes.Add("onKeyPress", "javascript:return validateCodeForSymbols(event)");
                textBoxInitials.Attributes.Add("onKeyPress", "javascript:return validateCodeForSymbols(event)");
                textBoxInitials.Attributes.Add("onKeyPress", "javascript:this.value=toUpperCase(this.value);");
                DataBindtoBranch();
                DataBindtoStakeholderType();
                GetUserProfileDetail();
                DisableInputFields();
            }
        }
#region Databind
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

        public void GetUserProfileDetail()
        {
            if (Session[BzFlexer.SAMS.WebView.Home.Global.BizLoginUserStakeholderId] != null)
            {
                Biz_Stakeholder stakeholder = new Biz_Stakeholder();

                stakeholder.Id = Convert.ToInt16(Session[BzFlexer.SAMS.WebView.Home.Global.BizLoginUserStakeholderId]);
                stakeholder = new Biz_EmployeeDetailService().ReadEmployeeDetailById(stakeholder.Id);

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
                    textBoxDateOfBirth.Text = stakeholder.DOB.ToString();
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
        }

#endregion

        #region "Display Handling"

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
            DisableInputFields();
        }

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
            textBoxOfficeTelephone.Enabled = true;
            dropDownListBranch.Enabled = true;
            dropDownListStakeholderType.Enabled = true;
            dropDownListEmployeeStatus.Enabled = false;
        }

        #endregion


        #region "Operations"

        public void ModifyEmployeeDetail()
        {
            try
            {
                Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
                Biz_Stakeholder stakeholder = new Biz_Stakeholder();

                stakeholder.Id = Convert.ToInt16(Session[BzFlexer.SAMS.WebView.Home.Global.BizLoginUserStakeholderId]);
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
                FlashText1.Display("Record Successfully Modified.", "okmessage");
            }
            catch (Exception exception)
            {
                FlashText1.Display("Record Modifing Failed.", "okmessage");
            }
        }

        public void AddNewPasswordHistory()
        {
            try
            {
                if (Page.IsValid)
                {
                    // Update Existing Password Hostory Record
                    Biz_PasswordHistory passwordHistory = new Biz_PasswordHistory();
                    Biz_PasswordHistoryService passwordHistoryService = new Biz_PasswordHistoryService();
                    passwordHistory = passwordHistoryService.ReadValidPassword(Convert.ToInt16(Session[BzFlexer.SAMS.WebView.Home.Global.BizLoginUserStakeholderId]), textBoxEmail.Text.Trim(), textBoxOldPassword.Text.Trim());

                    passwordHistory.Status = "I";
                    passwordHistory.ExpiryDate = DateTime.Now;
                    passwordHistory.sys_DateLastModification = DateTime.Now;
                    passwordHistoryService.UpdatePasswordHistory(passwordHistory);

                    // Create New Password History Record
                    Biz_PasswordHistory newPasswordHistory = new Biz_PasswordHistory();

                    newPasswordHistory.IdStakeholder = Convert.ToInt16(Session[BzFlexer.SAMS.WebView.Home.Global.BizLoginUserStakeholderId]);
                    newPasswordHistory.Old_Password = BzFlexer.SAMS.WebView.Home.Global.Encrypt(textBoxOldPassword.Text.Trim());
                    newPasswordHistory.New_Password = BzFlexer.SAMS.WebView.Home.Global.Encrypt(textBoxNewPassword.Text.Trim());
                    newPasswordHistory.Status = "A";
                    newPasswordHistory.EffectiveDate = DateTime.Now;
                    newPasswordHistory.User_Name = textBoxEmail.Text.Trim();
                    newPasswordHistory.sys_DateCreation = DateTime.Now;
                    newPasswordHistory.sys_DateLastModification = DateTime.Now;

                    passwordHistoryService.CreatePasswordHistory(newPasswordHistory);
                    FlashText1.Display("Password Updated Successfully.", "okmessage");
                }
            }
            catch (Exception exception)
            {
                FlashText1.Display("Password Updating Failed.", "okmessage");
            }
        }


        #endregion

        #region "Events"


        public void buttonCancel_Click(object sender, EventArgs e)
        {
            ClearData();
            GetUserProfileDetail();
        }

        public void buttonSave_Click(object sender, EventArgs e)
        {
            ModifyEmployeeDetail();
            ClearData();
            GetUserProfileDetail();
        }

        public void buttonModify_Click(object sender, EventArgs e)
        {
            if (CheckValidUser())
            {
                EnableInputFields();
                dropDownListBranch.Enabled = false;
                dropDownListStakeholderType.Enabled = false;
                textBoxEmail.Enabled = false;
                dropDownListEmployeeStatus.Enabled = false;
            }
        }

        public void buttonSave2_Click(object sender, EventArgs e)
        {
            if (CheckValidPassword())
            {
                AddNewPasswordHistory();
            }
        }

        public void buttonCancel2_Click(object sender, EventArgs e)
        {
            textBoxOldPassword.Text = "";
            textBoxNewPassword.Text = "";
            textBoxNewPassword2.Text = "";
        }

        #endregion

        #region "Validations"

        private Boolean CheckValidUser()
        {
            if (Session[BzFlexer.SAMS.WebView.Home.Global.BizLoginUserStakeholderId] == null)
            {
                FlashText1.Display("User Unavailable to Modify.", "errormessage");
                return false;
            }
            else
            {
                Biz_Stakeholder stakeholder = new Biz_Stakeholder();
                stakeholder = new Biz_EmployeeDetailService().ReadEmployeeDetailById(Convert.ToInt16(Session[BzFlexer.SAMS.WebView.Home.Global.BizLoginUserStakeholderId]));
                if (stakeholder.Status.Trim() == "I")
                {

                    FlashText1.Display("Inactive User. Cannot Modify.", "errormessage");
                    return false;
                }
            }
            return true;
        }

        private Boolean CheckValidPassword()
        {
            if (textBoxOldPassword.Text != string.Empty)
            {
                Biz_PasswordHistory passwordHistory = new Biz_PasswordHistory();
                passwordHistory = new Biz_PasswordHistoryService().ReadValidPassword(Convert.ToInt16(Session[BzFlexer.SAMS.WebView.Home.Global.BizLoginUserStakeholderId]), textBoxEmail.Text.Trim(), textBoxOldPassword.Text.Trim());
                if (passwordHistory == null)
                {
                    FlashText1.Display("Incorrect Old Password.", "errormessage");
                    return false;
                }
            }
            else
            {
                FlashText1.Display("Please Enter Old Password.", "errormessage");
                return false;
            }
            if (textBoxNewPassword.Text == string.Empty)
            {
                FlashText1.Display("Please Enter New Password.", "errormessage");
                return false;
            }
            else
            {
                if (!Regex.IsMatch(textBoxNewPassword.Text.Trim(), @"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?!.*s).*$"))
                {
                    FlashText1.Display("This is not a strong password.", "errormessage");
                    return false;
                }
            }
            if (textBoxNewPassword2.Text == string.Empty)
            {
                FlashText1.Display("Please Enter New Password.", "errormessage");
                return false;
            }
            if (textBoxNewPassword.Text.Trim() != textBoxNewPassword2.Text.Trim())
            {
                FlashText1.Display("New Passwords not match.", "errormessage");
                return false;
            }
            return true;
        }

        #endregion
    }
}