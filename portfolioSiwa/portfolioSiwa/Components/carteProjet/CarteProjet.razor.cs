using Microsoft.AspNetCore.Components;

namespace portfolioSiwa.Components.carteProjet
{
    public partial class CarteProjet
    {

        [Parameter]
        public String cheminImage {  get; set; }

        [Parameter]
        public String titre {  get; set; }

        [Parameter]
        public String paragraphe { get; set; }

        [Parameter]
        public String texteTag { get; set; }

        [Parameter]
        public String redirectionGithub { get; set; }

        [Parameter]
        public String cheminPageAssociee { get; set; }

        [Inject]
        private NavigationManager navigationManager { get; set; }


        public CarteProjet()
        {
            Console.WriteLine("Construction d'une carte");
        }

        public void redirectionBouton()
        {
            String chemin = "/" + this.cheminPageAssociee;
            Console.WriteLine("Passage dans le Card cliqué !  : " + chemin);
            this.navigationManager.NavigateTo(chemin);
        }
    }
}
