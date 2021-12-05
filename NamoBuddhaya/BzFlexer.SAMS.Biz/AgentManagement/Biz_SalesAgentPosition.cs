using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_SalesAgentPosition
    {
        #region "Biz_SalesAgentPosition Properties"
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
      #region  "Reference Properties" 

        public EntityCollection<Biz_MemberSalesAgentPosition> Biz_MemberSalesAgentPositions
        {
            get;
            set;
        }

        #endregion
    }
}
