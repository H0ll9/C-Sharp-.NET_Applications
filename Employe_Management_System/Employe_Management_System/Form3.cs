using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

//2.Display all the Project Leaders (In a Grid) reporting to selected Project Managers (In a Combobox)
namespace Employe_Management_System
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter("SELECT EmployeeName from tbl_EmployeeDetails where IdDesignation = 1;", con);

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

                SqlDataAdapter adp = new SqlDataAdapter("SELECT * from tbl_EmployeeDetails where IdReportingTo in (select IdEmployee from tbl_EmployeeDetails where EmployeeName = '"+comboBox1.SelectedValue.ToString()+ "') and IdDesignation = 2;", con);

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
