using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using GCCoffeeShopV2.Domain.Models;

namespace GCCoffeeShopV2.Data.Maps
{
    class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FirstName)
                .HasMaxLength(50)
                .IsRequired();
            Property(x => x.LastName)
                .HasMaxLength(50)
                .IsRequired();
            Property(x => x.DateOfBirth)
                .IsRequired();
            Property(x => x.FavoriteCoffee)
                .IsRequired();
            Property(x => x.Email)
                .HasMaxLength(254)
                .IsRequired();
            Property(x => x.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
