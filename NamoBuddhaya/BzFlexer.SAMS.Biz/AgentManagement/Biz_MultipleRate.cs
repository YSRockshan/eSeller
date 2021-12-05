using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_MultipleRate
    {
        #region "Biz_MultipleRateProperties"
        public long Id { get; set; }
        public long IdCommission { get; set; }
        public long IdSlab { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        #endregion
      #region  "Reference Properties" 

        public Biz_Commission Biz_Commissions
        {
            get;
            set;
        }

        public Biz_Slab Biz_Slabs
        {
            get;
            set;
        }

        #endregion
    }
}
