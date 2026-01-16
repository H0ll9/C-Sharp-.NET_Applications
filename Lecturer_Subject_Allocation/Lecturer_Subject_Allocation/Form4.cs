using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lecturer_Subject_Allocation
{
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=freel\\sqlexpress;Initial Catalog=LSA;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();
                
                SqlDataAdapter adp = new SqlDataAdapter("select IdLecturer,LecturerName from tbl_Lecturers;", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                comboBox1.DataSource  = dt;
                comboBox1.ValueMember = "IdLecturer";
                comboBox1.DisplayMember = "LecturerName";

                adp = new SqlDataAdapter("select * from tbl_Subjects", con);
                dt = new DataTable();
                adp.Fill(dt);
                dataGridView1.DataSource = dt;

                DataGridViewCheckBoxColumn c = new DataGridViewCheckBoxColumn();
                c.Name = "Check";
                c.Width = 50;
                dataGridView1.Columns.Add(c);

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection("Data Source=freel\\sqlexpress;Initial Catalog=LSA;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
                con.Open();

                SqlDataAdapter adp = new SqlDataAdapter("select IdLecturer from tbl_Lecturers;", con);
                DataTable dt = new DataTable();
                adp.Fill(dt);

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (Convert.ToBoolean(row.Cells["Check"].Value))
                    {
                        SqlCommand cmd = new SqlCommand("INSERT INTO tbl_LecturerSubjects VALUES(@sid, @scode, @lid)", con);
                        cmd.Parameters.AddWithValue("@sid", row.Cells["IdSubject"].Value);
                        cmd.Parameters.AddWithValue("@scode", row.Cells["SubjectCode"].Value);
                        cmd.Parameters.AddWithValue("@lid", Convert.ToInt32(comboBox1.SelectedValue));

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Insertion Successful");
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
