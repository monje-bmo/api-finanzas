using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace api.Data
{
    public class ApplicationDBContext
        : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        : base(options)
        { }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                }
            };
            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityRole>().HasData(roles);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CoinType> CoinTypes { get; set; }
        public DbSet<Debt> Debts { get; set; }
        public DbSet<DebtMovement> DebtMovements { get; set; }
        public DbSet<JournalHeader> JournalHeaders { get; set; }
        public DbSet<JournalLine> JournalLines { get; set; }
        public DbSet<TypeBusiness> TypeBusinesses { get; set; }

    }
}