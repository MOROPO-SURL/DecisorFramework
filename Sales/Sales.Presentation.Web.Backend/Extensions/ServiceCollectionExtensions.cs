using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Sales.Presentation.Web.Backend.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddDecisorSalesPresentationWebBackend(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.SalesDataInitializationHelper>();
        }
    }
}