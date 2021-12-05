using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Biz.AgentManagement ;

namespace BzFlexer.SAMS.Biz.Reference
{
 
    public class Biz_Stakeholder
    {
        #region "Biz_Stakeholder Properties"
        public long Id { get; set; }
        public long IdStakeholderType { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Initial { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Contact_Address { get; set; }
        public string Lane { get; set; }
        public string Road { get; set; }
        public string Town { get; set; }
        public string Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string NIC { get; set; }
        public string Passport { get; set; }
        public string Maritual_Status { get; set; }
        public string Designation { get; set; }
        public string EPF_No { get; set; }
        public string ETF_No { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Office_No { get; set; }
        public string Email_Address { get; set; }
        public long IdCurrentBranch { get; set; }
        public string Status { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
        #region"Reference Properties"
       
        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        public Biz_StakeholderType Biz_StakeholderTypes
        {
            get;
            set;
        }

        public EntityCollection<Biz_StakeholderSecurityGroup> Biz_StakeholderSecurityGroups
        {
            get;
            set;
        }

        public EntityCollection<Biz_PasswordHistory> Biz_PasswordHistories
        {
            get;
            set;
        }

        public EntityCollection<Biz_StakeholderTypeStakeholder> Biz_StakeholderTypeStakeholders
        {
            get;
            set;
        }

        public EntityCollection<Biz_BranchSalesAgent> Biz_BranchSalesAgents
        {
            get;
            set;
        }

        public EntityCollection<Biz_StakeholderBranch> Biz_StakeholderBranches
        {
            get;
            set;
        }

        public EntityCollection<Biz_MemberCommssionDetail> Biz_MemberCommssionDetails
        {
            get;
            set;
        }

        #endregion
    }
}
