using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.Remoting.Contexts;

namespace EN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection ("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=emflasyon;Integrated Security=True");

        public void dataGet(string DataList)
        { 
            SqlDataAdapter adapter = new SqlDataAdapter(DataList, conn);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            dataGridViewInflation.DataSource = dataSet.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dataGet("SELECT * FROM Table_1");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand addCommand = new SqlCommand();
            addCommand.Connection = conn;
            addCommand.CommandText = "INSERT INTO TABLE_1 (CODE, PRODUCT, QUANTITY, UNIT, PRICE, MARKET) VALUES (@CODES, @PRODUCTS, @QUANTITYS, @UNITS, @PRICES, @MARKETS)";
            addCommand.Parameters.AddWithValue("@CODES", textBoxCode.Text);
            addCommand.Parameters.AddWithValue("@PRODUCTS", textBoxProduct.Text);
            addCommand.Parameters.AddWithValue("@QUANTITYS", textBoxQuantity.Text);
            addCommand.Parameters.AddWithValue("@UNITS", textBoxUnit.Text);
            addCommand.Parameters.AddWithValue("@PRICES", textBoxPrice.Text);
            addCommand.Parameters.AddWithValue("@MARKETS", textBoxMarket.Text);
            addCommand.ExecuteNonQuery();
            dataGet("SELECT * FROM Table_1");
            conn.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand commandSearch = new SqlCommand();
            commandSearch.Connection = conn;
            commandSearch.CommandText = ("SELECT * FROM Table_1 WHERE PRODUCT LIKE '%" + textBoxProductSearch.Text + "%'    ");
            SqlDataAdapter adapterSearch = new SqlDataAdapter(commandSearch);
            DataSet dataSet = new DataSet();
            adapterSearch.Fill(dataSet);
            dataGridViewInflation.DataSource = dataSet.Tables[0];
            conn.Close();
        }
    }
}
