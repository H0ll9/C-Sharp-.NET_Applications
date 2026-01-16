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
    public partial class Form3 : Form
    {
        SqlConnection? con;
        SqlDataAdapter? adp;
        DataTable? dt;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                con = new SqlConnection("Data Source=freel\\sqlexpress;Initial Catalog=VMS;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
           
                adp = new SqlDataAdapter("select * from tbl_VehicleTypes;", con);
                dt = new DataTable();

                adp.Fill(dt);
                dataGridView1.DataSource = dt;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommandBuilder builder = new SqlCommandBuilder(adp);
                adp.Update(dt);
                MessageBox.Show("Updated");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
