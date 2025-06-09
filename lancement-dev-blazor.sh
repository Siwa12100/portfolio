#!/bin/bash

# === 🎯 USAGE ===
# ./lance-dev.sh <port> [-w]
# Exemple : ./lance-dev.sh 50001 -w

# === ✅ Vérification des arguments ===
if [ -z "$1" ]; then
  echo "❌ Utilisation : ./lance-dev.sh <port> [-w]"
  echo "   Exemple     : ./lance-dev.sh 50001 -w"
  exit 1
fi

PORT=$1
USE_WATCH=false

if [ "$2" == "-w" ]; then
  USE_WATCH=true
fi

# === 📦 Chargement des variables depuis le fichier .env ===
if [ -f .env ]; then
  echo "📦 Chargement des variables depuis .env..."
  export $(grep -v '^#' .env | xargs)
else
  echo "⚠️  Fichier .env non trouvé. Certaines variables peuvent manquer."
fi

# === 🖨 Affichage du port utilisé ===
echo "🚀 Port utilisé  = $PORT"

# === 🔥 Lancement de l'application ===

if [ "$USE_WATCH" = true ]; then
  echo "👀 Mode surveillance activé avec dotnet watch..."
  dotnet watch --project portfolio_siwa run --urls "http://0.0.0.0:$PORT"
else
  echo "🏃 Lancement classique avec dotnet run..."
  dotnet run --project portfolio_siwa --urls "http://0.0.0.0:$PORT"
fi
