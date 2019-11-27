namespace CoreTestApp.Configuration
{
    public class Settings
    {
        public SQlDatabaseConnection Database { get; set; }
    }

    public class SQlDatabaseConnection
    {
        public string ConnectionString { get; set; }
    }
}
