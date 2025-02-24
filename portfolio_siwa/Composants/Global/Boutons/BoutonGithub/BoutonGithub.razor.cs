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

        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        private async Task OuvrirLien()
        {
            if (this.NavigationManager is null) {
                Console.WriteLine("NavigationManager est null");
                return;
            }
            if (this.Lien is null) {
                Console.WriteLine("Lien est null");
                return;
            }

            var url = NavigationManager.ToAbsoluteUri(this.Lien).ToString();
            if (this.JSRuntime is not null)
            {
                await this.JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
            }
            else
            {
                Console.WriteLine("Impossible d'ouvrir le lien");
            }
        }
    }
}