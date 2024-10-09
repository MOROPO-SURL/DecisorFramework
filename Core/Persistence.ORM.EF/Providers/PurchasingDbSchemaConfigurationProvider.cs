namespace MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Providers
{
	public class PurchasingDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator[]
                {
                    new Configurators.LegalProviderEntityTypeConfigurator(),
                    new Configurators.NaturalProviderEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => null;
    }
}

