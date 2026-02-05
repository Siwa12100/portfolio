using Microsoft.AspNetCore.Components;

namespace Portfolio.Siwa.Composants.Global.BlocsContenu.DispositionContenu;

public partial class DispositionContenu : ComponentBase
{
    [Parameter] public RenderFragment? ContenuHaut { get; set; }
    [Parameter] public RenderFragment? ContenuGauche { get; set; }
    [Parameter] public RenderFragment? ContenuDroite { get; set; }
    [Parameter] public RenderFragment? ContenuBas { get; set; }
    [Parameter] public bool CentrageMilieu { get; set; } = false;

    private string ObtenirClasseCentrage()
        => CentrageMilieu 
            ? "disposition-contenu__centre--milieu" 
            : "disposition-contenu__centre--haut";
}
