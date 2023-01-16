using ManagerCafe.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ManagerCafe.Data.Configurations
{
    public class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(x => x.Password).HasMaxLength(100).IsRequired();
            builder.Property(x => x.FullName).HasMaxLength(400).IsRequired();
            builder.Property(x => x.IsActive).HasDefaultValue(false);
            builder.Property(x => x.PhoneNumber).HasMaxLength(400).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(300).IsRequired();
            builder.HasOne(x => x.UserType).WithMany(x => x.Users).HasForeignKey(x => x.UserTypeId);

            builder.HasIndex(x => x.UserName).IsFullText();
            builder.HasIndex(x => x.PhoneNumber).IsFullText();
            builder.HasIndex(x => x.Email).IsFullText();
            builder.HasIndex(x => x.UserTypeId);
        }
    }
}
