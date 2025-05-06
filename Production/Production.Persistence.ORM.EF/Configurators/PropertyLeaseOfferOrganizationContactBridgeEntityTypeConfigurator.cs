using MOROPO.Framework.Decisor.Production.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class PropertyLeaseOfferOrganizationContactBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<PropertyLeaseOfferOrganizationContactBridge, PropertyLeaseOffer, System.Guid, Domain.Persistence.Entities.OrganizationContact, System.Guid>
    {
        public PropertyLeaseOfferOrganizationContactBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = bridge => bridge.OrganizationContactBridges;
        }
    }
}
