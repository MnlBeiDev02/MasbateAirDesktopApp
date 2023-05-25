using DB_Helper;
using DGVPrinterHelper;
using Generic_WFA.Functions.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generic_WFA.Functions.Common
{
    class ReportFunction : BaseFunction
    {
        public static DataTable GetReports(string date = "")
        {
            var results = new DataTable();

            //var monitoringDetails = MonitoringFunction.GetMonitoringDetails();
             string query = string.Empty;
            if (!string.IsNullOrWhiteSpace(date))
                query = string.Format("SELECT equipment_type,equipment_name,brand,specification,availability,status FROM Monitoring WHERE processed_date LIKE '%{0}%' ORDER BY processed_date DESC", date);
            else 

          query = string.Format("SELECT equipment_type,equipment_name,brand,specification,availability,status FROM Monitoring WHERE processed_date LIKE '%{0}%' ORDER BY processed_date DESC",DateTime.Now.Year.ToString());

          var monitoringDetails = Queries.GetDatas(query, "Monitoring");

            results = ConvertToDataTable(monitoringDetails);

            return results;
        }


        //public static DataTable GetMonitoringDetails()
        //{
        //    var results = new DataTable();
        //    var monitoringDetails = Queries.GetDatas("SELECT ID,equipment_name AS Equipment,brand,specification,availability,status,processed_date,equipment_type FROM Monitoring ORDER BY processed_date", "Monitoring");

        //    results = ConvertToDataTable(monitoringDetails);

        //    return results;
        //}

        public static void PrintReport(DataGridView dgv,string perCompliment, string accomplishments, string remarks,string year)
        {
            var listPersonnel = perCompliment.Split(Environment.NewLine.ToCharArray());
            var listAccomplish = accomplishments.Split(Environment.NewLine.ToCharArray());
            var listRemarks = remarks.Split(Environment.NewLine.ToCharArray());

            DGVPrinter printer = new DGVPrinter();
            
            StringBuilder title = new StringBuilder();
            title.Append("ANNUAL REPORT OF MASBATE AIRPORT");
            title.Append(Environment.NewLine);
            title.Append(string.Format("YEAR {0} ", year));
            printer.Title = title.ToString();
            StringBuilder sb = new StringBuilder();

            printer.SubTitleFont = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
            printer.SubTitleAlignment = StringAlignment.Near;
            sb.Append(Environment.NewLine);
            sb.Append("I.PERSONNEL COMPLEMENT");
            sb.Append(Environment.NewLine);
            foreach (var personnel in listPersonnel)
            {
                if (!string.IsNullOrWhiteSpace(personnel))
                {
                    sb.Append("    " + personnel);
                    sb.Append(Environment.NewLine);
                }
              
            }
            //sb.Append("    " + perCompliment);
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            //sb.Append("");
            sb.Append("II.FACILITY OPERATION");
            printer.SubTitle = "  " + sb.ToString();//text area 
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            //printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Center;
            //printer.FooterBorder = Pens.AliceBlue;

            sb = new StringBuilder();
            sb.Append("III. ACCOMPLISHMENTS");
            sb.Append(Environment.NewLine);

            foreach (var accomplish in listAccomplish)
            {
                if (!string.IsNullOrWhiteSpace(accomplish))
                {
                    sb.Append("  " + accomplish);
                    sb.Append(Environment.NewLine);
                }
                
            }
           
           
            sb.Append(Environment.NewLine);
            sb.Append("IV.REMARKS AND RECOMMENDATIONS");
            //sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            foreach (var remark in listRemarks)
            {
                if (!string.IsNullOrWhiteSpace(remark))
                {
                    sb.Append("  " + remark);
                    sb.Append(Environment.NewLine);
                }
               
            }
            
            printer.FooterFont = new Font("Arial", 9, FontStyle.Regular, GraphicsUnit.Point);
            printer.FooterAlignment = StringAlignment.Near;

            //sb.Append(string.Format("Total : {0}",dgv.RowCount.ToString()));
            //sb.Append(Environment.NewLine);
            
            printer.Footer = sb.ToString();
            printer.FooterSpacing = 15;
            

            printer.PrintColumnHeaders = true;

            if (dgv.ColumnCount > 0 && dgv.RowCount > 0)
                printer.PrintPreviewDataGridView(dgv);
            else MessageBox.Show("No Record shown");
        }
    }
}
