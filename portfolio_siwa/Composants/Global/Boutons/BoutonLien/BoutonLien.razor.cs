using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.Boutons.BoutonLien
{
    public partial class BoutonLien
    {
        [Parameter]
        public string? Lien { get; set; }

        [Parameter]
        public string? Icone { get; set; }

        [Parameter]
        public bool? ModeCopierColler { get; set; }
    }
}