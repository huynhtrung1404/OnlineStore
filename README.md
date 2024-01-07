# OnlineStore

This project is created by me to learn about C#, ASP.Net Core, Entity Framework Core, and so on

## Technology

- ASP.Net Core 7
- Entity Framework Core 7
- MediatR
- AutoMapper

## Main purpose

This project is an example ASP.Net Core base on EShopOnWeb. It include DDD and some popular design pattern (Repository, unit of work ......)

## Running on local environment

1.  For running it on local machine, open folder Backend update fie appsettings.json file to connect MSSQL Server.
2.  Default project is OnlineStore.Api. Run this project with dotnet CLI or set this project is default if use Visual Studio

## Running with docker

- Go to the Deployment to check the docker compose file
- Run command: "docker compose -f docker-compose.yml" to build OnlineStore image
- Run command: "docker compose -f docker-compose.yml -f docker-db-compose.yml" up to create and run Sql Server and OnlineStore container.
