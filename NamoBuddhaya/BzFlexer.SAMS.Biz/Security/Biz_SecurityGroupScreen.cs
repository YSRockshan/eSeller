using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.Security
{
    public class Biz_SecurityGroupScreen
    {
        #region "Biz_SecurityGroupScreen Properies"
        public long Id { get; set; }
        public long IdModule { get; set; }
        public long IdScreen { get; set; }
        public long IdSecurityGroup { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
        #region "Navigation Properies"

        public Biz_Screen Biz_Screens
        {
            get;
            set;
        }

        public Biz_SecurityGroup Biz_SecurityGroups
        {
            get;
            set;
        }

        public Biz_SystemModule Biz_SystemModules
        {
            get;
            set;
        }

        #endregion
    }
}
