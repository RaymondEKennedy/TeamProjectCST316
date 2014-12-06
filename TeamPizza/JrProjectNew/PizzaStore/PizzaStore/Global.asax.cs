using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using PizzaStore.Models;


namespace PizzaStore
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            List<Pizza> m_pizza = new List<Pizza>();           

            ServiceReference1.Service1Client svc = new ServiceReference1.Service1Client();
            
            Application["SVC"] = svc;
            svc.LoadData();
            for (int i = 0; i < svc.GetPizzaCount(); i++)
            {
               Pizza p = new Pizza();
               p.name = svc.GetPizzaName(i);
               p.description = svc.GetPizzaDescription(i);
               p.price = svc.GetPizzaPrice(i);
               
               m_pizza.Add(p);               
            }
            Application["PizzaInfo"] = m_pizza;
        }
    }
}
