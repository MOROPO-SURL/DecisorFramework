using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class LegalClientVehicleLeasingDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel, int?> delegationAction;

    public LegalClientVehicleLeasingDetailPage(Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea terminar este arrendamiento y cerrar su respectivo contrato?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = BindingContext as Interop.API.Common.Models.Display.LegalClientVehicleLeasingDisplayModel;

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