using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Inventory.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class WarehouseDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.WarehouseDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.WarehouseDisplayModel, int> delegationAction;

    public WarehouseDetailPage(Interop.API.Common.Models.Display.WarehouseDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.WarehouseDisplayModel, int> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.WarehouseDisplayModel;

        this.NavigationPopModalPageAsync().ContinueWith(_ =>
        {
            // 0 for Edit
            Dispatcher.Dispatch(() => delegationAction.Invoke(model, 0));
        });
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = BindingContext as Interop.API.Common.Models.Display.WarehouseDisplayModel;

            Dispatcher.Dispatch(() =>
            {
                this.NavigationPopModalPageAsync().ContinueWith(_ =>
                {
                    // 1 for Delete
                    Dispatcher.Dispatch(() => delegationAction.Invoke(model, 1));
                });
            });
        });
    }
}