using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.ISCamaguey.Decisor.IDi.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.ISCamaguey.Decisor.IDi.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorUseCaseIDi(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<ResearchAreaDisplayModel>, ResearchAreaDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ProgramDisplayModel>, ProgramDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ResearcherCategoryDisplayModel>, ResearcherCategoryDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<TeachingCategoryDisplayModel>, TeachingCategoryDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ParticipatingOrganizationDisplayModel>, ParticipatingOrganizationDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<FinancierDisplayModel>, FinancierDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ExternalResearcherDisplayModel>, ExternalResearcherDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<InternalResearcherDisplayModel>, InternalResearcherDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<CallForProposalDisplayModel>, CallForProposalDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ProjectProposalDisplayModel>, ProjectProposalDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<ResearchAreaDisplayModel, ResearchAreaConfigurationPageModel>, ResearchAreaConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ProgramDisplayModel, ProgramConfigurationPageModel>, ProgramConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ParticipatingOrganizationDisplayModel, ParticipatingOrganizationConfigurationPageModel>, ParticipatingOrganizationConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<FinancierDisplayModel, FinancierConfigurationPageModel>, FinancierConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ExternalResearcherDisplayModel, ExternalResearcherConfigurationPageModel>, ExternalResearcherConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<InternalResearcherDisplayModel, InternalResearcherConfigurationPageModel>, InternalResearcherConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<CallForProposalDisplayModel, CallForProposalConfigurationPageModel>, CallForProposalConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ProjectProposalDisplayModel, ProjectProposalConfigurationPageModel>, ProjectProposalConfigurationPageFactory>();

            return builder;
        }
    }
}
