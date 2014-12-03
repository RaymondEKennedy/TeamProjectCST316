using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaStore.Controllers
{
    public class PizzaController : Controller
    {
        //
        // GET: /Pizza/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pizza()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Order()
        {
            return View();
        }
	}
}