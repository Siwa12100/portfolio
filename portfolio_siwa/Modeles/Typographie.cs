using System.Text.RegularExpressions;

namespace portfolio_siwa.Modeles
{
    /// <summary>
    /// Règles de typographie du français et de l'occitan, qui s'écrivent avec une espace insécable
    /// avant « ? », « ! », « : », « ; » et « % », entre les groupes de chiffres, et à l'intérieur des
    /// guillemets. Une espace ordinaire laisse le signe seul en début de ligne, ou coupe « 5 000 ».
    /// Appliquées ici plutôt que dans chaque texte : un texte ajouté en profite sans y penser.
    /// </summary>
    public static partial class Typographie
    {
        private const string Insecable = "\u00A0";

        public static string Francaise(string texte)
        {
            if (string.IsNullOrEmpty(texte))
            {
                return texte;
            }

            texte = AvantPonctuationHaute().Replace(texte, Insecable + "$1");
            texte = ChiffresSepares().Replace(texte, Insecable);
            texte = GuillemetsOuvrants().Replace(texte, "«" + Insecable);
            texte = GuillemetsFermants().Replace(texte, Insecable + "»");

            return texte;
        }

        /// <summary>Espace avant « ? ! : ; % », sauf en début de texte.</summary>
        [GeneratedRegex(@"(?<=\S) ([?!:;%])")]
        private static partial Regex AvantPonctuationHaute();

        /// <summary>Groupes de milliers (« 5 000 ») et unités qui suivent un nombre (« 37 millions »).</summary>
        [GeneratedRegex(@"(?<=\d) (?=\d{3}(?!\d)|millions?\b|milions?\b)")]
        private static partial Regex ChiffresSepares();

        [GeneratedRegex("« ")]
        private static partial Regex GuillemetsOuvrants();

        [GeneratedRegex(" »")]
        private static partial Regex GuillemetsFermants();
    }
}
