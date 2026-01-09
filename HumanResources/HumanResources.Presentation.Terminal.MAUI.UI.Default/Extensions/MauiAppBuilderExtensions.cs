using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Core.Presentation.Terminal.MAUI.UI.Factories.Facade;
using MOROPO.Framework.Decisor.HumanResources.Interop.API.Common.Models.Display;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.Models.Page.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Configuration;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Factories.Detail;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Terminal.MAUI.UI.Default.Extensions
{
    public static class MauiAppBuilderExtensions
    {
        public static Microsoft.Maui.Hosting.MauiAppBuilder UseDecisorFrameworkHumanResources(this Microsoft.Maui.Hosting.MauiAppBuilder builder)
        {
            builder.Services
                // DetailPage factory resgistration !!!
                .AddSingleton<IDetailContentPageFactoryFacade<SchoolingDisplayModel>, SchoolingDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<SalaryStandardDisplayModel>, SalaryStandardDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<WorkPositionDisplayModel>, WorkPositionDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<VacantPostulationDisplayModel>, VacantPostulationDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<OcupationCandidateDisplayModel>, OcupationCandidateDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<AdmitionPropousalDisplayModel>, AdmitionPropousalDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<NamingResolutionDisplayModel>, NamingResolutionDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<StaffDisplayModel>, StaffDetailPageFactory>()
                .AddSingleton<IDetailContentPageFactoryFacade<Models.Page.Detail.EmployeeDetailPageModel>, EmployeeDetailPageFactory>()

                // ConfigurationPage factory resgistration !!!
                .AddSingleton<IConfigurationContentPageFactoryFacade<SalaryStandardDisplayModel, SalaryStandardConfigurationPageModel>, SalaryConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<WorkPositionDisplayModel, WorkPositionConfigurationPageModel>, WorkPositionConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<Models.View.WorkforceConfigurationVacantViewModel, VacantConfigurationPageModel>, VacantConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<VacantPostulationDisplayModel, VacantPostulationConfigurationPageModel>, VacantPostulationConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<OcupationCandidateDisplayModel, OcupationCandidateConfigurationPageModel>, OcupationCandidateConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<AdmitionPropousalDisplayModel, AdmitionPropousalConfigurationPageModel>, AdmitionPropousalConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<NamingResolutionDisplayModel, NamingResolutionConfigurationPageModel>, NamingResolutionConfigurationPageFactory>()
                .AddSingleton<IConfigurationContentPageFactoryFacade<StaffDisplayModel, StaffConfigurationPageModel>, StaffConfigurationPageFactory>();

            return builder;
        }
    }
}
