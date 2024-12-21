using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Legal.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorLegalPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<Persistence.Entities.Tag, string>, Persistence.ORM.EF.Repositories.TagRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.Clause, System.Guid>, Persistence.ORM.EF.Repositories.ClauseRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.Section, System.Guid>, Persistence.ORM.EF.Repositories.SectionRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.Proforma, System.Guid>, Persistence.ORM.EF.Repositories.ProformaRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.CentralStateStructure, System.Guid>, Persistence.ORM.EF.Repositories.CentralStateSctructureRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.LegalDbSchemaConfigurationProvider>();
        }
    }
}

