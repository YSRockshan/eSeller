using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_SlabValueDetail
    {
        #region Biz_SlabValueDetail Properties
        public long ld { get; set; }
        public long IdSlabDetail { get; set; }
        public long IdCommssion { get; set; }
        public long IdSlab { get; set; }
        public decimal Value { get; set; }
        public Nullable<bool> Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
      #region  "Reference Properties" 

        public Biz_Commission Biz_Commissions
        {
            get;
            set;
        }

        public Biz_SlabDetail Biz_SlabDetails
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
