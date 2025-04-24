using CommunityToolkit.Maui;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.GovCamaguey.Decisor.Prototype.Interop.API.Common.Models.Display;
using MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Configuration;
using MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Factories.Detail;
using MOROPO.GovCamaguey.Decisor.Prototype.Terminal.Models.Page.Configuration;
using MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Configuration;
using MOROPO.GovCamaguey.Decisor.Prototype.Terminal.UI.Pages.Detail;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MOROPO.GovCamaguey.Decisor.Prototype.Terminal
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
               .UseMauiCommunityToolkit()
               .UseMauiCommunityToolkitMediaElement()
               .UseSkiaSharp()
               .ConfigureFonts(fonts =>
               {
                   fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                   fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                   fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesignIcons");
               })
               .Services
                   .AddSingleton<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade, Providers.HttpClientHelperProvider>()
                   .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IRuntimeContextProviderFacade, Providers.SingleRuntimeContextProvider>()
                   .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade, Helpers.MainExceptionHandlingHelper>()
                   .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade, Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.DefaultSessionManager>()
                   .AddSingleton<IDetailContentPageFactoryFacade<UnitMeasurementDisplayModel, UnitMeasurementDetailPage>, UnitMeasurementDetailPageFactory>()
                   .AddSingleton<IDetailContentPageFactoryFacade<PersonDisplayModel, PersonDetailPage>, PersonDetailPageFactory>()
                   .AddSingleton<IDetailContentPageFactoryFacade<OrganizationDisplayModel, OrganizationDetailPage>, OrganizationDetailPageFactory>()
                   .AddSingleton<IConfigurationContentPageFactoryFacade<UnitMeasurementDisplayModel, UnitMeasurementConfigurationPageModel, UnitMeasurementConfigurationPage>, UnitMeasurementConfigurationPageFactory>()
                   .AddSingleton<IConfigurationContentPageFactoryFacade<PersonDisplayModel, PersonConfigurationPageModel, PersonConfigurationPage>, PersonConfigurationPageFactory>()
                   .AddSingleton<IConfigurationContentPageFactoryFacade<OrganizationDisplayModel, OrganizationConfigurationPageModel, OrganizationConfigurationPage>, OrganizationConfigurationPageFactory>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
