namespace MOROPO.EPTCamaguey.Decisor.Terminal.MAUI.Providers
{
    public class SingleRuntimeContextProvider : Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IRuntimeContextProviderFacade
    {
        internal static Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OWNER_INFORMATION = new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel
        {
            Name = "Empresa Provicinal de Transporte de Camagüey",
            IsNamePresentInLogo = false,
            DefaultLogoImageSource = Microsoft.Maui.Controls.ImageSource.FromFile("identity_color.png")
        };

        public Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OwnerInformation => OWNER_INFORMATION;
    }
}
