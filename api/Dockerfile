FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

COPY ./Ranking.sln ./
COPY src/RS.Ranking.Catalog.Api/RS.Ranking.Catalog.Api.csproj  ./src/RS.Ranking.Catalog.Api/RS.Ranking.Catalog.Api.csproj
COPY src/RS.Ranking.Catalog.Application/RS.Ranking.Catalog.Application.csproj  ./src/RS.Ranking.Catalog.Application/RS.Ranking.Catalog.Application.csproj
COPY src/RS.Ranking.Catalog.Domain/RS.Ranking.Catalog.Domain.csproj  ./src/RS.Ranking.Catalog.Domain/RS.Ranking.Catalog.Domain.csproj
COPY src/RS.Ranking.Catalog.Infra.Data.EF/RS.Ranking.Catalog.Infra.Data.EF.csproj  ./src/RS.Ranking.Catalog.Infra.Data.EF/RS.Ranking.Catalog.Infra.Data.EF.csproj
COPY src/Flunt/Flunt.csproj  ./src/Flunt/Flunt.csproj

RUN dotnet restore --force

COPY . .

RUN dotnet publish -c Release -o out

FROM base AS final
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "RS.Ranking.Api.dll"]