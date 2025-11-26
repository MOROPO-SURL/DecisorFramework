using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class ServiceOrderSampleDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel, int?> delegationAction;

    public ServiceOrderSampleDetailPage(Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.ServiceOrderSampleDisplayModel;

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