using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Core.Presentation.Web.Backend.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddDecisorCorePresentationWebBackend(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.CoreDataInitializationHelper>();
        }
    }
}

