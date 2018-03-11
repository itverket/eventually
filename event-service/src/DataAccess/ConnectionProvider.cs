using System.Data.SqlClient;

namespace DataAccess
{
    public interface IConnectionProvider
    {
        SqlConnection GetConnection();
    }

    public class ConnectionProvider : IConnectionProvider
    {
        private string _connectionString;

        public ConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
            
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }

}
