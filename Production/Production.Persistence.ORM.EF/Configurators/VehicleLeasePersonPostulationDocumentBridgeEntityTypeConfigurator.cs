using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class VehicleLeasePersonPostulationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<VehicleLeasePersonPostulationDocumentBridge, VehicleLeasePersonPostulation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public VehicleLeasePersonPostulationDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}
