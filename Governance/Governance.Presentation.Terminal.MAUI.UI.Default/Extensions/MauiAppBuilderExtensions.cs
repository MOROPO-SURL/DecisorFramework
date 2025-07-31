using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.Governance.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;
using MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Pages.Detail;

namespace MOROPO.Framework.Decisor.Governance.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkGovernance(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<DecisionMakingGroupDisplayModel, DecisionMakingGroupDetailPage>, DecisionMakingGroupDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                /*.AddSingleton<IConfigurationContentPageFactoryFacade<SalaryStandardDisplayModel, SalaryStandardConfigurationPageModel, SalaryStandardConfigurationPage>, SalaryConfigurationPageFactory>()*/;

            return builder;
        }
    }
}
