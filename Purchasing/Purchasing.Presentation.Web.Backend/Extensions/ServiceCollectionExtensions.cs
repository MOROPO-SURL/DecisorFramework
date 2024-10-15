using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Purchasing.Presentation.Web.Backend.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddDecisorPurchasingPresentationWebBackend(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.PurchasingDataInitializationHelper>();
        }
    }
}

