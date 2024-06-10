using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Domain.Orders.Entities;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Infrastructure.DataPersistence.TypeConfigurators
{
    internal class TicketTypeConfigurator : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("Tickets");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => TicketId.Create(value));

            builder.Property(t => t.Cod);

            builder.Property(t => t.Title);

            builder.Property(t => t.Owner);

            builder.Property(t => t.Currency);

            builder.HasMany(t => t.Orders);

            builder.HasOne(t => t.Portfolio);
        }
    }
}
