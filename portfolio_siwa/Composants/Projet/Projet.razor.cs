using Microsoft.AspNetCore.Components;
using portfolio_siwa.Composants.Global.BlocsContenu.BlocTexteMedia;
using portfolio_siwa.Modeles;

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

        [Parameter]
        public string? LienGithub { get; set; }

        [Parameter]
        public RenderFragment? BasPage { get; set; }

        [Parameter]
        public PositionMedia PositionMedia { get; set; }

        [Parameter]
        public DetailsProjet? Details { get; set; }
    }
}