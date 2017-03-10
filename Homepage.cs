using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MovieAssignment
{
    public partial class Form1 : Form
    {
        private OleDbConnection con = new OleDbConnection();

        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Maricar\Desktop\Kyle\School\3rd Semester\MovieAssignment;
Persist Security Info=False;";
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "select Title from MovieDatabase";
               
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    listBox1.Items.Add(reader["Title"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "select * from MovieDatabase where Title='" + listBox1.Text + "'";
                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox6.Text = reader["Movie"].ToString();
                    textBox1.Text = reader["Title"].ToString();
                    textBox2.Text = reader["Genre"].ToString();
                    textBox7.Text = reader["Rating"].ToString();
                    textBox3.Text = reader["ReleaseDate"].ToString();
                    textBox4.Text = reader["Sold"].ToString();
                    textBox5.Text = reader["Description"].ToString();
                    pictureBox1.ImageLocation = reader["PicturePath"].ToString();
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            pictureBox1.ImageLocation = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Add frm = new Add();
            frm.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            Edit frm = new Edit();
            frm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Delete frm = new Delete();
            frm.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
