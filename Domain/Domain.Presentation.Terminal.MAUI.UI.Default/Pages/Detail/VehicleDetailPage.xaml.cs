using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class VehicleDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.VehicleDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.VehicleDisplayModel> completationFeedbackAction;

    public VehicleDetailPage(Interop.API.Common.Models.Display.VehicleDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.VehicleDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.VehicleDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() =>
                {
                    var _model = new Models.Page.Configuration.VehicleConfigurationPageModel(model);

                    var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                    var brandsAPIConnectClient = new Interop.API.Connect.Clients.BrandsAPIConnectClient(httpClientHelperProvider);
                    var kindsAPIConnectClient = new Interop.API.Connect.Clients.VehicleKindsAPIConnectClient(httpClientHelperProvider);
                    var engineKindsAPIConnectClient = new Interop.API.Connect.Clients.VehicleEngineKindsAPIConnectClient(httpClientHelperProvider);
                    var structuresAPIConnectClient = new Interop.API.Connect.Clients.ParentalStructuresAPIConnectClient(httpClientHelperProvider);

                    System.Threading.Tasks.Task.Run(async () =>
                    {
                        _model.AvailableBrands = await brandsAPIConnectClient.GetEnabledAsync();
                        _model.AvailableKinds = await kindsAPIConnectClient.GetEnabledAsync();
                        _model.AvailableEngineKinds = await engineKindsAPIConnectClient.GetEnabledAsync();
                        _model.AvailableStructures = await structuresAPIConnectClient.GetEnabledAsync();
                    }).ContinueWith(task => Dispatcher.Dispatch(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.VehicleConfigurationPage(completationFeedbackAction, _model))));
                });
            });
        });
    }
}