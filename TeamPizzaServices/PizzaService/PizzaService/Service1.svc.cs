using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;



namespace PizzaService
{

     
    
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
     
    public class PizzaInfo
    {
        public String name;
        public String description;
        public Double price;
    }

    public class OrderInfo
    {
        public string CustomerName;
        public string CustomerPhone;
        public string PizzaName;
        public string PizzaPrice;
        public int OrderID;
    }


    public class Service1 : IService1
    {
        
        static private List<PizzaInfo> PizzaData = new List<PizzaInfo>();
        static private List<OrderInfo> OrderList = new List<OrderInfo>();
        
        
        public String GetData(int value)
        {
            if (value > PizzaData.Count())
                return "";
            
            return PizzaData[value].name;
        }

        public String GetPizzaName(int value)
        {
            if (value > PizzaData.Count())
                return "";

            return PizzaData[value].name;
        }

        public String GetPizzaDescription(int value)
        {
            if (value > PizzaData.Count())
                return "";

            return PizzaData[value].description;
        }

        public Double GetPizzaPrice(int value)
        {
            if (value > PizzaData.Count())
                return 0.0;

            return PizzaData[value].price;
        }


        public void LoadData()
        {
            PizzaData.Clear();

            OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|PizzaAccessDB.accdb");
            connect.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Pizzas;", connect);
            OleDbDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                String name = (String)reader["PizzaName"];
                String desc = (String)reader["Description"];
                String price = (String)reader["Price"];

                PizzaInfo piz = new PizzaInfo();
                piz.name = name;
                piz.description = desc;
                piz.price = Convert.ToDouble(price);
                PizzaData.Add(piz);                
            }            
        }
              

      public void AddReceipt(String CustomerName, String CustomerPhone, String PizzaName, String Price)
        {
            
            OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|PizzaAccessDB.accdb");            
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connect;
           
            cmd.Parameters.Add(new OleDbParameter("@CustomerName", CustomerName));
            cmd.Parameters.Add(new OleDbParameter("@CustomerPhone", CustomerPhone));
            cmd.Parameters.Add(new OleDbParameter("@PizzaName", PizzaName));
            cmd.Parameters.Add(new OleDbParameter("@PizzaPrice", Price));

            cmd.CommandText = "insert into Orders(CustomerName, CustomerPhone, PizzaName, PizzaPrice) Values (@CustomerName,@CustomerPhone,@PizzaName,@PizzaPrice)";
            connect.Open();            
            cmd.ExecuteNonQuery();
            connect.Close();
        }


        public int GetPizzaCount()
        {
            return PizzaData.Count();
        }

        public int GetOrderCount()
        {
            int iCount = 0;
            OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|PizzaAccessDB.accdb");
            connect.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Orders;", connect);
            OleDbDataReader reader = cmd.ExecuteReader();
            OrderList.Clear();


            while (reader.Read())
            {
                iCount++;
                OrderInfo order = new OrderInfo();
                order.CustomerName = (String)reader["CustomerName"];
                order.CustomerPhone  = (String)reader["CustomerPhone"];
                order.PizzaName = (String)reader["PizzaName"];
                order.PizzaPrice  = (String)reader["PizzaPrice"];
                order.OrderID = (int)reader["ID"];
                OrderList.Add(order);
            }
            return iCount;
        }

        public List<OrderInfo> GetAllOrders()
        {
            return OrderList;
        }


        public string OrderGetCustomer(int i)
        {
            return OrderList[i].CustomerName;

        }
        
        public string OrderGetPhone(int i)
        {
            return OrderList[i].CustomerPhone; 
        }

        public string OrderGetPizzaName(int i)
        {
            return OrderList[i].PizzaName;
        }

        public string OrderGetPizzaCost(int i)
        {
            return OrderList[i].PizzaPrice; 
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        
    }
}
