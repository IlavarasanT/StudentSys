using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentMarkSys.Models;
using StudentMarkSys.Entity;
using StudentMarkSys.Utility;

namespace StudentMarkSys.Controllers
{
    [MyutilityClass]
    public class StudentController : Controller
    {
        MysqlsEntities1 entityobj = new MysqlsEntities1();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            var obj1 = entityobj.Student_Dep.Select(s => s).ToList();
            var obj2 = obj1.Select(x => new SelectListItem
            {
                Value = x.Dep_Id.ToString(),
                Text = x.Dep_Name

            }).ToList();
            ViewBag.drop = obj2;
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentMark modeobj)
        {
            Student_Detail tableobj = new Student_Detail();

            tableobj.Name = modeobj.Name;
            tableobj.Email = modeobj.Email;
            tableobj.Gender = modeobj.Gender;
            tableobj.Dep_Id = modeobj.Dep_Id;
            entityobj.Student_Detail.Add(tableobj);
            entityobj.SaveChanges();
            return RedirectToAction("Showdetails");
        }
        public ActionResult Addmark()
        {
            Student_Mark tableobj = new Student_Mark();
            var obj3 = entityobj.Student_Detail.Select(s => s).ToList();
            var obj4 = entityobj.Student_Detail.Select(s => s).ToList();
            tableobj.Std_Id = obj3.Where(e => e.Std_Id == tableobj.Std_Id).Select(e => e.Std_Id).SingleOrDefault();
            var dropdownlistname = obj4.Select(x => new SelectListItem
            {
                Value = x.Std_Id.ToString(),
                Text = x.Name

            }).ToList();
            ViewBag.project = dropdownlistname;

            return View();
        }
        [HttpPost]
        public ActionResult Addmark(StudentMarks modelobj2)
        {
            Student_Mark tableobj = new Student_Mark();
            tableobj.Mark1 = modelobj2.Mark1;
            tableobj.Mark2 = modelobj2.Mark2;
            tableobj.Std_Id = modelobj2.Std_Id;
            entityobj.Student_Mark.Add(tableobj);
            entityobj.SaveChanges();

            return RedirectToAction("ShowMark");
        }
        [HttpGet]
        public ActionResult Showdetails()
        {
            //var dblist = entityobj.Student_Detail.Where(x => !x.Is_Delete).Select(x => x).ToList();
            var studetailobj = entityobj.Student_Detail.Where(x => x.Is_Delete != true).Select(x => x).ToList();
           // var studetailsobj = entityobj.Student_Detail.Select(s => s).ToList();
            var studentdeptobj = entityobj.Student_Dep.Select(s => s).ToList();
            var studentlist = new List<StudentMark>();

            if (studetailobj != null)
            {
                foreach (var item in studetailobj)
                {
                    StudentMark modelobj = new StudentMark();
                    modelobj.Std_Id = item.Std_Id;
                    modelobj.Name = item.Name;
                    modelobj.Email = item.Email;
                    modelobj.Gender = item.Gender;
                    modelobj.Dept_Name = studentdeptobj.Where(s => s.Dep_Id == item.Dep_Id).Select(s => s.Dep_Name).SingleOrDefault();
                    studentlist.Add(modelobj);

                }
            }
              
                return View(studentlist);
            
        }
        
        public ActionResult ShowMark()
        {
            var studentmarkdetail = entityobj.Student_Mark.Where(x => x.Is_Delete != true).Select(x => x).ToList();
            //  var studentmarkdetail = entityobj.Student_Mark.Select(s => s).ToList();
            //var stkdObj = entityobj.Student_Mark.Select(e => new {  e.Std_Id,e.Name}).ToList();
            var getname = entityobj.Student_Detail.Select(x => new { x.Name, x.Std_Id }).ToList();
            var marklist = new List<StudentMarks>();
            if (studentmarkdetail != null)
            {


                foreach (var item in studentmarkdetail)
                {
                    StudentMarks markobj = new StudentMarks();
                    markobj.Std_Id = item.Std_Id;
                    markobj.Mark_Id = item.Mark_Id;
                    markobj.Name = getname.Where(e => e.Std_Id == item.Std_Id).Select(e => e.Name).SingleOrDefault();
                    //  markobj.Name = getname.Where(s => s.Std_Id == item.Std_Id).Select(x => x.Name).SingleOrDefault();
                    //        markobj.Name = entityobj.Student_Detail.Where(x=>x.Std_Id==item.Std_Id).Select(e => e.Name).SingleOrDefault();
                    markobj.Mark1 = (decimal)item.Mark1;
                    markobj.Mark2 = (decimal)item.Mark2;
                    ViewBag.Total = item.Mark1 + item.Mark2;
                    marklist.Add(markobj);

                }
            }

            return View(marklist);
        }



        public ActionResult DeleteStudent(int id)
        {
            var DeleteData = entityobj.Student_Detail.Where(x => x.Std_Id == id).SingleOrDefault();
            if (DeleteData != null && DeleteData.Std_Id > 0)
            {
                DeleteData.Is_Delete = true;
                entityobj.SaveChanges();
            }
            return RedirectToAction("Showdetails");
        }

        public ActionResult DeleteMark(int id)
        {
            var deleteMark = entityobj.Student_Mark.Where(x => x.Mark_Id == id).SingleOrDefault();
            if (deleteMark != null && deleteMark.Mark_Id > 0)
            {
                deleteMark.Is_Delete = true;
                entityobj.SaveChanges();
            }
            return RedirectToAction("ShowMark");
        }

      
        }

    }
