using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridge, PropertyLeasePersonPostulation, System.Guid, PropertySpaceLeasePropousal, System.Guid>
    {
        public PropertyLeasePersonPostulationPropertySpaceLeasePropousalBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.PropertySpaceBridges;
        }
    }
}
