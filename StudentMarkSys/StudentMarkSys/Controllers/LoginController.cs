using StudentMarkSys.Entity;
using StudentMarkSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMarkSys.Controllers
{
    public class LoginController : Controller
    {
        MysqlsEntities1 EntityObj = new MysqlsEntities1();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel ModelObj)
        {
            Login_Table TableObj = new Login_Table();
            //TableObj.Id = ModelObj.Id;
            TableObj.First_Name = ModelObj.FirstName;
            TableObj.Last_Name = ModelObj.LastName;
            TableObj.Email = ModelObj.Email;
            TableObj.PassWord = ModelObj.PassWord;
            TableObj.Is_Agree = ModelObj.IsAgree;
            TableObj.Is_Deleted = ModelObj.IsDeleted;
            TableObj.Current_Time_Stamp = DateTime.Now;
            TableObj.Updated_Time_Stamp = DateTime.Now; ;
            EntityObj.Login_Table.Add(TableObj);
            EntityObj.SaveChanges();

            ModelObj.Id = TableObj.Id;
            return Json(ModelObj,JsonRequestBehavior.AllowGet);
        }
        public ActionResult Emailvalidation(string email)
        {
            var obj = EntityObj.Login_Table.Any(e => e.Email == email);
            return Json(obj, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Loginval()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Loginval(LoginModel modelObj)
        {
            var obj = EntityObj.Login_Table.Any(e => e.PassWord == modelObj.PassWord && e.Email== modelObj.Email);
            if (obj)
            {
                Session["EmailId"] = modelObj.Email;
            }
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Loginval");
        }
    }
}
