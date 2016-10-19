using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SimpleShopWebFr.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SimpleShopDbContext : DbContext
    {
        public SimpleShopDbContext() : base("name=SimpleShopDbContext")
        { }


        public DbSet<Admin> Admins { get; set; }

        public DbSet<BillDetail> BillDetails { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<FinancialAccount> FinancialAccounts { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ShipAddress> ShipAddresses { get; set; }

        public DbSet<StandardAddress> StandardAddresses { get; set; }
    }
}