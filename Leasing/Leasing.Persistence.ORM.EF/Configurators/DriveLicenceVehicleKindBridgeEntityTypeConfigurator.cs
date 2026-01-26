namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators;

public class DriveLicenceVehicleKindBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.DriveLicenceVehicleKindBridge, Entities.DriveLicence, System.Guid, Domain.Persistence.Entities.VehicleKind, System.Guid>
{
    public DriveLicenceVehicleKindBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.VehicleKindBridges;
    }
}
