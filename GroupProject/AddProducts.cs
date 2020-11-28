using GroupProject.GroupProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class AddProducts : Form
    {
         string ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            Directory.GetCurrentDirectory() + "\\DB\\Games.mdf;" +
            "Integrated Security=True;Connect Timeout=30";
        ConnectionClass con = new ConnectionClass();
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public AddProducts()
        {
            InitializeComponent();
        }

        private void AddProducts_Load(object sender, EventArgs e)
        {
            string query = "select * from Categories";
            SqlDataAdapter da = new SqlDataAdapter(query, con.OpenConection());
            con.OpenConection().Open();
            DataSet ds = new DataSet();
            da.Fill(ds, "Categories");
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
            comboBox1.DataSource = ds.Tables["Categories"];

            con.OpenConection().Close();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.ConnectionString = ConnectionString;
            conn.Open();
            
            String Query = "insert into  Products(ProductName,Description,ImagePath,UnitPrice,CategoryID)"
                + "values(@name,@des,@img,@price,@cat) ";
            cmd.CommandText = Query;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            
            cmd.Parameters.AddWithValue("@name",textBox1.Text);
            cmd.Parameters.AddWithValue("@des",textBox2.Text);
            cmd.Parameters.AddWithValue("@img", openFileDialog1.FileName);
            cmd.Parameters.AddWithValue("@price", textBox3.Text);
            cmd.Parameters.AddWithValue("@cat",comboBox1.SelectedValue);
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                MessageBox.Show("Product Added");
            }
            else
                {
                MessageBox.Show("Product not Added Please Try again");
            }

            






        }                                                                                                                                
    }
}
