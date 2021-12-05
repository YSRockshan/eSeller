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
    public class Biz_BranchProduct
    {
        #region "BizBranchProduct Properties"
        public long Id { get; set; }
        public long IdBranch { get; set; }
        public long IdProduct { get; set; }
        public decimal StockOpen { get; set; }
        public decimal StockOnOrder { get; set; }
        public decimal Present_Value { get; set; }
        public decimal Present_Stock { get; set; }
        public decimal Reorder_Level { get; set; }
        public decimal Reorder_Quantity { get; set; }
        public decimal Buffer_Stock { get; set; }
        public string Auth_Status { get; set; }
        public decimal Reserve_Quantity { get; set; }
        public long IdProductCategory { get; set; }
        public long IdSubProductCategory { get; set; }

        #endregion
        #region"Reference Properties"
        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        public Biz_Product Biz_Products
        {
            get;
            set;
        }

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

        public EntityCollection<Biz_Invoice> Biz_Invoices
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
