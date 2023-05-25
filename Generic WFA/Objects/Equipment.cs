using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_WFA.Objects
{
    public class Equipment
    {
        private int _id;
        private string  _equipmentname;
        private string _brand;
        private DateTime _year_installed;
        private DateTime _createddate;
        private string _manufacturer;

        public int ID { get { return _id; } set { _id = value; } }
        public string Name { get { return _equipmentname; } set { _equipmentname = value; } }

        public string Brand { get { return _brand; } set { _brand = value; } }

        public DateTime YearInstalled { get { return _year_installed; } set { _year_installed = value; } }

        public DateTime CreatedDate { get { return _createddate; } set { _createddate = value; } }

        public string Manufacturer { get { return _manufacturer; } set { _manufacturer = value; } }



    }
}
