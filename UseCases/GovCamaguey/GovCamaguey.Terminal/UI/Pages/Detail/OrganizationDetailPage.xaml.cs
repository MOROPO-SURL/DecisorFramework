using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Detail;

public partial class OrganizationDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.OrganizationDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.OrganizationDisplayModel, int> delegationAction;

    public OrganizationDetailPage(Interop.API.Common.Models.Display.OrganizationDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.OrganizationDisplayModel, int> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.OrganizationDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.OrganizationDisplayModel;

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