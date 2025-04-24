using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Detail;

public partial class OrganizationDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.OrganizationDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.OrganizationDisplayModel> completationFeedbackAction;

    public OrganizationDetailPage(Interop.API.Common.Models.Display.OrganizationDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.OrganizationDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.OrganizationDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() =>
                {
                    var _model = new Models.Page.Configuration.OrganizationConfigurationPageModel(model);

                    Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.OrganizationConfigurationPage(completationFeedbackAction, _model));
                });
            });
        });
    }
}