using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using BzFlexer.SAMS.Biz.Reference;

namespace BzFlexer.SAMS.Biz.Reference
{
    [Serializable]
    public class Biz_StakeholderBranch
    {
        #region "BizStakeholderBranch Properties"
        public long Id { get; set; }
        public long IdStakeholder { get; set; }
        public long IdBranch { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
        #region"Reference Properties"#region 
        public Biz_Stakeholder Biz_Stakeholders
        {
            get;
            set;
        }

        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        #endregion

    }
}
