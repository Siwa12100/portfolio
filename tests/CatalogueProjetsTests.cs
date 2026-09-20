using portfolio_siwa.Donnees;
using portfolio_siwa.Modeles;

namespace tests;

public class CatalogueProjetsTests
{
    [Fact]
    public void Le_catalogue_contient_des_projets()
    {
        Assert.NotEmpty(CatalogueProjets.Tous);
    }

    [Fact]
    public void Chaque_fiche_est_complete()
    {
        foreach (var fiche in CatalogueProjets.Tous)
        {
            EstRempli(fiche.Titre, "Titre");
            EstRempli(fiche.Categorie, "Categorie");
            EstRempli(fiche.Resume, "Resume");
            EstRempli(fiche.ResumeCourt, "ResumeCourt");
            EstRempli(fiche.Cadre, "Cadre");

            Assert.StartsWith("/Images/", fiche.Image);
            Assert.True(fiche.ImageLargeur > 0 && fiche.ImageHauteur > 0);
            Assert.NotEmpty(fiche.Technos);

            foreach (var techno in fiche.Technos)
            {
                Assert.False(string.IsNullOrWhiteSpace(techno.Nom));
                Assert.StartsWith("/Images/", techno.Logo);
                EstRempli(techno.Role, $"Role de {techno.Nom}");
            }
        }
    }

    [Fact]
    public void Les_liens_externes_sont_absolus()
    {
        foreach (var fiche in CatalogueProjets.Tous)
        {
            foreach (var lien in new[] { fiche.LienSite, fiche.LienGithub })
            {
                if (lien is not null)
                {
                    Assert.StartsWith("https://", lien);
                }
            }
        }
    }

    /// <summary>Un projet ajouté sans sa traduction anglaise ou occitane doit faire échouer les tests.</summary>
    private static void EstRempli(Texte? texte, string champ)
    {
        if (texte is null)
        {
            return;
        }

        foreach (var langue in Langues.Toutes)
        {
            Assert.False(string.IsNullOrWhiteSpace(texte[langue]), $"{champ} : {langue} manquant");
        }
    }
}
