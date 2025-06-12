using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class PurchaseZoneDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, int?> delegationAction;

    public PurchaseZoneDetailPage(Interop.API.Common.Models.Display.PurchaseZoneDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.PurchaseZoneDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.PurchaseZoneDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.PurchaseZoneDisplayModel;

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