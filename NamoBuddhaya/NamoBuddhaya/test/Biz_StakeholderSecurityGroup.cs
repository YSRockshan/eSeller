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
    
    public partial class Biz_StakeholderSecurityGroup
    {
        public long Id { get; set; }
        public long IdSecurityGroup { get; set; }
        public long IdStakeholder { get; set; }
        public System.DateTime DateEffect { get; set; }
        public Nullable<System.DateTime> DateExpired { get; set; }
        public Nullable<long> IdStatus { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public long IdStakeholderType { get; set; }
    
        public virtual Biz_SecurityGroup Biz_SecurityGroup { get; set; }
        public virtual Biz_Stakeholder Biz_Stakeholder { get; set; }
        public virtual Biz_StakeholderType Biz_StakeholderType { get; set; }
    }
}