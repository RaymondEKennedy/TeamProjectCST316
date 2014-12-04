using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStore.Models
{
    public class PizzaStore
    {
        public List<Pizza> MasterList;
        public List<Order> MasterOrders;

        public PizzaStore()
        {
            // This should now pull from the database the 5 static pizzas and the orders.
            
        }
    }
}