using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_SalesTargetDetail
    {
        #region "Biz_SalesTargetDetail Properties"
        public long Id { get; set; }
        public long IdSalesTarget { get; set; }
        public decimal ? Quantity { get; set; }
        public long ? IdUnitOfMeasure { get; set; }
        public string Type { get; set; }
        public decimal Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long IdBranch { get; set; }
        public long IdInventoryItem { get; set; }
        #endregion
      #region  "Reference Properties" 

        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        public Biz_InventoryItem Biz_InventoryItems
        {
            get;
            set;
        }

        public Biz_SalesTarget Biz_SalesTargets
        {
            get;
            set;
        }

        public Biz_UnitOfMeasure Biz_UnitOfMeasures
        {
            get;
            set;
        }

        #endregion
    }
}
