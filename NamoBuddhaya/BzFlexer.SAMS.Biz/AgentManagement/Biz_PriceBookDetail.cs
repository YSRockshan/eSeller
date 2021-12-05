using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    public class Biz_PriceBookDetail
    {
        #region "Biz_PriceBookDetail Properties"
        public long Id { get; set; }
        public long IdPriceBook { get; set; }
        public decimal? Discount_Rate { get; set; }
        public decimal PricePer_Unit { get; set; }
        public decimal CostPer_Unit { get; set; }
        public decimal? Commission_Rate { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long? IdProduct { get; set; }
        public long IdUnitOfMeasure { get; set; }
        #endregion
      #region  "Reference Properties" 

        public Biz_Product Biz_Products
        {
            get;
            set;
        }

        public Biz_PriceBook Biz_PriceBooks
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
