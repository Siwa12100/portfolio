using Microsoft.AspNetCore.Components;

namespace siteValorium.components.blocImageTexteV1
{
    public partial class BlocImageTexteV1
    {
        [Parameter]
        public String cheminImage {  get; set; }

        [Parameter]
        public String titre {  get; set; }

        [Parameter]
        public MarkupString texte { get; set; }

    }
}
