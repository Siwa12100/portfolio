using Microsoft.AspNetCore.Components;

namespace siteValorium.components.navbar
{
    public partial class Navbar
    {
        [Parameter]
        public string cheminProfilGithub { get; set; }

        [Parameter]
        public string cheminImageGithub { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        private ElementReference elementRef;

        protected override void OnInitialized()
        {
            cheminProfilGithub = "https://github.com/Siwa12100";
            cheminImageGithub = "/icones/iconeGithub.png";
        }

        public void retourAccueil()
        {
            this.navigationManager.NavigateTo("/");
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
