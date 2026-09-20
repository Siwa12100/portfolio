using portfolio_siwa.Donnees;
using portfolio_siwa.Modeles;

namespace tests;

public class PlanDuSiteTests
{
    [Fact]
    public void Le_sitemap_annonce_toutes_les_pages_et_leurs_traductions()
    {
        var sitemap = PlanDuSite.Sitemap();

        foreach (var page in Langues.Pages)
        {
            foreach (var langue in Langues.Toutes)
            {
                var adresse = PlanDuSite.Absolu(langue, page);

                Assert.Contains($"<loc>{adresse}</loc>", sitemap);
                Assert.Contains($"""hreflang="{langue.CodeIso()}" href="{adresse}" """.TrimEnd(), sitemap);
            }
        }

        // Le français sert de version par défaut pour les visiteurs d'ailleurs.
        Assert.Contains("""hreflang="x-default" href="https://jean-marcillac.dev/" """.TrimEnd(), sitemap);
    }

    [Fact]
    public void Le_fichier_robots_ouvre_le_site_et_designe_le_sitemap()
    {
        var robots = PlanDuSite.Robots();

        Assert.Contains("User-agent: *", robots);
        Assert.Contains("Allow: /", robots);
        Assert.Contains($"Sitemap: {PlanDuSite.Domaine}/sitemap.xml", robots);

        // Les robots d'IA sont nommés un par un : sans ça, plusieurs s'abstiennent.
        Assert.Contains("User-agent: GPTBot", robots);
        Assert.Contains("User-agent: ClaudeBot", robots);
        Assert.Contains("User-agent: PerplexityBot", robots);
    }

    [Fact]
    public void Le_resume_pour_les_modeles_cite_chaque_projet()
    {
        var llms = PlanDuSite.Llms();

        foreach (var fiche in CatalogueProjets.Tous)
        {
            Assert.Contains(fiche.Titre[Langue.Anglais], llms);
        }

        Assert.Contains(PlanDuSite.Courriel, llms);
        Assert.Contains(PlanDuSite.Github, llms);
    }

    [Fact]
    public void Le_resume_pour_les_modeles_liste_les_affiliations()
    {
        var llms = PlanDuSite.Llms();

        foreach (var affiliation in CatalogueAffiliations.Toutes)
        {
            Assert.Contains(affiliation.Nom[Langue.Anglais], llms);
            Assert.Contains(affiliation.Role[Langue.Anglais], llms);
        }
    }

    [Fact]
    public void Les_donnees_structurees_declarent_les_deux_associations()
    {
        // La sélection se fait sur le nom français : un renommage la viderait sans rien casser
        // d'autre, d'où ce test.
        foreach (var langue in Langues.Toutes)
        {
            var json = DonneesStructurees.Json(langue, PageSite.Accueil);
            var personne = System.Text.Json.JsonDocument.Parse(json).RootElement
                .GetProperty("@graph").EnumerateArray()
                .First(noeud => noeud.GetProperty("@type").GetString() == "Person");

            var noms = personne.GetProperty("memberOf").EnumerateArray()
                .Select(organisation => organisation.GetProperty("name").GetString())
                .ToList();

            Assert.Equal(2, noms.Count);
            Assert.Contains("Valorium", noms);
            Assert.Contains(CatalogueAffiliations.Toutes.Single(a => a.Nom.Fr == "Institut occitan de l'Aveyron").Nom[langue], noms);
        }
    }

    [Fact]
    public void Les_donnees_structurees_sont_un_json_valide()
    {
        foreach (var langue in Langues.Toutes)
        {
            foreach (var page in new PageSite?[] { PageSite.Accueil, PageSite.MentionsLegales, null })
            {
                var json = DonneesStructurees.Json(langue, page);

                // Un chevron non échappé refermerait la balise script de la page.
                Assert.DoesNotContain("</", json);

                var racine = System.Text.Json.JsonDocument.Parse(json).RootElement;

                Assert.Equal("https://schema.org", racine.GetProperty("@context").GetString());
                Assert.NotEqual(0, racine.GetProperty("@graph").GetArrayLength());
            }
        }
    }
}
