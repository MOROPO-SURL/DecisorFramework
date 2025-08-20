namespace MOROPO.Framework.Decisor.HumanResources.Persistence.ORM.EF.Providers
{
    public class HumanResourcesDbSchemaConfigurationProvider : Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator>
                {
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.Schooling>(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.WorkPositionKind>(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.WorkPosition>(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.WorkPositionResponsability>(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.SalaryStandard>(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.Workforce>(),
                    new Configurators.WorkforceOrganizationalUnityBridgeEntityTypeConfigurator(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.Vacant>(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.VacantPostulation>(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.VacantPostulationOcupation>(),
                    new Configurators.VacantPostulationDocumentBridgeEntityTypeConfigurator(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.OcupationCandidate>(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.AdmitionPropousal>(),
                    new Configurators.EmploymentContractEntityTypeConfigurator(),
                    new Core.Persistence.ORM.EF.Configurators.Base.BaseEntityTypeConfigurator<Entities.NamingResolution>(),
                    new Configurators.StaffEntityTypeConfigurator(),
                    new Configurators.StaffWorkforceBridgeEntityTypeConfigurator(),
                    new Configurators.OcupationEntityTypeConfigurator()
                };
            }
        }

        public string DefaultPersistenceSchema => "decisorframework_humanresources";
    }
}
