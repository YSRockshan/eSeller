using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.Security
{
    public class Biz_StakeholderSecurityGroup
    {
        #region "Biz_StakeholderSecurityGroup Properties"
        public long Id { get; set; }
        public long IdSecurityGroup { get; set; }
        public long IdStakeholder { get; set; }
        public System.DateTime DateEffect { get; set; }
        public DateTime DateExpired { get; set; }
        public long IdStatus { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public long IdStakeholderType { get; set; }
        #endregion
       #region  "Reference Properties" 

        public Biz_SecurityGroup Biz_SecurityGroups
        {
            get;
            set;
        }

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

        #endregion
    }
}
