using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Helpers;

namespace MOROPO.Framework.Decisor.HumanResources.Presentation.Web.Backend.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorHumanResourcesPresentationWebBackend(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, HumanResourcesDataInitializationHelper>();
        }
    }
}

