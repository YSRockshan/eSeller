using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_SalesAgent
    {
        #region "Biz_SalesAgent Properties"
        public long Id { get; set; }
        public long IdStakeholder { get; set; }
        public string Marital_Status { get; set; }
        public string EPF_No { get; set; }
        public string ETF_No { get; set; }
        public long IdCurrentBranch { get; set; }
        public long IdRelatedBranch { get; set; }
        public long IdCurrentPosition { get; set; }
        public long IdCurrentDesignation { get; set; }
        public long IdReportingEmployee { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateConfirmed { get; set; }
        public DateTime DateResigned { get; set; }
        public long IdStatus { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
      #region  "Reference Properties" 

        public EntityCollection<Biz_BranchSalesAgent> Biz_BranchSalesAgents
        {
            get;
            set;
        }



        #endregion
    }
}
