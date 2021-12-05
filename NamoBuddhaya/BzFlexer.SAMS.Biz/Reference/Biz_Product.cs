using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using BzFlexer.SAMS.Biz.AgentManagement ;

namespace BzFlexer.SAMS.Biz.Reference
{

    public class Biz_Product
    {
        #region "BizProduct Properties"
        public long Id { get; set; }
        public long IdProductCategory { get; set; }
        public long IdSubProductCategory { get; set; }
        public long IdUnitOfMeasureType { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string More_Details { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        #endregion
        #region"Reference Properties"  
        public Biz_ProductCategory Biz_ProductCategories
        {
            get;
            set;
        }

        public Biz_SubProductCategory Biz_SubProductCategories
        {
            get;
            set;
        }

        public Biz_UnitOfMeasureType Biz_UnitOfMeasureTypes
        {
            get;
            set;
        }

        public EntityCollection<Biz_BranchProduct> Biz_BranchProducts
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

        public EntityCollection<Biz_SalesBudgetDetail> Biz_SalesBudgetDetails
        {
            get;
            set;
        }

        public EntityCollection<Biz_InventoryItem> Biz_InventoryItems
        {
            get;
            set;
        }


        #endregion
    }
}
