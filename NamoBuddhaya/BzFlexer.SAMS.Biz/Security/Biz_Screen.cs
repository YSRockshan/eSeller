using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.Security
{
    public class Biz_Screen
    {
        #region "Biz_Screen Properties"
        public long Id { get; set; }
        public string Description { get; set; }
        public long IdBizModule { get; set; }
        public long IdParentScreen { get; set; }
        public string ProgramFile_Name { get; set; }
        public Nullable<int> Sequence_No { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
       #region  "Reference Properties" 

        public Biz_SystemModule Biz_SystemModules
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
