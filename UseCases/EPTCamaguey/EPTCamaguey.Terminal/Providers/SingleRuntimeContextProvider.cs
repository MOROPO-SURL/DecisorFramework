namespace MOROPO.EPTCamaguey.Decisor.Terminal.Providers
{
    public class SingleRuntimeContextProvider : Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IRuntimeContextProviderFacade
    {
        internal static Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OWNER_INFORMATION = new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel
        {
            Name = "Empresa Provincial de Transporte Camagüey",
            LogoImageViewStyle = (Microsoft.Maui.Controls.Style)Microsoft.Maui.Controls.Application.Current.Resources["LogoImageViewStyle"]
        };

        public Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OwnerInformation => OWNER_INFORMATION;
    }
}
