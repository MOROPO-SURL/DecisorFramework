namespace MOROPO.Framework.Decisor.Purchasing.Persistence.ORM.EF.Providers
{
	public class PurchasingContractualDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator[]
                {
                    new Configurators.LegalProviderPurchasingContractEntityTypeConfigurator(),
                    new Configurators.NaturalProviderPurchasingContractEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_purchasing";
    }
}

