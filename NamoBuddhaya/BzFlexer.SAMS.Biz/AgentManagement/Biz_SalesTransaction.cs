using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;

namespace BzFlexer.SAMS.Biz.AgentManagement 
{
    [Serializable]
    public class Biz_SalesTransaction
    {
        #region "Biz_SalesTransaction Properties"
        public long Id { get; set; }
        public string Invoice_No { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string Status { get; set; }
        public long ? IdBranch { get; set; }

        #endregion
      #region  "Reference Properties" 

        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        public EntityCollection<Biz_Invoice> Biz_Invoices
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
