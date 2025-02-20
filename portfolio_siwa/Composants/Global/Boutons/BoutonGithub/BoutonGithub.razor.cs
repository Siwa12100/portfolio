using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace portfolio_siwa.Composants.Global.Boutons.BoutonDiscord
{
    public partial class BoutonGithub
    {
        [Parameter]
        public string? Lien { get; set; }

        [Parameter]
        public string? Texte { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        private void OuvrirLien()
        {
            if (Lien != null && this.NavigationManager != null)
            {
                this.NavigationManager.NavigateTo(Lien);
            }
        }
    }
}