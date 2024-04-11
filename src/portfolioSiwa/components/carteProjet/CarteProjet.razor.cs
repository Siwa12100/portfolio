using Microsoft.AspNetCore.Components;

namespace portfolioSiwa.components.carteProjet
{
    public partial class CarteProjet
    {

        [Parameter]
        public string cheminImage { get; set; }

        [Parameter]
        public string titre { get; set; }

        [Parameter]
        public string paragraphe { get; set; }

        [Parameter]
        public string texteTag { get; set; }

        [Parameter]
        public string redirectionGithub { get; set; }

        [Parameter]
        public string cheminPageAssociee { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }


        public CarteProjet()
        {
            Console.WriteLine("Construction d'une carte");
        }

        public void redirectionBouton()
        {
            string chemin = "/" + cheminPageAssociee;
            Console.WriteLine("Passage dans le Card cliqué !  : " + chemin);
            navigationManager.NavigateTo(chemin);
        }
    }
}
