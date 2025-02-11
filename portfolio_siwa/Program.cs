using Microsoft.AspNetCore.StaticFiles;
using MudBlazor.Services;
using portfolio_siwa;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Temporaire, pour corriger le bug liés aux vidéos de Blazor .NET 9 
app.MapGet("/banniereElendil", () =>
{
    var path = Path.Combine(app.Environment.ContentRootPath, "wwwroot", "Videos", "cinematique1.mp4");
    return Results.File(path, "video/mp4");
})
.AllowAnonymous();

app.Run();
