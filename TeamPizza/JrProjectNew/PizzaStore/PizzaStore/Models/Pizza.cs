using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStore.Models
{
    public class Pizza
    {
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }

        public Pizza(string n, string desc, double p)
        {
            name = n;
            description = desc;
            price = p;
        }

        public Pizza()
        {
            name = "";
            description = "";
            price = 0;
        }
    }
}