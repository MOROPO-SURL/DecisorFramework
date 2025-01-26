using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.Framework.Decisor.Legal.Persistence.ORM.EF.Providers
{
    public class LegalDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new BaseEntityTypeConfigurator<Entities.Tag>(),
                    new BaseEntityTypeConfigurator<Entities.Clause>(),
                    new Configurators.ClauseTagBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Section>(),
                    new BaseEntityTypeConfigurator<Entities.Proforma>(),
                    new Configurators.ProformaSectionClauseBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ProclamationKind>(),
                    new BaseEntityTypeConfigurator<Entities.Proclamation>(),
                    new Configurators.CentralStateStructureEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.RegulationKind>(),
                    new BaseEntityTypeConfigurator<Entities.Regulation>(),
                    new BaseEntityTypeConfigurator<Entities.Disposition>(),
                    new Configurators.DispositionTagBridgeEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_legal";
    }
}
