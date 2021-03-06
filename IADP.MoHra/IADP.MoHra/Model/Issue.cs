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
    
    public partial class Issue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Issue()
        {
            this.IssueHistory = new HashSet<IssueHistory>();
            this.IssueRevisions = new HashSet<IssueRevision>();
            this.IssueTime = new HashSet<IssueTime>();
        }
    
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> VersionId { get; set; }
        public string Subject { get; set; }
        public int AuthorMemberId { get; set; }
        public Nullable<int> AssignedToMemberId { get; set; }
        public int StatusId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> DueDate { get; set; }
        public Nullable<float> EstimatedHours { get; set; }
        public string Client { get; set; }
        public Nullable<System.DateTime> DeadlineDate { get; set; }
        public System.DateTime Created { get; set; }
        public System.DateTime LastHistoryDate { get; set; }
    
        public virtual IssueStatus Status { get; set; }
        public virtual IssueVersion Version { get; set; }
        public virtual Member AssignedMember { get; set; }
        public virtual Member AuthorMember { get; set; }
        public virtual Project Project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueHistory> IssueHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueRevision> IssueRevisions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IssueTime> IssueTime { get; set; }
    }
}
