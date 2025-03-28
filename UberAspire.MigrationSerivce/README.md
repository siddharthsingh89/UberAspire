## Migration Service
* The Migration Service is responsible for migrating Entity Framework DB Context as it evolves.
* It is a Background Worker service which runs immediately after Ride Database is initialized.
* It runs the safe DB Migration and ensures that the DB is up-to-date with the latest schema.

## Additional Information
1. We can use it to seed database with initial data.
2. Any other database specific job like index creation and maintianence can be added in this.

## References
1. [Entity Framework Core Migrations](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)
2. [Entity Framework Core Tools](https://docs.microsoft.com/en-us/ef/core/cli/dotnet)
3. [.Net Aspire Migratoin](https://learn.microsoft.com/en-us/dotnet/aspire/database/ef-core-migrations)