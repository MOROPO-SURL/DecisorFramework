namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class NaturalClientVehicleLeasingDriveLicenceBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.NaturalClientVehicleLeasingDriveLicenceBridge, Entities.NaturalClientVehicleLeasing, System.Guid, Entities.DriveLicence, System.Guid>
    {
        public NaturalClientVehicleLeasingDriveLicenceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DriveLicenceBridges;
        }
    }
}
