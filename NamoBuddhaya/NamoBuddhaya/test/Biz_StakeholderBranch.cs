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
    
    public partial class Biz_StakeholderBranch
    {
        public long Id { get; set; }
        public long IdStakeholder { get; set; }
        public long IdBranch { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
    
        public virtual Biz_Branch Biz_Branch { get; set; }
        public virtual Biz_Stakeholder Biz_Stakeholder { get; set; }
    }
}