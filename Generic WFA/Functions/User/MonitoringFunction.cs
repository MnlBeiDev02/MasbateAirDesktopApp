using DB_Helper;
using Generic_WFA.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic_WFA.Functions.User
{
    class MonitoringFunction : BaseFunction
    {
        public static DataTable GetMonitoringDetails()
        {
            var results = new DataTable();
            var query = string.Format("SELECT ID,equipment_name AS Equipment,brand,specification,availability,status,processed_date,equipment_type FROM Monitoring  WHERE processed_date LIKE'%{0}%'  ORDER BY processed_date DESC", DateTime.Now.Year.ToString());
            var monitoringDetails = Queries.GetDatas(query, "Monitoring");

            results = ConvertToDataTable(monitoringDetails);

            return results;
        }

        public List<Equipment> GetEquipment()
        {
            var results = new List<Equipment>();

            var equipment = Queries.GetDatas("SELECT ID,equipment_name,brand FROM Equipment ORDER BY equipment_name ", "Equipment");

            results = (from equip in equipment

                       select new Equipment
                       {
                           ID = equip["ID"],
                           Name = equip["equipment_name"],
                           Brand = equip["brand"]
                       }).ToList();

            return results;
        }

        //public static void DeleteUser(int id)
        //{



        //    //If res = DialogResult.Yes Then
        //    //    MsgBox("Succesfully  saved!");
        //    if (id >= 1)
        //    {
        //        Queries.DeleteData(id);
        //    }

        //    //RefreshGrid();

        //}

        private static void RefreshGrid()
        {
            GetMonitoringDetails();
        }

        public static bool SaveMonitoringInfo(MonitoringDetails monitoring)
        {
            bool isSaved = false;

            var values = new List<string> { monitoring.EquipmentName,monitoring.Brand, monitoring.Specification,monitoring.Availability, monitoring.Status, monitoring.EquipmentType,monitoring.ProcessedDate.ToString() };

            var fValues = new List<string>();

            foreach (var item in values)
            {
                fValues.Add(string.Format("'{0}'", item));
            }
            try
            {

                if (monitoring.ID == 0)
                    Queries.InsertData("equipment_name,brand,specification,availability,status,equipment_type,processed_date", "Monitoring", string.Join(",", fValues));
                else

                    Queries.UpdateData(string.Format("UPDATE Monitoring SET equipment_name = '{0}' , brand = '{1}',specification = '{2}',availability = '{3}',status = '{4}',equipment_type = '{5}' WHERE ID = {6} ", monitoring.EquipmentName, monitoring.Brand, monitoring.Specification, monitoring.Availability, monitoring.Status, monitoring.EquipmentType, monitoring.ID));
                isSaved = true;
                //RefreshGrid();

            }
            catch (Exception ex)
            {

                isSaved = false;
            }

            return isSaved;

        } 

    }
}
