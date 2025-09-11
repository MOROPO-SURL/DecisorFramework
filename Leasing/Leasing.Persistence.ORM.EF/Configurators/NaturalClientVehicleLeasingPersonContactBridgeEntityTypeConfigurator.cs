namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class NaturalClientVehicleLeasingPersonContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalClientVehicleLeasingPersonContactBridge, Entities.NaturalClientVehicleLeasing, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public NaturalClientVehicleLeasingPersonContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ContactBridges;
        }
    }
}
