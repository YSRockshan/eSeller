using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Service.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BzFlexer.SAMS.WebView.Home
{
    public partial class BizFlexer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session[Global.BizLoginUserStakeholderId] == null)
            {
                Response.Redirect("~/eCommerce/index.aspx");
            }
            if (!IsPostBack)
            {
                DataBindTodropDownListBranch();
                if (Session[Global.BizLoginUserStakeholderId] == "0")
                {
                    linkProfile.Text = "Demo User";
                    Session[Global.BizLoginUserStakeholderName] = "Demo User";
                    Session[Global.BizCurrentBranchId] = 12;
                    linkProfile.Enabled = false;
                }
                else
                {
                    Biz_EmployeeDetailService employeeDetailService = new Biz_EmployeeDetailService();
                    Biz_Stakeholder _stakeholder =
                        employeeDetailService.ReadEmployeeDetailById(
                            Convert.ToInt64(Session[Global.BizLoginUserStakeholderId]));

                    linkProfile.Text = _stakeholder.Initial + " " + _stakeholder.LastName;
                    Session[Global.BizLoginUserStakeholderName] = _stakeholder.Initial.Trim() + " " + _stakeholder.LastName.Trim();
                    Session[Global.BizCurrentBranchId] = dropDownListBranch.SelectedValue;
                    Session[Global.BizLoginBranchCode] = new Biz_BranchService().ReadBranchById(Convert.ToInt16(dropDownListBranch.SelectedValue)).Code;
                    Session[Global.BizLoginBranchName] = new Biz_BranchService().ReadBranchById(Convert.ToInt16(dropDownListBranch.SelectedValue)).Description;

                    SetBranchSessions();

                    if (linkProfile.Text == "Demo User")
                    {
                        linkProfile.Enabled = false;
                    }
                }
            }
            //else
            //{
            //    SetBranchSessions();
            //}
        }

        public void DataBindTodropDownListBranch()
        {
            Biz_StakeholderBranchService _stakeholderBranchService = new Biz_StakeholderBranchService();
            List<Biz_StakeholderBranch> _stakeholderBranches= new List<Biz_StakeholderBranch>();
            List<Biz_Branch> accessibleBranches = new List<Biz_Branch>();

            _stakeholderBranches = _stakeholderBranchService.ReadAllStakeholderBranchs();
            _stakeholderBranches = (from stakeholderBranch in _stakeholderBranches
                                   where
                                       stakeholderBranch.IdStakeholder ==
                                       Convert.ToInt16(Session[Global.BizLoginUserStakeholderId])
                                   select stakeholderBranch).ToList();
            List<long> stkBranchId = (from id in _stakeholderBranches select id.IdBranch).ToList();

            accessibleBranches =
                (from branchs in new Biz_BranchService().ReadAllBranch()
                 where stkBranchId.Contains(branchs.Id)
                 select branchs).ToList();

            dropDownListBranch.DataSource = accessibleBranches;
            dropDownListBranch.DataTextField = "Code";
            dropDownListBranch.DataValueField = "Id";
            dropDownListBranch.DataBind();

            if (Session[Global.BizCurrentBranchId] != null)
            {
                dropDownListBranch.SelectedValue = Convert.ToInt16(Session[Global.BizCurrentBranchId]).ToString();
            }
        }

        private void SetBranchSessions()
        {
            if (dropDownListBranch.Items.Count > 0 && Session[Global.BizCurrentBranchId] != null)
            {
                dropDownListBranch.SelectedValue = Session[Global.BizCurrentBranchId].ToString();
            }
            //if (dropDownListBranch.SelectedIndex > 0 && dropDownListBranch.SelectedValue != string.Empty)
            //{
            //    BranchService branchService =new BranchService();
            //    Branch branch = branchService.GetBranchById(Convert.ToInt16(dropDownListBranch.SelectedValue));

            //    Session[Global.BizCurrentBranchId] = branch.BranchId;
            //}
        }


        protected void linkLogOut_Click(object sender, EventArgs e)
        {
            //Session.Remove(Global.BizLoginUserStakeholderId);
            //UserService userService = new UserService();
            //userService.ExpireLogin(Convert.ToInt64(Session[Global.BizLoginId]));
            Session.Clear();
           Response.Redirect("~/eCommerce/index.aspx");
        }

        [WebMethod]
        public static void AbandonSession()
        {
            // TODO: Write the code for the database to log the session end
            HttpContext.Current.Session.Abandon();
        }

        public void dropDownListBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session[Global.BizCurrentBranchId] = dropDownListBranch.SelectedValue;
            SetBranchSessions();
        }

        protected void loginButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/eCommerce/index.aspx");
        }
    }
}