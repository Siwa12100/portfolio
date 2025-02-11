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

        protected async Task Rediriger()
        {
            if (NavigationManager is null) return;
            var url = NavigationManager.ToAbsoluteUri(this.LienDiscord).ToString();
            if (this.JSRuntime is not null)
            {
                await this.JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
            }
        }
    }
}