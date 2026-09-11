using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Extensions;

public static class MauiAppBuilderExtensions
{
    public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorUseCaseLab(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
    {
        builder.Services
            // DetailPage factory resgistration !!!
            .AddSingleton<IDetailContentPageFactoryFacade<WorkingGroupDisplayModel>, WorkingGroupDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ServiceOrderSampleDisplayModel>, ServiceOrderSampleDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ResearchSampleDisplayModel>, ResearchSampleDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<ProductionSampleDisplayModel>, ProductionSampleDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<WorkPlanDisplayModel>, WorkPlanDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<AnalysisDisplayModel>, AnalysisDetailPageFactory>()
            .AddSingleton<IDetailContentPageFactoryFacade<AssessmentDisplayModel>, AssessmentDetailPageFactory>()

            // ConfigurationPage factory resgistration !!!
            .AddSingleton<IConfigurationContentPageFactoryFacade<WorkingGroupDisplayModel, WorkingGroupConfigurationPageModel>, WorkingGroupConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<ServiceOrderSampleDisplayModel, ServiceOrderSampleConfigurationPageModel>, ServiceOrderSampleConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<ResearchSampleDisplayModel, ResearchSampleConfigurationPageModel>, ResearchSampleConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<ProductionSampleDisplayModel, ProductionSampleConfigurationPageModel>, ProductionSampleConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<WorkPlanDisplayModel, WorkPlanConfigurationPageModel>, WorkPlanConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<AnalysisDisplayModel, AnalysisConfigurationPageModel>, AnalysisConfigurationPageFactory>()
            .AddSingleton<IConfigurationContentPageFactoryFacade<AssessmentDisplayModel, AssessmentConfigurationPageModel>, AssessmentConfigurationPageFactory>();

        return builder;
    }
}
