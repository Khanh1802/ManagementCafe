using ManagerCafe.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagerCafe.Data.Configurations
{
    public class InvetoryEntityTypeConfiguration : IEntityTypeConfiguration<Invetory>
    {
        public void Configure(EntityTypeBuilder<Invetory> builder)
        {
            builder.ToTable("Inventory");
            builder.Property(x => x.Quatity).IsRequired();
            builder.Property(x => x.IsDeleted).HasDefaultValue(false);
            builder.HasOne(x => x.Product).WithMany(x => x.Invetories).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.WareHouse).WithMany(x => x.Invetories).HasForeignKey(x => x.WareHouseId);
        }
    }
}
