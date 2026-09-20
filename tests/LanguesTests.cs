using portfolio_siwa.Modeles;

namespace tests;

public class LanguesTests
{
    [Theory]
    [InlineData("/", Langue.Francais)]
    [InlineData("/mentions-legales", Langue.Francais)]
    [InlineData("/en", Langue.Anglais)]
    [InlineData("/en/legal-notice", Langue.Anglais)]
    [InlineData("/oc/mencions-legalas", Langue.Occitan)]
    [InlineData("/erreur/404", Langue.Francais)]
    [InlineData("", Langue.Francais)]
    public void La_langue_se_lit_dans_l_adresse(string chemin, Langue attendue)
    {
        Assert.Equal(attendue, Langues.Depuis(chemin));
    }

    [Theory]
    [InlineData("/", PageSite.Accueil)]
    [InlineData("/en", PageSite.Accueil)]
    [InlineData("/oc/", PageSite.Accueil)]
    [InlineData("/mentions-legales", PageSite.MentionsLegales)]
    [InlineData("/en/legal-notice", PageSite.MentionsLegales)]
    [InlineData("/oc/mencions-legalas", PageSite.MentionsLegales)]
    public void La_page_se_reconnait_dans_toutes_les_langues(string chemin, PageSite attendue)
    {
        Assert.Equal(attendue, Langues.PageDe(chemin));
    }

    [Theory]
    [InlineData("/erreur/404")]
    [InlineData("/Error")]
    [InlineData("/page-qui-nexiste-pas")]
    public void Une_adresse_inconnue_ne_designe_aucune_page(string chemin)
    {
        // C'est ce qui sort la page d'erreur de l'index et lui retire ses liens hreflang.
        Assert.Null(Langues.PageDe(chemin));
    }

    [Fact]
    public void Le_selecteur_de_langue_garde_la_page_affichee()
    {
        Assert.Equal("/en/legal-notice", Langues.Equivalent("/mentions-legales", Langue.Anglais));
        Assert.Equal("/mentions-legales", Langues.Equivalent("/oc/mencions-legalas", Langue.Francais));
        Assert.Equal("/oc", Langues.Equivalent("/en", Langue.Occitan));

        // Depuis une page inconnue, il n'y a que l'accueil comme point de chute.
        Assert.Equal("/en", Langues.Equivalent("/erreur/404", Langue.Anglais));
    }

    [Fact]
    public void L_ancre_et_la_requete_ne_changent_pas_la_page()
    {
        Assert.Equal(PageSite.Accueil, Langues.PageDe("/en#projets"));
        Assert.Equal(Langue.Anglais, Langues.Depuis("/en?source=instagram"));
    }

    [Fact]
    public void Chaque_page_a_une_adresse_unique()
    {
        var adresses = Langues.Pages
            .SelectMany(page => Langues.Toutes.Select(langue => langue.Adresse(page)))
            .ToList();

        Assert.Equal(adresses.Count, adresses.Distinct().Count());

        // Et chacune retombe bien sur sa langue et sa page.
        foreach (var page in Langues.Pages)
        {
            foreach (var langue in Langues.Toutes)
            {
                var adresse = langue.Adresse(page);

                Assert.Equal(langue, Langues.Depuis(adresse));
                Assert.Equal(page, Langues.PageDe(adresse));
            }
        }
    }
}
