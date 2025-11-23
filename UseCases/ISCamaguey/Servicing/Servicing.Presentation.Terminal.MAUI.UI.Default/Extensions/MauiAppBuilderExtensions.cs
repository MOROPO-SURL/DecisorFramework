using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.ISCamaguey.Decisor.Servicing.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.ISCamaguey.Decisor.Servicing.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorUseCaseServicing(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<TrainingServiceDisplayModel>, TrainingServiceDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<SampleAnalysisServiceDisplayModel>, SampleAnalysisServiceDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<GroundIntegralStudyServiceDisplayModel>, GroundIntegralStudyServiceDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalClientServicingContractDisplayModel>, LegalClientServicingContractDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<TrainingServiceDisplayModel, TrainingServiceConfigurationPageModel>, TrainingServiceConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<SampleAnalysisServiceDisplayModel, SampleAnalysisServiceConfigurationPageModel>, SampleAnalysisServiceConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<GroundIntegralStudyServiceDisplayModel, GroundIntegralStudyServiceConfigurationPageModel>, GroundIntegralStudyServiceConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalClientServicingContractDisplayModel, LegalClientServicingContractConfigurationPageModel>, LegalClientServicingContractConfigurationPageFactory>();

            return builder;
        }
    }
}
