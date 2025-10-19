using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class TrainingServiceDetailPage : Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Interop.API.Common.Models.Display.TrainingServiceDisplayModel>
{
    private readonly System.Action<Interop.API.Common.Models.Display.TrainingServiceDisplayModel, int?> delegationAction;

    public TrainingServiceDetailPage(Interop.API.Common.Models.Display.TrainingServiceDisplayModel bindingContextModel, System.Action<Interop.API.Common.Models.Display.TrainingServiceDisplayModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void EditButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Interop.API.Common.Models.Display.TrainingServiceDisplayModel;

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

            var model = BindingContext as Interop.API.Common.Models.Display.TrainingServiceDisplayModel;

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

    private void ExportButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayActionSheet("Exportar", Contants.CommonConstants.CANCEL_OPTION, null, Contants.CommonConstants.TECH_PAPER_EXPORT_OPTION, Contants.CommonConstants.COST_PAPER_EXPORT_OPTION).ContinueWith(task =>
        {
            if (task.IsCanceled || task.Result == null || task.Result == Contants.CommonConstants.CANCEL_OPTION) return;

            Dispatcher.Dispatch(() => DisplayAlert("Aviso", "Funcionalidad en desarrollo.", "Aceptar"));
        });
    }
}