using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using DAL;
namespace LabExam.Controllers
{
    public class PizzaController : Controller
    {
        
        // GET: Pizza
        public ActionResult Index()
        {
            List<Pizza> abc = DBLayer.getPizza();
             
            return View(abc);
        }

        public ActionResult create(int id)
        {
            // Debug.WriteLine(id);
            //System.Diagnostics.Debug.WriteLine("Hello World");
            Pizza a = DBLayer.getPizzabyid(id);
            DBLayer.insertPizza(a);    
            return RedirectToAction("Index", "Pizza");
        }

        public ActionResult Showcart()
        {
            

            return View();
        }
    }
}