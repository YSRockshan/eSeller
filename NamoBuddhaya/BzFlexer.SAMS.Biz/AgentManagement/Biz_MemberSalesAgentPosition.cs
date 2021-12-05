using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{/// Member Sales Agent Position
	[Serializable]
    public class Biz_MemberSalesAgentPosition
    {
        #region  "Biz_MemberSalesAgentPosition Properties"
        public long Id { get; set; }
        public long  IdSalesAgent { get; set; }
        public long IdSalesAgentPosition { get; set; }
        public Nullable<bool> Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long IdBranch { get; set; }
        #endregion
        #region  "Reference Properties" 

      

        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        public Biz_BranchSalesAgent Biz_BranchSalesAgents
        {
            get;
            set;
        }

        public Biz_SalesAgentPosition Biz_SalesAgentPositions
        {
            get;
            set;
        }

        #endregion
    }
}
