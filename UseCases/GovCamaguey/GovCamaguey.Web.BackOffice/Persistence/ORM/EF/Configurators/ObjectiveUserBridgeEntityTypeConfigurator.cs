using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators;

public class ObjectiveUserBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ObjectiveUserBridge, Objective, System.Guid, Framework.Guama.Security.Personal.Persistence.Entities.User, string>
{
    public ObjectiveUserBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = bridge => bridge.ObjectiveUserBridges;
    }
}