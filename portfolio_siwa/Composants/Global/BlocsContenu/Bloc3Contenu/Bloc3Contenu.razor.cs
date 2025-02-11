using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.BlocsContenu.Bloc3Contenu
{
    public partial class Bloc3Contenu
    {
        [Parameter]
        public RenderFragment? ContenuHaut { get; set; }

        [Parameter]
        public RenderFragment? ContenuDroite { get; set; }

        [Parameter]
        public RenderFragment? ContenuCentre { get; set; }

        [Parameter]
        public RenderFragment? ContenuGauche { get; set; }

        [Parameter]
        public RenderFragment? ContenuBas { get; set; }
    }
}