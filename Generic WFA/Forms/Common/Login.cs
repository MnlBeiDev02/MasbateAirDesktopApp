using Generic_WFA.Forms.Administration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Generic_WFA.Functions;

namespace Generic_WFA
{
    public partial class AdminUsers : Form
    {
        public AdminUsers()
        {
            InitializeComponent();
        }
        private int logAttempts { get; set; }
        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;

                        
            if (logAttempts <= 2)
            {
                bool isAdmin = false;
                var isValid = Login.ValidateUser(userName.Trim(), password.Trim(), out isAdmin);

                if (isValid)
                {
                    var homePage = new Home();
                    

                    MessageBox.Show("Login Successfully!");
                    logAttempts = 0;
                    if (isAdmin)
                    {
                      
                        this.Hide();
                        homePage.Show();    
                         
                        // Admin form
                    }
                    else
                    {
                        this.Hide();
                        homePage.Show();
                        // user form
                    }
                }

                else
                {

                    MessageBox.Show("Incorrect Password or Username");
                    logAttempts++;
                }



            }
            else
            {
                MessageBox.Show("Maximum login attempts exceeded , application terminated", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                this.Close();
            }
            
           
        }

        private void AdminUsers_Load(object sender, EventArgs e)
        {

        }
    }
}
