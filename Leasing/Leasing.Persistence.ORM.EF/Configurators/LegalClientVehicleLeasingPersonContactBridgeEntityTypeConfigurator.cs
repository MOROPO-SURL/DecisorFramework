namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class LegalClientVehicleLeasingPersonContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalClientVehicleLeasingPersonContactBridge, Entities.LegalClientVehicleLeasing, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public LegalClientVehicleLeasingPersonContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ContactBridges;
        }
    }
}
