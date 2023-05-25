using Generic_WFA.Forms.Administration;
using Generic_WFA.Functions;
using Generic_WFA.Functions.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LoginForm = Generic_WFA.Forms.Common;

namespace Generic_WFA.Forms.Common
{
    public partial class Report : Form
    {
        public Report()
        {
            InitializeComponent();
        }

        private void SetUpHeaders(int rowCount)
        {

            if (rowCount > 0)
            {
                //this.dgvReport.Columns[0].Visible = false;

                this.dgvReport.Columns[0].HeaderText = "EQUIPMENT TYPE";
                this.dgvReport.Columns[0].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);

                this.dgvReport.Columns[1].HeaderText = "EQUIPMENT ";
                this.dgvReport.Columns[1].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);

                this.dgvReport.Columns[2].HeaderText = "BRAND/MODEL";
                this.dgvReport.Columns[2].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);

                this.dgvReport.Columns[3].HeaderText = "SPECIFICATION";
                this.dgvReport.Columns[3].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);

                this.dgvReport.Columns[4].HeaderText = "AVAILABILITY";
                this.dgvReport.Columns[4].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);

                this.dgvReport.Columns[5].HeaderText = "STATUS";
                this.dgvReport.Columns[5].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
                
            } 
            else
            {
                dgvReport.Columns.Add("equipmentType", "EQUIPMENT TYPE");
                this.dgvReport.Columns[0].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);

                dgvReport.Columns.Add("equipment", "EQUIPMENT");
                this.dgvReport.Columns[1].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);

                dgvReport.Columns.Add("brand", "BRAND/MODEL");
                this.dgvReport.Columns[2].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);

                dgvReport.Columns.Add("availability", "AVAILABILITY");
                this.dgvReport.Columns[3].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);

                dgvReport.Columns.Add("status", "STATUS");
                this.dgvReport.Columns[4].HeaderCell.Style.Font = new Font("Century Gothic", 8.25F, FontStyle.Bold);
              
            }
           



            totalCnt.Text = dgvReport.RowCount.ToString();
        }
        public void GetMonitoring(string date ="")
        {
            if(dgvReport != null && dgvReport.Columns.Count > 0)
                dgvReport.Columns.Clear();

            var monitoringList  = new DataTable();
            if (string.IsNullOrWhiteSpace(date))
            {

                monitoringList = ReportFunction.GetReports();

                if (monitoringList.Columns.Count > 0){
                    dgvReport.DataSource = monitoringList;
                    SetUpHeaders(monitoringList.Rows.Count);
                }
                    
                 else  SetUpHeaders(0);
              
            }
            else
            {
                monitoringList = ReportFunction.GetReports(dateTimePicker1.Value.Year.ToString());

                if (monitoringList != null){
                    dgvReport.DataSource = monitoringList;
                    SetUpHeaders(monitoringList.Rows.Count);
                }


                else
                {
                    
                    SetUpHeaders(0);

                }
                    
                dgvReport.DataSource = monitoringList;
            }


            if (monitoringList != null && monitoringList.Rows.Count > 10 && monitoringList.Columns.Count > 10)
                this.dgvReport.ScrollBars = ScrollBars.None;
            else this.dgvReport.ScrollBars = ScrollBars.Both;
        }
        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var homePage = new Home();
            homePage.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
         
            if (!string.IsNullOrWhiteSpace(textPC.Text) && !string.IsNullOrWhiteSpace(txtAcc.Text) && !string.IsNullOrWhiteSpace(txtRar.Text))
            {
                ReportFunction.PrintReport(dgvReport, textPC.Text, txtAcc.Text, txtRar.Text, dateTimePicker1.Value.Year.ToString());

                textPC.Clear();
                txtAcc.Clear();
                txtRar.Clear();

            }
                
            else MessageBox.Show("Fields are required", "",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void toolStripReport_Click(object sender, EventArgs e)
        {
            this.Close();
            var reportWin = new Report();
            reportWin.Show();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            lblUserName.Text = BaseFunction.UserName;
            GetMonitoring();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy";
            dateTimePicker1.ShowUpDown = true;

            toolStripReport.BackColor = Color.White;
            toolStripReport.ForeColor = Color.RoyalBlue;

            var userType = BaseFunction.UserType;

            if (userType.Contains("user"))
            {
                //var monitoring = new M;
                usersToolStripMenuItem.Visible = false;
                GetMonitoring();

            }
        }

        private void dgvReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void equipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var equipmentWin = new Equipment();
            this.Close();
            equipmentWin.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new AdminUsers();
            login.Show();
           
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            GetMonitoring(dateTimePicker1.Value.Year.ToString()); //ReportFunction.GetReports(dateTimePicker1.Value.Year.ToString());
            if (dgvReport == null || dgvReport.RowCount == 0)
                totalCnt.Text = "0";
                
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var users = new Users();
            users.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var aboutWin = new About();
            aboutWin.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
