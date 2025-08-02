using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators
{
    public class PropertyLeaseOfferClauseBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<PropertyLeaseOfferClauseBridge, PropertyLeaseOffer, System.Guid, Legal.Persistence.Entities.Clause, System.Guid>
    {
        public PropertyLeaseOfferClauseBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ClauseBridges;
        }
    }
}
