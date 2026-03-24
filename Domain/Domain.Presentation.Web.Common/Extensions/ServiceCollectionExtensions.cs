using Microsoft.Extensions.DependencyInjection;
using MOROPO.Framework.Decisor.Domain.Persistence.Entities;
using MOROPO.Framework.Decisor.Domain.Persistence.ORM.EF.Repositories;
using MOROPO.Framework.Guama.Core.Persistence.Repositories;

namespace MOROPO.Framework.Decisor.Domain.Presentation.Web.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddDecisorDomainPresentationWebCommon(this IServiceCollection services)
        {
            services.AddScoped<IEntityRepository<ChangeNotification, System.Guid>, ChangeNotificationRepository>();
            services.AddScoped<IBridgeRepository<ChangeNotificationUserBridge, ChangeNotification, System.Guid, Guama.Security.Personal.Persistence.Entities.User, string>, ChangeNotificationUserBridgeRepository>();
            services.AddScoped<IEntityRepository<CentralStateStructure, System.Guid>, CentralStateSctructureRepository>();
            services.AddScoped<IEntityRepository<Colaborator, System.Guid>, ColaboratorRepository>();
            services.AddScoped<IEntityRepository<PersonContact, System.Guid>, PersonContactRepository>();
            services.AddScoped<IEntityRepository<OrganizationContact, System.Guid>, OrganizationContactRepository>();
            services.AddScoped<IEntityRepository<LegalBusinessKind, System.Guid>, LegalBusinessKindRepository>();
            services.AddScoped<IEntityRepository<NaturalBusinessKind, System.Guid>, NaturalBusinessKindRepository>();
            services.AddScoped<IEntityRepository<PropertyKind, System.Guid>, PropertyKindRepository>();
            services.AddScoped<IEntityRepository<VehicleEngineKind, System.Guid>, VehicleEngineKindRepository>();
            services.AddScoped<IEntityRepository<AdministrativeEntityKind, System.Guid>, AdministrativeEntityKindRepository>();
            services.AddScoped<IEntityRepository<OrganizationalUnit, System.Guid>, OrganizationalUnitRepository>();
            services.AddScoped<IEntityRepository<AdministrativeEntity, System.Guid>, AdministrativeEntityRepository>();
            services.AddScoped<IEntityRepository<OrganizationalStructure, System.Guid>, OrganizationalStructureRepository>();
            services.AddScoped<IEntityRepository<OrganizationalStructuringUnit, System.Guid>, OrganizationalStructuringUnitRepository>();
            services.AddScoped<IEntityRepository<Property, System.Guid>, PropertyRepository>();
            services.AddScoped<IEntityRepository<PropertySpace, System.Guid>, PropertySpaceRepository>();
            services.AddScoped<IEntityRepository<Brand, System.Guid>, BrandRepository>();
            services.AddScoped<IEntityRepository<VehicleKind, System.Guid>, VehicleKindRepository>();
            services.AddScoped<IEntityRepository<Vehicle, System.Guid>, VehicleRepository>();
            services.AddScoped<IEntityRepository<Employee, System.Guid>, EmployeeRepository>();
            services.AddScoped<IEntityRepository<UnitMeasurement, System.Guid>, UnitMeasurementRepository>();
            services.AddScoped<IBridgeRepository<UnitMeasurementConversionBridge, UnitMeasurement, System.Guid, UnitMeasurement, System.Guid>, UnitMeasurementConversionBridgeRepository>();
            services.AddScoped<IEntityRepository<KnowledgeArea, System.Guid>, KnowledgeAreaRepository>();
            services.AddScoped<IEntityRepository<AcademicAchievement, System.Guid>, AcademicAchievementRepository>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.ORM.EF.Providers.DomainDbSchemaConfigurationProvider>();

            services.AddSingleton<Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.DomainDataInitializationHelper>();
        }
    }
}