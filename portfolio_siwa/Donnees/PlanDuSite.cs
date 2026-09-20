using System.Reflection;
using System.Text;
using portfolio_siwa.Modeles;

namespace portfolio_siwa.Donnees
{
    /// <summary>
    /// Ce que les moteurs de recherche et les robots d'IA lisent avant la page elle-même :
    /// robots.txt, sitemap.xml et llms.txt. Les trois sont construits à partir du catalogue
    /// et de la liste des langues, donc ils ne peuvent pas se désynchroniser du site.
    /// </summary>
    public static class PlanDuSite
    {
        public const string Domaine = "https://jean-marcillac.dev";
        public const string Nom = "Jean Marcillac";
        public const string Courriel = "jean.marcillac12@gmail.com";
        public const string Github = "https://github.com/Siwa12100";
        public const string DepotSite = "https://github.com/Siwa12100/portfolio";
        public const string Cv = "https://cv.jean-marcillac.dev";

        /// <summary>
        /// Manifestation occitane vers laquelle mène la croix du menu. Le site est daté (les 17 et
        /// 18 octobre 2026, à Montségur) : à revoir une fois l'évènement passé.
        /// </summary>
        public const string CarrierasOccitanas = "https://www.carrieras-occitanas.eu/";
        public const string Discord = "sioa";

        /// <summary>Image d'aperçu des partages, en adresse absolue : les réseaux sociaux n'acceptent que ça.</summary>
        public const string ImagePartage = $"{Domaine}/Images/PhotoProfil.jpg";

        /// <summary>
        /// Largeur d'affichage de la photo d'accueil (11 à 19 rem selon l'écran). Elle sert
        /// à l'image et à son préchargement : les deux doivent désigner le même fichier,
        /// sinon le navigateur le télécharge deux fois.
        /// </summary>
        public const string TaillesPhoto = "(min-width: 1170px) 304px, max(176px, 26vw)";

        public const int ImagePartageLargeur = 900;
        public const int ImagePartageHauteur = 900;

        /// <summary>
        /// Robots d'IA autorisés nommément. Sans mention explicite, plusieurs d'entre eux
        /// s'abstiennent d'indexer : le but ici est justement d'être repris.
        /// </summary>
        private static readonly string[] RobotsIa =
        [
            "GPTBot", "OAI-SearchBot", "ChatGPT-User", "ClaudeBot", "Claude-User",
            "Claude-SearchBot", "anthropic-ai", "PerplexityBot", "Perplexity-User",
            "Google-Extended", "Applebot", "Applebot-Extended", "Amazonbot",
            "Meta-ExternalAgent", "Bingbot", "DuckAssistBot", "cohere-ai", "YouBot",
        ];

        /// <summary>Adresse absolue d'un chemin interne.</summary>
        public static string Absolu(string chemin) =>
            chemin == "/" ? $"{Domaine}/" : Domaine + chemin;

        public static string Absolu(Langue langue, PageSite page) => Absolu(langue.Adresse(page));

        /// <summary>
        /// Date de dernière modification annoncée dans le sitemap. Elle suit la date de
        /// construction de l'application : chaque déploiement porte un contenu à jour.
        /// </summary>
        public static DateOnly DerniereMiseAJour { get; } = DateDeConstruction();

        public static string Robots()
        {
            var texte = new StringBuilder();

            texte.AppendLine("# https://jean-marcillac.dev");
            texte.AppendLine("# Portfolio personnel. Contenu libre d'accès, indexation bienvenue.");
            texte.AppendLine();
            texte.AppendLine("User-agent: *");
            texte.AppendLine("Allow: /");
            texte.AppendLine("Disallow: /erreur/");
            texte.AppendLine("Disallow: /Error");
            texte.AppendLine();
            texte.AppendLine("# Assistants et moteurs conversationnels : autorisés explicitement.");

            foreach (var robot in RobotsIa)
            {
                texte.AppendLine();
                texte.AppendLine($"User-agent: {robot}");
                texte.AppendLine("Allow: /");
            }

            texte.AppendLine();
            texte.AppendLine($"Sitemap: {Domaine}/sitemap.xml");

            return texte.ToString();
        }

