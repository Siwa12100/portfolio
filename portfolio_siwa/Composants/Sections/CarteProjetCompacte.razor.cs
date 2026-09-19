using Microsoft.AspNetCore.Components;
using portfolio_siwa.Modeles;

namespace portfolio_siwa.Composants.Sections
{
    public partial class CarteProjetCompacte
    {
        [Parameter]
        [EditorRequired]
        public required FicheProjet Fiche { get; set; }
    }
}
