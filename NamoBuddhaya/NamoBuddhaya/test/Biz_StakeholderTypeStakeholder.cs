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
    
    public partial class Biz_StakeholderTypeStakeholder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biz_StakeholderTypeStakeholder()
        {
            this.Biz_BranchSalesAgent = new HashSet<Biz_BranchSalesAgent>();
        }
    
        public long Id { get; set; }
        public long IdStakeholderType { get; set; }
        public long IdStakeholder { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public Nullable<System.DateTime> DateEffect { get; set; }
        public string Status { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_BranchSalesAgent> Biz_BranchSalesAgent { get; set; }
        public virtual Biz_Stakeholder Biz_Stakeholder { get; set; }
        public virtual Biz_StakeholderType Biz_StakeholderType { get; set; }
    }
}
