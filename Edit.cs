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
    public partial class Edit : Form
    {
        private OleDbConnection con = new OleDbConnection();
        public Edit()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Maricar\Documents\MovieDatabase.accdb;
Persist Security Info=False;";
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "select * from MovieDatabase";

                command.CommandText = query;
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["Movie"].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "update MovieDatabase set Title='" + textBox1.Text + "', Genre='" + textBox2.Text + "', ReleaseDate='" + dateTimePicker1.Text + "', Rating='" + textBox3.Text + "', Sold='" + textBox4.Text + "', Description='" + textBox5.Text + "', PicturePath='" + textBox6.Text + "' where Movie =" + comboBox1.Text + "";

                MessageBox.Show(query);
                command.CommandText = query;
                command.ExecuteNonQuery();
                MessageBox.Show("Data Edit Successful");
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text.Length == 0)
            {
                MessageBox.Show("Please choose a Movie Number");
                comboBox1.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "select * from MovieDatabase where Movie='" + comboBox1.Text + "'"; ;

                command.CommandText = query;

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    textBox1.Text = reader["Title"].ToString();
                    textBox2.Text = reader["Genre"].ToString();
                    textBox3.Text = reader["Rating"].ToString();
                    //dateTimePicker1.Text = reader["ReleaseDate"].ToString();
                    textBox4.Text = reader["Sold"].ToString();
                    textBox5.Text = reader["Description"].ToString();
                    textBox6.Text = reader["PicturePath"].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }
    }
}
