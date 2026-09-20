using Microsoft.AspNetCore.Components;
using portfolio_siwa.Modeles;

namespace portfolio_siwa.Composants.Sections
{
    public partial class CarteProjet
    {
        [Parameter]
        [EditorRequired]
        public required FicheProjet Fiche { get; set; }

        /// <summary>Sur grand écran, place le visuel à droite plutôt qu'à gauche.</summary>
        [Parameter]
        public bool Inverse { get; set; }

        [CascadingParameter]
        private Langue Langue { get; set; }

        /// <summary>Année, cadre et mode de réalisation, dans l'ordre, sans les valeurs absentes.</summary>
        private IReadOnlyList<string> Contexte =>
            new[] { this.Fiche.Annee, this.Fiche.Cadre, this.Fiche.Realisation }
                .Where(element => element is not null)
                .Select(element => element![this.Langue])
                .ToList();
    }
}
