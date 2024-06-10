using DDD.Core.DataPersistence;
using DDD.Core.Handlers.SHS.RD.CGC.Core.DomainEvents;
using DDD.Core.Holders;
using DDD.Core.Messages;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Wallet.Infrastructure.DataPersistence.Sqlite3
{
    public class Sqlite3DbContext : DbContext, IDomainContext
    {
        private readonly IMessageHandler _messageHandler;

        public Sqlite3DbContext(DbContextOptions<Sqlite3DbContext> options, IMessageHandler messageHandler)
        {
            _messageHandler = messageHandler;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await DispatchDomainEvents(cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        private async Task DispatchDomainEvents(CancellationToken cancellationToken)
        {
            var eventHolders = ChangeTracker.Entries()
                .Where(ee => ee.Entity is DomainEventHolder)
                .Select(ee => (DomainEventHolder)ee.Entity)
                .ToList();

            foreach (var eventHolder in eventHolders)
            {
                while (eventHolder.TryRemoveDomainEvent(out IEvent domainEvent))
                {
                    await _messageHandler.PublishAsync(domainEvent, cancellationToken);
                }
            }
        }
    }
}
