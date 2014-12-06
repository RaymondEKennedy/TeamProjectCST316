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
            string temp = Request["PizzaType"].ToString();
            
            

                List<PizzaStore.Models.Pizza> p = ( List<PizzaStore.Models.Pizza>) v;
                for (int i = 0; i < p.Count(); i++)
                {
                    if (p[i].name == temp)
                    {
                        OurP.MyPizza = p[i];
                    }
                }
                ViewData["test"] = OurP;
            return View();
        }
     
        public ActionResult Receipt(string name, string number)
        {
            //OurP Should be sent to the database right here. 

            return View();
        }
    }
}