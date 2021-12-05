using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
   
    public class Biz_Period
    {
        #region "Biz_Period Properties"
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
       #region  "Reference Properties" 

        public EntityCollection<Biz_SalesForecast> Biz_SalesForecasts
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesBudget> Biz_SalesBudgets
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
