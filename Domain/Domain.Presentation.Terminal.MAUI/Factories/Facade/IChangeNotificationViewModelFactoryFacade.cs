namespace MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Factories.Facade;

public interface IChangeNotificationViewModelFactoryFacade
{
    Models.View.ChangeNotificationViewModel Build(Interop.API.Common.Models.Display.ChangeNotificationDisplayModel model);
}
