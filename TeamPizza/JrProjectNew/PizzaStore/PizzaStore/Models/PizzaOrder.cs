using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStore.Models
{
    public class PizzaOrder
    {
        
        public List<Pizza> PizzaList;
        public PizzaOrder()
        {
            PizzaList = new List<Pizza>();
        }        
    }
    
    public class Pizza
    {
        public string PizzaName { get; set; }
        public List<Topping> myTopping { get; set; }
        public int Price { get; set;}
    }

    public class Topping
    {
        public string ToppingName { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
    }
}