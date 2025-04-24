using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Shells
{
    public partial class AppShell : Microsoft.Maui.Controls.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            BindingContext = new Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel
            {
                OwnerInformation = Providers.SingleRuntimeContextProvider.OWNER_INFORMATION
            };
        }

        private Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel ConcretBindingContext => BindingContext as Framework.Decisor.Core.Presentation.Terminal.MAUI.Models.Page.MainPageModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var sessionManager = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade>();

            ConcretBindingContext.User = sessionManager.CurrentSession?.User;

            if (ConcretBindingContext.User == null)
            {
                this.NavigationPushModalPageAsync(new Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Default.Pages.DefaultUserAuthenticationPage());
            }
        }
    }
}
