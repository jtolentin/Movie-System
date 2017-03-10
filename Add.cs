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
    public partial class Add : Form
    {
        private OleDbConnection con = new OleDbConnection();
        public Add()
        {
            InitializeComponent();
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Maricar\Documents\MovieDatabase.accdb;
Persist Security Info=False;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                command.CommandText = "insert into MovieDatabase (Movie,Title,Genre,Rating,ReleaseDate,Sold,Description,PicturePath) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                //OleDbDataReader reader = command.ExecuteReader();
                command.ExecuteNonQuery();
                MessageBox.Show("Data Saved");
                con.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(textBox1.Text, out i))
            {
                if (i <= 0)
                {
                    MessageBox.Show("Movie Number cannot be zero");
                    textBox1.Focus();
                }
            }
        }


        private void textBox5_Leave(object sender, EventArgs e)
        {
            int i;
            if (int.TryParse(textBox5.Text, out i))
            {
                if (i < 0)
                {
                    MessageBox.Show("Sold Value cannot be negative");
                    textBox5.Focus();
                } 
            }


        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)8)
                {
                    MessageBox.Show("Please enter numbers only");
                    e.KeyChar = (char)0;
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                if (e.KeyChar != (char)8)
                {
                    MessageBox.Show("Please enter numbers only");
                    e.KeyChar = (char)0;
                }
            }
        }

        private void Form4_Load(object sender, EventArgs e)
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
                
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            double i;
            if (double.TryParse(textBox4.Text, out i))
            {
                if (i < 0)
                {
                    MessageBox.Show("Ratings cannot be negative");
                    textBox4.Focus();
                }
                else if (i > 10)
                {
                    MessageBox.Show("Ratings cannot be greater the 10");
                    textBox4.Focus();
                }

            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                MessageBox.Show("Input Only Digits");
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                MessageBox.Show("Please put a Movie Title");
                textBox2.Focus();
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                MessageBox.Show("Please put a Movie Genre");
                textBox3.Focus();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (textBox6.Text.Length == 0)
            {
                MessageBox.Show("Please put a Movie Description");
                textBox6.Focus();
            }
        }
    }
}
