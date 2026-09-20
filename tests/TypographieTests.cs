using portfolio_siwa.Modeles;

namespace tests;

public class TypographieTests
{
    private const string Insecable = "\u00A0";

    [Theory]
    [InlineData("Une question ?", "Une question" + Insecable + "?")]
    [InlineData("Contact : moi", "Contact" + Insecable + ": moi")]
    [InlineData("Attention ! Vraiment ; oui", "Attention" + Insecable + "! Vraiment" + Insecable + "; oui")]
    [InlineData("95 % du territoire", "95" + Insecable + "% du territoire")]
    [InlineData("plus de 5 000 vidéos", "plus de 5" + Insecable + "000 vidéos")]
    [InlineData("29 000 sources et 4 500 informateurs", "29" + Insecable + "000 sources et 4" + Insecable + "500 informateurs")]
    [InlineData("plus de 37 millions de clients", "plus de 37" + Insecable + "millions de clients")]
    [InlineData("un « mot » entre guillemets", "un «" + Insecable + "mot" + Insecable + "» entre guillemets")]
    public void Les_espaces_deviennent_insecables(string entree, string attendu)
    {
        Assert.Equal(attendu, Typographie.Francaise(entree));
    }

    [Theory]
    [InlineData("En 2025 et 2026")]                  // des années, pas des milliers
    [InlineData("Voir https://exemple.fr/page")]     // un « : » collé au mot n'est pas de la ponctuation
    [InlineData("Bonjour")]
    [InlineData("")]
    public void Le_reste_du_texte_n_est_pas_touche(string entree)
    {
        Assert.Equal(entree, Typographie.Francaise(entree));
    }

    [Fact]
    public void Un_texte_est_traite_en_francais_et_en_occitan_mais_pas_en_anglais()
    {
        var texte = new Texte("Vraiment ?", "Really?", "Vertadièrament ?");

        Assert.Equal("Vraiment" + Insecable + "?", texte[Langue.Francais]);
        Assert.Equal("Vertadièrament" + Insecable + "?", texte[Langue.Occitan]);
        Assert.Equal("Really?", texte[Langue.Anglais]);
    }

    [Fact]
    public void La_typographie_ne_change_pas_le_texte_nu_utilise_par_les_moteurs()
    {
        // Nu() retire les balises : l'espace insécable doit survivre à ce passage.
        var texte = new Texte("Un <strong>essai</strong> : oui", "A test", "Un ensag");

        Assert.Equal("Un essai" + Insecable + ": oui", texte.Nu(Langue.Francais));
    }
}
