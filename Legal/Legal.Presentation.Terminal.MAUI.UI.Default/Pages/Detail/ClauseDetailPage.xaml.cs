using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class ClauseDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ClauseDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.ClauseDisplayModel> completationFeedbackAction;

    public ClauseDetailPage(Interop.API.Common.Models.Display.ClauseDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.ClauseDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.ClauseDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.ClauseConfigurationPage(completationFeedbackAction, new Models.Page.Configuration.ClauseConfigurationPageModel(model))));
        });
    }
}