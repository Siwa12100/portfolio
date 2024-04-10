using Microsoft.AspNetCore.Components;
using siteValorium.components.blocImageTexteV1;

namespace siteValorium.components.blocImageTexteV2
{
    public partial class BlocImageTexteV2
    {
        [Parameter]
        public String cheminImage { get; set; }

        [Parameter]
        public String titre { get; set; }

        [Parameter]
        public MarkupString texte { get; set; }

    }
}
