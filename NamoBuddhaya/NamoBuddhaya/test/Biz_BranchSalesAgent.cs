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
    
    public partial class Biz_BranchSalesAgent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biz_BranchSalesAgent()
        {
            this.Biz_MemberSalesAgentPosition = new HashSet<Biz_MemberSalesAgentPosition>();
            this.Biz_MemberSalesTarget = new HashSet<Biz_MemberSalesTarget>();
        }
    
        public long Id { get; set; }
        public Nullable<long> IdSalesAgent { get; set; }
        public Nullable<System.DateTime> DateEffect { get; set; }
        public Nullable<System.DateTime> DateExpired { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public Nullable<long> IdBranch { get; set; }
        public Nullable<long> IdStakeholderTypeStakeholder { get; set; }
        public Nullable<long> IdStakeholder { get; set; }
    
        public virtual Biz_Branch Biz_Branch { get; set; }
        public virtual Biz_SalesAgent Biz_SalesAgent { get; set; }
        public virtual Biz_StakeholderTypeStakeholder Biz_StakeholderTypeStakeholder { get; set; }
        public virtual Biz_Stakeholder Biz_Stakeholder { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_MemberSalesAgentPosition> Biz_MemberSalesAgentPosition { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_MemberSalesTarget> Biz_MemberSalesTarget { get; set; }
    }
}
