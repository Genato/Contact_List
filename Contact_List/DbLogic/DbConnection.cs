using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Contact_List.BusinessLogic
{
    public class DbConnection
    {
        public DbConnection()
        {
            SqlCommand = new SqlCommand();
            SqlCommand.Connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["ContactList"].ConnectionString);
        }

        public SqlCommand SqlCommand { get; set; }
        public SqlDataReader Reader { get; set; }
    }
}