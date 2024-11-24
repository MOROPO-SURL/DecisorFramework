using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Financial.Presentation.Web.Common.Extensions
{
	public static class ServiceCollectionExtensions
	{
        public static void AddDecisorFinancialPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<Persistence.Entities.Currency, System.Guid>, Persistence.ORM.EF.Repositories.CurrencyRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.BankAgency, System.Guid>, Persistence.ORM.EF.Repositories.BankAgencyRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.BankBranch, System.Guid>, Persistence.ORM.EF.Repositories.BankBranchRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.BankAccount, System.Guid>, Persistence.ORM.EF.Repositories.BankAccountRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.BankDebitCard, string>, Persistence.ORM.EF.Repositories.BankDebitCardRepository>();
            services.AddScoped<IEntityRepository<Persistence.Entities.CostCenter, System.Guid>, Persistence.ORM.EF.Repositories.CostCenterRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.FinantialDbSchemaConfigurationProvider>();
        }
    }
}

