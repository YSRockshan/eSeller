using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using BzFlexer.SAMS.Biz.AgentManagement ;

namespace BzFlexer.SAMS.Biz.Reference
{
    [Serializable]
    public class Biz_UnitOfMeasure
    {
        #region "BizUnitOfMeasure Properties"
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public long ? IdUnitOfMeasureType { get; set; }
        public string Symbol { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
        #region"Reference Properties"
        public Biz_UnitOfMeasureType Biz_UnitOfMeasureTypes
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesBudgetDetail> Biz_SalesBudgetDetails
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesForecastDetail> Biz_SalesForecastDetails
        {
            get;
            set;
        }

        public EntityCollection<Biz_PriceBookDetail> Biz_PriceBookDetails
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesTargetDetail> Biz_SalesTargetDetails
        {
            get;
            set;
        }

        public EntityCollection<Biz_Invoice> Biz_Invoices
        {
            get;
            set;
        }

        #endregion
    }
}
