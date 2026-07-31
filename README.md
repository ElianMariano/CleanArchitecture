# Clean Architecture

### How to Set Up

Docker set up

> docker-compose up -d

Login on PgAdmin with your credentials. The defaults are admin@admin.com and admin123.
Register a new host with name postgres_db. User is admin and password admin123.

Execute the entity framework migrations:

> dotnet ef migrations add InitialCreate --project src\CleanArchitecture.Infrastructure --startup-project src\CleanArchitecture.Api

> dotnet ef database update --project src\CleanArchitecture.Infrastructure --startup-project src\CleanArchitecture.Api