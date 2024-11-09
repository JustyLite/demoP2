
using System.Data.SqlClient;


namespace demoP2
{
    class Database
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = DESKTOP-U55V8JU\MSSQLSERVER01;Initial Catalog = demoP2;Integrated Security = True");
        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed) { sqlConnection.Open(); }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open) { sqlConnection.Close(); }
        }
    }
    
}
