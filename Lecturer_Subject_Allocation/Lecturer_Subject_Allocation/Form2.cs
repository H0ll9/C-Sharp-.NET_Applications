using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Lecturer_Subject_Allocation
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=freel\\sqlexpress;Initial Catalog=LSA;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO tbl_Subjects (IdSubject, SubjectCode, SubjectName) VALUES (@id, @code, @name);", con);

                cmd.Parameters.AddWithValue("@id", textBox1.Text);
                cmd.Parameters.AddWithValue("@code", textBox2.Text);
                cmd.Parameters.AddWithValue("@name", textBox3.Text);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Subject Inserted !!!");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }
    }
}
