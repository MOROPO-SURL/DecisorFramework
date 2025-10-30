using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Providers
{
	public class SalesDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return
                [
                    new BaseEntityTypeConfigurator<Entities.Contract.AbstractSale>(),
                    new Configurators.LegalClientWholesaleSaleEntityTypeConfigurator(),
                    new Configurators.NaturalClientWholesaleSaleEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.RetailSale>(),
                    new Configurators.LegalClientBudgetEntityTypeConfigurator(),
                    new Configurators.LegalClientBudgetProductBridgeEntityTypeConfigurator(),
                    new Configurators.LegalClientBudgetServiceBridgeEntityTypeConfigurator(),
                    new Configurators.NaturalClientBudgetEntityTypeConfigurator(),
                    new Configurators.NaturalClientBudgetProductBridgeEntityTypeConfigurator(),
                    new Configurators.NaturalClientBudgetServiceBridgeEntityTypeConfigurator()
                ];
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_sales";
    }
}

