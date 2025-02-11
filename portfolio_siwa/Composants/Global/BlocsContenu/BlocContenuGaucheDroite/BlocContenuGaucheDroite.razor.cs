using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.BlocsContenu.BlocContenuGaucheDroite
{
    public partial class BlocContenuGaucheDroite
    {
        [Parameter]
        public RenderFragment? ContenuHaut { get; set; }

        [Parameter]
        public RenderFragment? ContenuDroite { get; set; }

        [Parameter]
        public RenderFragment? ContenuGauche { get; set; }

        [Parameter]
        public RenderFragment? ContenuBas { get; set; }

        [Parameter]
        public bool CentrageMilieu { get; set; } = true;
    }
}