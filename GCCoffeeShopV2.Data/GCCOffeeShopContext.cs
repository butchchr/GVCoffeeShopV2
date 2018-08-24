using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GCCoffeeShopV2.Data.Maps;
using GCCoffeeShopV2.Domain.Models;

namespace GCCoffeeShopV2.Data
{
    public class GCCoffeeShopContext : DbContext
    {
        public GCCoffeeShopContext() : base()
        {
            Database.SetInitializer(new GCCoffeeShopInitializer());
        }

        public IDbSet<Product> Products { get; set; }
        public IDbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
