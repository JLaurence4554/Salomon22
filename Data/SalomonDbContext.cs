using Microsoft.EntityFrameworkCore;
using SalomonAPI.Model;

namespace SalomonAPI.Data
{
    public class SalomonDbContext  : DbContext
    {
        public SalomonDbContext(DbContextOptions<SalomonDbContext> options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<RentalDetail> RentalDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Rental>()
                .HasOne(r => r.Customers)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CustomerId);

            builder.Entity<Rental>()
               .HasOne(r => r.Movies)
               .WithMany(c => c.Rentals)
               .HasForeignKey(r => r.MovieId);

            builder.Entity<RentalDetail>()
                .HasOne(rd => rd.Rentals)
                .WithMany(r => r.RentalDetails)
                .HasForeignKey(rd => rd.RentalId);
        }
    }
}
