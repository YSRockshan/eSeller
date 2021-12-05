using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_SlabDetail
    {
        #region "Biz_SlabDetail Properties"

        public long Id { get; set; }
        public long IdSlab { get; set; }
        public decimal Slab_From { get; set; }
        public decimal Slab_To { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public decimal Rate { get; set; }

        #endregion
      #region  "Reference Properties" 

        public Biz_Slab Biz_Slabs
        {
            get;
            set;
        }

        public EntityCollection<Biz_SlabValueDetail> Biz_SlabValueDetails
        {
            get;
            set;
        }

        #endregion
    }
}
