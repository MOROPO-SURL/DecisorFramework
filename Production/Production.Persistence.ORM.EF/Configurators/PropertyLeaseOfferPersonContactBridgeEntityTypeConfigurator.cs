using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class PropertyLeaseOfferPersonContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<PropertyLeaseOfferPersonContactBridge, PropertyLeaseOffer, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public PropertyLeaseOfferPersonContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.PersonContactBridges;
        }
    }
}
