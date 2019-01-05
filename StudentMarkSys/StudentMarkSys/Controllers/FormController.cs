using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMarkSys.Controllers
{
    public class FormController : Controller
    {
        // GET: Form
        public ActionResult AccountCreate()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}