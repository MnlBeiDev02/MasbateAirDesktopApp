using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_WFA.Objects
{
    public class UserDetails
    {
        private int _userID;
        private string _userName;
        private string _userType;
        private DateTime _createdDate;
        private string _department;
        private string _password;
        public int UserID { get { return _userID; } set { _userID = value; } }
        public string UserName { get { return _userName; } set { _userName = value; } }

        public string UserType { get { return _userType; } set { _userType = value; } }

        public DateTime CreatedDate { get { return _createdDate; } set { _createdDate = value; } }

        public string Departmnent { get { return _department; } set { _department = value; } }

        public string Password { get { return _password; } set { _password = value; } }
    }
}
