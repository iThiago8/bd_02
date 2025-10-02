using Greenhouse.Models;
using Microsoft.EntityFrameworkCore;

namespace Greenhouse.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Plant> Plants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Plant>().ToTable("Plant");
        }
    }
}
