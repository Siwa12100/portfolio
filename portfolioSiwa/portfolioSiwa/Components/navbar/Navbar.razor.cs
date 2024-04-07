using Microsoft.AspNetCore.Components;

namespace portfolioSiwa.Components.navbar
{
    public partial class Navbar
    {
        [Parameter]
        public String cheminProfilGithub { get; set; }

        [Parameter]
        public String cheminImageGithub { get; set; }

        [Inject]
        private NavigationManager navigationManager {  get; set; }

        protected override void OnInitialized()
        {
            this.cheminProfilGithub = "https://github.com/Siwa12100";
            this.cheminImageGithub = "/icones/iconeGithub.png";
        }

        public void retourAccueil()
        {
            this.navigationManager.NavigateTo("/");
        }
    }
}
