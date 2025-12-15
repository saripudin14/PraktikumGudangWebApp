using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using GudangWebApp.Models;

namespace GudangWebApp.Data
{
    public class ApplicationDbContextFactory
        : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite("Data Source=gudang.db");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
