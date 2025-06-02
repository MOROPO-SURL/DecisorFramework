using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class OrganizationalUnityParentalDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel> completationFeedbackAction;

    public OrganizationalUnityParentalDetailPage(Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.OrganizationalUnityParentalDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        //var model = BindingContext as Interop.API.Common.Models.Display.OrganizationContactDisplayModel;

        //this.NavigationPopModalPageAsync().ContinueWith(_ =>
        //{
        //    Dispatcher.Dispatch(() =>
        //    {
        //        delegationAction.Invoke(() =>
        //        {
        //            var _model = new Models.Page.Configuration.Orga(model);

        //            var apiConnectClient = new Interop.API.Connect.Clients.LegalBusinessKindsAPIConnectClient(Microsoft.Maui.IPlatformApplication.Current.Services.GetRequiredService<Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade>());

        //            apiConnectClient.GetEnabledAsync().ContinueWith(task =>
        //            {
        //                if (task.IsCompleted)
        //                {
        //                    _model.AvailableBusinessKinds = task.Result;
        //                }

        //                Dispatcher.Dispatch(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.OrganizationContactConfigurationPage(completationFeedbackAction, _model)));
        //            });
        //        });
        //    });
        //});
    }
}