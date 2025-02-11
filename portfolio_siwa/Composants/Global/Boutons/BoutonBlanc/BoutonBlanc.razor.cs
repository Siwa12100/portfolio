using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.Boutons.BoutonBlanc
{
    public partial class BoutonBlanc
    {
        [Parameter]
        public string? Texte { get; set; }
        [Parameter]
        public string? Lien { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        private void Naviguer()
        {
            if (NavigationManager != null && !string.IsNullOrWhiteSpace(Lien))
            {
                NavigationManager.NavigateTo(Lien);
            }
        }
    }
}