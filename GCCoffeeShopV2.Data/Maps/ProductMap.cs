using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using GCCoffeeShopV2.Domain.Models;

namespace GCCoffeeShopV2.Data.Maps
{
    class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProductName)
                .HasMaxLength(50)
                .IsRequired();
            Property(x => x.Price)
                .IsRequired();
            Property(x => x.Description)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
