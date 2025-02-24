using Microsoft.AspNetCore.Components;
using MudBlazor;
using portfolio_siwa.Modeles;

namespace portfolio_siwa.Composants.FenetreProjet
{
    public partial class FenetreProjet
    {
        [CascadingParameter]
        IMudDialogInstance? MudDialog { get; set; }

        [Parameter]
        public DetailsProjet? DetailsProjet { get; set; }

        protected void FermerFenetre()
        {
            if (MudDialog != null)
            {
                MudDialog.Close();
            }
        }
    }
}