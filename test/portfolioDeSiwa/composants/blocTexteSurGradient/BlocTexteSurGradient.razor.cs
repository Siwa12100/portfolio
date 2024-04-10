using Microsoft.AspNetCore.Components;

namespace siteValorium.composants.blocTexteSurGradient
{
    public partial class BlocTexteSurGradient
    {
        [Parameter]
        public String titre {  get; set; }

        [Parameter]
        public MarkupString contenu { get; set; }
    }
}
