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
    
    public partial class Biz_Stakeholder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biz_Stakeholder()
        {
            this.Biz_BranchSalesAgent = new HashSet<Biz_BranchSalesAgent>();
            this.Biz_MemberCommssionDetail = new HashSet<Biz_MemberCommssionDetail>();
            this.Biz_PasswordHistory = new HashSet<Biz_PasswordHistory>();
            this.Biz_StakeholderBranch = new HashSet<Biz_StakeholderBranch>();
            this.Biz_StakeholderSecurityGroup = new HashSet<Biz_StakeholderSecurityGroup>();
            this.Biz_StakeholderTypeStakeholder = new HashSet<Biz_StakeholderTypeStakeholder>();
        }
    
        public long Id { get; set; }
        public long IdStakeholderType { get; set; }
        public string Title { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Initial { get; set; }
        public string Country { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string PostalCode { get; set; }
        public string Contact_Address { get; set; }
        public string Lane { get; set; }
        public string Road { get; set; }
        public string Town { get; set; }
        public string Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string NIC { get; set; }
        public string Passport { get; set; }
        public string Maritual_Status { get; set; }
        public string Designation { get; set; }
        public string EPF_No { get; set; }
        public string ETF_No { get; set; }
        public string Telephone { get; set; }
        public string Mobile { get; set; }
        public string Office_No { get; set; }
        public string Email_Address { get; set; }
        public long IdCurrentBranch { get; set; }
        public string Status { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_BranchSalesAgent> Biz_BranchSalesAgent { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_MemberCommssionDetail> Biz_MemberCommssionDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_PasswordHistory> Biz_PasswordHistory { get; set; }
        public virtual Biz_StakeholderType Biz_StakeholderType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_StakeholderBranch> Biz_StakeholderBranch { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_StakeholderSecurityGroup> Biz_StakeholderSecurityGroup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_StakeholderTypeStakeholder> Biz_StakeholderTypeStakeholder { get; set; }
    }
}
