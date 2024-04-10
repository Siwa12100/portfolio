using Microsoft.AspNetCore.Components;

namespace portfolioDeSiwa.components.navbar
{
    public partial class Navbar
    {
        [Parameter]
        public string cheminProfilGithub { get; set; }

        [Parameter]
        public string cheminImageGithub { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }

        protected override void OnInitialized()
        {
            cheminProfilGithub = "https://github.com/Siwa12100";
            cheminImageGithub = "/icones/iconeGithub.png";
        }

        public void retourAccueil()
        {
            navigationManager.NavigateTo("/");
        }
    }
}
