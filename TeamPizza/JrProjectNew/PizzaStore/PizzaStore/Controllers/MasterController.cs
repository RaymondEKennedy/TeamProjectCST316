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
        public static PizzaStore.Models.OrderInfo OurOrder; // If anyone asks blame lance for this line
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
            OurOrder = new PizzaStore.Models.OrderInfo();
            var v = HttpContext.Application["PizzaInfo"];
            
            ViewData["PizzaNames"] = v;

            if (Request["CustomerName"] != "")
           {
               OurOrder.CustomerName = Request["CustomerName"].ToString();
               OurOrder.CustomerPhone = Request["CustomerPhone"].ToString();
            
            }
//            else
 //           {
                
                
//            }

            string temp = Request["PizzaType"].ToString();
            
            

                List<PizzaStore.Models.Pizza> p = ( List<PizzaStore.Models.Pizza>) v;
                for (int i = 0; i < p.Count(); i++)
                {
                    if (p[i].name == temp)
                    {
                        OurOrder.PizzaName  = p[i].name;
                        OurOrder.PizzaPrice = p[i].price.ToString();
                    }
                }
                ViewData["test"] = OurOrder;
            return View();
        }
     
        public ActionResult Receipt(string name, string number)
        {
            
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
            svc.AddReceipt(OurOrder.CustomerName, OurOrder.CustomerPhone , OurOrder.PizzaName, OurOrder.PizzaPrice);
            
            // This is how you get all the orders back
            int i = svc.GetOrderCount();
            for (int k=0; k<i; k++)
            {
                string temp = svc.OrderGetCustomer(k);
                temp = svc.OrderGetPhone(k);
                temp = svc.OrderGetPizzaName(k);
                temp =  svc.OrderGetPizzaCost(k);

            }
            
            return View();
        }
    }
}