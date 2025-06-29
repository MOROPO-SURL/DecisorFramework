using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class VehicleLeaseOfferClauseBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<VehicleLeaseOfferClauseBridge, VehicleLeaseOffer, System.Guid, Legal.Persistence.Entities.Clause, System.Guid>
    {
        public VehicleLeaseOfferClauseBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ClauseBridges;
        }
    }
}
