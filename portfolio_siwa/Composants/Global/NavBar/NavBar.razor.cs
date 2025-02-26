using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace portfolio_siwa.Composants.Global.NavBar
{
    public partial class NavBar
    {
        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        protected IJSRuntime? JSRuntime { get; set; }

        protected string? LienDiscord = "https://discord.gg/hfKf5y2DC9";
        protected string? CheminCv = "https://cv.jean-marcillac.dev";

        protected async Task Rediriger()
        {
            if (NavigationManager is null) return;
            var url = NavigationManager.ToAbsoluteUri(this.LienDiscord).ToString();
            if (this.JSRuntime is not null)
            {
                await this.JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
            }
        }

        protected void DirigerBalise(int balise)
        {
            if (NavigationManager is null) return;
            string chemin = "";
            if (balise == 1) chemin = "#home";
            if (balise == 2) chemin = "#travaux";
            if (balise == 3) chemin = "#propos";
            Console.WriteLine("Redirection vers : " + chemin);
            NavigationManager.NavigateTo(chemin);
        }

        protected async Task RedirigerCv()
        {
            if (NavigationManager is null) return;
            var url = NavigationManager.ToAbsoluteUri(this.CheminCv).ToString();
            if (this.JSRuntime is not null)
            {
                await this.JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
            }

            return;
        }
    }
}