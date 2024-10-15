namespace MOROPO.Framework.Decisor.Inventory.Persistence.ORM.EF.Providers
{
	public class InventoryDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new Configurators.ProductCustomAttributeBridgeEntityTypeConfigurator(),
                    new Configurators.ProductWarehousingDecreaseKindBridgeEntityTypeConfigurator(),
                    new Configurators.DepartureBatchBridgeEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => null;
    }
}

