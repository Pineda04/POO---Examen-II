using Microsoft.EntityFrameworkCore;
using LoanAPI.Database.Entities;

namespace LoanAPI.Database
{
    public class ExamenU2Context : DbContext
    {
        public ExamenU2Context(DbContextOptions<ExamenU2Context> options) : base(options)
        {
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries();

            foreach (var entry in entries)
            {
                var entity = entry.Entity;

                if (entity != null)
                {
                    if (entry.State == EntityState.Added)
                    {
                        
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        
                    }
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de las relaciones y restricciones
            modelBuilder.Entity<LoanEntity>()
                .HasMany(l => l.AmortizationSchedule)
                .WithOne(a => a.Loan)
                .HasForeignKey(a => a.LoanId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CustomerEntity>()
                .HasMany(c => c.Loans)
                .WithOne(l => l.Customer)
                .HasForeignKey(l => l.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<AmortizationScheduleEntity> AmortizationSchedules { get; set; }
    }
}
