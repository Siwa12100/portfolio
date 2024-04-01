using Microsoft.AspNetCore.Components;

namespace portfolioSiwa.Components.hautDePage
{
    public partial class HautDePage
    {
        [Parameter]
        public String description {  get; set; }

        [Parameter]
        public String titre { get; set; }

        [Parameter]
        public String cheminImage { get; set; }

        protected override void OnInitialized()
        {
            this.cheminImage = "/images/photoProfil.png";
            this.titre = "Jean Marcillac";

            String msgDescription = "Passionné par l'informatique et la culture numérique depuis des années, " + 
                "je suis actuellement en seconde année de BUT Informatique à Clermont-Ferrand dans l'optique de devenir un développeur "  + 
                "full stack pleinement aguérri.\n Passionné par les univers et la réalité virtuelle, j'oeuvre dans ces domaines sur " +
                "une partie de mon temps libre  en ma qualité de président " + 
                " de l'association Valorium.";

            this.description = msgDescription;

            
        }
    }
}
