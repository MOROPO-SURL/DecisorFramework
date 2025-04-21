using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators
{
    public class ActionOrganizationParticipationBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ActionOrganizationParticipationBridge, Action, System.Guid, Organization, System.Guid>
    {
        public ActionOrganizationParticipationBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.OrganizationParticipationBridges;
        }
    }
}
