using PWC_TestApp.Models;
using Microsoft.EntityFrameworkCore;
namespace PWC_TestApp.Data
{
    public class AppDbContext:DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Client> Clients { get; set; }
    }
}
