namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

public class ChangeNotificationDetailFactory : Core.Presentation.Terminal.MAUI.UI.Factories.Facade.IDetailContentPageFactoryFacade<Models.View.ChangeNotificationViewModel>
{
    public Core.Presentation.Terminal.MAUI.UI.Pages.Base.DetailBaseContentPage<Models.View.ChangeNotificationViewModel> Build(Models.View.ChangeNotificationViewModel model, System.Action<Models.View.ChangeNotificationViewModel, int?> delegationAction = null)
    {
        return new Pages.Detail.ChangeNotificationDetailPage(model, delegationAction);
    }
}
