namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Configurators
{
    public class PurchaseEmployeeBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.PurchaseEmployeeBridge, Entities.Purchase, System.Guid, Essential.Persistence.Entities.Employee, System.Guid>
    {
        public PurchaseEmployeeBridgeEntityTypeConfigurator()
        {
            prowNavigationExpression = entity => entity.EmployeeBridges;
        }
    }
}
