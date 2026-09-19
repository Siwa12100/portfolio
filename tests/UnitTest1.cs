using portfolio_siwa.Donnees;

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
            Assert.False(string.IsNullOrWhiteSpace(fiche.Titre));
            Assert.False(string.IsNullOrWhiteSpace(fiche.Categorie));
            Assert.False(string.IsNullOrWhiteSpace(fiche.Resume.Value));
            Assert.False(string.IsNullOrWhiteSpace(fiche.Cadre));
            Assert.StartsWith("/Images/", fiche.Image);
            Assert.True(fiche.ImageLargeur > 0 && fiche.ImageHauteur > 0);
            Assert.NotEmpty(fiche.Technos);
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
}
