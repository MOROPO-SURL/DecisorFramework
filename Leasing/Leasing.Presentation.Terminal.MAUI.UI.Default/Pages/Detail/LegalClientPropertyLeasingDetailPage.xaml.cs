using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Leasing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class LegalClientPropertyLeasingDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel, int?> delegationAction;

    public LegalClientPropertyLeasingDetailPage(Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea terminar este arrendamiento y cerrar su respectivo contrato?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = BindingContext as Interop.API.Common.Models.Display.LegalClientPropertyLeasingDisplayModel;

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