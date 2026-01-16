using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;
using Microsoft.Data.SqlClient;

// 3. Display all the Engineers (In a Grid) reporting to the selected Project Leader (In a Combo box).

namespace Employe_Management_System
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter("SELECT EmployeeName from tbl_EmployeeDetails where IdDesignation = 2;", con);

                DataTable table = new DataTable();
                adp.Fill(table);

                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "EmployeeName";
                comboBox1.ValueMember = "EmployeeName";
                
                con.Close();
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
                SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tbl_EmployeeDetails where IdReportingTo in (select IdEmployee from tbl_EmployeeDetails where EmployeeName = '" + comboBox1.SelectedValue.ToString() + "') ", con);

                DataTable table = new DataTable();
                adp.Fill(table);


                dataGridView1.DataSource = table;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
