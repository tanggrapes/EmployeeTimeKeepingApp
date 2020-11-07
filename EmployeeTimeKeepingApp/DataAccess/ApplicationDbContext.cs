using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeTimeKeepingApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace EmployeeTimeKeepingApp.DataAccess
{
    public class ApplicationDbContext: DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<TimeKeepingTransaction> TimeKeepingTransactions { get; set; }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

        public Task<IDbContextTransaction> Transaction() => base.Database.BeginTransactionAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.TimeKeepingTransactions)
                .WithOne(t => t.Employee)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransactionType>()
                .HasMany(t => t.TimeKeepingTransactions)
                .WithOne(t => t.TransactionType)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransactionType>()
                .HasData(
                new TransactionType() { TransactionTypName = "IN", TransactionTypeId = 1 },
                new TransactionType() { TransactionTypName = "OUT" , TransactionTypeId = 2}
                );


        }

    }
}
