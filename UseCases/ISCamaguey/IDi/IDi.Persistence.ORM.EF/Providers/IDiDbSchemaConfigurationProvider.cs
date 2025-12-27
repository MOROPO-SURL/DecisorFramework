using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Providers
{
    public class IDiDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return
                [
                    new Configurators.ResearcherEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.AwardKind>(),
                    new BaseEntityTypeConfigurator<Entities.AwardResult>(),
                    new BaseEntityTypeConfigurator<Entities.Extension>(),
                    new BaseEntityTypeConfigurator<Entities.ExternalResearcher>(),
                    new BaseEntityTypeConfigurator<Entities.Financier>(),
                    new Configurators.FinancierResearchAreaBridgeEntityTypeConfigurator(),
                    new Configurators.FinancierDocumentBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.InternalResearcher>(),
                    new BaseEntityTypeConfigurator<Entities.NewTechniqueResult>(),
                    new BaseEntityTypeConfigurator<Entities.OppositionReport>(),
                    new BaseEntityTypeConfigurator<Entities.ParticipatingOrganization>(),
                    new Configurators.ParticipatingOrganizationResearchAreaBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Program>(),
                    new Configurators.ProgramExpectResultEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.Project>(),
                    new BaseEntityTypeConfigurator<Entities.ProjectBudgetFunancing>(),
                    new Configurators.ProjectBugetCurrencyBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ProjectCategory>(),
                    new Configurators.ProjectParticipatingOrganizationBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ProjectProposal>(),
                    new BaseEntityTypeConfigurator<Entities.ProjectReport>(),
                    new Configurators.ProjectResearcherBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ProjectSpecificObjective>(),
                    new BaseEntityTypeConfigurator<Entities.PublicationResult>(),
                    new Configurators.PublicationResultResearcherBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ResearchArea>(),
                    new BaseEntityTypeConfigurator<Entities.ResearcherCategory>(),
                    new Configurators.ResearcherResearchAreaDoctorateBridgeEntityTypeConfigurator(),
                    new Configurators.ResearcherResearchAreaMasteryBridgeEntityTypeConfigurator(),
                    new Configurators.ResearcherResearchAreaSpecializationBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.ScientificTechnicalResult>(),
                    new BaseEntityTypeConfigurator<Entities.ScientificTechnicalResultIntroduction>(),
                    new BaseEntityTypeConfigurator<Entities.ScientificTechnicalResultKind>(),
                    new BaseEntityTypeConfigurator<Entities.TeachingCategory>(),
                    new BaseEntityTypeConfigurator<Entities.ThesisResult>(),
                    new Configurators.ThesisResultResearcherBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.TrainingResult>(),
                    new Configurators.TrainingResultResearcherBridgeEntityTypeConfigurator(),
                    new BaseEntityTypeConfigurator<Entities.CallForProposal>(),
                    new Configurators.CallForProposalResearchAreaBridgeEntityTypeConfigurator(),
                    new Configurators.CallForProposalDocumentBridgeEntityTypeConfigurator()
                ];
            }
        }

        public string DefaultPersistenceSchema => "decisoriscamaguey_idi";
    }
}
