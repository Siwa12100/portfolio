using System.Reflection;
using portfolio_siwa.Donnees;
using portfolio_siwa.Modeles;

namespace tests;

public class TraductionsTests
{
    /// <summary>
    /// Garde-fou sur l'oubli le plus probable : une chaîne ajoutée en français,
    /// et laissée vide dans les deux autres langues.
    /// </summary>
    [Fact]
    public void Chaque_chaine_existe_dans_les_trois_langues()
    {
        var chaines = typeof(Traductions)
            .GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Where(propriete => propriete.PropertyType == typeof(Texte))
            .ToList();

        Assert.NotEmpty(chaines);

        foreach (var propriete in chaines)
        {
            var texte = (Texte)propriete.GetValue(null)!;

            foreach (var langue in Langues.Toutes)
            {
                Assert.False(
                    string.IsNullOrWhiteSpace(texte[langue]),
                    $"{propriete.Name} : {langue} manquant");
            }
        }
    }

    [Fact]
    public void Chaque_affiliation_existe_dans_les_trois_langues()
    {
        Assert.NotEmpty(CatalogueAffiliations.Toutes);

        foreach (var affiliation in CatalogueAffiliations.Toutes)
        {
            foreach (var langue in Langues.Toutes)
            {
                Assert.False(string.IsNullOrWhiteSpace(affiliation.Nom[langue]), $"Nom : {langue} manquant");
                Assert.False(string.IsNullOrWhiteSpace(affiliation.Role[langue]), $"Rôle de {affiliation.Nom.Fr} : {langue} manquant");
                Assert.False(string.IsNullOrWhiteSpace(affiliation.Presentation[langue]), $"Présentation de {affiliation.Nom.Fr} : {langue} manquant");
            }
        }
    }

    [Fact]
    public void Les_balises_sont_retirees_du_texte_nu()
    {
        var texte = new Texte("Un <strong>essai</strong>", "A <strong>test</strong>", "Un <strong>ensag</strong>");

        Assert.Equal("Un essai", texte.Nu(Langue.Francais));
        Assert.Equal("A test", texte.Nu(Langue.Anglais));
    }
}
