using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_Helper
{
    public class DBConfiguration
    {
        enum Provider 
        { MySql,MSSql,MSAccess }

        public static string ConnectionString { get;set; }
        public static dynamic Conn { get; set; }
        public static dynamic Comm { get; set; }

        public static string ProviderName { get; set; }
        public static void ConnectDB()
        {
            int provId = 0;
              ConnectionString = GetUsedConnString(out provId);
             
            
             try
             {
                 switch (provId)
                 {
                     case (int)Provider.MySql:
                         //con = instansiate Mysql Class
                         break;

                     case(int)Provider.MSSql:
                         //con = Instansiate MS Sql Class
                         break;
                     
                     case (int)Provider.MSAccess:
                         Conn = new OleDbConnection(ConnectionString);
                         ProviderName = Provider.MSAccess.ToString(); 
                         break;
                 }
                 
             }
             catch (Exception ex)
             {
                 
                 throw ex;
             }
            

        }

        public static void ExecuteQuery(string query)
        {
            try
            {
                using (var comm = new OleDbCommand(query,Conn))
                {
                    comm.CommandType = CommandType.Text;
                    Conn.Open();
                    Conn.ExecuteNonQuery(query);
                    Conn.Close();
    
                }
                
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        private static string GetUsedConnString(out int provId)
        {
            var uconStr = string.Empty;
            provId = 0;

            var _lstConStr = ConfigurationManager.ConnectionStrings;

            string uConstr = string.Empty;

            foreach (var conStr in _lstConStr) 
            {

                if (string.IsNullOrWhiteSpace(conStr.ToString()))
                {
                    uConstr = conStr.ToString();

                    if (conStr.ToString().Contains("Mysql")) provId = 0;
                    else if (conStr.ToString().Contains("Oledb")) provId = 1;
                    else provId = 2;
                }
                

            }

            if (string.IsNullOrWhiteSpace(uConstr))
            {
                
                string errorMsg = "Connection string not present";

                return errorMsg;
            }
              
            
            return uconStr;
        }


    }
}
