using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) 
        : base(options) 
        { }
        
        public DbSet<User> Users { get; set; }
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