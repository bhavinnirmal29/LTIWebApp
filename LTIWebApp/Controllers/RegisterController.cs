using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTIWebApp.Models;
namespace LTIWebApp.Controllers
{
    public class RegisterController : Controller
    {
        LTIMVCEntities db = new LTIMVCEntities();
        // GET: Register
        [HttpGet]
        public ActionResult RegisterPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterPage(Registration reg)
        {
            string uname = Request.Form["username"];
            string pwd = Request.Form["pwd"];
            string email = Request.Form["email1"];
            string city = Request.Form["city"];
            string mob = Request.Form["mobile"];
            reg.Username = uname;
            reg.Pwd = pwd;
            reg.Email = email;
            reg.City = city;
            reg.Mobile = mob;
            db.Registrations.Add(reg);
            int res = db.SaveChanges();
            if (res > 0)
                ModelState.AddModelError("", "One Row Inserted");
            else
                ModelState.AddModelError("", "No Rows Inserted");

            return View();
        }
    }
}