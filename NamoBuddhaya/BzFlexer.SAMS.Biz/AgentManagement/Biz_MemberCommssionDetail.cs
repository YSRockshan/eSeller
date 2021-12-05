using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{    /// Member Commssion Detail
    [Serializable]
    public class Biz_MemberCommssionDetail
    {
        #region  "Biz_Invoice Properties"
        public long Id { get; set; }
        public long IdSalesAgent { get; set; }
        public long? IdSalesTransaction { get; set; }
        public decimal? Commission { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public decimal? Target_Commission { get; set; }
        public decimal? Total_Commission { get; set; }
        public DateTime Date_Commission { get; set; }
        public long IdBranch { get; set; }
        public long SequenceNumber { get; set; }
        public long IdInvoice { get; set; }
        #endregion
        #region  "Reference Properties" 
        
        public Biz_Stakeholder Biz_Stakeholders
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

        public Biz_Invoice Biz_Invoices
        {
            get;
            set;
        }


        #endregion
    }
}
