using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using GCCoffeeShopV2.Domain.Models;

namespace GCCoffeeShopV2.Data
{
    class GCCoffeeShopInitializer : DropCreateDatabaseAlways<GCCoffeeShopContext>
    {
        protected override void Seed(GCCoffeeShopContext context)
        {
            var product = new Product()
            {
                ProductName = "Dark Roast",
                Price = 9.99m,
                Description = "A simple pound of beans"
            };
            context.Products.Add(product);

            var customer = new Customer()
            {
                FirstName = "Jill",
                LastName = "Palms",
                DateOfBirth = new DateTime(1990, 4, 20),
                FavoriteCoffee = "Black",
                Email = "JillPalms@Michigan.org",
                Password = "BillyTheSquid"
            };
            context.Customers.Add(customer);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
