namespace portfolio_siwa.Modeles
{
    /// <summary>Un projet présenté sur la page d'accueil.</summary>
    public sealed record FicheProjet
    {
        public required Texte Titre { get; init; }

        /// <summary>Étiquette courte affichée au-dessus du titre.</summary>
        public required Texte Categorie { get; init; }

        /// <summary>Année ou période. Null si elle n'est pas encore arrêtée.</summary>
        public Texte? Annee { get; init; }

        /// <summary>Cadre du projet : stage, TP noté, association…</summary>
        public Texte? Cadre { get; init; }

        /// <summary>Seul, en binôme, en équipe.</summary>
        public Texte? Realisation { get; init; }

        public required string Image { get; init; }

        /// <summary>
        /// Dimensions réelles du fichier. Elles partent dans les attributs width/height
        /// pour que le navigateur réserve la place avant même d'avoir chargé l'image.
        /// </summary>
        public required int ImageLargeur { get; init; }

        public required int ImageHauteur { get; init; }

        /// <summary>
        /// Largeurs des variantes réduites de l'image, à côté de l'original : pour
        /// <c>/Images/projets/x.jpg</c>, les fichiers <c>x-480.jpg</c> et <c>x-800.jpg</c>.
        /// </summary>
        public static IReadOnlyList<int> LargeursVariantes { get; } = [480, 800];

        /// <summary>
        /// Attribut srcset : le navigateur prend la variante la plus légère qui suffit à
        /// l'écran, au lieu de télécharger systématiquement l'image pleine taille.
        /// </summary>
        public string SrcSet => string.Join(", ",
            LargeursVariantes
                .Select(largeur => $"{this.Variante(largeur)} {largeur}w")
                .Append($"{this.Image} {this.ImageLargeur}w"));

        /// <summary>Chemin de la variante d'une largeur donnée.</summary>
        public string Variante(int largeur) =>
            $"{this.Image[..this.Image.LastIndexOf('.')]}-{largeur}.jpg";

        /// <summary>Résumé du projet. Peut contenir un peu de HTML (mises en avant).</summary>
        public required Texte Resume { get; init; }

        /// <summary>Une phrase, pour la version compacte de la carte.</summary>
        public required Texte ResumeCourt { get; init; }

        public IReadOnlyList<TechnoProjet> Technos { get; init; } = [];

        public string? LienSite { get; init; }

        public string? LienGithub { get; init; }
    }
}
