using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTIWebApp.Models;
namespace LTIWebApp.Controllers
{
    public class LoginController : Controller
    {
        LTIMVCEntities db1 = new LTIMVCEntities();
        [HttpGet]
        // GET: Login
        public ActionResult LoginPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginPage(Registration reg)
        {
            
            string uname = Request.Form["username"];
            string pwd = Request.Form["pwd"];
            var data = db1.Registrations.Where(x => x.Username.Equals(uname) && x.Pwd == pwd).SingleOrDefault();
            if(data==null)
            {
                ModelState.AddModelError("", "Login Failed");
            }
            else
            {
                ModelState.AddModelError("", "Login Successfull");
            }
            return View();
        }
    }
}