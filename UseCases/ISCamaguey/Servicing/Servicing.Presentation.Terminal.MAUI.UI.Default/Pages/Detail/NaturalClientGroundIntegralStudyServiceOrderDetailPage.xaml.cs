using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class NaturalClientGroundIntegralStudyServiceOrderDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel, int?> delegationAction;
    public NaturalClientGroundIntegralStudyServiceOrderDetailPage(Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
		InitializeComponent();

        this.delegationAction = delegationAction;

        OptionButtonsLayout.IsVisible = delegationAction != null;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var concreteBindingContext = BindingContext as Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.NaturalClientGroundIntegralStudyServiceOrderDisplayModel;

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