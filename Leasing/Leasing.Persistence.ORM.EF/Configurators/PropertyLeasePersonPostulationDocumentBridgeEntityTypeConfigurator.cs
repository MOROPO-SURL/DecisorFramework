using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class PropertyLeasePersonPostulationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<PropertyLeasePersonPostulationDocumentBridge, PropertyLeasePersonPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public PropertyLeasePersonPostulationDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}
