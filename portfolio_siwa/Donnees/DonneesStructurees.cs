using System.Collections.Concurrent;
using System.Text.Json;
using portfolio_siwa.Modeles;

namespace portfolio_siwa.Donnees
{
    /// <summary>
    /// Description du site en JSON-LD (schema.org), posée dans le head de chaque page.
    /// C'est la forme que les moteurs de recherche et les modèles de langage lisent en
    /// premier : elle leur dit qui est l'auteur, ce que contient la page et dans quelle
    /// langue, sans avoir à interpréter la mise en page.
    /// </summary>
    public static class DonneesStructurees
    {
        private const string IdPersonne = $"{PlanDuSite.Domaine}/#personne";
        private const string IdSite = $"{PlanDuSite.Domaine}/#site";

        private static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = false,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
        };

        // Six pages en tout : le JSON est construit une fois, puis resservi.
        private static readonly ConcurrentDictionary<(Langue, PageSite?), string> Cache = new();

        public static string Json(Langue langue, PageSite? page) =>
            Cache.GetOrAdd((langue, page), cle => Construire(cle.Item1, cle.Item2));

        private static string Construire(Langue langue, PageSite? page)
        {
            var graphe = new List<object>
            {
                Personne(langue),
                Site(langue),
                Page(langue, page),
            };

            if (page == PageSite.Accueil)
            {
                graphe.AddRange(CatalogueProjets.Tous.Select(fiche => Projet(fiche, langue)));
            }

            return JsonSerializer.Serialize(new Dictionary<string, object?>
            {
                ["@context"] = "https://schema.org",
                ["@graph"] = graphe,
            }, Options);
        }

        private static Dictionary<string, object?> Personne(Langue langue) => new()
        {
            ["@type"] = "Person",
            ["@id"] = IdPersonne,
            ["name"] = PlanDuSite.Nom,
            ["givenName"] = "Jean",
            ["familyName"] = "Marcillac",
            ["jobTitle"] = Traductions.Metier[langue],
            ["description"] = Traductions.Description[langue],
            ["url"] = PlanDuSite.Absolu(langue, PageSite.Accueil),
            ["image"] = PlanDuSite.ImagePartage,
            ["email"] = $"mailto:{PlanDuSite.Courriel}",
            ["knowsLanguage"] = Langues.Toutes
                .Select(autre => new Dictionary<string, object?>
                {
                    ["@type"] = "Language",
                    ["name"] = autre.Nom(),
                    ["alternateName"] = autre.CodeIso(),
                })
                .ToArray(),
            ["knowsAbout"] = Competences(),
            ["alumniOf"] = new Dictionary<string, object?>
            {
                ["@type"] = "CollegeOrUniversity",
                ["name"] = "INSA Lyon",
                ["url"] = "https://www.insa-lyon.fr",
            },
            ["worksFor"] = new Dictionary<string, object?>
            {
                ["@type"] = "Organization",
                ["name"] = "Enedis",
                ["url"] = "https://www.enedis.fr",
            },
            ["sameAs"] = new[] { PlanDuSite.Github, PlanDuSite.Cv },
        };

        private static Dictionary<string, object?> Site(Langue langue) => new()
        {
            ["@type"] = "WebSite",
            ["@id"] = IdSite,
            ["url"] = $"{PlanDuSite.Domaine}/",
            ["name"] = PlanDuSite.Nom,
            ["description"] = Traductions.Description[langue],
            ["inLanguage"] = Langues.Toutes.Select(autre => autre.CodeIso()).ToArray(),
            ["publisher"] = new Dictionary<string, object?> { ["@id"] = IdPersonne },
            ["author"] = new Dictionary<string, object?> { ["@id"] = IdPersonne },
        };

        private static Dictionary<string, object?> Page(Langue langue, PageSite? page)
        {
            var adresse = page is null
                ? PlanDuSite.Absolu(langue, PageSite.Accueil)
                : PlanDuSite.Absolu(langue, page.Value);

            var fiche = new Dictionary<string, object?>
            {
                // La page d'accueil est avant tout une page de profil : le type le dit.
                ["@type"] = page == PageSite.Accueil ? "ProfilePage" : "WebPage",
                ["@id"] = $"{adresse}#page",
                ["url"] = adresse,
                ["inLanguage"] = langue.CodeIso(),
                ["isPartOf"] = new Dictionary<string, object?> { ["@id"] = IdSite },
                ["about"] = new Dictionary<string, object?> { ["@id"] = IdPersonne },
                ["name"] = page == PageSite.MentionsLegales
                    ? Traductions.MentionsLegales[langue]
                    : Traductions.TitrePage[langue],
                ["description"] = page == PageSite.MentionsLegales
                    ? Traductions.DescriptionLegales[langue]
                    : Traductions.Description[langue],
            };

            if (page == PageSite.Accueil)
            {
                fiche["mainEntity"] = new Dictionary<string, object?> { ["@id"] = IdPersonne };
                fiche["primaryImageOfPage"] = new Dictionary<string, object?>
                {
                    ["@type"] = "ImageObject",
                    ["url"] = PlanDuSite.ImagePartage,
                    ["width"] = PlanDuSite.ImagePartageLargeur,
                    ["height"] = PlanDuSite.ImagePartageHauteur,
                    ["caption"] = Traductions.PhotoAlt[langue],
                };
            }

            return fiche;
        }

        private static Dictionary<string, object?> Projet(FicheProjet fiche, Langue langue) => SansVide(new()
        {
            ["@type"] = "CreativeWork",
            ["name"] = fiche.Titre[langue],
            ["headline"] = fiche.Titre[langue],
            ["description"] = fiche.Resume.Nu(langue),
            ["abstract"] = fiche.ResumeCourt.Nu(langue),
            ["genre"] = fiche.Categorie[langue],
            ["temporalCoverage"] = fiche.Annee?[langue],
            ["url"] = fiche.LienSite,
            ["codeRepository"] = fiche.LienGithub,
            ["image"] = Absolue(fiche.Image),
            ["inLanguage"] = langue.CodeIso(),
            ["keywords"] = string.Join(", ", fiche.Technos.Select(techno => techno.Nom)),
            ["author"] = new Dictionary<string, object?> { ["@id"] = IdPersonne },
            ["isPartOf"] = new Dictionary<string, object?> { ["@id"] = IdSite },
        });

        /// <summary>
        /// Retire les entrées vides. Un projet sans dépôt public ni site en ligne
        /// laisserait sinon des champs à null dans le JSON, que les validateurs
        /// signalent sans que ça apporte quoi que ce soit.
        /// </summary>
        private static Dictionary<string, object?> SansVide(Dictionary<string, object?> fiche) =>
            fiche.Where(entree => entree.Value is not null)
                 .ToDictionary(entree => entree.Key, entree => entree.Value);

        /// <summary>Les technologies du catalogue, sans doublon : c'est le savoir-faire réel.</summary>
        private static string[] Competences() =>
            CatalogueProjets.Tous
                .SelectMany(fiche => fiche.Technos)
                .Select(techno => techno.Nom)
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .Order(StringComparer.OrdinalIgnoreCase)
                .ToArray();

        private static string Absolue(string chemin) =>
            chemin.StartsWith('/') ? PlanDuSite.Domaine + chemin : $"{PlanDuSite.Domaine}/{chemin}";
    }
}
