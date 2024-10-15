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
                    new Configurators.BudgetProductBridgeEntityTypeConfigurator(),
                    new Configurators.BudgetServiceBridgeEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => null;
    }
}

