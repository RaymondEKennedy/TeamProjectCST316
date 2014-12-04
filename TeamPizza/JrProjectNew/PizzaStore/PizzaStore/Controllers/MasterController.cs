using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStore.Models;



namespace PizzaStore.Controllers
{
    
    
    public class MasterController : Controller
    {
        // Use ViewData[] to pass info to the view. 
        // Use Session or the DB to pass things between controllers/views
        // If all else fails make a global.
        // Do not use Goto Lance -RLR
        public ActionResult Splash()
        {
           
            // use ViewData[] to store the master list of pizzas and display them pass the resulting choice ethier via Query string or Session
            //So something like ViewData["MyList"] = PizzaStore.Models.PizzaStore.MasterList -RLR
            var v = HttpContext.Application["PizzaInfo"];
            ViewData["PizzaNames"] = v;
            return View();
        }
        public ActionResult Checkout()
        {
            //this should take the info from the customer post it to the DB; -RLR
            return View();
        }
        public ActionResult Receipt()
        {
            //There should now be a ViewData[] for CustomerName from the order Price from the order and pizza name from the order; - RLR
            return View();
        }
    }
}