namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class NaturalClientVehicleLeasingCompensationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalClientVehicleLeasingCompensationDocumentBridge, Entities.NaturalClientVehicleLeasingCompensation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public NaturalClientVehicleLeasingCompensationDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}