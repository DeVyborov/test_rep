using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.Classes
{
    public static class SQLclass
    {
        public static SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=авторизация;Integrated Security=True");

        public static void OpenConnection()
        {
            conn.Open();
        }

        public static void CloseConnection()
        {
            conn.Close();
        }
    }
}
