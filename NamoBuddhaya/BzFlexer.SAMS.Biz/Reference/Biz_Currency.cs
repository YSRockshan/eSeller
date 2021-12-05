using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using BzFlexer.SAMS.Biz.AgentManagement ;

namespace BzFlexer.SAMS.Biz.Reference
{
  
    public class Biz_Currency
    {
        #region "BizCurrency Properties"
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
        #region"Reference Properties"

        public EntityCollection<Biz_PriceBook> Biz_PriceBooks
        {
            get;
            set;
        }

        #endregion
    }
}
