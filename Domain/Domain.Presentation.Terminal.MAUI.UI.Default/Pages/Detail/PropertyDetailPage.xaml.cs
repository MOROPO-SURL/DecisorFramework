using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class PropertyDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PropertyDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.PropertyDisplayModel> completationFeedbackAction;

    public PropertyDetailPage(Interop.API.Common.Models.Display.PropertyDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.PropertyDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.PropertyDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() =>
                {
                    var _model = new Models.Page.Configuration.PropertyConfigurationPageModel(model);

                    var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                    var kindsAPIConnectClient = new Interop.API.Connect.Clients.PropertyKindsAPIConnectClient(httpClientHelperProvider);
                    var structuresAPIConnectClient = new Interop.API.Connect.Clients.ParentalStructuresAPIConnectClient(httpClientHelperProvider);

                    System.Threading.Tasks.Task.Run(async () =>
                    {
                        _model.AvailableKinds = await kindsAPIConnectClient.GetAsync();
                        _model.AvailableStructures = await structuresAPIConnectClient.GetEnabledAsync();
                    }).ContinueWith(task => Dispatcher.Dispatch(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.PropertyConfigurationPage(completationFeedbackAction, _model))));
                });
            });
        });
    }
}