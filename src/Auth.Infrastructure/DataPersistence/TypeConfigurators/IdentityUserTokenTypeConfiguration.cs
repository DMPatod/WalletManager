using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Auth.Infrastructure.DataPersistence.TypeConfigurators
{
    internal class IdentityUserTokenTypeConfiguration : IEntityTypeConfiguration<IdentityUserToken<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserToken<string>> builder)
        {
            // Composite primary key consisting of the UserId, LoginProvider and Name
            builder.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

            var maxKeyLength = 128;
            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(t => t.LoginProvider).HasMaxLength(maxKeyLength);
            builder.Property(t => t.Name).HasMaxLength(maxKeyLength);

            // Maps to the AspNetUserTokens table
            builder.ToTable("UserTokens");
        }
    }
}
