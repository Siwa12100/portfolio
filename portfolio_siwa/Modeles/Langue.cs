namespace portfolio_siwa.Modeles
{
    public enum Langue
    {
        Francais,
        Anglais,
        Occitan,
    }

    /// <summary>Les pages du site. Chacune existe dans les trois langues.</summary>
    public enum PageSite
    {
        Accueil,
        MentionsLegales,
    }

    public static class Langues
    {
        public static IReadOnlyList<Langue> Toutes { get; } =
            [Langue.Francais, Langue.Anglais, Langue.Occitan];

        public static IReadOnlyList<PageSite> Pages { get; } =
            [PageSite.Accueil, PageSite.MentionsLegales];

        /// <summary>Premier segment d'URL de la langue. Le français n'en a pas.</summary>
        public static string Prefixe(this Langue langue) => langue switch
        {
            Langue.Anglais => "en",
            Langue.Occitan => "oc",
            _ => "",
        };

        /// <summary>Code utilisé dans l'attribut lang et les liens hreflang.</summary>
        public static string CodeIso(this Langue langue) => langue switch
        {
            Langue.Anglais => "en",
            Langue.Occitan => "oc",
            _ => "fr",
        };

        /// <summary>Code région attendu par les aperçus de partage (Open Graph).</summary>
        public static string Locale(this Langue langue) => langue switch
        {
            Langue.Anglais => "en_GB",
            Langue.Occitan => "oc_FR",
            _ => "fr_FR",
        };

        /// <summary>Libellé court du sélecteur de langue.</summary>
        public static string Etiquette(this Langue langue) => langue switch
        {
            Langue.Anglais => "EN",
            Langue.Occitan => "OC",
            _ => "FR",
        };

        /// <summary>Nom de la langue, écrit dans cette langue.</summary>
        public static string Nom(this Langue langue) => langue switch
        {
            Langue.Anglais => "English",
            Langue.Occitan => "Occitan",
            _ => "Français",
        };

        /// <summary>Adresse d'une page dans cette langue, à la racine du site.</summary>
        public static string Adresse(this Langue langue, PageSite page) => page switch
        {
            PageSite.MentionsLegales => langue switch
            {
                Langue.Anglais => "/en/legal-notice",
                Langue.Occitan => "/oc/mencions-legalas",
                _ => "/mentions-legales",
            },
            _ => langue == Langue.Francais ? "/" : $"/{langue.Prefixe()}",
        };

        /// <summary>Adresse de la page d'accueil dans cette langue.</summary>
        public static string Accueil(this Langue langue) => langue.Adresse(PageSite.Accueil);

        /// <summary>Adresse des mentions légales dans cette langue.</summary>
        public static string MentionsLegales(this Langue langue) => langue.Adresse(PageSite.MentionsLegales);

        /// <summary>
        /// Même page, dans une autre langue. Sert au sélecteur de langue, qui doit
        /// garder le visiteur sur la page où il se trouve.
        /// </summary>
        public static string Equivalent(string cheminRelatif, Langue cible) =>
            cible.Adresse(PageDe(cheminRelatif) ?? PageSite.Accueil);

        /// <summary>
        /// Déduit la langue du premier segment de l'URL. Tout ce qui n'est pas
        /// reconnu retombe sur le français.
        /// </summary>
        public static Langue Depuis(string cheminRelatif)
        {
            var segment = Segments(cheminRelatif).FirstOrDefault() ?? "";

            return segment.ToLowerInvariant() switch
            {
                "en" => Langue.Anglais,
                "oc" => Langue.Occitan,
                _ => Langue.Francais,
            };
        }

        /// <summary>
        /// Page correspondant à un chemin, quelle que soit sa langue. Null pour une
        /// adresse inconnue : la page d'erreur ne doit ni être indexée ni se déclarer
        /// équivalente à une autre.
        /// </summary>
        public static PageSite? PageDe(string cheminRelatif)
        {
            var segments = Segments(cheminRelatif).ToList();

            if (segments.Count > 0 && (segments[0] == "en" || segments[0] == "oc"))
            {
                segments.RemoveAt(0);
            }

            if (segments.Count == 0)
            {
                return PageSite.Accueil;
            }

            if (segments.Count > 1)
            {
                return null;
            }

            return segments[0].ToLowerInvariant() switch
            {
                "mentions-legales" or "legal-notice" or "mencions-legalas" => PageSite.MentionsLegales,
                _ => null,
            };
        }

        /// <summary>Chemin ramené à sa forme canonique : une barre au début, rien à la fin.</summary>
        public static string Normalise(string cheminRelatif)
        {
            if (string.IsNullOrWhiteSpace(cheminRelatif))
            {
                return "/";
            }

            // La chaîne de requête et l'ancre ne désignent pas une autre page.
            var chemin = cheminRelatif.Split('?')[0].Split('#')[0].Trim('/');

            return chemin.Length == 0 ? "/" : $"/{chemin}";
        }

        private static string[] Segments(string cheminRelatif) =>
            Normalise(cheminRelatif).Split('/', StringSplitOptions.RemoveEmptyEntries);
    }
}
