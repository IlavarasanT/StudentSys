//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Student_Detail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Student_Detail()
        {
            this.Student_Mark = new HashSet<Student_Mark>();
        }
    
        public int Std_Id { get; set; }
        public Nullable<int> Dep_Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public Nullable<bool> Is_Delete { get; set; }
    
        public virtual Student_Dep Student_Dep { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Student_Mark> Student_Mark { get; set; }
    }
}
