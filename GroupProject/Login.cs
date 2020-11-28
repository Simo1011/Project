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
    public partial class Login : Form
    {
        SqlConnection mycon;
        DataTable dataTable;
        SqlCommand sqlcmd;
        SqlDataAdapter myadapter;
        String Query = "";
       
       
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mycon = new SqlConnection();

            mycon.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            Directory.GetCurrentDirectory() + "\\DB\\Games.mdf;" +
            "Integrated Security=True;Connect Timeout=30";
            if (checkBox1.Checked )
            {
                Query = "select * from Users where  Username='" + txt1.Text + "' and  Password='" + txt2.Text + "' " + " and Admin=1";
                ;
            }
            else
            {
                Query = "select * from Users where  Username='" + txt1.Text + "' and  Password='" + txt2.Text + "' " + " and Admin=0";
             } 
            try
            {
                mycon.Open();

                sqlcmd = new SqlCommand();
                sqlcmd.CommandText = Query;
                myadapter = new SqlDataAdapter();
                sqlcmd.Connection = mycon;

                SqlDataReader reader = sqlcmd.ExecuteReader();
                int counter = 0;

                while (reader.Read())
                {
                    counter++;
                }
                if (counter == 1)
                {
                    this.Close();
                    Main.f1.enebleAdminMenu();


                }
                else if (counter != 1)
                {
                    MessageBox.Show("Username and password are not correct");
                }
               

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                mycon.Dispose();
            }

        }
    }
}
