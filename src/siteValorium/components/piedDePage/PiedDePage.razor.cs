using Microsoft.AspNetCore.Components;

namespace siteValorium.components.piedDePage
{
    public partial class PiedDePage
    {
        [Inject]
        private NavigationManager navigationManager { get; set; }

        public void retourAccueil()
        {
            this.navigationManager.NavigateTo("/");
        }

        public void redirectionBouton()
        {
            this.navigationManager.NavigateTo("https://github.com/Siwa12100/portfolio");
        }
    }
}
