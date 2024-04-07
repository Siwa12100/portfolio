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


        public void CardCliquee()
        {

        }
    }
}
