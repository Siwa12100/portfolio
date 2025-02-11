using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.FondMedia
{
    public partial class FondMedia
    {
        [Parameter]
        public RenderFragment? BackgroundContent { get; set; }

        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}