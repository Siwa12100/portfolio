using portfolio_siwa;

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

app.Run();
