using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class VehicleLeaseOfferClauseBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<VehicleLeaseOfferClauseBridge, VehicleLeaseOffer, System.Guid, Legal.Persistence.Entities.Clause, System.Guid>
    {
        public VehicleLeaseOfferClauseBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ClauseBridges;
        }
    }
}
