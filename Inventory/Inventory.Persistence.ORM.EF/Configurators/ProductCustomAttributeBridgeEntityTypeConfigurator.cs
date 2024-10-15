namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Configurators
{
	public class ProductCustomAttributeBridgeEntityTypeConfigurator : Guama.Core.Persistence.ORM.EF.Configurators.Contract.AbstractBridgeEntityTypeConfigurator<Entities.ProductCustomAttributeBridge, Entities.Product, System.Guid, Entities.CustomAttribute, System.Guid>
	{
		public ProductCustomAttributeBridgeEntityTypeConfigurator()
		{
			prowNavigationExpression = entity => entity.CustomAttributeBridges;
		}
	}
}