using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using portfolio_siwa.Donnees;
using portfolio_siwa.Modeles;

namespace tests;

/// <summary>
/// Le site démarré pour de bon, interrogé comme le ferait un navigateur ou un robot.
/// Ces tests gardent des promesses faites aux visiteurs et aux moteurs de recherche, que
/// rien d'autre ne surveille : les mentions légales disent qu'aucun cookie n'est posé,
/// et le référencement suppose que chaque langue soit servie avec les bonnes balises.
/// </summary>
public class SiteHttpTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> fabrique;

    public SiteHttpTests(WebApplicationFactory<Program> fabrique)
    {
        // Configuration de production : c'est celle qui sert les visiteurs.
        this.fabrique = fabrique.WithWebHostBuilder(constructeur => constructeur.UseEnvironment("Production"));
    }

    public static IEnumerable<object[]> ToutesLesPages() =>
        Langues.Pages.SelectMany(page => Langues.Toutes.Select(langue => new object[] { langue, page }));

    [Theory]
    [MemberData(nameof(ToutesLesPages))]
    public async Task Chaque_page_est_servie_dans_sa_langue_avec_ses_balises(Langue langue, PageSite page)
    {
        var client = this.fabrique.CreateClient();
        var reponse = await client.GetAsync(langue.Adresse(page));
        var html = await reponse.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.OK, reponse.StatusCode);
        Assert.Contains($"<html lang=\"{langue.CodeIso()}\"", html);
        Assert.Contains($"<link rel=\"canonical\" href=\"{PlanDuSite.Absolu(langue, page)}\"", html);

        // Les trois traductions et la version par défaut se déclarent sur chaque page.
        foreach (var autre in Langues.Toutes)
        {
            Assert.Contains($"hreflang=\"{autre.CodeIso()}\" href=\"{PlanDuSite.Absolu(autre, page)}\"", html);
        }

        Assert.Contains("hreflang=\"x-default\"", html);
        Assert.Contains("application/ld+json", html);
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/en")]
    [InlineData("/oc")]
    [InlineData("/mentions-legales")]
    [InlineData("/en/legal-notice")]
    [InlineData("/oc/mencions-legalas")]
    [InlineData("/robots.txt")]
    [InlineData("/sitemap.xml")]
    [InlineData("/llms.txt")]
    [InlineData("/adresse-qui-nexiste-pas")]
    public async Task Aucune_reponse_ne_depose_de_cookie(string chemin)
    {
        var client = this.fabrique.CreateClient();
        var reponse = await client.GetAsync(chemin);

        // Les mentions légales affirment que le site ne dépose aucun cookie. Le service
        // antiforgery par défaut en posait un sur chaque page : voir AntiforgerySansFormulaire.
        Assert.False(reponse.Headers.Contains("Set-Cookie"), $"{chemin} dépose un cookie");
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/en/legal-notice")]
    public async Task Le_html_se_revalide_sans_interdire_le_cache(string chemin)
    {
        var client = this.fabrique.CreateClient();
        var reponse = await client.GetAsync(chemin);
        var cache = reponse.Headers.CacheControl;

        Assert.NotNull(cache);
        Assert.True(cache!.NoCache);

        // no-store empêche le retour instantané en arrière : c'est ce que posait l'antiforgery.
        Assert.False(cache.NoStore);
        Assert.Equal("SAMEORIGIN", reponse.Headers.GetValues("X-Frame-Options").Single());
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/en")]
    [InlineData("/sitemap.xml")]
    public async Task Les_reponses_sont_compressees_quand_le_navigateur_le_demande(string chemin)
    {
        var client = this.fabrique.CreateClient();
        var requete = new HttpRequestMessage(HttpMethod.Get, chemin);
        requete.Headers.AcceptEncoding.ParseAdd("gzip");

        var reponse = await client.SendAsync(requete);

        Assert.Contains("gzip", reponse.Content.Headers.ContentEncoding);
    }

    [Theory]
    [InlineData("/")]
    [InlineData("/oc")]
    [InlineData("/en/legal-notice")]
    [InlineData("/robots.txt")]
    [InlineData("/sitemap.xml")]
    [InlineData("/llms.txt")]
    public async Task Un_controle_en_HEAD_reussit_comme_un_GET(string chemin)
    {
        var client = this.fabrique.CreateClient();
        var reponse = await client.SendAsync(new HttpRequestMessage(HttpMethod.Head, chemin));

        // Le corps n'est pas contrôlé ici : c'est Kestrel qui le supprime pour HEAD, et le
        // serveur de test ne le fait pas. Ce qui compte, c'est que la page ne soit pas refusée.
        Assert.Equal(HttpStatusCode.OK, reponse.StatusCode);
    }

    [Fact]
    public async Task Une_adresse_inconnue_repond_404_et_reste_hors_de_l_index()
    {
        var client = this.fabrique.CreateClient();
        var reponse = await client.GetAsync("/en/nimporte-quoi");
        var html = await reponse.Content.ReadAsStringAsync();

        Assert.Equal(HttpStatusCode.NotFound, reponse.StatusCode);
        Assert.Contains("noindex", html);

        // La page d'erreur garde la langue de l'adresse demandée, pas celle de /erreur/404.
        Assert.Contains("<html lang=\"en\"", html);

        // Elle ne se déclare équivalente à aucune autre page : pas de <link rel="alternate">.
        // Les liens du sélecteur de langue portent eux aussi un hreflang, d'où la précision.
        Assert.DoesNotContain("<link rel=\"alternate\"", html);
    }

    [Fact]
    public async Task Aucune_ressource_n_est_chargee_chez_un_tiers()
    {
        var client = this.fabrique.CreateClient();
        var html = await (await client.GetAsync("/")).Content.ReadAsStringAsync();

        // Les mentions légales promettent qu'aucune donnée n'est transmise : une police ou un
        // script chargés ailleurs enverraient l'adresse IP de chaque visiteur à un tiers.
        Assert.DoesNotContain("fonts.googleapis.com", html);
        Assert.DoesNotContain("fonts.gstatic.com", html);
        Assert.DoesNotContain("<script src=\"http", html);
        Assert.DoesNotContain("<link rel=\"stylesheet\" href=\"http", html);
    }
}
