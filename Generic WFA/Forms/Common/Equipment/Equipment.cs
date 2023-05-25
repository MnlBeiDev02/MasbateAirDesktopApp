using Generic_WFA.Forms.Administration;
using Generic_WFA.Functions;
using Generic_WFA.Functions.Common;
using Generic_WFA.Functions.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equip = Generic_WFA.Objects;
namespace Generic_WFA.Forms.Common
{
    public partial class Equipment : Form
    {
        public Equipment()
        {
            InitializeComponent();
        }

        private void Equipment_Load(object sender, EventArgs e)
        {
            lblUserName.Text = BaseFunction.UserName;
            equipmentsToolStripMenuItem.BackColor = Color.White;
            equipmentsToolStripMenuItem.ForeColor = Color.RoyalBlue;
            
            GetEquipment();

            var userType = BaseFunction.UserType;
            if (userType.Contains("user"))
            {
                //var monitoring = new M;
                usersToolStripMenuItem.Visible = false;
                
            }
        }

        private void GetEquipment()
        {
            var equipment = EquipmentFunction.GetEquipment();
            dgvMonitoring.DataSource = equipment;
            this.dgvMonitoring.Columns[0].Visible = false;
            this.dgvMonitoring.Columns[1].HeaderText = "Equipment";
            this.dgvMonitoring.Columns[2].HeaderText = "Brand/Model";
            this.dgvMonitoring.Columns[3].HeaderText = "Year Installed";
            this.dgvMonitoring.Columns[4].HeaderText = "Manufacturer";

          
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var equipmentModal = new EquipmentModal();

           
            //this.dgvMonitoring.Columns[5].HeaderText = "Department";
            equipmentModal.ShowDialog();
            GetEquipment();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var selected = new object();

            var equipment = new Equip.Equipment();
            var updateEquipment = new EquipmentFunction();
            var modal = new EquipmentModal();

            if (dgvMonitoring.SelectedRows.Count == 1)
            {

                if (dgvMonitoring.SelectedCells.Count > 1)
                {
                    equipment.ID = int.Parse(dgvMonitoring.SelectedCells[0].Value.ToString());
                    equipment.Name = dgvMonitoring.SelectedCells[1].Value.ToString();
                    equipment.Brand = dgvMonitoring.SelectedCells[2].Value.ToString();
                    equipment.YearInstalled = DateTime.Parse(dgvMonitoring.SelectedCells[3].Value.ToString());
                    equipment.Manufacturer = dgvMonitoring.SelectedCells[4].Value.ToString();
                   
                  



                    //userModal.Show();
                    modal.ShowEquipmentModal(equipment);
                    GetEquipment();
                    //UserFunction.SaveUser(userDetails);
                }
                else
                {
                    selected = dgvMonitoring.CurrentCell.Value;
                }

            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var homePage = new Home();
            homePage.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var users = new Users();
            users.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new AdminUsers();
            login.Show();

        }

        private void equipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var equipmentWindow = new Equipment();
            equipmentWindow.Show();
        }

        private void toolStripReport_Click(object sender, EventArgs e)
        {
            this.Close();
            var reportWindow = new Report();
            reportWindow.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var aboutWindow = new About();
            aboutWindow.Show();
        }
    }
}
