using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PizzaStore.Controllers
{
    public class MasterController : Controller
    {
        // GET: Master
        public ActionResult Splash()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Receipt()
        {
            return View();
        }
    }
}