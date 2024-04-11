using Microsoft.AspNetCore.Components;

namespace portfolioSiwa.components.piedDePage
{
    public partial class PiedDePage
    {
        [Inject]
        private NavigationManager navigationManager { get; set; }

        public void retourAccueil()
        {
            navigationManager.NavigateTo("/");
        }

        public void redirectionBouton()
        {
            navigationManager.NavigateTo("https://github.com/Siwa12100/portfolio");
        }
    }
}
