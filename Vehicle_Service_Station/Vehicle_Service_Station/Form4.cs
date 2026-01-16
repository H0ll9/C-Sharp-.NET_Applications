using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Vehicle_Service_Station
{
    public partial class Form4 : Form
    {
        public SqlConnection? con;
        public SqlDataAdapter? adp;
        public DataTable? dt;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=freel\\sqlexpress;Initial Catalog=VMS;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                adp = new SqlDataAdapter("select IdVehicleType,VehicleType from tbl_VehicleTypes;", con);
                dt = new DataTable();
                adp.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "VehicleType";
                comboBox1.ValueMember = "IdVehicleType";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedValue == null || comboBox1.SelectedValue is DataRowView)
                    return;

                int vehicleTypeId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                adp = new SqlDataAdapter("SELECT ServiceCharge FROM tbl_VehicleTypes WHERE IdVehicleType = " + vehicleTypeId, con);
                dt = new DataTable();
                adp.Fill(dt);
                int serviceCharge = Convert.ToInt32(dt.Rows[0]["ServiceCharge"]);
                
                adp = new SqlDataAdapter("SELECT COUNT(*) FROM tbl_ServiceDetails WHERE IdVehicleType = " + vehicleTypeId, con);
                dt = new DataTable();
                adp.Fill(dt);
                int serviceCount = Convert.ToInt32(dt.Rows[0][0]);


                int totalCost = serviceCount * serviceCharge;

                textBox1.Text = totalCost.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
