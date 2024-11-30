using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Production.Presentation.Web.Backend.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorProductionPresentationWebBackend(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.ProductionDataInitializationHelper>();
        }
    }
}

