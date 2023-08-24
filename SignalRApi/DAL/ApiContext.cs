using Microsoft.EntityFrameworkCore;

namespace SignalRApi.DAL
{
    public class ApiContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApiContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
