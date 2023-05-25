using Generic_WFA.Forms.Common;
using Generic_WFA.Forms.User;
using Generic_WFA.Functions;
using Generic_WFA.Functions.User;
using Generic_WFA.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equip = Generic_WFA.Forms.Common.Equipment;

namespace Generic_WFA.Forms.Administration
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Admin_Home_Load(object sender, EventArgs e)
        {

            //toolStripMenuItem1.Text = BaseFunction.UserName;
            //toolStripMenuItem1.ForeColor = Color.White;
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            dgvMonitoring.Visible = false;
            lblUserName.Text = BaseFunction.UserName;
            var userType = BaseFunction.UserType;
            homeToolStripMenuItem.BackColor = Color.White;
            homeToolStripMenuItem.ForeColor = Color.RoyalBlue;

            if (userType.Contains("user"))
            {
                //var monitoring = new M;
                usersToolStripMenuItem.Visible = false;
                btnAdd.Visible = true;
                btnUpdate.Visible = true;
                dgvMonitoring.Visible = true;
                dgvMonitoring.ForeColor = Color.Black;
                GetMonitoring();

            }
                
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userPage = new Users();
            this.Hide();
            userPage.Show();
        }

        private void equipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var equipmentWin = new Equip();
            equipmentWin.Show();
            this.Close();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new AdminUsers();
            login.Show();
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        public void GetMonitoring()
        {
            var monitoringList = MonitoringFunction.GetMonitoringDetails();
            if (monitoringList.Columns.Count > 0)
            {

                this.dgvMonitoring.DataSource = monitoringList;
                this.dgvMonitoring.Columns[0].Visible = false;
                this.dgvMonitoring.Columns[1].HeaderText = "EQUIPMENT";
                this.dgvMonitoring.Columns[1].HeaderCell.Style.Font = new Font("Century Gothic",9.75F,FontStyle.Bold);
                //this.dgvMonitoring.Font = Font.Bold;

                this.dgvMonitoring.Columns[2].HeaderText = "BRAND/MODEL";
                this.dgvMonitoring.Columns[2].HeaderCell.Style.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);

                this.dgvMonitoring.Columns[3].HeaderText = "SPECIFICATION";
                this.dgvMonitoring.Columns[3].HeaderCell.Style.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);

                this.dgvMonitoring.Columns[4].HeaderText = "AVAILABILITY";
                this.dgvMonitoring.Columns[4].HeaderCell.Style.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);

                this.dgvMonitoring.Columns[5].HeaderText = "STATUS";
                this.dgvMonitoring.Columns[5].HeaderCell.Style.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);

                this.dgvMonitoring.Columns[6].Visible = false;

                this.dgvMonitoring.Columns[7].HeaderText = "EQUIPMENT TYPE";
                this.dgvMonitoring.Columns[7].HeaderCell.Style.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold);
            }
            else
            {
                dgvMonitoring.Columns.Add("equipment", "Equipment");
                dgvMonitoring.Columns.Add("brand", "Brand/Model");
                dgvMonitoring.Columns.Add("availability", "Availability");
                dgvMonitoring.Columns.Add("status", "Status");
                dgvMonitoring.Columns.Add("equipmentType", "Equipment Type");
            }

            if (monitoringList.Rows.Count > 10 && monitoringList.Columns.Count > 10)
                this.dgvMonitoring.ScrollBars = ScrollBars.None;
            else this.dgvMonitoring.ScrollBars = ScrollBars.Both;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var modal = new MonitoringModal();

            modal.ShowDialog();
            GetMonitoring();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selected = new object();

            var monitoring = new MonitoringDetails();
            var updateMonDetails = new MonitoringFunction();
            var modal = new MonitoringModal();

            if (dgvMonitoring.SelectedRows.Count == 1)
            {

                if (dgvMonitoring.SelectedCells.Count > 1)
                {
                    monitoring.ID = int.Parse(dgvMonitoring.SelectedCells[0].Value.ToString());
                    monitoring.EquipmentName = dgvMonitoring.SelectedCells[1].Value.ToString();
                    monitoring.Brand = dgvMonitoring.SelectedCells[2].Value.ToString();
                    monitoring.Specification = dgvMonitoring.SelectedCells[3].Value.ToString();
                    monitoring.Availability = dgvMonitoring.SelectedCells[4].Value.ToString();
                    monitoring.Status = dgvMonitoring.SelectedCells[5].Value.ToString();
                    monitoring.EquipmentType = dgvMonitoring.SelectedCells[7].Value.ToString();

                    //2 pass
                    //3 usertype
                    //4 created_on
                    //5 department



                    //userModal.Show();
                    modal.ShowMonitoringModal(monitoring);
                    GetMonitoring();
                    //UserFunction.SaveUser(userDetails);
                }
                else
                {
                    selected = dgvMonitoring.CurrentCell.Value;
                }

            }
            //else MessageBox.Show("Select only one row");
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Refresh();
            GetMonitoring();
            this.Show();
        }

        private void toolStripReport_Click(object sender, EventArgs e)
        {
            this.Close();
            var reportWin = new Report();
            reportWin.Show();
        }

        private void instrumentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var aboutPage = new About();
            aboutPage.Show();
        }

        private void userLabel_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvMonitoring_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }
    }
}
