using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.Techno
{
    public partial class Techno
    {
        [Parameter]
        public string? Nom { get; set; }

        [Parameter]
        public string? Logo { get; set; }

        [Parameter]
        public string? Description { get; set; }
    }
}