using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.Boutons.BoutonValorium
{
    public partial class BoutonValorium
    {
        [Parameter]
        public string? Texte { get; set; }

        [Parameter]
        public string? Lien { get; set; }
    }
}