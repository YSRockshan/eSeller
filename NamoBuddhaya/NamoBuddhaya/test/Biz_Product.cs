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
    
    public partial class Biz_Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biz_Product()
        {
            this.Biz_BranchProduct = new HashSet<Biz_BranchProduct>();
            this.Biz_InventoryItem = new HashSet<Biz_InventoryItem>();
            this.Biz_PriceBookDetail = new HashSet<Biz_PriceBookDetail>();
            this.Biz_SalesBudgetDetail = new HashSet<Biz_SalesBudgetDetail>();
            this.Biz_SalesForecastDetail = new HashSet<Biz_SalesForecastDetail>();
        }
    
        public long Id { get; set; }
        public Nullable<long> IdProductCategory { get; set; }
        public Nullable<long> IdSubProductCategory { get; set; }
        public Nullable<long> IdUnitOfMeasureType { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string More_Details { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_BranchProduct> Biz_BranchProduct { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_InventoryItem> Biz_InventoryItem { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_PriceBookDetail> Biz_PriceBookDetail { get; set; }
        public virtual Biz_ProductCategory Biz_ProductCategory { get; set; }
        public virtual Biz_SubProductCategory Biz_SubProductCategory { get; set; }
        public virtual Biz_UnitOfMeasureType Biz_UnitOfMeasureType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_SalesBudgetDetail> Biz_SalesBudgetDetail { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_SalesForecastDetail> Biz_SalesForecastDetail { get; set; }
    }
}
