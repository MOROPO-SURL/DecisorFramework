namespace MOROPO.Framework.Decisor.Servicing.Persistence.ORM.EF.Providers
{
    public class ServicingDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.Service>()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_servicing";
    }
}

