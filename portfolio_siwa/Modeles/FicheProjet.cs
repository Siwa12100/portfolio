using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Modeles
{
    /// <summary>Un projet présenté sur la page d'accueil.</summary>
    public sealed record FicheProjet
    {
        public required string Titre { get; init; }

        /// <summary>Étiquette courte affichée au-dessus du titre (ex. « Intelligence artificielle »).</summary>
        public required string Categorie { get; init; }

        /// <summary>Année ou période. Null si elle n'est pas encore arrêtée.</summary>
        public string? Annee { get; init; }

        /// <summary>Cadre du projet : stage, TP noté, association…</summary>
        public string? Cadre { get; init; }

        /// <summary>Seul, en binôme, en équipe.</summary>
        public string? Realisation { get; init; }

        public required string Image { get; init; }

        /// <summary>
        /// Dimensions réelles du fichier. Elles partent dans les attributs width/height
        /// pour que le navigateur réserve la place avant même d'avoir chargé l'image.
        /// </summary>
        public required int ImageLargeur { get; init; }

        public required int ImageHauteur { get; init; }

        /// <summary>Résumé du projet. Peut contenir un peu de HTML (liens, mises en avant).</summary>
        public required MarkupString Resume { get; init; }

        /// <summary>Une phrase, pour la version compacte de la carte.</summary>
        public required string ResumeCourt { get; init; }

        public IReadOnlyList<TechnoProjet> Technos { get; init; } = [];

        public string? LienSite { get; init; }

        public string? LienGithub { get; init; }
    }
}
