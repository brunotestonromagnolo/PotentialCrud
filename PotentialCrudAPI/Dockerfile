#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["PotentialCrudAPI/PotentialCrudAPI.csproj", "PotentialCrudAPI/"]
COPY ["PotentialCrud.Infrastructure/PotentialCrud.Infrastructure.csproj", "PotentialCrud.Infrastructure/"]
COPY ["PotentialCrudDomain.Core/PotentialCrudDomain.Core.csproj", "PotentialCrudDomain.Core/"]
COPY ["PotentialCrudDomain/PotentialCrudDomain.csproj", "PotentialCrudDomain/"]
COPY ["PotentialCrud.Domain.Service/PotentialCrud.Domain.Service.csproj", "PotentialCrud.Domain.Service/"]
COPY ["PotentialCrudApplication/PotentialCrudApplication.csproj", "PotentialCrudApplication/"]
RUN dotnet restore "PotentialCrudAPI/PotentialCrudAPI.csproj"
COPY . .
WORKDIR "/src/PotentialCrudAPI"
RUN dotnet build "PotentialCrudAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PotentialCrudAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
EXPOSE 6651
ENTRYPOINT ["dotnet", "PotentialCrudAPI.dll"]