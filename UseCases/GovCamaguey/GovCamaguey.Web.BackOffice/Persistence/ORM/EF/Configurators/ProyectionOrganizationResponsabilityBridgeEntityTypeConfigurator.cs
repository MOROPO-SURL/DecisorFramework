using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators
{
    public class ProyectionOrganizationResponsabilityBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ProyectionOrganizationResponsabilityBridge, Proyection, System.Guid, Organization, System.Guid>
    {
        public ProyectionOrganizationResponsabilityBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.OrganizationResponsablityBridges;
        }
    }
}
