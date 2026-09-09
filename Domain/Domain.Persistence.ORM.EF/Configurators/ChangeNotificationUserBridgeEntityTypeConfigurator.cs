namespace MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Configurators;

public class ChangeNotificationUserBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ChangeNotificationUserBridge, Entities.ChangeNotification, System.Guid, Guama.Security.Personal.Persistence.Entities.User, string>
{
    public ChangeNotificationUserBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.UserBridges;
    }
}