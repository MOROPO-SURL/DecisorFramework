using CommunityToolkit.Maui;
using Maui.FreakyControls.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Domain.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Domain.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.Financial.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Financial.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using MOROPO.Framework.Decisor.Legal.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Factories;
using MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Configuration;
using MOROPO.Framework.Decisor.Legal.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MOROPO.EPTCamaguey.Decisor.Terminal
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
           .InitializeFreakyControls()
           .Services
               .AddSingleton<Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade, Providers.HttpClientHelperProvider>()
               .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Providers.Facade.IRuntimeContextProviderFacade, Providers.SingleRuntimeContextProvider>()
               .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Helpers.Facade.IExceptionHandlingHelperFacade, Helpers.MainExceptionHandlingHelper>()
               .AddSingleton<Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.Facade.ISessionManagerFacade, Framework.Decisor.Core.Presentation.Terminal.MAUI.Managers.DefaultSessionManager>()
               // DetailPage factory registrations !!!
               .AddSingleton<IDetailContentPageFactoryFacade<SchoolingDisplayModel, SchoolingDetailPage>, SchoolingDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<SalaryStandardDisplayModel, SalaryStandardDetailPage>, SalaryStandardDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<PersonContactDisplayModel, PersonContactDetailPage>, PersonContactDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<OrganizationContactDisplayModel, OrganizationContactDetailPage>, OrganizationContactDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<NaturalBusinessKindDisplayModel, NaturalBusinessKindDetailPage>, NaturalBusinessKindDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<BankAgencyDisplayModel, BankAgencyDetailPage>, BankAgencyDetailPageFactory>()
               .AddSingleton<IDetailContentPageFactoryFacade<SectionDisplayModel, SectionDetailPage>, SectionDetailPageFactory>()
               // ConfigurationPage factory resgistration !!!
               .AddSingleton<IConfigurationContentPageFactoryFacade<SalaryStandardDisplayModel, SalaryStandardConfigurationPageModel, SalaryStandardConfigurationPage>, SalaryConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<PersonContactDisplayModel, PersonContactConfigurationPageModel, PersonContactConfigurationPage>, PersonContactConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<OrganizationContactDisplayModel, OrganizationContactConfigurationPageModel, OrganizationContactConfigurationPage>, OrganizationContactConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<BankAgencyDisplayModel, BankAgencyConfigurationPageModel, BankAgencyConfigurationPage>, BankAgencyConfigurationPageFactory>()
               .AddSingleton<IConfigurationContentPageFactoryFacade<SectionDisplayModel, SectionConfigurationPageModel, SectionConfigurationPage>, SectionConfigurationPageFactory>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
