using System;
using System.Collections.Generic;
using System.Text;
using Holidayview.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Holidayview.Infrastructure
{
    public class Context : IdentityDbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Disable> Disables { get; set; }
        public DbSet<Leader> Leaders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<LeaveBalance> LeaveBalances { get; set; }
        public DbSet<CustomerType> CustomerTypes { get; set; }

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Add start data to database
            builder.Entity<CustomerType>()
                .HasData(new CustomerType {Id = 1, Name = "Director"},
                    new CustomerType {Id = 2, Name = "Manager"},
                    new CustomerType {Id = 3, Name = "Leader"});

            builder.Entity<Director>()
                .HasData(new Director { Id = 1, Name = "None", Surname = "None"},
                    new Director { Id = 2, Name = "John", Surname = "Wick"});

            builder.Entity<Manager>()
                .HasData(new Manager { Id = 1, Name = "None", Surname = "None"},
                    new Manager { Id = 2, Name = "Mark", Surname = "Wahlberg" });

            builder.Entity<Leader>()
                .HasData(new Leader { Id = 1, Name = "None", Surname = "None"},
                    new Leader { Id = 2, Name = "Bill", Surname = "Murray"});

            builder.Entity<Company>()
                .HasData(new Company { Id = 1, Name = "None" },
                    new Company { Id = 2, Name = "Best Performance" },
                    new Company { Id = 3, Name = "Clermont" });

            builder.Entity<Disable>()
                .HasData(new Disable { Id = 1, Name = "None" },
                    new Disable { Id = 2, Name = "YES" },
                    new Disable { Id = 3, Name = "NO" });

            builder.Entity<Vacation>()
                .HasData(new Vacation { Id = 1, LeaveDimension = 20 },
                    new Vacation { Id = 2, LeaveDimension = 26 },
                    new Vacation { Id = 3, LeaveDimension = 30 },
                    new Vacation { Id = 4, LeaveDimension = 36 });

            builder.Entity<Customer>()
                .HasData(new Customer
                {
                    Id = 1,
                    Name = "admin",
                    Surname = "admin",
                    IndividualId = 1,
                    Email = "admin@gmail.com",
                    CustomerTypeId = 1,
                    DirectorId = 1,
                    ManagerId = 1,
                    LeaderId = 1,
                    IsActive = true,
                    CompanyId = 1,
                    DisableId = 1,
                    VacationId = 1
                });

            builder.Entity<LeaveBalance>()
                .HasData(new LeaveBalance
                {
                    Id = 1,
                    BalanceOfLeave = 26,
                    LeaveLeft = 26,
                    LeaveTaken = 0,
                    CustomerId = 1
                });
            
            /*
            builder.Entity<Customer>()
                .HasOne(a => a.Director).WithOne(b => b.Customer)
                .HasForeignKey<Director>(e => e.CustomerRef);*/
        }
    }
}
