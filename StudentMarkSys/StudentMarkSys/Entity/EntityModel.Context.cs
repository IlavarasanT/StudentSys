﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentMarkSys.Entity
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MysqlsEntities1 : DbContext
    {
        public MysqlsEntities1()
            : base("name=MysqlsEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Login_Table> Login_Table { get; set; }
        public virtual DbSet<Student_Dep> Student_Dep { get; set; }
        public virtual DbSet<Student_Detail> Student_Detail { get; set; }
        public virtual DbSet<Student_Mark> Student_Mark { get; set; }
    }
}
