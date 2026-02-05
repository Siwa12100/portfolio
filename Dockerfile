# Étape de base pour exécuter l'application avec .NET 9
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 8080

# Créer un utilisateur non-root pour l'étape finale
RUN useradd -m appuser

# Étape de construction avec .NET 9 SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copier uniquement les fichiers nécessaires au restore
COPY portfolio_siwa/portfolio_siwa.csproj ./portfolio_siwa/

# Restore des dépendances
RUN dotnet restore portfolio_siwa/portfolio_siwa.csproj

# Copier les fichiers sources
COPY portfolio_siwa/ ./portfolio_siwa/
COPY tests/ ./tests/
COPY portfolio_siwa.sln ./

WORKDIR /src/portfolio_siwa

# Construire l'application (pas besoin de clean dans Docker)
RUN dotnet build "portfolio_siwa.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Étape de publication
FROM build AS publish
ARG BUILD_CONFIGURATION=Release

# Publier l'application
RUN dotnet publish "portfolio_siwa.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Étape finale : image d'exécution sécurisée
FROM base AS final
WORKDIR /app

# Copier le résultat publié
COPY --from=publish /app/publish .

# Changer les droits et utiliser l'utilisateur non-root
RUN chown -R appuser:appuser /app
USER appuser

# Entrée de l'application
ENTRYPOINT ["dotnet", "portfolio_siwa.dll"]








# # Étape de base pour exécuter l'application avec .NET 9
# FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
# WORKDIR /app
# EXPOSE 8080

# # Créer un utilisateur non-root pour l'étape finale
# RUN useradd -m appuser

# # Étape de construction avec .NET 9 SDK
# FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
# ARG BUILD_CONFIGURATION=Release
# WORKDIR /src

# # Copier uniquement les fichiers nécessaires au restore
# COPY portfolio_siwa/portfolio_siwa.csproj ./portfolio_siwa/

# # Désactiver le cache Docker si la structure change
# RUN dotnet restore portfolio_siwa/portfolio_siwa.csproj

# # Copier uniquement les fichiers utiles à la compilation (et ignorer les fichiers sensibles)
# COPY portfolio_siwa/ ./portfolio_siwa/
# COPY tests/ ./tests/
# COPY portfolio_siwa.sln ./

# WORKDIR /src/portfolio_siwa

# # Nettoyer les dossiers avant build pour éviter les problèmes de compression
# RUN dotnet clean && rm -rf bin obj

# # Construire l'application
# RUN dotnet build "portfolio_siwa.csproj" -c $BUILD_CONFIGURATION -o /app/build

# # Étape de publication
# FROM build AS publish
# ARG BUILD_CONFIGURATION=Release

# # Nettoyage avant publication
# WORKDIR /src/portfolio_siwa
# RUN dotnet clean && rm -rf bin obj

# # Empêcher la compression des assets Blazor (si bug compression) 
# RUN dotnet publish "portfolio_siwa.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# # Étape finale : image d'exécution sécurisée
# FROM base AS final
# WORKDIR /app

# # Copier le résultat publié
# COPY --from=publish /app/publish .

# # Changer les droits et utiliser l'utilisateur non-root
# RUN chown -R appuser:appuser /app
# USER appuser

# # Entrée de l'application
# ENTRYPOINT ["dotnet", "portfolio_siwa.dll"]