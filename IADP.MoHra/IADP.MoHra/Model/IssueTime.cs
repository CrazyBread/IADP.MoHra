//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IADP.MoHra.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class IssueTime
    {
        public int Id { get; set; }
        public int IssueId { get; set; }
        public int MemberId { get; set; }
        public System.DateTime Date { get; set; }
        public float Hours { get; set; }
        public string Comment { get; set; }
    
        public virtual Issue Issue { get; set; }
        public virtual Member Member { get; set; }
    }
}