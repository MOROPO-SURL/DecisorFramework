using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Detail;

public partial class PersonDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PersonDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.PersonDisplayModel> completationFeedbackAction;

    public PersonDetailPage(Interop.API.Common.Models.Display.PersonDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.PersonDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.PersonDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() =>
                {
                    var _model = new Models.Page.Configuration.PersonConfigurationPageModel(model);

                    Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.PersonConfigurationPage(completationFeedbackAction, _model));
                });
            });
        });
    }
}