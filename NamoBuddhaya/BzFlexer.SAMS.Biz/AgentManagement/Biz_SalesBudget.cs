using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_SalesBudget
    {
        #region "Biz_SalesBudget Properties"
        public long Id { get; set; }
        public long IdPeriod { get; set; }
        public long IdSalesForecast { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        #endregion
      #region  "Reference Properties" 

   
        public Biz_SalesForecast Biz_SalesForecasts
        {
            get;
            set;
        }
      
        public Biz_Period Biz_Periods
        {
            get;
            set;
        }
        
        public EntityCollection<Biz_SalesBudgetDetail> Biz_SalesBudgetDetails
        {
            get;
            set;
        }
        
        public EntityCollection<Biz_SalesTarget> Biz_SalesTargets
        {
            get;
            set;
        }

        #endregion
    }
}
