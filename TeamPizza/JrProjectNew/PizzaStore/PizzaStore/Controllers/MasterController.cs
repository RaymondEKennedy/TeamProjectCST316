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
        public static PizzaStore.Models.Order OurOrder; // If anyone asks blame lance for this line
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
            OurOrder = new PizzaStore.Models.Order();
            var v = HttpContext.Application["PizzaInfo"];
            
            ViewData["PizzaNames"] = v;
            Customer coolKid= new Customer();
//            if (Request["CustomerName"] != null)
//            {
               coolKid.CustomerName = Request["CustomerName"].ToString();
               coolKid.PhoneNumber = Request["CustomerPhone"].ToString();
//            } 
            OurOrder.MyCustomer = coolKid;
            string temp = Request["PizzaType"].ToString();
            
            

                List<PizzaStore.Models.Pizza> p = ( List<PizzaStore.Models.Pizza>) v;
                for (int i = 0; i < p.Count(); i++)
                {
                    if (p[i].name == temp)
                    {
                        OurOrder.MyPizza = p[i];
                    }
                }
                ViewData["test"] = OurOrder;
            return View();
        }
     
        public ActionResult Receipt(string name, string number)
        {
            //OurOrder Should be sent to the database right here. 
            //AddReceipt
            //ServiceReference1.Service1Client  svc = (ServiceReference1.Service1Client) ViewData["SVC"];
            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
            svc.AddReceipt(OurOrder.MyCustomer.CustomerName,OurOrder.MyCustomer.PhoneNumber,OurOrder.MyPizza.name,OurOrder.MyPizza.price.ToString());
            //svc.AddReceipt("CName","CNumber","PizzaName","Price");
            return View();
        }
    }
}