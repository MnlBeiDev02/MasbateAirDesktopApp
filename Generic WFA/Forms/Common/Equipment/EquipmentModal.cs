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
using Equip = Generic_WFA.Objects;
namespace Generic_WFA.Forms.Common
{
    public partial class EquipmentModal : Form
    {
        public EquipmentModal()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var brand = txtBrand.Text;
            var name = txtEquipment.Text;
            var yearInstalled = dtpYear.Text;
            var manufacturer = txtMan.Text;
            //var equipmetType = cbEquipType.Text;

            if ((!string.IsNullOrWhiteSpace(brand) && !string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(manufacturer)))
            //!string.IsNullOrWhiteSpace(txtID.Text))
            {
                //Update


                if (!string.IsNullOrWhiteSpace(txtID.Text))
                {
                    var equipment = new Equip.Equipment
                    {
                        ID = int.Parse(txtID.Text),
                        Name = name,
                        Brand = brand,
                        YearInstalled = dtpYear.Value,
                        Manufacturer = manufacturer,
                        CreatedDate = DateTime.Now,

                    };

                    EquipmentFunction.SaveEquipment(equipment);
                    MessageBox.Show("Save Successfully");

                    this.Close();


                }
                else
                {

                    var equipment = new Equip.Equipment
                    {
                        Name = name,
                        Brand = brand,
                        YearInstalled = dtpYear.Value,
                        Manufacturer = manufacturer,
                        CreatedDate = DateTime.Now,

                    };

                    EquipmentFunction.SaveEquipment(equipment);

                    MessageBox.Show("Save Successfully");

                    this.Close();


                }
            }
        }


        public void ShowEquipmentModal(Equip.Equipment equipment)
        {

            var brand = txtBrand.Text;
            var name = txtEquipment.Text;
            var yearInstalled = dtpYear.Value;
            var manufacturer = txtMan.Text;

            if (equipment != null)
            {
                txtID.Text = equipment.ID.ToString();

                txtEquipment.Text = equipment.Name;
                txtBrand.Text = equipment.Brand;
                dtpYear.Value = equipment.YearInstalled;
                txtMan.Text = manufacturer;
            }

            this.ShowDialog();
        }

        private void EquipmentModal_Load(object sender, EventArgs e)
        {
            txtID.Visible = false;
            dtpYear.CustomFormat = "yyyy";
            dtpYear.ShowUpDown = true;
        }
    }
}
