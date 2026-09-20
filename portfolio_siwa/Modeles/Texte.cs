using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Modeles
{
    /// <summary>
    /// Un contenu dans les trois langues du site. Les trois versions restent côte à côte :
    /// en ajouter une quatrième ou corriger une traduction se fait au même endroit.
    /// </summary>
    public sealed partial record Texte(string Fr, string En, string Oc)
    {
        // Calculées une fois : un texte s'affiche à chaque page, la typographie ne change jamais.
        private readonly string frTypographie = Typographie.Francaise(Fr);
        private readonly string ocTypographie = Typographie.Francaise(Oc);

        public string this[Langue langue] => langue switch
        {
            Langue.Anglais => this.En,
            Langue.Occitan => this.ocTypographie,
            _ => this.frTypographie,
        };

        /// <summary>Même contenu, rendu tel quel quand il porte un peu de HTML.</summary>
        public MarkupString Balise(Langue langue) => new(this[langue]);

        /// <summary>
        /// Texte nu, sans les balises de mise en avant. Les métadonnées de la page et
        /// les données structurées en ont besoin : un &lt;strong&gt; y passerait en clair.
        /// </summary>
        public string Nu(Langue langue) => Balises().Replace(this[langue], "").Trim();

        /// <summary>Pour ce qui ne se traduit pas : noms propres, années.</summary>
        public static Texte Unique(string valeur) => new(valeur, valeur, valeur);

        [GeneratedRegex("<[^>]+>")]
        private static partial Regex Balises();
    }
}
