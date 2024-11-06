using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Providers
{
	public class SalesDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator[]
                {
                    new Configurators.LegalClientEntityTypeConfigurator(),
                    new Configurators.NaturalClientEntityTypeConfigurator(),
                    new Configurators.BudgetEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientBudget>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientBudget>(),
                    new Configurators.BudgetProductBridgeEntityTypeConfigurator(),
                    new Configurators.BudgetServiceBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Contract.AbstractSale>(),
                    new BaseEntityTypeConfigurator<Entities.LegalClientWholesaleSale>(),
                    new BaseEntityTypeConfigurator<Entities.NaturalClientWholesaleSale>(),
                    new BaseEntityTypeConfigurator<Entities.RetailSale>()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_sales";
    }
}

