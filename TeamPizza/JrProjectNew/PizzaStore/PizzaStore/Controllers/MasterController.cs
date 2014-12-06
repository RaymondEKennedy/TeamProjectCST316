using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaStore.Models;
using System.Web.UI;


namespace PizzaStore.Controllers
{
    
    
    public class MasterController : Controller
    {
        public static PizzaStore.Models.Order OurP; // If anyone asks blame lance for this line
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
        public ActionResult Checkout(string test)
        {
            OurP = new PizzaStore.Models.Order();
            var v = HttpContext.Application["PizzaInfo"];
            ViewData["PizzaNames"] = v;
            Customer coolKid= new Customer();
            coolKid.CustomerName = Request["CustomerName"].ToString();
            coolKid.PhoneNumber = Request["CustomerPhone"].ToString();
            OurP.MyCustomer = coolKid;
            OurP.pizzaName = Request["PizzaType"].ToString();
            return View();
        }
     
        public ActionResult Receipt(string name, string number)
        {
            //There should now be a ViewData[] for CustomerName from the order Price from the order and pizza name from the order; - RLR
            return View();
        }
    }
}