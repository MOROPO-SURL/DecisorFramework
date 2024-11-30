namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ProductionColaboratorBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProductionColaboratorBridge, Entities.Production, System.Guid, Essential.Persistence.Entities.Colaborator, System.Guid>
    {
        public ProductionColaboratorBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.ColaboratorBridges;
        }
    }
}
