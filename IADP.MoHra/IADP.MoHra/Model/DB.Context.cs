﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DB : DbContext
    {
        public DB()
            : base(Helpers.DatabaseHelper.FixConnectionString("DB"))
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<IssueHistory> IssueHistory { get; set; }
        public virtual DbSet<IssueRevision> IssueRevision { get; set; }
        public virtual DbSet<IssueStatus> IssueStatus { get; set; }
        public virtual DbSet<IssueTime> IssueTime { get; set; }
        public virtual DbSet<IssueVersion> IssueVersion { get; set; }
        public virtual DbSet<Member> Member { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Revision> Revision { get; set; }
    }
}
