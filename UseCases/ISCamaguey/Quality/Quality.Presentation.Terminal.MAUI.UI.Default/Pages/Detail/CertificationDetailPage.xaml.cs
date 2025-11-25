using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class CertificationDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.CertificationDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.CertificationDisplayModel, int?> delegationAction;
    public CertificationDetailPage(Interop.API.Common.Models.Display.CertificationDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.CertificationDisplayModel, int?> delegationAction) : base(bindingContextModel)
	{
		InitializeComponent();

        this.delegationAction = delegationAction;

        if (delegationAction == null) OptionButtonLayout.IsVisible = false;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.CertificationDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.CertificationDisplayModel;

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