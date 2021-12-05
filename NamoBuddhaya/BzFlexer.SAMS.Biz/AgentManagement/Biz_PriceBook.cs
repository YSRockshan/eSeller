using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_PriceBook
    {
        #region "Biz_PriceBook Properties"

        public long Id { get; set; }
        public long IdCurrency { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
      #region  "Reference Properties" 

        public Biz_Currency Biz_Currencies
        {
            get;
            set;
        }

        public EntityCollection<Biz_BranchPriceBook> Biz_BranchPriceBooks
        {
            get;
            set;
        }

        #endregion
    }
}
