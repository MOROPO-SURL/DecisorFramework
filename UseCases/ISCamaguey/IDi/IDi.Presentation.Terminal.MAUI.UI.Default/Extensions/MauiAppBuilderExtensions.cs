using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Extensions;

public static class MauiAppBuilderExtensions
{
    public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorUseCaseIDi(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
    {
        builder.Services
            // DetailPage factory resgistration !!!
            .AddSingleton<IDetailContentPageFactoryFacade<ProgramDisplayModel>, ProgramDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ResearcherCategoryDisplayModel>, ResearcherCategoryDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<TeachingCategoryDisplayModel>, TeachingCategoryDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ParticipatingOrganizationDisplayModel>, ParticipatingOrganizationDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<FinancierDisplayModel>, FinancierDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ExternalResearcherDisplayModel>, ExternalResearcherDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<InternalResearcherDisplayModel>, InternalResearcherDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<CallForProposalDisplayModel>, CallForProposalDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ProjectDisplayModel>, ProjectDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ProjectProposalDisplayModel>, ProjectProposalDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ProjectCategoryDisplayModel>, ProjectCategoryDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ProgramKindDisplayModel>, ProgramKindDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<PublicationResultDisplayModel>, PublicationResultDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ThesisResultDisplayModel>, ThesisResultDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<AwardKindDisplayModel>, AwardKindDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<AwardResultDisplayModel>, AwardResultDetailPageFactory>()

            // ConfigurationPage factory resgistration !!!
            .AddSingleton<IConfigurationContentPageFactoryFacade<ProgramDisplayModel, ProgramConfigurationPageModel>, ProgramConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<ParticipatingOrganizationDisplayModel, ParticipatingOrganizationConfigurationPageModel>, ParticipatingOrganizationConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<FinancierDisplayModel, FinancierConfigurationPageModel>, FinancierConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<ExternalResearcherDisplayModel, ExternalResearcherConfigurationPageModel>, ExternalResearcherConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<InternalResearcherDisplayModel, InternalResearcherConfigurationPageModel>, InternalResearcherConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<CallForProposalDisplayModel, CallForProposalConfigurationPageModel>, CallForProposalConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<ProjectDisplayModel, ProjectConfigurationPageModel>, ProjectConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<ProjectProposalDisplayModel, ProjectProposalConfigurationPageModel>, ProjectProposalConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<PublicationResultDisplayModel, PublicationResultConfigurationPageModel>, PublicationResultConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<ThesisResultDisplayModel, ThesisResultConfigurationPageModel>, ThesisResultConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<AwardKindDisplayModel, AwardKindConfigurationPageModel>, AwardKindConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<AwardResultDisplayModel, AwardResultConfigurationPageModel>, AwardResultConfigurationPageFactory>();

        return builder;
    }
}
