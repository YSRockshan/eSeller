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
    
    public partial class Biz_SalesTarget
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biz_SalesTarget()
        {
            this.Biz_Invoice = new HashSet<Biz_Invoice>();
            this.Biz_MemberSalesTarget = new HashSet<Biz_MemberSalesTarget>();
            this.Biz_SalesTargetDetail = new HashSet<Biz_SalesTargetDetail>();
        }
    
        public long Id { get; set; }
        public Nullable<long> IdCommssion { get; set; }
        public Nullable<long> IdSalesBudget { get; set; }
        public Nullable<long> IdPeriod { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsCommissionApplied { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
    
        public virtual Biz_Commission Biz_Commission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_Invoice> Biz_Invoice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_MemberSalesTarget> Biz_MemberSalesTarget { get; set; }
        public virtual Biz_Period Biz_Period { get; set; }
        public virtual Biz_SalesBudget Biz_SalesBudget { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_SalesTargetDetail> Biz_SalesTargetDetail { get; set; }
    }
}
