using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class VehicleLeaseOfferDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel> completationFeedbackAction;

    public VehicleLeaseOfferDetailPage(Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.VehicleLeaseOfferDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() =>
                {
                    var _model = new Models.Page.Configuration.VehicleLeaseOfferConfigurationPageModel(model);

                    Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.VehicleLeaseOfferConfigurationPage(completationFeedbackAction, _model));
                });
            });
        });
    }
}