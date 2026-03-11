using MOROPO.Framework.Caney.MVVM.Core.Extensions;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

public partial class ChangeNotificationDetailPage : Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Models.View.ChangeNotificationViewModel>
{
    private readonly System.Action<Models.View.ChangeNotificationViewModel, int?> delegationAction;

    public ChangeNotificationDetailPage(Models.View.ChangeNotificationViewModel bindingContextModel, System.Action<Models.View.ChangeNotificationViewModel, int?> delegationAction) : base(bindingContextModel)
    {
        InitializeComponent();

        this.delegationAction = delegationAction;
    }

    private void ChangeDetailButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        var model = BindingContext as Models.View.ChangeNotificationViewModel;

        
    }

    private void DeleteButton_Clicked(object sender, System.EventArgs eventArgs)
    {
        DisplayAlert("Confirmación", "Está seguro que desea eliminar este elemento?", "Eliminar", "Cancelar").ContinueWith(task =>
        {
            if (!task.Result) return;

            var model = BindingContext as Models.View.ChangeNotificationViewModel;

            Dispatcher.Dispatch(() =>
            {
                this.NavigationPopModalPageAsync().ContinueWith(_ =>
                {
                    // null for Delete
                    Dispatcher.Dispatch(() => delegationAction.Invoke(model, null));
                });
            });
        });
    }
}