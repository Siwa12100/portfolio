using portfolio_siwa;
using portfolio_siwa.Donnees;

var builder = WebApplication.CreateBuilder(args);

// Rendu statique côté serveur : le site n'a aucun état à maintenir, donc pas de
// circuit SignalR à garder ouvert. Les navigateurs intégrés (Instagram…) coupent
// ces connexions dès que l'utilisateur quitte l'application.
builder.Services.AddRazorComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// Réexécute la requête sur /erreur/404 sans changer l'URL ni le code de statut :
// en rendu statique, une URL inconnue renverrait sinon une page blanche.
app.UseStatusCodePagesWithReExecute("/erreur/{0}");

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>();

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
