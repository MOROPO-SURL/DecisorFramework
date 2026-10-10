using MOROPO.Framework.Guama.Core.Presentation.Web.Backend.Models.View;
using System.Collections.Generic;

namespace MOROPO.EPTCamaguey.Decisor.Web.BackOffice.Extensions
{
    public static class ManagementDashboardSectionProviderEnumerableExtensions
    {
        public static Dictionary<string, ICollection<ManagementDashboardSectionViewModel>> ToManagementDashboardSectionGroups(this IEnumerable<Framework.Guama.Core.Presentation.Web.Backend.Providers.Facade.IManagementDashboardSectionProviderFacade> self)
        {
            var securitySection = new List<ManagementDashboardSectionViewModel>();
            var locationSection = new List<ManagementDashboardSectionViewModel>();
            var legalSection = new List<ManagementDashboardSectionViewModel>();
            var domainSection = new List<ManagementDashboardSectionViewModel>();
            var financialSection = new List<ManagementDashboardSectionViewModel>();
            var humanResourcesSection = new List<ManagementDashboardSectionViewModel>();
            var commercialSection = new List<ManagementDashboardSectionViewModel>();
            var governanceSection = new List<ManagementDashboardSectionViewModel>();
            var leasingSection = new List<ManagementDashboardSectionViewModel>();

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
                Title = "Tipos de Estructura",
                Controller = "structurekinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                //Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Inmueble",
                Controller = "propertykinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                //Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Vehículo",
                Controller = "vehiclekinds",
                Action = "Index",
                Area = "domain",
                // TODO Set spected permission
                //Role = Framework.Decisor.Domain.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            domainSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Tipos de Motorización",
                Controller = "vehicleenginekinds",
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
            humanResourcesSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Empleados",
                Controller = "employees",
                Action = "Index",
                Area = "HHRR",
                Role = Framework.Decisor.HumanResources.Interop.API.Common.Constants.Security.Authorization.EmployeeViewerPermission
            });
            #endregion

            #region Commercial
            commercialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Clientes Jurídicos",
                Controller = "legalclients",
                Action = "Index",
                Area = "commercial",
                Role = Framework.Decisor.Commercial.Interop.API.Common.Constants.Security.Authorization.LegalClientViewerPermission
            });
            commercialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Clientes Naturales",
                Controller = "naturalclients",
                Action = "Index",
                Area = "commercial",
                Role = Framework.Decisor.Commercial.Interop.API.Common.Constants.Security.Authorization.NaturalClientViewerPermission
            });
            commercialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Términos de Pago",
                Controller = "paymentterms",
                Action = "Index",
                Area = "commercial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            #endregion

            #region Financial
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Centros de Costo",
                Controller = "costcenters",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                Role = Framework.Decisor.Financial.Interop.API.Common.Constants.Security.Authorization.CostCenterViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Agencias Bancarias",
                Controller = "bankagencies",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Sucursales Bancarias",
                Controller = "bankbranches",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Cuentas Bancarias",
                Controller = "bankaccounts",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Monedas",
                Controller = "currencies",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            financialSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Cobros",
                Controller = "incomes",
                Action = "Index",
                Area = "financial",
                // TODO Set spected permission
                //Role = Financial.Presentation.Web.Backend.Constants.Security.Authorization Constants.Security.Authorization.LegalProviderViewerPermission
            });
            #endregion

            #region Governance
            governanceSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Grupos Decisores",
                Controller = "decisionmakinggroups",
                Action = "Index",
                Area = "governance",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            governanceSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Reuniones",
                Controller = "meetings",
                Action = "Index",
                Area = "governance",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            #endregion

            #region Purchasing
            leasingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Propuestas",
                Controller = "propousals",
                Action = "Index",
                Area = "leasing",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            leasingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Ofertas",
                Controller = "offers",
                Action = "Index",
                Area = "leasing",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            leasingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Postulaciones",
                Controller = "postulations",
                Action = "Index",
                Area = "leasing",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            leasingSection.Add(new ManagementDashboardSectionViewModel
            {
                Title = "Arrendamientos",
                Controller = "leasings",
                Action = "Index",
                Area = "leasing",
                // TODO Set spected permission
                //Role = Constants.Security.Authorization.LegalProviderViewerPermission
            });
            #endregion

            return new Dictionary<string, ICollection<ManagementDashboardSectionViewModel>>
            {
                { "Seguridad", securitySection },
                { "Locación", locationSection },
                //{ "Jurídico", legalSection },
                { "Dominio", domainSection },
                { "Finanzas", financialSection },
                { "Recursos Humanos", humanResourcesSection },
                { "Comercial", commercialSection },
                { "jump-0", null },
                { "Gobernanza", governanceSection },
                { "Arrendamiento", leasingSection }
            };
        }
    }
}
