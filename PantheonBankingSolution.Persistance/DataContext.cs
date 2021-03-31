using Microsoft.EntityFrameworkCore;
using PantheonBankingSolution.Domain;
using System;

namespace PantheonBankingSolution.Persistance
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    
    }
}
