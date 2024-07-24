using Auth.Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.DataPersistence.Sqlite3
{
    public class Sqlite3DbContext : IdentityDbContext<AuthUser>
    {
        public Sqlite3DbContext(DbContextOptions<Sqlite3DbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(Sqlite3DbContext).Assembly);
        }
    }
}
