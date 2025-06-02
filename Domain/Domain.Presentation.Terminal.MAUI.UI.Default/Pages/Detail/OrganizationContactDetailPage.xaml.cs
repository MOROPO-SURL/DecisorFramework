using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class OrganizationContactDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.OrganizationContactDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, int> delegationAction;

    public OrganizationContactDetailPage(Interop.API.Common.Models.Display.OrganizationContactDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.OrganizationContactDisplayModel, int> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.OrganizationContactDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.OrganizationContactDisplayModel;

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