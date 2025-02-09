using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class UnitMeasurementDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> completationFeedbackAction;

    public UnitMeasurementDetailPage(Interop.API.Common.Models.Display.UnitMeasurementDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.UnitMeasurementDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.UnitMeasurementDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() => Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.UnitMeasurementConfigurationPage(completationFeedbackAction, new Models.Page.Configuration.UnitMeasurementConfigurationPageModel(model))));
            });
        });
    }
}