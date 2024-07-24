using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Domain.Users;
using Wallet.Domain.Users.ValueObjects;

namespace Wallet.Infrastructure.DataPersistence.TypeConfigurators
{
    internal class UserTypeConfigurator : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users", t => t.ExcludeFromMigrations());

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

            builder.HasQueryFilter(u => u.Id != null!);
        }
    }
}
