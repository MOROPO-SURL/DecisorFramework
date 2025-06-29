using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class VehicleLeaseOrganizationPostulationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<VehicleLeaseOrganizationPostulationDocumentBridge, VehicleLeaseOrganizationPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public VehicleLeaseOrganizationPostulationDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}
