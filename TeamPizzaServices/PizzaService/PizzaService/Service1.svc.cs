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

    public class Service1 : IService1
    {
        
        static private List<PizzaInfo> PizzaData = new List<PizzaInfo>(); 
        
        
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
            connect.Open();
            OleDbCommand cmd = new OleDbCommand("insert into Orders(CustomerName, CustomerPhone, PizzaName, PizzaPrice) Values ('" + CustomerName + "','" + CustomerPhone + "','" + PizzaName + "','" + Price + "')", connect);
            
            cmd.Parameters.AddWithValue("@CustomerName", CustomerName);
            cmd.Parameters.AddWithValue("@CustomerPhone", CustomerPhone);
            cmd.Parameters.AddWithValue("@PizzaName", PizzaName);
            cmd.Parameters.AddWithValue("@PizzaPrice", Price);
            cmd.ExecuteNonQuery();
            connect.Close();
        }


        public int GetPizzaCount()
        {
            return PizzaData.Count();
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
