# Étape de construction
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Le restore d'abord, seul : tant que le .csproj ne bouge pas, le cache tient.
COPY portfolio_siwa/portfolio_siwa.csproj ./portfolio_siwa/
RUN dotnet restore portfolio_siwa/portfolio_siwa.csproj

COPY portfolio_siwa/ ./portfolio_siwa/
RUN dotnet publish portfolio_siwa/portfolio_siwa.csproj \
    -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Image d'exécution
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
EXPOSE 8080

RUN useradd -m appuser
COPY --from=build --chown=appuser:appuser /app/publish .
USER appuser

ENTRYPOINT ["dotnet", "portfolio_siwa.dll"]
