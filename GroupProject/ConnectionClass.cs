using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Linq;
    using System.Web;

    namespace GroupProject

    {
        public class ConnectionClass
        {

          public   string ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=" +
            Directory.GetCurrentDirectory() + "\\DB\\Games.mdf;" +
            "Integrated Security=True;Connect Timeout=30";
            SqlConnection con;
           public SqlCommand cmd = new SqlCommand();


            public SqlConnection OpenConection()
            {
                con = new SqlConnection(ConnectionString);
                return con;
            }


            public void CloseConnection()
            {
                con.Close();
            }


            public int  ExecuteQueries(string Query_)
            {
                SqlCommand cmd = new SqlCommand(Query_, con);
                 return   cmd.ExecuteNonQuery();
            }


            public SqlDataReader DataReader(string Query_)
            {
                SqlCommand cmd = new SqlCommand(Query_, con);
                SqlDataReader dr = cmd.ExecuteReader();
                return dr;
            }


            public object ShowDataInGridView(string Query_)
            {
                SqlDataAdapter dr = new SqlDataAdapter(Query_, ConnectionString);
                DataSet ds = new DataSet();
                dr.Fill(ds);
                object dataum = ds.Tables[0];
                return dataum;
            }
        }
    }
}
