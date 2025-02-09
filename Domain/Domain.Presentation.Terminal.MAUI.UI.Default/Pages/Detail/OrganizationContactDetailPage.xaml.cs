using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class OrganizationContactDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.OrganizationContactDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.OrganizationContactDisplayModel> completationFeedbackAction;

    public OrganizationContactDetailPage(Interop.API.Common.Models.Display.OrganizationContactDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.OrganizationContactDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.OrganizationContactDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() =>
                {
                    var _model = new Models.Page.Configuration.OrganizationContactConfigurationPageModel(model);

                    var apiConnectClient = new Interop.API.Connect.Clients.LegalBusinessKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

                    apiConnectClient.GetEnabledAsync().ContinueWith(task =>
                    {
                        if (task.IsCompleted)
                        {
                            _model.AvailableBusinessKinds = task.Result;
                        }

                        Dispatcher.Dispatch(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.OrganizationContactConfigurationPage(completationFeedbackAction, _model)));
                    });
                });
            });
        });
    }
}