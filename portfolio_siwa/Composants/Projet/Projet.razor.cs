using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Projet
{
    public partial class Projet
    {
        [Parameter]
        public string? Titre { get; set; }

        [Parameter]
        public MarkupString? Description { get; set; }

        [Parameter]
        public string? ImagePrincipale { get; set; }

        [Parameter]
        public string? CheminIcone { get; set; }

        [Parameter]
        public MarkupString? Texte { get; set; }
    }
}