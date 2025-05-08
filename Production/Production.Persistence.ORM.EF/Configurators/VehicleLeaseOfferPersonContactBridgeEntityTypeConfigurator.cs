using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class VehicleLeaseOfferPersonContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<VehicleLeaseOfferPersonContactBridge, VehicleLeaseOffer, System.Guid, Domain.Persistence.Entities.PersonContact, System.Guid>
    {
        public VehicleLeaseOfferPersonContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.PersonContactBridges;
        }
    }
}