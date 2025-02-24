using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;

namespace portfolio_siwa.Composants.Global.Boutons.BoutonLien
{
    public partial class BoutonLien
    {
        [Parameter]
        public string? Lien { get; set; }

        [Parameter]
        public string? Icone { get; set; }

        [Parameter]
        public bool? ModeCopierColler { get; set; }

        [Inject]
        public NavigationManager? NavigationManager { get; set; }

        [Inject]
        public IJSRuntime? JSRuntime { get; set; }

        [Parameter]
        public string? Texte { get; set; }

        [Inject]
        protected ISnackbar? Snackbar { get; set; }

        [Parameter]
        public int TypeLien { get; set; }

        protected async Task BoutonClique()
        {   
            Console.WriteLine("Bouton cliqué");
            if (this.ModeCopierColler != null && this.ModeCopierColler == true) {
                Console.WriteLine("Copie du contenu");
                await this.CopierContenuCoordonnees();
            } else {
                Console.WriteLine("Redirection vers le lien");
                await this.RedirigerVersLien();
            }
        }

        protected async Task CopierContenuCoordonnees()
        {
            if (this.JSRuntime is null) {
                Console.WriteLine("JSRuntime est null");
                return;
            }
            
            await JSRuntime.InvokeVoidAsync("copyToClipboard", this.Texte); 

            if (this.TypeLien == 1){
                this.AfficherMessage("Identifiant Discord copié !", Severity.Success);
            }

            if (this.TypeLien == 2){
                this.AfficherMessage("Adresse mail copiée !", Severity.Success);
            }
        }

        protected async Task RedirigerVersLien()
        {
            if (this.NavigationManager is null) {
                Console.WriteLine("NavigationManager est null");
                return;
            }
            if (this.Lien is null) {
                Console.WriteLine("Lien est null");
                return;
            }

            var url = NavigationManager.ToAbsoluteUri(this.Lien).ToString();
            if (this.JSRuntime is not null)
            {
                await this.JSRuntime.InvokeVoidAsync("window.open", url, "_blank");
            }
            else
            {
                Console.WriteLine("Impossible d'ouvrir le lien");
            }
        }

        private void AfficherMessage(string message, Severity niveau)
        {
            Console.WriteLine("Affichage du msg : " + message);
            Snackbar?.Add(message, niveau);
        }
    }
}