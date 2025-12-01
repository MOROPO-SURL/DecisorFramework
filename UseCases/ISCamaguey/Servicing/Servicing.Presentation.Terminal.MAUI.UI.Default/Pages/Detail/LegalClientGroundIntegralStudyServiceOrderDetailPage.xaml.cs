using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class LegalClientGroundIntegralStudyServiceOrderDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel, int?> delegationAction;
    public LegalClientGroundIntegralStudyServiceOrderDetailPage(Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
		InitializeComponent();
        
        this.delegationAction = delegationAction;

        OptionButtonsLayout.IsVisible = delegationAction != null;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var concreteBindingContext = BindingContext as Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.LegalClientGroundIntegralStudyServiceOrderDisplayModel;

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