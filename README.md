## Introduction

This project was created to help me learn about C#, ASP.Net Core, Entity Framework Core, and more.

## Purpose

The purpose of this project is to provide an example of how to build an ASP.Net Core application using DDD and popular design patterns.

## Technologies

This project uses the following technologies:

- ASP.Net Core 8
- Entity Framework Core 8
- MediatR
- AutoMapper

## How to Use

To use this project, follow these steps:

1. Clone the repository.
2. Open the `Backend` folder and update the `appsettings.json` file to connect to MSSQL Server.
3. Run the `OnlineStore.Api` project with the dotnet CLI or set it as the default project if you're using Visual Studio.

## How to Contribute

If you'd like to contribute to this project, please follow these steps:

1. Submit a bug report or feature request by opening an issue.
2. Fork the repository.
3. Create a new branch.
4. Make your changes.
5. Submit a pull request.

## Running Locally

To run this project locally, follow these steps:

1. Go to the `Deployment` folder to check the docker-compose file.
2. Run the command: `docker compose -f docker-compose.yml` to build the OnlineStore image.
3. Run the command: `docker compose -f docker-compose.yml -f docker-db-compose.yml up` to create and run the SQL Server and OnlineStore containers.
