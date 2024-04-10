using Microsoft.AspNetCore.Components;

namespace siteValorium.composants.navbar
{
    public partial class Navbar
    {
        [Inject]
        protected NavigationManager navigationManager {  get; set; }

        private ElementReference elementRef;

        protected async Task redirectionValorium()
        {
            navigationManager.NavigateTo("https://discord.gg/dN2V7tn6gV");

        }

        protected async Task redirectionAccueil()
        {
            navigationManager.NavigateTo("/");

        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await elementRef.FocusAsync();
            }
        }

    }
}
