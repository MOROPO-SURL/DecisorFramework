using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class NaturalClientVehicleLeasingDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel, int?> delegationAction;

    public NaturalClientVehicleLeasingDetailPage(Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea terminar este arrendamiento y cerrar su contrato?", "Terminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = BindingContext as Interop.API.Common.Models.Display.NaturalClientVehicleLeasingDisplayModel;

            Dispatcher.Dispatch(() => this.NavigationPopModalPageAsync().ContinueWith(_ => Dispatcher.Dispatch(() => delegationAction.Invoke(model, 0))));
        });
    }
}