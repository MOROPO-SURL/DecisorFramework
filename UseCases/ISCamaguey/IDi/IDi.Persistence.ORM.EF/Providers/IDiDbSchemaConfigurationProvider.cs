using MOROPO.Framework.Decisor.Core.Persistence.ORM.EF.Configurators.Base;

namespace MOROPO.ISCamaguey.Decisor.IDi.Persistence.ORM.EF.Providers;

public class IDiDbSchemaConfigurationProvider : Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
{
    public System.Collections.Generic.ICollection<Framework.Guama.Core.Persistence.ORM.EF.Configurators.Contract.IEntityTypeConfigurator> EntityTypeConfigurators
    {
        get
        {
            return
            [
                new BaseEntityTypeConfigurator<Entities.AwardKind>(),
                new BaseEntityTypeConfigurator<Entities.AwardResult>(),
                new BaseEntityTypeConfigurator<Entities.Extension>(),
                new BaseEntityTypeConfigurator<Entities.ExternalResearcher>(),
                new BaseEntityTypeConfigurator<Entities.Financier>(),
                new Configurators.FinancierKnowledgeAreaBridgeEntityTypeConfigurator(),
                new Configurators.FinancierDocumentBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.InternalResearcher>(),
                new BaseEntityTypeConfigurator<Entities.NewTechniqueResult>(),
                new BaseEntityTypeConfigurator<Entities.OppositionReport>(),
                new BaseEntityTypeConfigurator<Entities.ParticipatingOrganization>(),
                new Configurators.ParticipatingOrganizationKnowledgeAreaBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.Program>(),
                new BaseEntityTypeConfigurator<Entities.ProgramKind>(),
                new Configurators.ProgramExpectResultEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.ImpactDimension>(),
                new BaseEntityTypeConfigurator<Entities.Project>(),
                new BaseEntityTypeConfigurator<Entities.ProjectImpact>(),
                new Configurators.ProjectProgramExpectResultBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.ProjectBudgetFunancing>(),
                new BaseEntityTypeConfigurator<Entities.ProjectCategory>(),
                new Configurators.ProjectParticipatingOrganizationBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.ProjectProposal>(),
                new BaseEntityTypeConfigurator<Entities.ProjectReport>(),
                new BaseEntityTypeConfigurator<Entities.InternalResearcherProjectParticipation>(),
                new BaseEntityTypeConfigurator<Entities.ExternalResearcherProjectParticipation>(),
                new BaseEntityTypeConfigurator<Entities.ProjectSpecificObjective>(),
                new BaseEntityTypeConfigurator<Entities.PublicationResult>(),
                new Configurators.PublicationResultInternalResearcherBridgeEntityTypeConfigurator(),
                new Configurators.PublicationResultExternalResearcherBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.ResearcherCategory>(),
                new BaseEntityTypeConfigurator<Entities.ScientificTechnicalResult>(),
                new BaseEntityTypeConfigurator<Entities.ScientificTechnicalResultIntroduction>(),
                new BaseEntityTypeConfigurator<Entities.ScientificTechnicalResultKind>(),
                new BaseEntityTypeConfigurator<Entities.TeachingCategory>(),
                new BaseEntityTypeConfigurator<Entities.ThesisResult>(),
                new Configurators.ThesisResultInternalResearcherBridgeEntityTypeConfigurator(),
                new Configurators.ThesisResultExternalResearcherBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.TrainingResult>(),
                new Configurators.TrainingResultInternalResearcherBridgeEntityTypeConfigurator(),
                new Configurators.TrainingResultExternalResearcherBridgeEntityTypeConfigurator(),
                new BaseEntityTypeConfigurator<Entities.CallForProposal>(),
                new Configurators.CallForProposalKnowledgeAreaBridgeEntityTypeConfigurator(),
                new Configurators.CallForProposalDocumentBridgeEntityTypeConfigurator()
            ];
        }
    }

    public string DefaultPersistenceSchema => "decisoriscamaguey_idi";
}