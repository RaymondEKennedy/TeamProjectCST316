using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Ray's.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Ray's Pizza.";

            return View();
        }
    }
}