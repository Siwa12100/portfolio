using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace portfolio_siwa.Composants.Global.Boutons.BoutonDiscord
{
    public partial class BoutonDiscord
    {
        [Parameter]
        public string? Lien { get; set; }

        [Parameter]
        public string? Texte { get; set; } = "Discord";

        [Parameter]
        public string? CheminIcone { get; set; } = "/Images/Icones/discordIcone.png";

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        protected IJSRuntime? JSRuntime { get; set; }
        private async Task Rediriger()
        {
            if (Lien != null && NavigationManager != null)
            {
                var url = NavigationManager.ToAbsoluteUri(this.Lien).ToString();
                if (this.JSRuntime is not null)
                {
                    await this.JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
                }
            }
            else
            {
                Console.WriteLine("Lien Discord non défini");
            }
        }
    }
}   