using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Commercial.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class NaturalClientDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.NaturalClientDisplayModel> completationFeedbackAction;

    public NaturalClientDetailPage(Interop.API.Common.Models.Display.NaturalClientDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.NaturalClientDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.NaturalClientDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() =>
                {
                    var _model = new Models.Page.Configuration.NaturalClientConfigurationPageModel(model);

                    System.Threading.Tasks.Task.Run(async () =>
                    {
                        var httpClientHelperProvider = Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>();

                        var paymentTermsAPIConnectClient = new Interop.API.Connect.Clients.PaymentTermsAPIConnectClient(httpClientHelperProvider);
                        var naturalBusinessKindAPIConnectClient = new Domain.Interop.API.Connect.Clients.NaturalBusinessKindsAPIConnectClient(httpClientHelperProvider);

                        return new { PaymentTerms = await paymentTermsAPIConnectClient.GetEnabledAsync(), BusinessKinds = await naturalBusinessKindAPIConnectClient.GetEnabledAsync() };

                    }).ContinueWith(task =>
                    {
                        if (task.IsCompleted)
                        {
                            _model.AvailablePaymentTerms = task.Result.PaymentTerms;
                            _model.AvailableBusinessKinds = task.Result.BusinessKinds;
                        }

                        Dispatcher.Dispatch(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.NaturalClientConfigurationPage(completationFeedbackAction, _model)));
                    });
                });
            });
        });
    }
}