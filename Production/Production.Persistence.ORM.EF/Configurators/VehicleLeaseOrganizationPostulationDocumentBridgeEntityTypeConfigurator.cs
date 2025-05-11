using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class VehicleLeaseOrganizationPostulationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<VehicleLeaseOrganizationPostulationDocumentBridge, VehicleLeaseOrganizationPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public VehicleLeaseOrganizationPostulationDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}
