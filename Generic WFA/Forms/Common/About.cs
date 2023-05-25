using Generic_WFA.Forms.Administration;
using Generic_WFA.Functions;
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

namespace Generic_WFA.Forms.Common
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label41_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void About_Load(object sender, EventArgs e)
        {
            lblUserName.Text = BaseFunction.UserName;
            aboutToolStripMenuItem.BackColor = Color.White;
            aboutToolStripMenuItem.ForeColor = Color.RoyalBlue;
        }

        private void equipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var equipment = new Equip();
            equipment.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var users = new AdminUsers();
            users.Show();
        }

        private void toolStripReport_Click(object sender, EventArgs e)
        {
            this.Close();
            var report = new Report();
            report.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var homeWindow = new Home();
            homeWindow.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var loginWindow = new AdminUsers();
            loginWindow.Show();
        }
    }
}
