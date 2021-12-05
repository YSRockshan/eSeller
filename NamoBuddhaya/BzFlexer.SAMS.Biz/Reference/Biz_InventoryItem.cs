using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Biz.AgentManagement ;

namespace BzFlexer.SAMS.Biz.Reference
{
    [Serializable]
    public class Biz_InventoryItem
    {
        #region "BizInventoryItem Properties"
        public long Id { get; set; }
        public string CodeInventoryItem { get; set; }
        public long IdBranchproduct { get; set; }
        public string Status { get; set; }
        public long IdBranch { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public long IdProduct { get; set; }
        public string Description { get; set; }
        #endregion
        #region"Reference Properties"
       
        public Biz_Branch Biz_Branches
        {
            get;
            set;
        }

        public Biz_BranchProduct Biz_BranchProducts
        {
            get;
            set;
        }

        public Biz_Product Biz_Products
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
