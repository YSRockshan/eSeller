using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement
{
    [Serializable]
    public class Biz_BranchPriceBook
    {
        #region  "Biz_BranchPriceBook Properties"
        public long Id { get; set; }
        public long IdPriceBook { get; set; }
        public DateTime DateEffect { get; set; }
        public DateTime ? DateExpired { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long IdBranch { get; set; }
        #endregion
        #region  "Reference Properties"

        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        public Biz_PriceBook Biz_PriceBooks
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
