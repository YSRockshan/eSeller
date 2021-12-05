using System;
using BzFlexer.SAMS.WebView.Home;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Service.Security;

namespace BzFlexer.SAMS.WebView.eCommerce
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            Session[Global.BizDatabaseName] = String.Empty;

            if (TextBoxEmail.Text == String.Empty)
            {
                LabelNotification.Text = "Invalid [Email]";
            }
            else if (TextBoxPassword.Text == String.Empty)
            {
                LabelNotification.Text = "Invalid [Password]";
            }
            else
            {
                Biz_PasswordHistory _passwordhistoryList = new Biz_PasswordHistory();
                _passwordhistoryList = new Biz_PasswordHistoryService().ReadPasswordHistoryByLoginIdAndPassword(TextBoxEmail.Text.Trim(), TextBoxPassword.Text.Trim());

                if (_passwordhistoryList == null)
                {
                    LabelNotification.Text = "Invalid [Email] or [Password] <br /> Please try again";
                    Session[Global.BizDatabaseName] = String.Empty;
                }
                else
                {
                    if (_passwordhistoryList.Biz_Stakeholders.Status.Trim() != "A")
                    {
                        LabelNotification.Text = "Inactive User. <br /> Please Contact Administrator.";
                        Session[Global.BizDatabaseName] = String.Empty;
                    }
                    else
                    {
                        //UserLogService userLogService = new UserLogService();
                        //UserLog userLog = new UserLog();

                        //userLog.UserStakeholderId = passwordhistoryList.Stakeholder.StakeholderId;
                        //userLog.TerminalUserName = System.Environment.UserName;
                        //userLog.TerminalIp = System.Environment.MachineName;
                        //userLog.LoginDate = DateTime.Today;
                        //userLog.LoginTime = DateTime.Now;

                        Session[Global.BizLogUserEmail] = TextBoxEmail.Text.ToString();
                        Session[Global.BizLoginUserStakeholderId] = _passwordhistoryList.Biz_Stakeholders.Id.ToString();
                        Session[Global.BizLogUserPassWord] = TextBoxPassword.Text.ToString();


                        Response.Redirect("~/Home/BizFlexerHome.aspx");
                    }
                }
            }
        }
    }
}