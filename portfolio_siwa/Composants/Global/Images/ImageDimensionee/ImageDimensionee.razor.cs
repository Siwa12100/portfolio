using Microsoft.AspNetCore.Components;

namespace portfolio_siwa.Composants.Global.Images.ImageDimensionee
{
    public partial class ImageDimensionee
    {
        [Parameter]
        public string? CheminImage { get; set; }

        [Parameter]
        public string? TexteAlternatif { get; set; } = "Image";

        [Parameter]
        public Boolean BordureArrondie { get; set; } = false;
    }
}