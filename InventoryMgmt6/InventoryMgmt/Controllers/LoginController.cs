using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryMgmt.Models;
using System.Web.Security;

namespace InventoryMgmt.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Models.Membership model)
        {
            using (var context = new UsersEntities())
            {
                bool isValid = context.Users1.Any(x => x.Nama == model.Nama && x.Password == model.Password);
                if (isValid)
                {
                    FormsAuthentication.SetAuthCookie(model.Nama, false);
                    return RedirectToAction("Index", "Dashboard");
                }

                ModelState.AddModelError("", "Invalid nama and password");
                return View();
            }                
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(Users model)
        {
            using (var context = new UsersEntities())
            {
                context.Users1.Add(model);
                context.SaveChanges();
            }
                return RedirectToAction("Login") ;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}