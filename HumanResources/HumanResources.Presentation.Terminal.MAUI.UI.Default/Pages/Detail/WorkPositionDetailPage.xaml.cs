using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class WorkPositionDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.WorkPositionDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.WorkPositionDisplayModel> completationFeedbackAction;

    public WorkPositionDetailPage(Interop.API.Common.Models.Display.WorkPositionDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.WorkPositionDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.WorkPositionDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() =>
                {
                    var _model = new Models.Page.Configuration.WorkPositionConfigurationPageModel(model);

                    var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                    var kindsAPIConnectClient = new Interop.API.Connect.Clients.WorkPositionKindsAPIConnectClient(httpClientHelperProvider);
                    var shoolingsAPIConnectClient = new Interop.API.Connect.Clients.SchoolingsAPIConnectClient(httpClientHelperProvider);

                    System.Threading.Tasks.Task.Run(async () =>
                    {
                        _model.AvailableKinds = await kindsAPIConnectClient.GetAsync();
                        _model.AvailableSchoolings = await shoolingsAPIConnectClient.GetAsync();
                    }).ContinueWith(task =>
                    {
                        Dispatcher.Dispatch(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.WorkPositionConfigurationPage(completationFeedbackAction, _model)));
                    });
                });
            });
        });
    }
}