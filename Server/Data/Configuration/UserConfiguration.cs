using GrpcService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrpcService.Data.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            ConfigureUserFields(builder);
        }

        private void ConfigureUserFields(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Id).HasColumnName("id");
            builder.Property(u => u.Name).HasColumnName("name");
            builder.Property(u => u.Balance).HasColumnName("balance");
            builder.Property(u => u.CreatedAt).HasColumnName("created_date");
        }
    }
}
