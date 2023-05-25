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
        public static List<dynamic> GetDatas (string query ,string table, string criteria = "")
        {
            var results = new List<dynamic>();
            Conn = GetUsedConnString();
            //ConnectDB();
            string queryStr = !string.IsNullOrWhiteSpace(criteria) ?  query + table + criteria : query + ";" + table;
            
            //ExecuteQuery(queryStr);
            using (var conn = new OleDbConnection(Conn))
            {
                conn.Open();
                using (var comm = new OleDbCommand(query,conn ))
                {
                    comm.CommandType = CommandType.Text;
                    
                    try
                    {

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
                                    element.Add(columnNames.ElementAt(i), reader.GetValue(i));

                                if (element.Any()) results.Add(element);

                                readCount++;


                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        conn.Close();
                        throw ex;
                    }
                    conn.Close();
                }
                
            }

            return results;
        }

        public static void InsertData(string column, string table, string values)
        {
            Conn = GetUsedConnString();

            var insertQuery = string.Format("INSERT INTO {0} ( {1} ) VALUES ( {2})",table,column,values);

            using(var conn = new OleDbConnection(Conn))
        	{
		
                using (var comm = new OleDbCommand(insertQuery, conn  )) {

                comm.CommandType = CommandType.Text;
                conn.Open();
                comm.ExecuteNonQuery();
                conn.Close(); 
            
            }
 
	    }
           
        }

        public static void UpdateData(string query)
        {
            Conn = GetUsedConnString();
          


            var updateQuery = query;

            using (var conn = new OleDbConnection(Conn))
            {

                using (var comm = new OleDbCommand(updateQuery, conn))
                {

                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();

                }
            }
        }

        public static void DeleteData(int id)
        {
            var delQuery = string.Format("DELETE FROM [User] WHERE id ={0}", id);

            using (var conn = new OleDbConnection(Conn))
            {

                using (var comm = new OleDbCommand(delQuery, conn))
                {

                    comm.CommandType = CommandType.Text;
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();

                }

            }
        }
    }

    
}
