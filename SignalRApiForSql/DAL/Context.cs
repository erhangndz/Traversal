using Microsoft.EntityFrameworkCore;

namespace SignalRApiForSql.DAL
{
    public class Context:DbContext
    {
        protected readonly IConfiguration Configuration;

        public Context(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
