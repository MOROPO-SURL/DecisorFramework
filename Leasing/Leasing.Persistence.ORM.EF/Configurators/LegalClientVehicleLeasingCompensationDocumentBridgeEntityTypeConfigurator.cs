namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class LegalClientVehicleLeasingCompensationDocumentBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalClientVehicleLeasingCompensationDocumentBridge, Entities.LegalClientVehicleLeasingCompensation, System.Guid, Guama.Media.Persistence.Entities.Document, System.Guid>
    {
        public LegalClientVehicleLeasingCompensationDocumentBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DocumentBridges;
        }
    }
}
