using System.Data.SqlClient;

namespace ChemiClean.SQLServer
{
    public static class ServerConfig
    {
        // Enter Server Name and Database Name Here
        public const string Server = @"ServerName";
        public const string Database = "DatabaseName";
        public const string Security = "true";
        public static readonly SqlConnection Connection = new SqlConnection(ConnectionString);

        public static string ConnectionString => "server = " + Server + "; " + "database = " + Database + "; " + "integrated security = " + Security;

       public static  void Up()
        {
            Connection.Open();
        }

        public static void Down()
        {
            Connection.Close();
        }
    }
}
