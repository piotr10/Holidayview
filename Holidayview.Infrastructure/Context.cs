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

        public Context(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*
            builder.Entity<Customer>()
                .HasOne(a => a.Director).WithOne(b => b.Customer)
                .HasForeignKey<Director>(e => e.CustomerRef);*/
        }
    }
}
