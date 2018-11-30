using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GCCAdmin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            runquery();
        }

        private void runquery()
        {

            string query = textBox1.Text;
            if(query == "")
            {

                MessageBox.Show("enter query");
                return;
            }
            string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gcc_users";
            MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);

            try
            {
                databaseConnection.Open();
                MySqlDataReader myreader = commandDatabase.ExecuteReader();
                if (myreader.HasRows)
                {
                    MessageBox.Show("see results on console");
                    while (myreader.Read())
                    {
                        Console.WriteLine(myreader.GetString(0) + " - " + myreader.GetString(1) + " - " + myreader.GetString(2));
                    }
                }

                else
                {
                    MessageBox.Show("query executed");
                }
            }

            catch(Exception e)
            {
                MessageBox.Show("query error" + e.Message);
            }
                
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            displayusers();
        }
        private void displayschedule()
        {
            try
            {
                string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gcc_users";
                MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM schedule", MySQLConnectionString);

                databaseConnection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "schedule");
                dataGridView1.DataSource = ds.Tables["schedule"];
                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        private void displayusers()
        {
            try
            {
                string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gcc_users";
                MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM members", MySQLConnectionString);

                databaseConnection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "members");
                dataGridView1.DataSource = ds.Tables["members"];
                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adduser();
            displayusers();
            refresh();
        }

        private void refresh()
        {
            fname.Clear();
            lname.Clear();
            ID.Clear();
            sport.Clear();
            password.Clear();
            email.Clear();
        }
        private void adduser()
        {
            string firstname = fname.Text;
            string lastname = lname.Text;
            string id = ID.Text;
            string asport = sport.Text;
            string pass = password.Text;
            string mail = email.Text;

            MySqlConnection sc = new MySqlConnection();
            MySqlCommand com = new MySqlCommand();
            sc.ConnectionString = ("datasource=127.0.0.1;port=3306;username=root;password=;database=gcc_users");
            sc.Open();
            com.Connection = sc;
            com.CommandText = (@"INSERT INTO members (fname, lname, ID, Sport, password, email) VALUES ('" + firstname + "','" + lastname + "','" + id + "','" + asport + "','" + pass + "','" + mail + "');");
            com.ExecuteNonQuery();
            sc.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            displayschedule();
            label12.Text = "Schedule Submissions";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            displayusers();
            label12.Text = "Current Athletes";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            inventory inv = new inventory();
            inv.Show();
            this.Hide();
        }
    }
}
