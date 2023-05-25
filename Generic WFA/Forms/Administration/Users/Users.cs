using DGVPrinterHelper;
using Generic_WFA.Forms.Administration.User;
using Generic_WFA.Forms.Common;
using Generic_WFA.Functions;
using Generic_WFA.Functions.Administration;
using Generic_WFA.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equip = Generic_WFA.Forms.Common.Equipment;

namespace Generic_WFA.Forms.Administration
{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void Users_Load(object sender, EventArgs e)
        {
            GetUsers();
            //Print.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
        public void GetUsers()
        {


            var userList = UserFunction.GetUserDetails();
            this.txtResult.DataSource = userList;
            this.txtResult.Columns[0].Visible = false;
            this.txtResult.Columns[1].HeaderText = "User Name";
            this.txtResult.Columns[2].HeaderText = "Password";
            this.txtResult.Columns[3].HeaderText = "User Type";
            this.txtResult.Columns[4].HeaderText = "Created Date";
            this.txtResult.Columns[5].HeaderText = "Department";
            

            if (userList.Rows.Count > 10 && userList.Columns.Count > 10)
                this.txtResult.ScrollBars = ScrollBars.None;
            else this.txtResult.ScrollBars = ScrollBars.Both;

            //da.SelectCommand = cmd
            //da.Fill(dt)
            //if (userList != null)
            //{
            //    for (int i = 0; i < userList.Columns.Count; i++)
            //    {

            //        txtResult.Columns.Add("txtResult", userList.Columns[i].ToString());

            //    }


            //    if (userList.Rows.Count == 1)
            //        txtResult.Rows.Insert(0, userList.Rows[0].ItemArray);

            //    else
            //    {
            //        for (int i = 0; i < userList.Rows.Count; i++)
            //        {
            //            txtResult.Rows.Insert(i, userList.Rows[i].ItemArray);
            //        }

            //    }

            //}
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var modal = new UserModal();
            
            modal.ShowDialog();
            GetUsers();
            //txtResult.Refresh();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var selected = new object();
            
            var userDetails = new UserDetails();
            var updateUserDetails = new UserFunction();
            var userModal = new UserModal();

            if (txtResult.SelectedRows.Count == 1)
            {

                if (txtResult.SelectedCells.Count > 1)
                {
                    userDetails.UserID = int.Parse(txtResult.SelectedCells[0].Value.ToString());
                    userDetails.UserName = txtResult.SelectedCells[1].Value.ToString();
                    userDetails.CreatedDate = DateTime.Parse(txtResult.SelectedCells[5].Value.ToString()); 
                    userDetails.Password = txtResult.SelectedCells[2].Value.ToString();
                    userDetails.UserType = txtResult.SelectedCells[3].Value.ToString();
                    userDetails.Departmnent = txtResult.SelectedCells[4].Value.ToString();
                  
                    //2 pass
                    //3 usertype
                    //4 created_on
                    //5 department
                   
                 

                    //userModal.Show();
                    userModal.ShowUserModal(userDetails);
                    GetUsers();
                    //UserFunction.SaveUser(userDetails);
                }
                else
                {
                    selected = txtResult.CurrentCell.Value;
                }

            }
            else MessageBox.Show("Select only one row");


        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (txtResult.SelectedCells.Count > 1)
            {
                id = int.Parse(txtResult.SelectedCells[0].Value.ToString());
            }

            var res = MessageBox.Show("Do you really want to Delete data?", "", MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes)
            {
                UserFunction.DeleteUser(id);
            }
           

            GetUsers();
            //txtResult.Refresh();
            
            //GetUsers();
        }

        private void Print_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Custom Report";
            printer.SubTitle = string.Format("Date {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "footers";
            printer.FooterSpacing = 15;
           
            //printer.PrintColumnHeaders = true;

            if (txtResult.ColumnCount > 0 && txtResult.RowCount > 0 )
                printer.PrintPreviewDataGridView(txtResult);
            else MessageBox.Show("No Record shown");
           //printer.PrintDataGridView(txtResult);

         
          
           

        }
        

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            BaseFunction.PrintDGV(txtResult,e);
        }

        private void txtResult_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex == -1)
            //{
            //    Color c1 = Color.FromArgb(255, 54, 54, 54);
            //    Color c2 = Color.FromArgb(255, 62, 62, 62);
            //    Color c3 = Color.FromArgb(255, 98, 98, 98);

            //    LinearGradientBrush br = new LinearGradientBrush(e.CellBounds, c1, c3, 90, true);
            //    ColorBlend cb = new ColorBlend();
            //    cb.Positions = new[] { 0, (float)0.5, 1 };
            //    cb.Colors = new[] { c1, c2, c3 };
            //    br.InterpolationColors = cb;


            //    e.Graphics.FillRectangle(br, e.CellBounds);
            //    e.PaintContent(e.ClipBounds);
            //    e.Handled = true;
            //}
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            var home = new Administration.Home();
            home.Show();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var login = new AdminUsers();
            login.Show();

        }

        private void toolStripReport_Click(object sender, EventArgs e)
        {
            this.Close();
            var reportWin = new Report();
            reportWin.Show();
        }

        private void equipmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var equipmentWin = new Equip();
            equipmentWin.Show();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetUsers();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var homePage = new Home();
            homePage.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            var aboutWindow = new About();
            aboutWindow.Show();
        }
    }
}
