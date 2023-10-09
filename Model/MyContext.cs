using Microsoft.EntityFrameworkCore;

namespace MarkitingAPI.Model
{
    public class MyContext:DbContext
    {
        public MyContext() : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        public MyContext(DbContextOptions options) : base(options) { }

        public DbSet<Advertisingcampaigns> Advertisingcampaignss { get; set; }
        public DbSet<Electioncampaigns>Electioncampaignss { get; set; }
        public DbSet<Ourcustomers_success> ourcustomers_Successess { get; set; }
        public DbSet<Ourservices> Ourservicess { get; set; }
        public DbSet<Ourworks> Ourworkss { get; set; }
        public DbSet<whous> whouss { get; set; }
        public DbSet<workteam> workteams { get; set; }
        public DbSet<Admin> admins { get; set; }
    }
}
