using Microsoft.AspNetCore.Antiforgery;
using Microsoft.Net.Http.Headers;
using portfolio_siwa;
using portfolio_siwa.Donnees;
using portfolio_siwa.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Rendu statique côté serveur : le site n'a aucun état à maintenir, donc pas de
// circuit SignalR à garder ouvert. Les navigateurs intégrés (Instagram…) coupent
// ces connexions dès que l'utilisateur quitte l'application.
builder.Services.AddRazorComponents();

// Le site n'a aucun formulaire : pas de jeton antiforgery à émettre. Le service par défaut
// posait pourtant un cookie sur chaque page (voir AntiforgerySansFormulaire).
builder.Services.AddSingleton<IAntiforgery, AntiforgerySansFormulaire>();

// Une page fait 45 Ko de HTML, contre moins de 9 Ko compressée : sur le réseau mobile
// d'un navigateur intégré, c'est le poids qui décide de la vitesse d'affichage.
// Aucun jeton ni secret dans les pages, donc rien qu'une attaque par compression
// puisse exploiter : on peut compresser aussi en HTTPS.
builder.Services.AddResponseCompression(options => options.EnableForHttps = true);

var app = builder.Build();

// Pas de compression en développement : dotnet watch injecte dans chaque page un script de
// rechargement automatique du navigateur, et il ne sait pas le faire dans une réponse compressée
// (« Unable to configure browser refresh script injection »). Le poids ne compte que en ligne.
if (!app.Environment.IsDevelopment())
{
    app.UseResponseCompression();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Les contrôles de disponibilité et certains outils d'aperçu de lien interrogent en HEAD.
// Le routage ne sert que GET : sans ce relais, ils reçoivent une erreur alors que la page existe.
// Kestrel n'envoie de toute façon pas le corps d'une réponse à HEAD.
app.Use((context, next) =>
{
    if (HttpMethods.IsHead(context.Request.Method))
    {
        context.Request.Method = HttpMethods.Get;
    }

    return next();
});

// Les deux en-têtes que posait, sans le dire, le service antiforgery par défaut.
// X-Frame-Options garde le site hors des cadres d'autres sites. Le HTML se revalide à chaque
// visite plutôt que de rester en cache : une page périmée pointerait vers des feuilles de
// style et des scripts aux noms qui changent à chaque déploiement.
app.Use((context, next) =>
{
    context.Response.OnStarting(() =>
    {
        var entetes = context.Response.Headers;

        entetes[HeaderNames.XFrameOptions] = "SAMEORIGIN";

        if (entetes.ContentType.ToString().StartsWith("text/html", StringComparison.Ordinal))
        {
            entetes.CacheControl = "no-cache";
        }

        return Task.CompletedTask;
    });

    return next();
});

// WebApplication place sinon le routage tout au début du pipeline, donc avant le relais HEAD
// ci-dessus : l'endpoint serait choisi d'après la méthode d'origine, et HEAD n'en trouverait aucun.
app.UseRouting();

// Réexécute la requête sur /erreur/404 sans changer l'URL ni le code de statut :
// en rendu statique, une URL inconnue renverrait sinon une page blanche.
app.UseStatusCodePagesWithReExecute("/erreur/{0}");

app.MapStaticAssets();

app.MapRazorComponents<App>().DisableAntiforgery();

// Ce que lisent les robots avant la page elle-même. Les trois textes sont construits
// à partir du catalogue et de la liste des langues, donc une fois pour toutes au
// démarrage : ils ne changent qu'avec un nouveau déploiement.
var robots = PlanDuSite.Robots();
var sitemap = PlanDuSite.Sitemap();
var llms = PlanDuSite.Llms();

app.MapGet("/robots.txt", () => Results.Text(robots, "text/plain; charset=utf-8"));
app.MapGet("/sitemap.xml", () => Results.Text(sitemap, "application/xml; charset=utf-8"));

// Convention llmstxt.org : un résumé propre du site, pour les assistants qui
// préfèrent du texte au HTML de la page.
app.MapGet("/llms.txt", () => Results.Text(llms, "text/plain; charset=utf-8"));

app.Run();

// Rend le point d'entrée visible aux tests d'intégration (WebApplicationFactory).
public partial class Program;
