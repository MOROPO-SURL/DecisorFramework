using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Production.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class ProductionOrderDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ProductionOrderDisplayModel>
{
    private readonly System.Action<System.Action> delegationAction;
    private readonly System.Action<Interop.API.Common.Models.Display.ProductionOrderDisplayModel> completationFeedbackAction;

    public ProductionOrderDetailPage(Interop.API.Common.Models.Display.ProductionOrderDisplayModel bindingContextModel, System.Action<System.Action> delegationAction, System.Action<Interop.API.Common.Models.Display.ProductionOrderDisplayModel> completationFeedbackAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
        this.completationFeedbackAction = completationFeedbackAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.ProductionOrderDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            Dispatcher.Dispatch(() =>
            {
                delegationAction.Invoke(() =>
                {
                    var _model = new Models.Page.Configuration.ProductionOrderConfigurationPageModel(model);

                    Microsoft.Maui.Controls.Application.Current.MainPage.NavigationPushPageAsync(new Configuration.ProductionOrderConfigurationPage(completationFeedbackAction, _model));
                });
            });
        });
    }
}