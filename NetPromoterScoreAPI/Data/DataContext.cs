using Microsoft.EntityFrameworkCore;
using NetPromoterScoreAPI.Models;

namespace NetPromoterScoreAPI.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Calification> Califications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Calification)
                .WithOne()
                .HasForeignKey<Calification>(c => c.IdUser);
        }

    }
}
