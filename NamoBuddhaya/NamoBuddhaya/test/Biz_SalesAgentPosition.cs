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
    
    public partial class Biz_SalesAgentPosition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biz_SalesAgentPosition()
        {
            this.Biz_MemberSalesAgentPosition = new HashSet<Biz_MemberSalesAgentPosition>();
        }
    
        public long Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_MemberSalesAgentPosition> Biz_MemberSalesAgentPosition { get; set; }
    }
}