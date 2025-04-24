using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Detail;

public partial class GuidelineDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.GuidelineDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.GuidelineDisplayModel> completationFeedbackAction;

    public GuidelineDetailPage(Interop.API.Common.Models.Display.GuidelineDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.GuidelineDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.GuidelineDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.GuidelineConfigurationPage(completationFeedbackAction, new Models.Page.Configuration.GuidelineConfigurationPageModel(model))));
            });
        });
    }
}