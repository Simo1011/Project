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
   
    
    public partial class Main : Form
    {
        SqlConnection mycon;
        DataTable dataTable;
        SqlCommand sqlcmd;
        SqlDataAdapter myadapter;
        public static Main f1;
        public Main()
        {
            InitializeComponent();
        }

     

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Login login = new Login();
            login.MdiParent = this;
            login.Show();
            f1 = this;

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }
        public void enebleAdminMenu()
        {
          prodectsMenu.Enabled = true;
            costumersToolStripMenuItem.Enabled = true;
            logInToolStripMenuItem.Enabled = false;


        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddProducts pr = new AddProducts();
            pr.Show();
        }
    }
}
