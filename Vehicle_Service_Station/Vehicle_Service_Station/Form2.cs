using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Vehicle_Service_Station
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=freel\\sqlexpress;Initial Catalog=VMS;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into tbl_ServiceDetails (IdService, VehicleNumber, ServiceDetails, IdVehicleType) values (@service, @number, @details, @type);", con);

                cmd.Parameters.AddWithValue("@service", textBox1.Text);
                cmd.Parameters.AddWithValue("@number", textBox2.Text);
                cmd.Parameters.AddWithValue("@details", textBox3.Text);
                cmd.Parameters.AddWithValue("@type", Convert.ToInt32(comboBox1.SelectedValue));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Record inserted successfully!");
                con.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try 
            {
                SqlConnection con = new SqlConnection("Data Source=freel\\sqlexpress;Initial Catalog=VMS;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlDataAdapter adp = new SqlDataAdapter("select IdVehicleType,VehicleType from tbl_VehicleTypes;", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "VehicleType";
                comboBox1.ValueMember = "IdVehicleType";
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
