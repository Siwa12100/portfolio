namespace portfolio_siwa.Modeles
{
    /// <summary>Une organisation à laquelle je suis rattaché.</summary>
    /// <param name="Nom">Nom de l'organisation. Traduit quand elle a un nom dans chaque langue.</param>
    /// <param name="Logo">Tuile de <see cref="LargeurLogo"/> x <see cref="HauteurLogo"/> px, en double densité.</param>
    /// <param name="Role">Ce que j'y fais, en quelques mots : c'est le titre de la carte.</param>
    /// <param name="Presentation">Ce qu'est l'organisation. Mon rôle est déjà dans le titre : ne pas le répéter.</param>
    /// <param name="Teinte">
    /// Couleur de marque, en #rrggbb : elle colore le reflet, la bordure et le nom de la carte.
    /// Assez claire pour se lire sur le fond bleu nuit du site.
    /// </param>
    /// <param name="LogoSansFond">Vrai si la tuile est transparente : elle flotte alors sur la carte, sans plaque.</param>
    public sealed record Affiliation(
        Texte Nom,
        string Logo,
        Texte Role,
        Texte Presentation,
        string Teinte,
        bool LogoSansFond = false)
    {
        /// <summary>Taille d'affichage de la tuile. Le fichier fait le double, pour les écrans à forte densité.</summary>
        public const int LargeurLogo = 140;

        public const int HauteurLogo = 80;

        /// <summary>
        /// Composantes de <see cref="Teinte"/> sous la forme « r, g, b », pour rgba() en CSS : c'est
        /// la seule écriture qui laisse régler la transparence d'une variable, sans dépendre de
        /// color-mix, que tous les navigateurs intégrés ne connaissent pas encore.
        /// </summary>
        public string TeinteRvb =>
            $"{Convert.ToInt32(this.Teinte[1..3], 16)}, {Convert.ToInt32(this.Teinte[3..5], 16)}, {Convert.ToInt32(this.Teinte[5..7], 16)}";
    }
}
