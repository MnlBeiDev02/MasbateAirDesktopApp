using DB_Helper;
using Generic_WFA.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using draw = System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;
using media = System.Windows.Media;
using System.Windows;

namespace Generic_WFA.Functions
{
     class BaseFunction
    {
         private static  int _userId;
         private static  string _userType;
         private static  string _username;
         private static string _department;
         public static int UserID { get { return _userId; } }
         public static string UserType { get { return _userType; } }
         public static string UserName { get { return _username; } }

         public static string Department { get { return _department; } }


            public static UserDetails GetUserDetails(string userName, string pass ,string id = "")
            {

                var fields  = !String.IsNullOrWhiteSpace(id) ? string.Format("SELCT userName,password,Id FROM User WHERE Id = {0}",id) : string.Format("SELECT * FROM [User] WHERE username = '{0}'",userName);
                var userDetail = Queries.GetDatas(fields, "user").FirstOrDefault();

                var userInfo = userDetail != null ? new UserDetails { UserID = userDetail["ID"], UserName = userDetail["username"], UserType = userDetail["usertype"],Password = userDetail["password"] } : null;
 
                 if (userInfo != null){
                     _userId = userInfo.UserID;
                     _userType = userInfo.UserType;
                     _username = userInfo.UserName;
                     _department = userInfo.Departmnent;
                 } 

                return userInfo;
            }



            public static DataTable ConvertToDataTable(List<dynamic> items)
            {
                var data = items.ToArray();
                if (data.Count() == 0) return null;

                var dt = new DataTable();
                foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
                {
                    dt.Columns.Add(key);
                }
                foreach (var d in data)
                {
                    dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
                }
                return dt;
            }
            public static string GetEncryptedData(string pass)
            {
                return EncryptData(pass);
            }

            public static string GetDecryptedData(string pass)
            {
                return DecryptData(pass);
            }

           
            private static string DecryptData(string encryptedPassword)
            {
                string initVector = "@1B2c3D4e5F6g7H8";
                string userCryptKey = "@rindj";

                var rijndaelKey = new CryptographyRijndael(userCryptKey, initVector);

                return rijndaelKey.Decrypt(encryptedPassword);
            }

            private static string EncryptData(string password)
            {
                string initVector = "@1B2c3D4e5F6g7H8";
                string userCryptKey = "@rindj";
                var rijndaelKey = new CryptographyRijndael(userCryptKey, initVector);

                return rijndaelKey.Encrypt(password);
            }

            public static void PrintDGV(DataGridView dgv, System.Drawing.Printing.PrintPageEventArgs e)
            {

                //Graphics graphic = e.Graphics;
                //Bitmap bm = new Bitmap(dgv.Width, dgv.Height);

                //graphic.DrawString("Sample", new Font("Times New Roman",14,FontStyle.Bold),Brushes.Black,20,50);

                //int strPos = 225;
                //for (int i = 0; i < dgv.RowCount;i++)
                //{

                //foreach (var row in dgv.Rows[i])
                ////{
                //    string text = dgv.Rows[i].Cells["username"].Value.ToString(); //or whatever you want from the current row
                //    if (strPos == 225)
                //    {

                //        strPos = strPos + 1;
                //        graphic.DrawString(text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 20, strPos);

                //    }
                //    else
                //    {
                //        strPos  = strPos + 1;
                //        graphic.DrawString(text, new Font("Times New Roman", 14, FontStyle.Bold), Brushes.Black, 21, 227);
                //    } 


                //}

                //}



                //dgv.DrawToBitmap(bm, new Rectangle(0, 0, dgv.Width, dgv.Height));

                //e.Graphics.DrawImage(bm, 0, 0);
                //}
            }
   }
}
