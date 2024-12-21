namespace MOROPO.Tool.Decisor.Terminal.Providers
{
    public class SingleRuntimeContextProvider : Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IRuntimeContextProviderFacade
    {
        internal static Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OWNER_INFORMATION = new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel
        {
            Name = "MOROPO S.U.R.L.",
            LogoImageViewStyle = (Microsoft.Maui.Controls.Style)Microsoft.Maui.Controls.Application.Current.Resources["LogoImageViewStyle"]
        };

        public Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OwnerInformation => OWNER_INFORMATION;
    }
}
