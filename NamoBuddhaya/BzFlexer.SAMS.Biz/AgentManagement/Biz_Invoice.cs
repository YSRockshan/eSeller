using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using BzFlexer.SAMS.Biz.Reference;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_Invoice
    {
        #region  "Biz_Invoice Properties"
        public long Id { get; set; }
        public long? IdSalesTransaction { get; set; }
        public long? IdSalesTarget { get; set; }
        public long? IdBranchPriceBook { get; set; }
        public decimal Discount_Value { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total_Value { get; set; }
        public decimal Commission_Value { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long? IdBranchProduct { get; set; }
        public long IdSalesPerson { get; set; }
        public string Status { get; set; }
        public int serialNo { get; set; }
        public long IdItem { get; set; }
        public long IdUnitOfMeasure { get; set; }
        public long? IdBranch { get; set; }
        #endregion
        #region  "Reference Properties" 
        public Biz_BranchPriceBook Biz_BranchPriceBooks
        {
            get;
            set;
        }

        public Biz_BranchProduct Biz_BranchProducts
        {
            get;
            set;
        }

        public Biz_SalesTarget Biz_SalesTargets
        {
            get;
            set;
        }

        public Biz_InventoryItem Biz_InventoryItems
        {
            get;
            set;
        }

        public Biz_UnitOfMeasure Biz_UnitOfMeasures
        {
            get;
            set;
        }

        public Biz_SalesTransaction Biz_SalesTransactions
        {
            get;
            set;
        }

        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        public EntityCollection<Biz_MemberCommssionDetail> Biz_MemberCommssionDetails
        {
            get;
            set;
        }

        #endregion
    }
}
