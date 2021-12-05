using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_MemberSalesTarget
    {
        #region "Biz_MemberSalesTarget Properties"
        public long Id { get; set; }
        public long IdSalesTarget { get; set; }
        public long IdSalesAgent { get; set; }
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

        public Biz_SalesTarget Biz_SalesTargets
        {
            get;
            set;
        }

        public Biz_BranchSalesAgent Biz_BranchSalesAgents
        {
            get;
            set;
        }

        #endregion
    }
}
