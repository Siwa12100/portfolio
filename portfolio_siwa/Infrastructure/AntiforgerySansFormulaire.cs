using Microsoft.AspNetCore.Antiforgery;

namespace portfolio_siwa.Infrastructure
{
    /// <summary>
    /// Antiforgery neutre, pour un site sans formulaire.
    /// <para>
    /// Le moteur Blazor demande un jeton à chaque réponse, avant même de savoir s'il y a un
    /// formulaire à protéger. Le service par défaut répond en posant un cookie et un
    /// « Cache-Control: no-store » sur toutes les pages : un cookie que les mentions légales
    /// disent ne jamais déposer, et l'impossibilité pour le navigateur de garder la page en
    /// mémoire pour un retour instantané en arrière.
    /// </para>
    /// <para>
    /// Ce service ne pose donc ni cookie ni en-tête. Il refuse en revanche toute validation :
    /// si un formulaire est ajouté un jour, il échouera bruyamment au lieu de rester sans
    /// protection. Il faudra alors retirer ce service, réactiver <c>UseAntiforgery()</c> et
    /// mettre à jour les mentions légales, puisqu'un cookie sera de nouveau posé.
    /// </para>
    /// </summary>
    public sealed class AntiforgerySansFormulaire : IAntiforgery
    {
        private const string Message =
            "Ce site n'a aucun formulaire, donc aucune protection antiforgery. " +
            "Pour en ajouter un, retirer AntiforgerySansFormulaire (voir sa documentation).";

        public AntiforgeryTokenSet GetAndStoreTokens(HttpContext httpContext) => Vide;

        public AntiforgeryTokenSet GetTokens(HttpContext httpContext) => Vide;

        public Task<bool> IsRequestValidAsync(HttpContext httpContext) => Task.FromResult(false);

        public Task ValidateRequestAsync(HttpContext httpContext) =>
            throw new InvalidOperationException(Message);

        public void SetCookieTokenAndHeader(HttpContext httpContext)
        {
        }

        private static AntiforgeryTokenSet Vide { get; } = new(
            requestToken: null,
            cookieToken: null,
            formFieldName: "__RequestVerificationToken",
            headerName: "RequestVerificationToken");
    }
}
