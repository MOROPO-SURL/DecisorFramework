using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators;

public class ActionUserBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ActionUserBridge, Action, System.Guid, Framework.Guama.Security.Personal.Persistence.Entities.User, string>
{
    public ActionUserBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = bridge => bridge.ActionUserBridges;
    }
}