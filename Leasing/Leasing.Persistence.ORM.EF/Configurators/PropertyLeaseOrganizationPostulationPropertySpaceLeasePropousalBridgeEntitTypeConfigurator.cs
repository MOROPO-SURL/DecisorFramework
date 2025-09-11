using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridgeEntitTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridge, PropertyLeaseOrganizationPostulation, System.Guid, PropertySpaceLeasePropousal, System.Guid>
    {
        public PropertyLeaseOrganizationPostulationPropertySpaceLeasePropousalBridgeEntitTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.PropertySpaceBridges;
        }
    }
}
