using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_BranchSalesAgent
    {
        #region  "Biz_BranchSelesAgent Properties"
        public long Id { get; set; }
        public long IdSalesAgent { get; set; }
        public DateTime? DateEffect { get; set; }
        public DateTime? DateExpired { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long IdBranch { get; set; }
        public long IdStakeholderTypeStakeholder { get; set; }
        public long IdStakeholder { get; set; }
        #endregion
        #region  "Reference Properties"

        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        public Biz_StakeholderTypeStakeholder Biz_StakeholderTypeStakeholders
        {
            get;
            set;
        }

        public Biz_Stakeholder Biz_Stakeholders
        {
            get;
            set;
        }

        public Biz_SalesAgent Biz_SalesAgents
        {
            get;
            set;
        }

        public EntityCollection<Biz_MemberSalesAgentPosition> Biz_MemberSalesAgentPositions
        {
            get;
            set;
        }

        public EntityCollection<Biz_MemberSalesTarget> Biz_MemberSalesTargets
        {
            get;
            set;
        }

        #endregion
    }
    }
