using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Employe_Management_System
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select a.IdEmployee, a.EmployeeName, a.ContactNumber,a.IdDesignation, a.IdReportingTo, b.EmployeeName from tbl_EmployeeDetails a, tbl_EmployeeDetails b where a.IdReportingTo = b.IdEmployee;", con);

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}