using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wallet.Domain.Orders;
using Wallet.Domain.Orders.ValueObjects;

namespace Wallet.Infrastructure.DataPersistence.TypeConfigurators
{
    internal class OrderTypeConfigurator : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => OrderId.Create(value));

            builder.HasOne(o => o.Ticket);
        }
    }
}
