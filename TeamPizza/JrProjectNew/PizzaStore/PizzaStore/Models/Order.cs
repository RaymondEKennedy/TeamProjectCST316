using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PizzaStore.Models
{
    public class Order
    {
        public Pizza MyPizza;
        public Customer MyCustomer;
        public int MyId;
        public Order()
        {
            //pull customer and pizza from database;
        }
    }
    

    public class Customer
    {
        public string CustomerName;
        public int CustomerId;
        public string PhoneNumber;

        public Customer()
        {
            CustomerName = null;
            PhoneNumber = null;
        }

        public Customer(string na, string nu)
        {
            CustomerName = na;
            PhoneNumber = nu;
            //should be created from controller
        }
    }
}