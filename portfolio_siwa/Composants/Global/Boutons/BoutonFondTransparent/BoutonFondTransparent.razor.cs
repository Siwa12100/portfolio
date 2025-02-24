using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using portfolio_siwa.Modeles;

namespace portfolio_siwa.Composants.Global.Boutons.BoutonFondTransparent
{
    public partial class BoutonFondTransparent
    {
        [Parameter]
        public string? Texte { get; set; }

        [Parameter]
        public string? Icone { get; set; }

        [Parameter]
        public string? CheminRedirection { get; set; }

        [Parameter]
        public string? Alt { get; set; } = "Bouton";

        [Parameter]
        public bool OuvreNouvelOnglet { get; set; } = false;

        [Parameter]
        public bool ModeCopierPressePapier { get; set; } = false;

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        [Parameter]
        public bool FondBlanc { get; set; } = false;

        [Parameter]
        public bool EffetHalo { get; set; } = false;

        [Inject]
        protected ISnackbar? Snackbar { get; set; }

        [Parameter]
        public DetailsProjet? DetailsProjet { get; set; }

        [Inject]
        protected IDialogService? DialogService { get; set; }

        private async Task Rediriger()
        {   
            if (this.DetailsProjet != null) 
            {
                await OuvrirDetails();
                return;
            }
            
            if (ModeCopierPressePapier)
            {
                await CopierContenuCoordonnees();
                return;
            }
            
            if (CheminRedirection != null && NavigationManager != null)
            {
                if (OuvreNouvelOnglet)
                {
                    var url = NavigationManager.ToAbsoluteUri(this.CheminRedirection).ToString();
                    if (this.JSRuntime is not null)
                    {
                        await this.JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
                    }

                    return;
                }

                NavigationManager.NavigateTo(CheminRedirection);
            }
        }

        protected async Task OuvrirDetails()
        {
            if (this.DialogService == null)
            {
                Console.WriteLine("DialogService is null");
                return;
            }

            var parameters = new DialogParameters { { "DetailsProjet", this.DetailsProjet }};
            var options = new DialogOptions { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseButton = true };

            var dialogue = this.DialogService.Show<FenetreProjet.FenetreProjet>("Détails du projet", parameters, options);
            var result = await dialogue.Result;
        }

            protected async Task CopierContenuCoordonnees()
            {
                if (this.JSRuntime is null) return;
                await JSRuntime.InvokeVoidAsync("copyToClipboard", this.Texte);

                this.AfficherMessage("Ip copiée dans le presse-papier", Severity.Success);
            }

            private void AfficherMessage(string message, Severity niveau)
            {
                Snackbar?.Add(message, niveau);
            }
    }

}