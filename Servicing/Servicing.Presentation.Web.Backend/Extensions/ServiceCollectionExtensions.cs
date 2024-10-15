using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Servicing.Presentation.Web.Backend.Extensions
{
    public static class ServiceCollectionExtensions
	{
        public static void AddDecisorServicingPresentationWebBackend(this IServiceCollection services)
        {
            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.ServicingDataInitializationHelper>();
        }
    }
}

