using BzFlexer.SAMS.Biz.Reference;
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
    public class Biz_Branch
    {
        #region "Biz_Branch Properties"
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        #endregion
        #region"Reference Properties"
        

        public EntityCollection<Biz_Stakeholder> Biz_Stakeholders
        {
            get;
            set;
        }

        public EntityCollection<Biz_BranchProduct> Biz_BranchProducts
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesBudgetDetail> Biz_SalesBudgetDetails
        {
            get;
            set;
        }

        public EntityCollection<Biz_BranchPriceBook> Biz_BranchPriceBooks
        {
            get;
            set;
        }

        public EntityCollection<Biz_BranchSalesAgent> Biz_BranchSalesAgents
        {
            get;
            set;
        }

        public EntityCollection<Biz_MemberSalesAgentPosition> Biz_MemberSalesAgentPositions
        {
            get;
            set;
        }

        public EntityCollection<Biz_MemberSalesTarget> Biz_MemberSalesTargets
        {
            get;
            set;
        }


        public EntityCollection<Biz_SalesTargetDetail> Biz_SalesTargetDetails
        {
            get;
            set;
        }

        public EntityCollection<Biz_StakeholderBranch> Biz_StakeholderBranches
        {
            get;
            set;
        }

        public EntityCollection<Biz_InventoryItem> Biz_InventoryItems
        {
            get; set;
        }

        public EntityCollection<Biz_Invoice> Biz_Invoices
        {
            get;
            set;
        }

        public EntityCollection<Biz_SalesTransaction> Biz_SalesTransactions
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
