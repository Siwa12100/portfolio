using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.BlocsContenu.BlocTexteMedia
{
    public partial class BlocTexteMedia
    {
        [Parameter]
        public string? TexteTitre { get; set; }

        [Parameter]
        public string? CheminIconeTitre { get; set; }

        [Parameter]
        public MarkupString? Texte { get; set; }

        [Parameter]
        public RenderFragment? Media { get; set; }

        [Parameter]
        public RenderFragment? Media2 { get; set; }

        [Parameter]
        public RenderFragment? BasPage { get; set; }

        [Parameter]
        public PositionMedia PositionMedia { get; set; } = PositionMedia.Droite;

        [Parameter]
        public MarkupString? TexteEnHaut { get; set; }

        [Parameter]
        public RenderFragment? SousTexte { get; set; }

        [Parameter]
        public bool CentrageMilieu { get; set; } = true;
    }
}