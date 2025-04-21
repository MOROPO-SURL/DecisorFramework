using MOROPO.GovCamaguey.Decisor.Prototype.Persistence.Entities;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Web.BackOffice.Persistence.ORM.EF.Configurators
{
    public class ProyectionOrganizationParticipationBridgeEntityTypeConfigurator : Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<ProyectionOrganizationParticipationBridge, Proyection, System.Guid, Organization, System.Guid>
    {
        public ProyectionOrganizationParticipationBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.OrganizationParticipationBridges;
        }
    }
}
