namespace MOROPO.Framework.Decisor.Production.Persistence.ORM.EF.Configurators
{
    public class ProductionEmployeeBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProductionEmployeeBridge, Entities.Production, System.Guid, HumanResources.Persistence.Entities.Employee, System.Guid>
    {
        public ProductionEmployeeBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.EmployeeBridges;
        }
    }
}
