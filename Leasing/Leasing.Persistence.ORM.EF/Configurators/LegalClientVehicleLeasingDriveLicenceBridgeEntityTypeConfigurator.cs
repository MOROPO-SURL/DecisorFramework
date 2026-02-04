namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class LegalClientVehicleLeasingDriveLicenceBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.LegalClientVehicleLeasingDriveLicenceBridge, Entities.LegalClientVehicleLeasing, System.Guid, Entities.DriveLicence, System.Guid>
    {
        public LegalClientVehicleLeasingDriveLicenceBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.DriveLicenceBridges;
        }
    }
}
