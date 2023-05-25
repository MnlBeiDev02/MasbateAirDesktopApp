using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB_Helper;
namespace Generic_WFA.Functions
{
    class Login : BaseFunction
    {

       
       public static bool ValidateUser(string userName,string pass,out bool isAdmin )
        {
            
             bool isValid;
             isAdmin = false;

             //var encryptedData = GetEncryptedData(pass);
             //var descryptedData = GetDecryptedData(encryptedData);

            var userDetail = GetUserDetails(userName, pass);
            
            if (userDetail != null)
            {
                var decryptedPass = GetDecryptedData(userDetail.Password);
                if (decryptedPass == pass)
                {
                    isValid = true;
                    if (userDetail.UserType.Contains("admin"))
                        isAdmin = true;
                }
                else isValid = false;
            }
            else isValid = false;

            return isValid;

        }

       


    }
}
