using MOROPO.Framework.Decisor.Domain.Persistence.Entities;

namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ProductionColaboratorBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProductionColaboratorBridge, Entities.Production, System.Guid, Colaborator, System.Guid>
    {
        public ProductionColaboratorBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ColaboratorBridges;
        }
    }
}
