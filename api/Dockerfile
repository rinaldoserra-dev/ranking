FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/RS.Ranking.Catalog.Api/RS.Ranking.Catalog.Api.csproj", "src/RS.Ranking.Catalog.Api/"]
RUN dotnet restore "src/RS.Ranking.Catalog.Api/RS.Ranking.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/src/RS.Ranking.Catalog.Api"
RUN dotnet build "RS.Ranking.Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RS.Ranking.Catalog.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS.Ranking.Catalog.Api.dll"]