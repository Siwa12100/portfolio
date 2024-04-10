using Microsoft.AspNetCore.Components;

namespace siteValorium.composants.blocVideoTexteV1
{
    public partial class BlocVideoTexteV1
    {
        [Parameter]
        public String cheminVideo { get; set; }

        [Parameter]
        public String titre { get; set; }

        [Parameter]
        public MarkupString texte { get; set; }

    }
}
