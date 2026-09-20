using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Diagnostics;

namespace portfolio_siwa.Modeles
{
    /// <summary>
    /// Le chemin que le visiteur a réellement demandé. Il ne se confond pas toujours
    /// avec celui que rend le serveur : une page d'erreur est obtenue en rejouant la
    /// requête sur /erreur/404, alors que l'adresse affichée reste celle d'origine.
    /// </summary>
    public static class Requete
    {
        public static string Chemin(HttpContext? contexte, NavigationManager navigation)
        {
            // Deux relais possibles selon la panne : un code d'erreur (404) ou une
            // exception non rattrapée (500). Les deux conservent l'adresse demandée.
            var origine = contexte?.Features.Get<IStatusCodeReExecuteFeature>()?.OriginalPath
                ?? contexte?.Features.Get<IExceptionHandlerPathFeature>()?.Path;

            var chemin = string.IsNullOrEmpty(origine)
                ? navigation.ToBaseRelativePath(navigation.Uri)
                : origine;

            return Langues.Normalise(chemin);
        }
    }
}
