using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_SalesTarget
    {
        #region "Biz_SalesTarget Properties"
        public long Id { get; set; }
        public long ? IdCommssion { get; set; }
        public long ? IdSalesBudget { get; set; }
        public long IdPeriod { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsCommissionApplied { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
      #region  "Reference Properties" 

        public EntityCollection<Biz_Invoice> Biz_Invoices
        {
            get;
            set;
        }

        public EntityCollection<Biz_MemberSalesTarget> Biz_MemberSalesTargets
        {
            get;
            set;
        }

        public Biz_Period Biz_Periods
        {
            get;
            set;
        }

        public Biz_SalesBudget Biz_SalesBudgets
        {
            get;
            set;
        }

        public Biz_Commission Biz_Commissions
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesTargetDetail> Biz_SalesTargetDetails
        {
            get;
            set;
        }

        public Biz_SalesForecast Biz_SalesForecasts
        {
            get;
            set;
        }

        #endregion
    }
}
