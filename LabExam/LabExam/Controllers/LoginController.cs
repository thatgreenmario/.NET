using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using BOL;

namespace LabExam.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(string username,string password)
        {
            List<User> userlist = DBLayer.getAll();
            foreach(User a in userlist)
            {
                if ((a.UserEmail).Equals(username) && (a.UserPassword).Equals(password))
                {
                    Session["user"] = a.UserId;
                    return RedirectToAction("Index", "Pizza");
                }
            }

            return View("Index");
            //ViewData["name"] = username;


        }
    }

        
}