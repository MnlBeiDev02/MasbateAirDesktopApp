using DB_Helper;
using Generic_WFA.Forms.Administration;
using Generic_WFA.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generic_WFA.Functions.Administration
{
    class UserFunction : BaseFunction
    {
        public static DataTable GetUserDetails()
        {
            var results = new DataTable();
            var userDetails = Queries.GetDatas("SELECT ID,username,[password],usertype,department,created_date FROM [User] ORDER BY created_date", "user");

            results = ConvertToDataTable(userDetails);

            return results;
        }

        public static void DeleteUser(int id)
        {

           
            
                //If res = DialogResult.Yes Then
                //    MsgBox("Succesfully  saved!");
                if (id >= 1)
                {
                    Queries.DeleteData(id);
                }
            
            //RefreshGrid();

        }

        private static void RefreshGrid()
        {
            GetUserDetails();
        }

        public static void SaveUser(UserDetails user)
        {
            

            var values = new List<string> { user.UserName, GetEncryptedData(user.Password), user.UserType, user.Departmnent,user.CreatedDate.ToString() };

            var fValues = new List<string>();

            foreach (var item in values)
            {
                fValues.Add(string.Format("'{0}'", item));
            }

            if (user.UserID == 0)
                Queries.InsertData("username,[password],usertype,department,created_date", "[User]", string.Join(",", fValues));
            else
                if (user.Password == GetPassword(user.Password,user.UserID))
                    Queries.UpdateData(string.Format("UPDATE [User] SET username = '{0}',[password] = '{1}',usertype = '{2}',department = '{3}' WHERE ID = {4} ", user.UserName, user.Password, user.UserType, user.Departmnent, UserID));
            else 
                Queries.UpdateData(string.Format("UPDATE [User] SET username = '{0}',[password] = '{1}',usertype = '{2}',department = '{3}' WHERE ID = {4} ",user.UserName,GetEncryptedData( user. Password),user.UserType,user.Departmnent,UserID));
            //RefreshGrid();
        }

        private static string GetPassword(string pass, int id)
        {
            var userDetails = Queries.GetDatas(string.Format("SELECT [password] FROM [User] WHERE ID = {0} ", id), "user");

            return userDetails[0]["password"].ToString();

        }
    }
}
