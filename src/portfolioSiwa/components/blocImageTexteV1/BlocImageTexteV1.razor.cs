using Microsoft.AspNetCore.Components;

namespace portfolioSiwa.components.blocImageTexteV1
{
    public partial class BlocImageTexteV1
    {
        [Parameter]
        public string cheminImage { get; set; }

        [Parameter]
        public string titre { get; set; }

        [Parameter]
        public MarkupString texte { get; set; }

    }
}
