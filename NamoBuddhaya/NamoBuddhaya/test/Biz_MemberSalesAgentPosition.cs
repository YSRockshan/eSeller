//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NamoBuddhaya.test
{
    using System;
    using System.Collections.Generic;
    
    public partial class Biz_MemberSalesAgentPosition
    {
        public long Id { get; set; }
        public Nullable<long> IdSalesAgent { get; set; }
        public Nullable<long> IdSalesAgentPosition { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<long> IdBranch { get; set; }
    
        public virtual Biz_Branch Biz_Branch { get; set; }
        public virtual Biz_BranchSalesAgent Biz_BranchSalesAgent { get; set; }
        public virtual Biz_SalesAgentPosition Biz_SalesAgentPosition { get; set; }
    }
}
