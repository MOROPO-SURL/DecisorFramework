namespace MOROPO.Framework.Decisor.Governance.Persistence.ORM.EF.Providers
{
    public class GovernanceDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.DecisionMakingGroup>(),
                    new Configurators.DecisionMakingGroupEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.DecisionMakingGroupContactBridgeEntityTypeConfigurator(),
                    new Configurators.MeetingEntityTypeConfigurator(),
                    new Configurators.MeetingEmployeeBridgeEntityTypeConfigurator(),
                    new Configurators.MeetingContactBridgeEntityTypeConfigurator(),
                    new Configurators.MeetingDocumentBridgeEntityTypeConfigurator(),
                    new Configurators.AgreementEntityTypeConfigurator(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.Statement>()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_governance";
    }
}
