using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkHumanResources(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<SchoolingDisplayModel, SchoolingDetailPage>, SchoolingDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<SalaryStandardDisplayModel, SalaryStandardDetailPage>, SalaryStandardDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<WorkPositionDisplayModel, WorkPositionDetailPage>, WorkPositionDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VacantPostulationDisplayModel, VacantPostulationDetailPage>, VacantPostulationDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<OcupationCandidateDisplayModel, OcupationCandidateDetailPage>, OcupationCandidateDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<AdmitionPropousalDisplayModel, AdmitionPropousalDetailPage>, AdmitionPropousalDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<NamingResolutionDisplayModel, NamingResolutionDetailPage>, NamingResolutionDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<SalaryStandardDisplayModel, SalaryStandardConfigurationPageModel, SalaryStandardConfigurationPage>, SalaryConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<WorkPositionDisplayModel, WorkPositionConfigurationPageModel, WorkPositionConfigurationPage>, WorkPositionConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<WorkPositionDisplayModel, WorkPositionConfigurationPageModel, WorkPositionConfigurationPage>, WorkPositionConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<VacantPostulationDisplayModel, VacantPostulationConfigurationPageModel, VacantPostulationConfigurationPage>, VacantPostulationConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<OcupationCandidateDisplayModel, OcupationCandidateConfigurationPageModel, OcupationCandidateConfigurationPage>, OcupationCandidateConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<AdmitionPropousalDisplayModel, AdmitionPropousalConfigurationPageModel, AdmitionPropousalConfigurationPage>, AdmitionPropousalConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<NamingResolutionDisplayModel, NamingResolutionConfigurationPageModel, NamingResolutionConfigurationPage>, NamingResolutionConfigurationPageFactory>();

            return builder;
        }
    }
}
