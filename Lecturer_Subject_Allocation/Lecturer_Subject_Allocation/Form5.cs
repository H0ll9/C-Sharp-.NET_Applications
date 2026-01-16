using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Lecturer_Subject_Allocation
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
                SqlConnection con = new SqlConnection("Data Source=freel\\sqlexpress;Initial Catalog=LSA;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select LecturerName from tbl_Lecturers;", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.ValueMember = "LecturerName";
                comboBox1.DisplayMember = "LecturerName";

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=freel\\sqlexpress;Initial Catalog=LSA;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select a.IdSubject, a.SubjectCode, a.SubjectName from tbl_Subjects a, tbl_Lecturers b, tbl_LecturerSubjects c where a.IdSubject = c.IdSubject AND b.IdLecturer = c.IdLecturer AND b.LecturerName = '" + comboBox1.SelectedValue.ToString() + "'", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

