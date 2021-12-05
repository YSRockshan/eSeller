using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Biz.AgentManagement ;

namespace BzFlexer.SAMS.Biz.Reference
{
    [Serializable]
    public class Biz_StakeholderTypeStakeholder
    {
        #region "BizStakeholderTypeStakeholder Properties"
        public long Id { get; set; }
        public long IdStakeholderType { get; set; }
        public long IdStakeholder { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public DateTime DateEffect { get; set; }
        public string Status { get; set; }
        #endregion
        #region"Reference Properties"  
        public Biz_StakeholderType Biz_StakeholderTypes
        {
            get;
            set;
        }

        public Biz_Stakeholder Biz_Stakeholders
        {
            get;
            set;
        }

        public EntityCollection<Biz_BranchSalesAgent> Biz_BranchSalesAgents
        {
            get;
            set;
        }

        #endregion
    }
}