        public static string Sitemap()
        {
            var date = DerniereMiseAJour.ToString("yyyy-MM-dd");
            var xml = new StringBuilder();

            xml.AppendLine("""<?xml version="1.0" encoding="UTF-8"?>""");
            xml.AppendLine("""<urlset xmlns="http://www.sitemaps.org/schemas/sitemap/0.9" xmlns:xhtml="http://www.w3.org/1999/xhtml">""");

            foreach (var page in Langues.Pages)
            {
                foreach (var langue in Langues.Toutes)
                {
                    xml.AppendLine("  <url>");
                    xml.AppendLine($"    <loc>{Absolu(langue, page)}</loc>");

                    // Les trois versions se déclarent mutuellement : Google sert alors
                    // la bonne langue selon le visiteur, sans les traiter comme des doublons.
                    foreach (var autre in Langues.Toutes)
                    {
                        xml.AppendLine($"""    <xhtml:link rel="alternate" hreflang="{autre.CodeIso()}" href="{Absolu(autre, page)}" />""");
                    }

                    xml.AppendLine($"""    <xhtml:link rel="alternate" hreflang="x-default" href="{Absolu(Langue.Francais, page)}" />""");
                    xml.AppendLine($"    <lastmod>{date}</lastmod>");
                    xml.AppendLine($"    <changefreq>{(page == PageSite.Accueil ? "monthly" : "yearly")}</changefreq>");
                    xml.AppendLine($"    <priority>{(page == PageSite.Accueil ? "1.0" : "0.3")}</priority>");
                    xml.AppendLine("  </url>");
                }
            }

            xml.AppendLine("</urlset>");

            return xml.ToString();
        }

        /// <summary>
        /// Résumé du site au format llms.txt, en anglais : c'est ce que lisent les modèles
        /// de langage quand ils préfèrent un texte propre au HTML de la page.
        /// </summary>
        public static string Llms()
        {
            const Langue langue = Langue.Anglais;
            var texte = new StringBuilder();

            texte.AppendLine($"# {Nom}");
            texte.AppendLine();
            texte.AppendLine($"> {Traductions.Description[langue]}");
            texte.AppendLine();
            texte.AppendLine(Traductions.HeroApproche[langue]);
            texte.AppendLine();
            texte.AppendLine("The site is published in three languages: French (canonical), English and Occitan.");
            texte.AppendLine();

            texte.AppendLine("## Pages");
            texte.AppendLine();
            foreach (var autre in Langues.Toutes)
            {
                texte.AppendLine($"- [Home page, {autre.Nom()}]({Absolu(autre, PageSite.Accueil)}): portfolio, projects and contact details.");
            }
            texte.AppendLine($"- [Legal notice]({Absolu(Langue.Anglais, PageSite.MentionsLegales)}): publisher, hosting and personal data.");
            texte.AppendLine();

            texte.AppendLine("## Affiliations");
            texte.AppendLine();
            foreach (var affiliation in CatalogueAffiliations.Toutes)
            {
                texte.AppendLine($"- {affiliation.Nom[langue]}: {affiliation.Role[langue]}. {affiliation.Presentation[langue]}");
            }
            texte.AppendLine();

            texte.AppendLine("## Projects");
            texte.AppendLine();
            foreach (var fiche in CatalogueProjets.Tous)
            {
                var lien = fiche.LienSite ?? fiche.LienGithub ?? $"{Absolu(langue, PageSite.Accueil)}#projets";
                var contexte = fiche.Annee is null ? "" : $" ({fiche.Annee[langue]})";

                texte.AppendLine($"- [{fiche.Titre[langue]}]({lien}){contexte}: {fiche.ResumeCourt.Nu(langue)} " +
                                 $"Built with {string.Join(", ", fiche.Technos.Select(techno => techno.Nom))}.");
            }
            texte.AppendLine();

            texte.AppendLine("## About");
            texte.AppendLine();
            texte.AppendLine($"- {Traductions.AProposOrigine.Nu(langue)}");
            texte.AppendLine($"- {Traductions.AProposReflexion.Nu(langue)}");
            texte.AppendLine($"- {Traductions.AProposConclusion.Nu(langue)}");
            texte.AppendLine();

            texte.AppendLine("## Contact");
            texte.AppendLine();
            texte.AppendLine($"- Email: {Courriel}");
            texte.AppendLine($"- GitHub: {Github}");
            texte.AppendLine($"- Discord: {Discord}");
            texte.AppendLine($"- Resume: {Cv}");
            texte.AppendLine($"- Source code of this site: {DepotSite}");

            return texte.ToString();
        }

        private static DateOnly DateDeConstruction()
        {
            try
            {
                var fichier = Assembly.GetExecutingAssembly().Location;

                if (!string.IsNullOrEmpty(fichier) && File.Exists(fichier))
                {
                    return DateOnly.FromDateTime(File.GetLastWriteTimeUtc(fichier));
                }
            }
            catch (IOException)
            {
                // Rien de grave : la date du jour fait un repère honnête.
            }

            return DateOnly.FromDateTime(DateTime.UtcNow);
        }
    }
}
