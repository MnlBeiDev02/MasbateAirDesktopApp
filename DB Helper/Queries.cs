using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
namespace DB_Helper
{
    public class Queries : DBConfiguration
    {
        public static List<dynamic> GetDatas (string query ,string table)
        {
            var results = new List<dynamic>();
            string queryStr = query + ";" + table;
            
            //ExecuteQuery(queryStr);
            
                using(var comm = new OleDbCommand(query,Conn))
                {
                    comm.CommandType = CommandType.Text;
                    Conn.Open();
                    using (var reader = comm.ExecuteReader())
                    {
                        var columnNames = new List<string>();
                        var readCount = 0;
                        var dict = new List<Dictionary<string, object>>();
                        while (reader.Read())
                        {
                            var element = new Dictionary<string, object>();
                            if (readCount == 0)
                                for (int i = 0; i < reader.FieldCount; i++) 
                                    columnNames.Add(reader.GetName(i));
                            for (int i = 0; i < columnNames.Count; i++) 
                                element.Add(columnNames.ElementAt(i),reader.GetValue(i));
                            
                               if(element.Any()) results.Add(element);

                            readCount++;
                        
                            
                        }
                        
                    }
                    Conn.Close();
                }
            

            return results;
        }

        public static void InsertData(string column, string table, string values)
        {
            var insertQuery = string.Format("INSERT INTO (table {0} ) VALUES (columns {1})",column,table);
           
        }

        public static void UpdateData(String columns, string table, string values)
        {

        }

        public static void DeleteData(string id, string table)
        {

        }
    }

    
}
