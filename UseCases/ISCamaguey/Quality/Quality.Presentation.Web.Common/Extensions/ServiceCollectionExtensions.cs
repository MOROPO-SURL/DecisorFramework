using Microsoft.Extensions.DependencyInjection;
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.Entities;
using MOROPO.ISCamaguey.Decisor.Quality.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.ISCamaguey.Decisor.Quality.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddISCamagueyDecisorQualityPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<CubanStandard, System.Guid>, CubanStandardRepository>();
            services.AddScoped<IEntityRepository<IsoStandard, System.Guid>, IsoStandardRepository>();
            services.AddScoped<IEntityRepository<Certification, System.Guid>, CertificationRepository>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.QualityDbSchemaConfigurationProvider>();
        }
    }
}