using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

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
                    new BaseEntityTypeConfigurator<Entities.CustomAttribute>(),
                    new BaseEntityTypeConfigurator<Entities.Product>(),
                    new BaseEntityTypeConfigurator<Entities.Classification>(),
                    new BaseEntityTypeConfigurator<Entities.Category>(),
                    new Configurators.ProductCustomAttributeBridgeEntityTypeConfigurator(),
                    new Configurators.ProductWarehousingDecreaseKindBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Warehouse>(),
                    new BaseEntityTypeConfigurator<Entities.Batch>(),
                    new BaseEntityTypeConfigurator<Entities.Contract.AbstractDeparture>(),
                    new Configurators.DepartureBatchBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Contract.AbstractReception>(),
                    new Configurators.ReceptionBatchBridgeEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_inventory";
    }
}

