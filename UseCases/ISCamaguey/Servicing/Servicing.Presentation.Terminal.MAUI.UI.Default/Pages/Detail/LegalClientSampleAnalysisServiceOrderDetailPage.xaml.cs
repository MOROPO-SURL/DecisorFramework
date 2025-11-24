using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class LegalClientSampleAnalysisServiceOrderDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel, int?> delegationAction;

    public LegalClientSampleAnalysisServiceOrderDetailPage(Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;

        OptionButtonsLayout.IsVisible = delegationAction != null;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var concreteBindingContext = BindingContext as Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            // null for Edit
            Dispatcher.Dispatch(() => delegationAction.Invoke(concreteBindingContext, null));
        });
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = BindingContext as Interop.API.Common.Models.Display.LegalClientSampleAnalysisServiceOrderDisplayModel;

            Dispatcher.Dispatch(() =>
            {
                this.NavigationPopModalPageAsync().ContinueWith(_ =>
                {
                    // 0 for Delete
                    Dispatcher.Dispatch(() => delegationAction.Invoke(model, 0));
                });
            });
        });
    }
}