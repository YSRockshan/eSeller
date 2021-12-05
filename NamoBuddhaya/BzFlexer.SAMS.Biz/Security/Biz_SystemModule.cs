using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.Security
{
    public class Biz_SystemModule
    {
        #region "Biz_SystemModule Properties"
        public long Id { get; set; }
        public string SystemModule_Code { get; set; }
        public string Description { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
       #region  "Reference Properties" 

        public EntityCollection<Biz_Screen> Biz_Screens
        {
            get;
            set;
        }

        public EntityCollection<Biz_SecurityGroupScreen> Biz_SecurityGroupScreens
        {
            get;
            set;
        }

        #endregion
    }
}
