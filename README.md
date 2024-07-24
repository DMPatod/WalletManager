dotnet ef migrations add InitialAuthMigration -p .\src\Auth.Infrastructure -s .\src\WalletManager.Api -c Auth.Infrastructure.DataPersistence.Sqlite3.Sqlite3DbContext -o DataPersistence\Migrations
dotnet ef migrations add OrderUserRelation -p .\src\Wallet.Infrastructure -s .\src\WalletManager.Api -c Wallet.Infrastructure.DataPersistence.Sqlite3.Sqlite3DbContext -o DataPersistence\Migrations

dotnet ef migrations list -p .\src\WalletManager.API -c Auth.Infrastructure.DataPersistence.Sqlite3.Sqlite3DbContext

dotnet ef database update -p .\src\Auth.Infrastructure -s .\src\WalletManager.Api -c Auth.Infrastructure.DataPersistence.Sqlite3.Sqlite3DbContext
dotnet ef database update -p .\src\Wallet.Infrastructure -s .\src\WalletManager.Api -c Wallet.Infrastructure.DataPersistence.Sqlite3.Sqlite3DbContext

dotnet ef database drop -p .\src\Auth.Infrastructure -s .\src\WalletManager.Api -c Auth.Infrastructure.DataPersistence.Sqlite3.Sqlite3DbContext

DMpatod24!