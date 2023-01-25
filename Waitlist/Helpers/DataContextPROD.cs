using Waitlist.Entity.Aws;
using Waitlist.Entity.Passenger;

namespace Waitlist.Helpers
{
    public class DataContextPROD : DbContext
    {

        protected readonly IConfiguration Configuration;
        public DataContextPROD(IConfiguration configuration)
        {
            Configuration = configuration;
        }

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

        public DbSet<Passenger> Passenger { get; set; }
        public DbSet<AwsCredentials> AwsCredentials { get; set; }
        public DbSet<Lounge> Lounge { get; set; }

    }
}
