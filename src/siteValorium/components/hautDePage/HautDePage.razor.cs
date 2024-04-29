using Microsoft.AspNetCore.Components;

namespace siteValorium.components.hautDePage
{
    public partial class HautDePage
    {
        [Parameter]
        public MarkupString description { get; set; }

        [Parameter]
        public string titre { get; set; }

        [Parameter]
        public string cheminImage { get; set; }

        protected override void OnInitialized()
        {
            cheminImage = "/images/photoProfil.webp";
            titre = "Jean Marcillac";

            MarkupString msgHautDePage = new MarkupString("Passionné par l'informatique et le numérique depuis " +
                "des années, je suis actuellement étudiant en BUT Informatique à Clermont-Ferrand dans l'optique de " +
                "devenir un développeur full-stack pleinement qualifié. <br><br>Engagé en tant que président dans " +
                "les travaux de l'association <a href='http://valorium-mc.fr' target='_blank'>Valorium</a>, travaillant à la collaboration de communautés et à la création d'un univers " +
                "virtuel autour du jeu Minecraft.");



            description = msgHautDePage;
        }
    }
}
