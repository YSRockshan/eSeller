using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_SingleRate
    {
        #region "Biz_SingleRate Properties"
        public long Id { get; set; }
        public long IdCommssion { get; set; }
        public decimal Rate { get; set; }
        public string Status { get; set; }
        public string Rate_Mode { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
      #region  "Reference Properties" 

        
        public Biz_Commission Biz_Commissions
        {
            get;
            set;
        }

        #endregion
    }
}
