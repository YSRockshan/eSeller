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
    
    public partial class Biz_Screen
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Biz_Screen()
        {
            this.Biz_SecurityGroupScreen = new HashSet<Biz_SecurityGroupScreen>();
        }
    
        public long Id { get; set; }
        public string Description { get; set; }
        public long IdBizModule { get; set; }
        public Nullable<long> IdParentScreen { get; set; }
        public string ProgramFile_Name { get; set; }
        public Nullable<int> Sequence_No { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
    
        public virtual Biz_SystemModule Biz_SystemModule { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Biz_SecurityGroupScreen> Biz_SecurityGroupScreen { get; set; }
    }
}
