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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-EM62T5T\MSSQLSERVER1;Database= Bank1;Trusted_Connection=True;");
            
        } 
    }
}
