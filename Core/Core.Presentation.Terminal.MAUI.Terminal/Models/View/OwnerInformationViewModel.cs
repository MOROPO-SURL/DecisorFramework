namespace MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View
{
    public class OwnerInformationViewModel
    {
        public string Name { get; set; }

        public bool IsNamePresentInLogo { get; set; }

        public Microsoft.Maui.Controls.ImageSource DefaultLogoImageSource { get; set; }

        public Microsoft.Maui.Controls.ImageSource LightLogoImageSource { get; set; }

        public Microsoft.Maui.Controls.ImageSource DarkLogoImageSource { get; set; }
    }
}
