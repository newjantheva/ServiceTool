using Microsoft.EntityFrameworkCore;
using ServiceTool.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceTool.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=mydb;Trusted_Connection=True;");
        }
    }
}
