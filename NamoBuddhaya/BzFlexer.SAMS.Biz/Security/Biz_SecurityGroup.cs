using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.Security
{
    public class Biz_SecurityGroup
    {
        #region "Biz_SecurityGroup Properties"
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
       #region  "Reference Properties" 

        public EntityCollection<Biz_SecurityGroupScreen> Biz_SecurityGroupScreens
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

        #endregion
    }
}
