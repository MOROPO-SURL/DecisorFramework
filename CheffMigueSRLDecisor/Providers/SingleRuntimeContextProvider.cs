namespace MOROPO.CheffMigueSRL.Decisor.Terminal.Providers
{
    public class SingleRuntimeContextProvider : Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IRuntimeContextProviderFacade
    {
        internal static Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OWNER_INFORMATION = new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel
        {
            Name = "CheffMIGUE S.R.L.",
            IsNamePresentInLogo = false,
            DefaultLogoImageSource = Microsoft.Maui.Controls.ImageSource.FromFile("logo_chef_nuevo.png")
        };

        public Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.View.OwnerInformationViewModel OwnerInformation => OWNER_INFORMATION;
    }
}
