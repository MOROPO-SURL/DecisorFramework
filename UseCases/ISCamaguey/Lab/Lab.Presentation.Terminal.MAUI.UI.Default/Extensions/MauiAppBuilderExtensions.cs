using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.ISCamaguey.Decisor.Lab.Interop.API.Common.Models.Display;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.ISCamaguey.Decisor.Lab.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorUseCaseLab(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<WorkingGroupDisplayModel>, WorkingGroupDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<ServiceOrderSampleDisplayModel>, ServiceOrderSampleDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<WorkingGroupDisplayModel, WorkingGroupConfigurationPageModel>, WorkingGroupConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<ServiceOrderSampleDisplayModel, ServiceOrderSampleConfigurationPageModel>, ServiceOrderSampleConfigurationPageFactory>();

            return builder;
        }
    }
}
