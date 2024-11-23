using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Models.View;
using System.Collections.Generic;

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySection = new List<ManagementDashboardSectionViewModel>();
            var locationSection = new List<ManagementDashboardSectionViewModel>();
            var purchaseSection = new List<ManagementDashboardSectionViewModel>();
            var humanResourcesSection = new List<ManagementDashboardSectionViewModel>();
            var saleSection = new List<ManagementDashboardSectionViewModel>();
            var globalsSection = new List<ManagementDashboardSectionViewModel>();

            foreach (var provider in self)
            {
                if (provider is Framework.Guama.Security.Personal.Presentation.Web.Backend.Providers.ManagementDashboardSectionProvider)
                {
                    securitySection.AddRange(provider.GetManagementDashboardSections());
                }
            }

            securitySection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Registros",
                Controller = "traces",
                Action = "index",
                Area = "security",
                Role = Core.Presentation.Web.Backend.Constants.Security.Authorization.TraceViewerPermission
            });

            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Países",
                Controller = "countries",
                Action = "index",
                Area = "location",
                Role = Guama.Location.Presentation.Constants.Permissions.CountryViewer
            });
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Regiones",
                Controller = "regions",
                Action = "index",
                Area = "location",
                Role = Guama.Location.Presentation.Constants.Permissions.RegionViewer
            });
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Provincias",
                Controller = "states",
                Action = "index",
                Area = "location",
                Role = Guama.Location.Presentation.Constants.Permissions.StateViewer
            });
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Municipios",
                Controller = "municipalities",
                Action = "index",
                Area = "location",
                Role = Guama.Location.Presentation.Constants.Permissions.MunicipalityViewer
            });

            humanResourcesSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Empleados",
                Controller = "employees",
                Action = "Index",
                Area = "HHRR",
                Role = HumanResources.Presentation.Web.Backend.Constants.Security.Authorization.EmployeeViewerPermission
            });

            purchaseSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Proveedores Jurídicos",
                Controller = "legalproviders",
                Action = "Index",
                Area = "purchasing",
                Role = Purchasing.Presentation.Web.Backend.Constants.Security.Authorization.LegalProviderViewerPermission
            });
            purchaseSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Proveedores Naturales",
                Controller = "naturalproviders",
                Action = "Index",
                Area = "purchasing",
                Role = Purchasing.Presentation.Web.Backend.Constants.Security.Authorization.NaturalProviderViewerPermission
            });

            saleSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Clientes Jurídicos",
                Controller = "legalclients",
                Action = "Index",
                Area = "sales",
                Role = Sales.Presentation.Web.Backend.Constants.Security.Authorization.LegalClientViewerPermission
            });
            saleSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Clientes Naturales",
                Controller = "naturalclients",
                Action = "Index",
                Area = "sales",
                Role = Sales.Presentation.Web.Backend.Constants.Security.Authorization.NaturalClientViewerPermission
            });

            globalsSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Pers. Jurídica",
                Controller = "legalbusinesskinds",
                Action = "Index",
                Area = "globals",
                Role = Core.Presentation.Web.Backend.Constants.Security.Authorization.LegalBusinessKindViewerPermission
            });
            globalsSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Pers. Natural",
                Controller = "naturalbusinesskinds",
                Action = "Index",
                Area = "globals",
                Role = Core.Presentation.Web.Backend.Constants.Security.Authorization.NaturalBusinessKindViewerPermission
            });

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySection },
                { "Locación", locationSection },
                { "Recursos Humanos", humanResourcesSection },
                { "Compras", purchaseSection },
                { "Ventas", saleSection },
                { "Generales", globalsSection }
            };
        }
    }
}
