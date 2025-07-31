using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class PropertyLeaseOrganizationPostulationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<PropertyLeaseOrganizationPostulationDocumentBridge, PropertyLeaseOrganizationPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public PropertyLeaseOrganizationPostulationDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}
