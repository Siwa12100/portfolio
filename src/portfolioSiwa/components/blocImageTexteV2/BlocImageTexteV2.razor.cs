using Microsoft.AspNetCore.Components;

namespace portfolioSiwa.components.blocImageTexteV2
{
    public partial class BlocImageTexteV2
    {
        [Parameter]
        public string cheminImage { get; set; }

        [Parameter]
        public string titre { get; set; }

        [Parameter]
        public MarkupString texte { get; set; }

    }
}
