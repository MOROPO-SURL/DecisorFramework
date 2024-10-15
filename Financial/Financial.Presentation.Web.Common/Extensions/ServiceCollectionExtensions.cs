using Microsoft.Extensions.DependencyInjection;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Web.Common.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void AddDecisorFinancialPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<Guama.Core.Persistence.Repositories.IEntityRepository<Persistence.Entities.CostCenter, System.Guid>, Persistence.ORM.EF.Repositories.CostCenterRepository>();
        }
    }
}

