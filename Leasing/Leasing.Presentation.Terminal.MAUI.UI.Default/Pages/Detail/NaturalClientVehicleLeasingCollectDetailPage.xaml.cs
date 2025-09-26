using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class NaturalClientVehicleLeasingCollectDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel, int?> delegationAction;

    public NaturalClientVehicleLeasingCollectDetailPage(Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            // null for Edit
            Dispatcher.Dispatch(() => delegationAction.Invoke(model, null));
        });
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = BindingContext as Interop.API.Common.Models.Display.NaturalClientVehicleLeasingCollectDisplayModel;

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