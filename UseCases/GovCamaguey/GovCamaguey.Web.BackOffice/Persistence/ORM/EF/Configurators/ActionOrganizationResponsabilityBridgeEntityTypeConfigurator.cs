using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators
{
    public class ActionOrganizationResponsabilityBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ActionOrganizationResponsabilityBridge, Action, System.Guid, Organization, System.Guid>
    {
        public ActionOrganizationResponsabilityBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.OrganizationResponsabilityBridges;
        }
    }
}
