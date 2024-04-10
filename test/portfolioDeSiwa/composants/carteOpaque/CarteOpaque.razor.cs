using Microsoft.AspNetCore.Components;

namespace siteValorium.composants.carteOpaque
{
    public partial class CarteOpaque
    {

        [Parameter]
        public String titre {  get; set; }

        [Parameter]
        public String contenu { get; set; }
    }
}
