//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using Jayadi.ERM.Domain.Security;
//using Jayadi.ERM.Service.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Jayadi.ERM.Web.View
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void buttonLogin_Click(object sender, EventArgs e)
        //{
        //    Session[Global.KeyDatabaseName] = String.Empty;

        //    if (textBoxEmail.Text == String.Empty)
        //    {
        //        labelErrorMessage.Text = "Please enter [Email]";
        //    }
        //    else if (textBoxPassword.Text == String.Empty)
        //    {
        //        labelErrorMessage.Text = "Please enter [Password]";
        //    }
        //    else
        //    {
        //        PasswordHistory passwordhistoryList = new PasswordHistory();
        //        passwordhistoryList = new PasswordHistoryService().GetPasswordHistoryByLoginIdAndPassword(textBoxEmail.Text.Trim(), textBoxPassword.Text.Trim());

        //        if (passwordhistoryList == null)
        //        {
        //            labelErrorMessage.Text = "Incorrect [Email] or [Password] <br /> Please try again";
        //            Session[Global.KeyDatabaseName] = String.Empty;
        //        }
        //        else
        //        {
        //            if (passwordhistoryList.Stakeholder.Status.Trim() != "A")
        //            {
        //                labelErrorMessage.Text = "Inactive User. <br /> Please Contact Administrator.";
        //                Session[Global.KeyDatabaseName] = String.Empty;
        //            }
        //            else
        //            {
        //                //UserLogService userLogService = new UserLogService();
        //                //UserLog userLog = new UserLog();

        //                //userLog.UserStakeholderId = passwordhistoryList.Stakeholder.StakeholderId;
        //                //userLog.TerminalUserName = System.Environment.UserName;
        //                //userLog.TerminalIp = System.Environment.MachineName;
        //                //userLog.LoginDate = DateTime.Today;
        //                //userLog.LoginTime = DateTime.Now;

        //                Session[Global.KeyLogUserEmail] = textBoxEmail.Text.ToString();
        //                Session[Global.KeyLoginUserStakeholderId] = passwordhistoryList.Stakeholder.StakeholderId.ToString();
        //                Session[Global.KeyLogUserPassWord] = textBoxPassword.Text.ToString();

                       

        //              //  Response.Redirect("~/tree/WebForm2.aspx");
        //               Response.Redirect("MainForm.aspx");
        //            }
        //        }
        //    }
        //}
    }
}