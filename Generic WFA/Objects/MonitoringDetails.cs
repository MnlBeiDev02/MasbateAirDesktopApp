using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_WFA.Objects
{
    public class MonitoringDetails
    {
        private int _id;
        private string _brand;
        private string _specification;
        private string _availability;
        private DateTime _processedDate;
        private string _status;
        private string _equipmentType;
        private string _equipmentName;
        public int ID { get { return _id; } set { _id = value; } }
        public string Brand { get { return _brand; } set { _brand = value; } }

        public string Specification { get { return _specification; } set { _specification = value; } }

        public DateTime ProcessedDate { get { return _processedDate; } set { _processedDate = value; } }

        public string Status { get { return _status; } set { _status = value; } }

        public string Availability { get { return _availability; } set { _availability = value; } }
        public string EquipmentType { get { return _equipmentType; } set { _equipmentType = value; } }

        public string EquipmentName { get { return _equipmentName; } set { _equipmentName = value; } }
      
    }
}
