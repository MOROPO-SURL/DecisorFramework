using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class VehicleLeaseOfferOrganizationContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<VehicleLeaseOfferOrganizationContactBridge, VehicleLeaseOffer, System.Guid, Domain.Persistence.Entities.OrganizationContact, System.Guid>
    {
        public VehicleLeaseOfferOrganizationContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.OrganizationContactBridges;
        }
    }
}
