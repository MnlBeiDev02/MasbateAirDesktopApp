
using Generic_WFA.Functions.Administration;
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

namespace Generic_WFA.Forms.Administration.User
{
    public partial class UserModal : Form
    {
        public UserModal()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void ShowUserModal(UserDetails user)
        {

            if (user != null)
            {
                txtID.Text =  user.UserID.ToString();
                
                textUname.Text = user.UserName;
                textPass.Text = user.Password;
                txtReEnterPass.Text = user.Password;
                cBoxUType.Text = user.UserType;
                cBoxDepartment.Text = user.Departmnent;
            }

            this.ShowDialog();
        }
        private void UserModal_Load(object sender, EventArgs e)
        {
            //cBoxDepartment.Items.Add("Dept1");
            txtID.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var pass = textPass.Text;
            var cPass = txtReEnterPass.Text;

            if (!string.IsNullOrWhiteSpace(txtID.Text))
            {
                //Update
                

                if (pass == cPass && !string.IsNullOrWhiteSpace(textPass.Text) && !string.IsNullOrWhiteSpace(textUname.Text))
                {
                    var userDetails = new UserDetails
                    {
                        UserID = int.Parse(txtID.Text),
                        UserName = textUname.Text,
                        Password = textPass.Text,
                        UserType = cBoxUType.Text,
                        Departmnent = cBoxDepartment.Text,

                    };

                    UserFunction.SaveUser(userDetails);

                    this.Close();


                }
                
            }

            else
            {


                if (pass == cPass && !string.IsNullOrWhiteSpace(textPass.Text) && !string.IsNullOrWhiteSpace(textUname.Text))
                {
                    var userDetails = new UserDetails
                    {
                        UserName = textUname.Text,
                        Password = textPass.Text,
                        UserType = cBoxUType.Text,
                        Departmnent = cBoxDepartment.Text,
                        CreatedDate = DateTime.Now
                    };

                    UserFunction.SaveUser(userDetails);

                    this.Close();




                }
                else MessageBox.Show("Password did not match");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void cBoxUType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtReEnterPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
