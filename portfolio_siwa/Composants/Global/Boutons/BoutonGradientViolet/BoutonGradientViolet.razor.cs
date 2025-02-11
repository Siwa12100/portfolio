using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.Boutons.BoutonGradientViolet
{
    public partial class BoutonGradientViolet
    {
        [Parameter]
        public string? Texte { get; set; }

        [Parameter]
        public string? Icone { get; set; }

        [Parameter]
        public string? CheminRedirection { get; set; }

        [Parameter]
        public string? Alt { get; set; } = "Bouton";

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        private void Rediriger()
        {
            if (CheminRedirection != null && NavigationManager != null)
            {
                NavigationManager.NavigateTo(CheminRedirection);
            }
        }
    }
}