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
     

    public class Service1 : IService1
    {
        private static List<String> PizzaNames = new List<String>(); 
        
        
        public String GetData(int value)
        {
            if (value > PizzaNames.Count())
                return "";
            return PizzaNames[value];
        }

        public void LoadData()
        {
            PizzaNames.Clear();
            OleDbConnection connect = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\Rosen\Documents\GitHub\TeamProjectCST316\TeamPizza\JrProjectNew\TeamPizzaDB\PizzaAccessDB.accdb");
            connect.Open();
            OleDbCommand cmd = new OleDbCommand("select PizzaName from PizzaTypes;", connect);
            OleDbDataReader reader = cmd.ExecuteReader();
            
            while (reader.Read())
            {
                PizzaNames.Add((string)reader["PizzaName"]);                
            }            
        }


        public int GetPizzaCount()
        {
            return PizzaNames.Count();
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
