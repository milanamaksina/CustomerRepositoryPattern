using System.Data.SqlClient;


namespace CustomerRepositoryPattern
{
    public abstract class ServerOptions
    {
        public SqlConnection GetConnection()
        {
            return new SqlConnection("Server=.\\;Database=Maksina_Customer.db;Trusted_Connection=True;");
        }
    }
}
