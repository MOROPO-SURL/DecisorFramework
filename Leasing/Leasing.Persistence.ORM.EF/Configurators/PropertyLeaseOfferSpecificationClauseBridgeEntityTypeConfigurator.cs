using MOROPO.Framework.Decisor.Leasing.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Leasing.Persistence.ORM.EF.Configurators;

public class PropertyLeaseOfferSpecificationClauseBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<PropertyLeaseOfferSpaceSpecificationClauseBridge, PropertyLeaseOfferSpaceSpecification, System.Guid, Legal.Persistence.Entities.Clause, System.Guid>
{
    public PropertyLeaseOfferSpecificationClauseBridgeEntityTypeConfigurator()
    {
        prowNavigationExpression = entity => entity.ClauseBridges;
    }
}
