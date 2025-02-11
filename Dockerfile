# Étape de base pour exécuter l'application avec .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Étape de construction avec .NET 9 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copie du fichier projet et restauration des dépendances
COPY ["portfolio_siwa/portfolio_siwa.csproj", "portfolio_siwa/"]
RUN dotnet restore "./portfolio_siwa/portfolio_siwa.csproj"

# Copie des sources et compilation
COPY . .
WORKDIR "/src/portfolio_siwa"
RUN dotnet build "./portfolio_siwa.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Étape de publication
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./portfolio_siwa.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Étape finale : image pour l'exécution
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "portfolio_siwa.dll"]
