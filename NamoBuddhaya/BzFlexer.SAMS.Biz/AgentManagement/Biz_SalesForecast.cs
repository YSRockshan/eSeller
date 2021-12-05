using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    public class Biz_SalesForecast
    {
        #region "Biz_SalesForecast Properties"
        public long Id { get; set; }
        public long IdPeriod { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }

        #endregion
       #region  "Reference Properties" 

        public Biz_Period Biz_Periods
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesForecastDetail> Biz_SalesForecastDetails
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesBudget> Biz_SalesBudgets
        {
            get;
            set;
        }

        #endregion
    }
}
