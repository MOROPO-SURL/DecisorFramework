using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Models.View;
using System.Collections.Generic;

namespace MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySection = new List<ManagementDashboardSectionViewModel>();
            var locationSection = new List<ManagementDashboardSectionViewModel>();
            var domainSection = new List<ManagementDashboardSectionViewModel>();
            var humanResourcesSection = new List<ManagementDashboardSectionViewModel>();

            #region Security
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
                Role = Framework.Decisor.Core.Presentation.Web.Backend.Constants.Security.Authorization.TraceViewerPermission
            });
            #endregion

            #region Location
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Países",
                Controller = "countries",
                Action = "index",
                Area = "location",
                Role = Framework.Guama.Location.Presentation.Constants.Permissions.CountryViewer
            });
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Regiones",
                Controller = "regions",
                Action = "index",
                Area = "location",
                Role = Framework.Guama.Location.Presentation.Constants.Permissions.RegionViewer
            });
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Provincias",
                Controller = "states",
                Action = "index",
                Area = "location",
                Role = Framework.Guama.Location.Presentation.Constants.Permissions.StateViewer
            });
            locationSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Municipios",
                Controller = "municipalities",
                Action = "index",
                Area = "location",
                Role = Framework.Guama.Location.Presentation.Constants.Permissions.MunicipalityViewer
            });
            #endregion

            #region Domain
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Ent. Admin.",
                Controller = "administrativeentitykinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                //Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Pers. Jurídica",
                Controller = "legalbusinesskinds",
                Action = "Index",
                Area = "domain",
                Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.LegalBusinessKindViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Pers. Natural",
                Controller = "naturalbusinesskinds",
                Action = "Index",
                Area = "domain",
                Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.NaturalBusinessKindViewerPermission
            });
            #endregion

            #region HH.RR.
            humanResourcesSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Plaza",
                Controller = "workpositionkinds",
                Action = "Index",
                Area = "HHRR",
                Role = Framework.Decisor.HumanResources.Interop.API.Common.Constants.Security.Authorization.WorkPositionKindViewerPermission
            });
            #endregion

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySection },
                { "Locación", locationSection },
                { "Dominio", domainSection },
                { "Recursos Humanos", humanResourcesSection }
            };
        }
    }
}
