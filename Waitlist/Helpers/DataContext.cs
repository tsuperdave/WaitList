namespace Waitlist.Helpers
{
    public class DataContext : DataContextPROD
    {

        public DataContext(IConfiguration config) : base(config) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var env = Environment.GetEnvironmentVariable("DB_CONNECT");

            if (env.Contains("CHANGE"))
            {
                options.UseMySQL(Configuration.GetConnectionString("CHANGE"));
            }
            else if (env.Contains("CHANGE"))
            {
                options.UseMySQL(Configuration.GetConnectionString("CHANGE"));
            }

        }

    }
}
