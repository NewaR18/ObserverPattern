using ObserverPattern.SqlConn;
using System.Data;
using System.Data.SqlClient;
namespace ObserverPattern.Repository
{
    public class ConnRepo
    {
        public SqlConnection Connection()
        {
            string connString = new Connection().GetConnectionString();
            SqlConnection connection = new SqlConnection(connString);
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }
    }
}
