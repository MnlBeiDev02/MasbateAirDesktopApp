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

namespace Generic_WFA.Forms.User
{
    public partial class MonitoringModal : Form
    {
        public MonitoringModal()
        {
            InitializeComponent();
        }

        private void MonitoringModal_Load(object sender, EventArgs e)
        {
            txtID.Visible = false;

            var equipment = new MonitoringFunction();
           
              foreach (var item in equipment.GetEquipment())
	            {
                    cbEquipment.Items.Add(item.Name);
                    cbBrand.Items.Add(item.Brand);
                    
	            }
          
        }

        public void ShowMonitoringModal(MonitoringDetails monitoring)
        {

            if (monitoring != null)
            {
                txtID.Text = monitoring.ID.ToString();

                cbBrand.Text = monitoring.Brand;
                txtSpecs.Text = monitoring.Specification;
                txtAvail.Text = monitoring.Availability;
                cbStatus.Text = monitoring.Status;
                cbEquipType.Text = monitoring.EquipmentType;
                cbEquipment.Text = monitoring.EquipmentName;
            }

            this.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var brand = cbBrand.Text;
            var specs = txtSpecs.Text;
            var availability = txtAvail.Text;
            var status = cbStatus.Text;
            var equipmetType = cbEquipType.Text;
            var equipmentName = cbEquipment.Text;

            bool isSaved = false;
            if ((!string.IsNullOrWhiteSpace(brand) && !string.IsNullOrWhiteSpace(specs) && !string.IsNullOrWhiteSpace(status)))
                //!string.IsNullOrWhiteSpace(txtID.Text))
            {
                //Update


                if (!string.IsNullOrWhiteSpace(txtID.Text))
                {
                    var monitorDetails = new MonitoringDetails
                    {
                        ID = int.Parse(txtID.Text),
                        EquipmentName = equipmentName,
                        Status = status,
                        Brand = brand,
                        Specification = specs,
                        Availability = availability,
                        EquipmentType = equipmetType,

                    };

                    MonitoringFunction.SaveMonitoringInfo(monitorDetails);
                    if (!isSaved)
                        MessageBox.Show("Save Successfully");
                    else
                        MessageBox.Show("Error");

                    this.Close();


                }
                else
                {

                    var monitorDetails = new MonitoringDetails
                    {
                       EquipmentName = equipmentName,
                        Brand = brand,
                        Specification = specs,
                        Availability = availability,
                        Status = status,
                        EquipmentType = equipmetType,
                        ProcessedDate = DateTime.Now

                    };

                    MonitoringFunction.SaveMonitoringInfo(monitorDetails);

                    if (!isSaved)
                        MessageBox.Show("Save Successfully");
                    else
                        MessageBox.Show("Error");
                        this.Close();

                   
                }
            }
        }
    }
}
