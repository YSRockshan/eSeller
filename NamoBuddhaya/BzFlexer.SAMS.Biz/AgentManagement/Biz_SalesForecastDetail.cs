using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    public class Biz_SalesForecastDetail
    {
        #region "Biz_SalesForecastDetail Properties"
        public long Id { get; set; }
        public long IdSalesForecast { get; set; }
        public long ? IdUnitOfMeasure { get; set; }
        public decimal ? Quantity { get; set; }
        public decimal ? Value { get; set; }
        public string Type { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long IdProduct { get; set; }
        #endregion
       #region  "Reference Properties" 

        public Biz_SalesForecast Biz_SalesForecasts
        {
            get;
            set;
        }

        public Biz_Product Biz_Products
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
