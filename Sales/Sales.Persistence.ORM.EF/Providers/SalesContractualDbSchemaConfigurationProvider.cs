namespace MOROPO.Framework.Decisor.Sales.Persistence.ORM.EF.Providers
{
	public class SalesContractualDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator[]
                {
                    new Configurators.LegalClientSaleContractEntityTypeConfigurator(),
                    new Configurators.NaturalClientSaleContractEntityTypeConfigurator(),
                    new Configurators.LegalClientWholesaleSaleEntityTypeConfigurator(),
                    new Configurators.NaturalClientWholesaleSaleEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => null;
    }
}

