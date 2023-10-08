FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

COPY OnlineStore.Api/*.csproj ./OnlineStore.Api/
COPY OnlineStore.Application/*.csproj ./OnlineStore.Application/
COPY OnlineStore.Infrastructure/*.csproj ./OnlineStore.Infrastructure/
COPY OnlineStore.Domain/*.csproj ./OnlineStore.Domain/
RUN dotnet restore OnlineStore.Api/OnlineStore.Api.csproj
COPY OnlineStore.Api ./OnlineStore.Api
COPY OnlineStore.Application ./OnlineStore.Application
COPY OnlineStore.Infrastructure ./OnlineStore.Infrastructure
COPY OnlineStore.Domain ./OnlineStore.Domain
WORKDIR /source/OnlineStore.Api
RUN dotnet dev-certs https --trust
RUN dotnet publish -c release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /run
COPY --from=build /source/OnlineStore.Api/out .
COPY --from=build /root/.dotnet/corefx/cryptography/x509stores/my/* /root/.dotnet/corefx/cryptography/x509stores/my/
ENTRYPOINT ["dotnet", "OnlineStore.Api.dll"]