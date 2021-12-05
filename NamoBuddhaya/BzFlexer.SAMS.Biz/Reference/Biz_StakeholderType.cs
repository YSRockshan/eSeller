using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using BzFlexer.SAMS.Biz.Security;

namespace BzFlexer.SAMS.Biz.Reference
{

    public class Biz_StakeholderType
    {
        #region "Biz_StakeholderType Properties"
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
        #region "Reference Properties"

        public EntityCollection<Biz_Stakeholder> Biz_Stakeholders
        {
            get;
            set;
        }

        public EntityCollection<Biz_StakeholderTypeSecurityGroup> Biz_StakeholderTypeSecurityGroups
        {
            get;
            set;
        }

        public EntityCollection<Biz_StakeholderSecurityGroup> Biz_StakeholderSecurityGroups
        {
            get;
            set;
        }

        public EntityCollection<Biz_StakeholderTypeStakeholder> Biz_StakeholderTypeStakeholders
        {
            get;
            set;
        }

        #endregion
    }
}
