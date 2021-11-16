using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab2
{
    class BankContext: DbContext
    {
        public BankContext()
        {

        }
        
        public virtual DbSet<UserData> Users { set; get; }
        public virtual DbSet<EmployeeData> Employees { set; get; }
        public virtual DbSet<Bill> Bills { set; get; }
        public virtual DbSet<Card> Cards { set; get; }
        public virtual DbSet<Currency> Currencies { set; get; }
        public virtual DbSet<Credit> Credits { set; get; }
        public virtual DbSet<Deposit> Deposits { set; get; }
        public virtual DbSet<Service> Services { set; get; }
        public virtual DbSet<Operation> Operations { set; get; }
        public virtual DbSet<ExchangeCurrency> ExchangeCurrencies { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-EM62T5T\MSSQLSERVER1;Database= Bank2;Trusted_Connection=True;");
            
        } 
    }
}
