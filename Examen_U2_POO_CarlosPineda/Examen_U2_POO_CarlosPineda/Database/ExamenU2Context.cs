using Microsoft.EntityFrameworkCore;
using LoanAPI.Database.Entities;
using Examen_U2_POO_CarlosPineda.Services.Interfaces;

namespace LoanAPI.Database
{
    public class ExamenU2Context : DbContext
    {
        private readonly IAuthService _authService;

        public ExamenU2Context(DbContextOptions options, IAuthService authService) : base(options)
        {
            this._authService = authService;
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

        public DbSet<LoanEntity> Loans { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<AmortizationScheduleEntity> AmortizationSchedules { get; set; }
    }
}
