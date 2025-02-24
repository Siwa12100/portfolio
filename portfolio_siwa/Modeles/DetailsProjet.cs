using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Modeles
{
    public class DetailsProjet
    {
        public string? Titre { get; set; }
        public MarkupString? Texte { get; set; }
        public string? CheminImage { get; set; }
    }
}