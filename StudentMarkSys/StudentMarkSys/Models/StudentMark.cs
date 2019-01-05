using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentMarkSys.Models
{
    public class StudentMark
    {
       
        public int Std_Id { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public int Dep_Id { get; set; }
        public string Dept_Name { get; set; }

        public bool Isdelete { get; set; }

    }

    public class Department
    {
        public int Dep_Id { get; set; }

        public string Dept_Name { get; set; }
    }


    public class StudentMarks
    {
        public string Name { get; set; }
        public decimal Mark1 { get; set; }
        public decimal Mark2 { get; set; }
      public int Mark_Id { get; set; }
        public int Std_Id { get; set; }


    }
    public class LoginModel
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassWord { get; set; }
        public bool IsAgree { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CurrentTimeStamp { get; set; }
        public DateTime UpdatedTimeStamp { get; set; }
    }

}
