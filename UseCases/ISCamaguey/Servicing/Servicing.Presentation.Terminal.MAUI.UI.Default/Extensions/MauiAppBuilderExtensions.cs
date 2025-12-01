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
                .AddSingleton<IDetailContentPageFactoryFacade<NaturalClientServicingContractDisplayModel>, NaturalClientServicingContractDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalClientSampleAnalysisServiceOrderDisplayModel>, LegalClientSampleAnalysisServiceOrderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<NaturalClientSampleAnalysisServiceOrderDisplayModel>, NaturalClientSampleAnalysisServiceOrderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalClientTrainingServiceOrderDisplayModel>, LegalClientTrainingServiceOrderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<NaturalClientTrainingServiceOrderDisplayModel>, NaturalClientTrainingServiceOrderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<LegalClientGroundIntegralStudyServiceOrderDisplayModel>, LegalClientGroundIntegralStudyServiceOrderDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<NaturalClientGroundIntegralStudyServiceOrderDisplayModel>, NaturalClientGroundIntegralStudyServiceOrderDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<TrainingServiceDisplayModel, TrainingServiceConfigurationPageModel>, TrainingServiceConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<SampleAnalysisServiceDisplayModel, SampleAnalysisServiceConfigurationPageModel>, SampleAnalysisServiceConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<GroundIntegralStudyServiceDisplayModel, GroundIntegralStudyServiceConfigurationPageModel>, GroundIntegralStudyServiceConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalClientServicingContractDisplayModel, LegalClientServicingContractConfigurationPageModel>, LegalClientServicingContractConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<NaturalClientServicingContractDisplayModel, NaturalClientServicingContractConfigurationPageModel>, NaturalClientServicingContractConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalClientSampleAnalysisServiceOrderDisplayModel, LegalClientSampleAnalysisServiceOrderConfigurationPageModel>, LegalClientSampleAnalysisServiceOrderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<NaturalClientSampleAnalysisServiceOrderDisplayModel, NaturalClientSampleAnalysisServiceOrderConfigurationPageModel>, NaturalClientSampleAnalysisServiceOrderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalClientTrainingServiceOrderDisplayModel, LegalClientTrainingServiceOrderConfigurationPageModel>, LegalClientTrainingServiceOrderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<NaturalClientTrainingServiceOrderDisplayModel, NaturalClientTrainingServiceOrderConfigurationPageModel>, NaturalClientTrainingServiceOrderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<LegalClientGroundIntegralStudyServiceOrderDisplayModel, LegalClientGroundIntegralStudyServiceOrderConfigurationPageModel>, LegalClientGroundIntegralStudyServiceOrderConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<NaturalClientGroundIntegralStudyServiceOrderDisplayModel, NaturalClientGroundIntegralStudyServiceOrderConfigurationPageModel>, NaturalClientGroundIntegralStudyServiceOrderConfigurationPageFactory>();

            return builder;
        }
    }
}
