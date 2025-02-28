namespace MOROPO.CheffMIGUE.Decisor.Terminal.Providers
{
    public class SingleRuntimeContextProvider : Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IRuntimeContextProviderFacade
    {
        internal static Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OWNER_INFORMATION = new()
        {
            Name = "CheffMIGUE S.R.L.",
            LogoImageViewStyle = (Microsoft.Maui.Controls.Style)Microsoft.Maui.Controls.Application.Current.Resources["LogoImageViewStyle"]
        };

        public Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OwnerInformation => OWNER_INFORMATION;
    }
}
