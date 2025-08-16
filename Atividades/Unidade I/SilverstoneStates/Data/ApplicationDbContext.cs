using Microsoft.EntityFrameworkCore;
using SilverstoneStates.Models;

namespace SilverstoneStates.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Realty> Realties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Realty>().ToTable("Realty");
        }
    }
}
