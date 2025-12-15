using Microsoft.EntityFrameworkCore;

namespace GudangWebApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Barang> Barang { get; set; }
    }
}
