using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.BlocsContenu.Titre1
{
    public partial class Titre1
    {
        [Parameter]
        public string? TexteTitre { get; set; }

        [Parameter]
        public string? CheminIconeTitre { get; set; }
    }
}