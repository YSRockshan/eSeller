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
    
    public partial class Biz_SalesBudget
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biz_SalesBudget()
        {
            this.Biz_SalesBudgetDetail = new HashSet<Biz_SalesBudgetDetail>();
            this.Biz_SalesTarget = new HashSet<Biz_SalesTarget>();
        }
    
        public long Id { get; set; }
        public Nullable<long> IdPeriod { get; set; }
        public Nullable<long> IdSalesForecast { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
    
        public virtual Biz_Period Biz_Period { get; set; }
        public virtual Biz_SalesForecast Biz_SalesForecast { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_SalesBudgetDetail> Biz_SalesBudgetDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_SalesTarget> Biz_SalesTarget { get; set; }
    }
}