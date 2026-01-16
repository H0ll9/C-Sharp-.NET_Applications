using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Employe_Management_System
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new Form1().Show();
        }
        //Insertion operation
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_EmployeeDetails (IdEmployee,EmployeeName,ContactNumber,IdDesignation,IdReportingTo) VALUES(@id, @name, @contact, @deptid, @reportid);", con);

                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@name", textBox2.Text);
                cmd.Parameters.AddWithValue("@contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@deptid", int.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@reportid", int.Parse(textBox5.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted !!!");
                con.Close();

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox1.Focus();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
