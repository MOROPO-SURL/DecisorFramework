namespace MOROPO.Framework.Decisor.Essential.Persistence.ORM.EF.Providers
{
    public class EssentialDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new Configurators.ColaboratorEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_essential";
    }
}

