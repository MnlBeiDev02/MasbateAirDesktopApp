using DB_Helper;
using Generic_WFA.Forms.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Equip  = Generic_WFA.Objects;

namespace Generic_WFA.Functions.Common
{
     class EquipmentFunction : BaseFunction
    {
        public static DataTable GetEquipment()
        {
            return Equipment();
        }

        private static DataTable Equipment()
        {
            var results = new DataTable();

            //var monitoringDetails = MonitoringFunction.GetMonitoringDetails();
            var equipment = Queries.GetDatas("SELECT ID,equipment_name,brand,year_installed,manufacturer FROM Equipment ORDER BY equipment_name ", "Equipment");

            results = ConvertToDataTable(equipment);

            return results;
        }
        public static void SaveEquipment(Equip.Equipment equipment)
        {


            var values = new List<string> { equipment.Name,equipment.Brand,equipment.YearInstalled.Year.ToString(),equipment.Manufacturer,equipment.CreatedDate.ToString()  };

            var fValues = new List<string>();

            foreach (var item in values)
            {
                fValues.Add(string.Format("'{0}'", item));
            }

            if (equipment.ID == 0)
                Queries.InsertData("equipment_name,brand,year_installed,manufacturer,created_date", "Equipment", string.Join(",", fValues));
            else

                Queries.UpdateData(string.Format("UPDATE Equipment SET equipment_name = '{0}',brand = '{1}',year_installed = '{2}',manufacturer = '{3}' WHERE ID = {4} ", equipment.Name, equipment.Brand, equipment.YearInstalled.Year.ToString(),equipment.Manufacturer,equipment.ID));
            //RefreshGrid();
        } 
    }
}
