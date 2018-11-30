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
    public partial class inventory : Form
    {
        public inventory()
        {
            InitializeComponent();
        }

        private void inventory_Load(object sender, EventArgs e)
        {
            showinventory();
        }

        private void showinventory()
        {
            try
            {
                string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gcc_users";
                MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM inventory", MySQLConnectionString);

                databaseConnection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "inventory");
                dataGridView1.DataSource = ds.Tables["inventory"];
                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 athlete = new Form1();
            athlete.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            additem();
            showinventory();
            refresh();
        }

        private void additem()
        {
            string itemkey = itemid.Text;
            string item = itemname.Text;
            string quantity = itemquant.Text;
            string descr = description.Text;

            MySqlConnection sc = new MySqlConnection();
            MySqlCommand com = new MySqlCommand();
            sc.ConnectionString = ("datasource=127.0.0.1;port=3306;username=root;password=;database=gcc_users");
            sc.Open();
            com.Connection = sc;
            com.CommandText = (@"INSERT INTO inventory (ID, Name, Quantity, Description) VALUES ('" + itemkey + "','" + item + "','" + quantity + "','" + descr + "');");
            com.ExecuteNonQuery();
            sc.Close();
        }

        private void refresh()
        {
            itemid.Clear();
            itemname.Clear();
            itemquant.Clear();
            description.Clear();
            searchid.Clear();
            searchquant.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            updateinv();
            showinventory();
            refresh();

        }

        private void updateinv()
        {
            int upquant = Int32.Parse(searchquant.Text);
            int id = Int32.Parse(searchid.Text);

            MySqlConnection sc = new MySqlConnection();
            MySqlCommand com = new MySqlCommand();
            sc.ConnectionString = ("datasource=127.0.0.1;port=3306;username=root;password=;database=gcc_users");
            sc.Open();
            com.Connection = sc;
            com.CommandText = ("UPDATE inventory SET Quantity = @quan Where ID = @id");
            com.Parameters.AddWithValue("@quan", upquant);
            com.Parameters.AddWithValue("@id", id);

            com.ExecuteNonQuery();
            sc.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            searchinv();
        }

        private void searchinv()
        {

            try
            {
                int ids = Int32.Parse(searchid.Text);
                string MySQLConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=gcc_users";
                MySqlConnection databaseConnection = new MySqlConnection(MySQLConnectionString);
                MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM inventory WHERE ID = " + ids, MySQLConnectionString);

                databaseConnection.Open();

                DataSet ds = new DataSet();
                adapter.Fill(ds, "inventory");
                dataGridView1.DataSource = ds.Tables["inventory"];
                databaseConnection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showinventory();
        }
    }
}
